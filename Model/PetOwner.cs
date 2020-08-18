using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AGL_DeveloperTestClientApp.Model
{
    public class PetOwner
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("pets")]
        public List<Pet> Pets {get; set;}

    }

}