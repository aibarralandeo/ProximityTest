using ProximityTest.PlanetsClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProximityTest.PlanetsClient.Services
{
    public interface IRestClient
    {
        void SetBaseUrl(string url);
        Task<IEnumerable<Planet>> GetPlanetsAsync();
    }
}
