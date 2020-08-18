using System;
using System.Text.Json.Serialization;

namespace AGL_DeveloperTestClientApp.Model
{
    public class Pet
    {
        [JsonPropertyName("name")]
        public string PetName { get; set; }
        
        [JsonPropertyName("type")]
        public string PetType { get; set; }
    }
}