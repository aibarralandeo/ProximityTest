using Newtonsoft.Json;

namespace ProximityTest.PlanetsClient.Models
{
    public class AuthResponse
    {
        [JsonProperty("dont_tell_anyone_this_token")]
        public string Token { get; set; }
    }
}
