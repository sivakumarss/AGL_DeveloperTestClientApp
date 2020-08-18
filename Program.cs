using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using AGL_DeveloperTestClientApp.Model;
using AGL_DeveloperTestClientApp.Infrastructure;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace AGL_DeveloperTestClientApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            try
            {
               await GetCats();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}  /n Inner Exception: {ex.InnerException}" );
            }

        }

        private static async Task GetCats()
        {
            var maleCats = new List<Cat>();
            var femaleCats = new List<Cat>();

            var aglDeveloperTestApi = client.GetStreamAsync("http://agl-developer-test.azurewebsites.net/people.json");
            var petOwners = await JsonSerializer.DeserializeAsync<List<PetOwner>>(await aglDeveloperTestApi);
            
            if(petOwners.Count <= 0 )
                throw new NullReferenceException();

            foreach (var owner in petOwners){
                if(owner.Pets != null  && owner.Pets.Count > 0){
                    foreach(var pet in owner.Pets){

                        if(pet.PetType == Constants.CAT ){
                            var cat = new Cat(){
                                CatName = pet.PetName,
                                CatOwnerGender = owner.Gender
                            };

                            if(cat.CatOwnerGender == Constants.MALE){
                                maleCats.Add(cat);
                            } else if (cat.CatOwnerGender == Constants.FEMALE){
                                femaleCats.Add(cat);
                            }
                        }
                    }
                }
            }


            Console.WriteLine($"---{Constants.MALE}--");
            foreach(var cat in maleCats.Select(c => c).OrderBy(c => c.CatName))
            {
                Console.WriteLine(cat.CatName);
            }

            Console.WriteLine($"---{Constants.FEMALE}--");
            foreach(var cat in femaleCats.Select(c => c).OrderBy(c => c.CatName))
            {
                Console.WriteLine(cat.CatName);
            }

        }
    }
}
