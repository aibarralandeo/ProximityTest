using Newtonsoft.Json;
using System;

namespace ProximityTest.PlanetsClient.Models
{
    public class PlanetResponse
    {
        public string Name { get; set; }
        
        [JsonProperty("pic")]
        public Uri Picture { get; set; }
    }
}
