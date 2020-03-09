using ProximityTest.PlanetsClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProximityTest.PlanetsClient.Services
{
    public interface IRestService
    {
        Task<string> GetTokenAsync();
        Task SetTokenAsync(string token);
        Task<AuthResponse> AuthAsync();
        Task<IEnumerable<PlanetResponse>> GetPlanetsAsync();
    }
}
