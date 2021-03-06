﻿using Newtonsoft.Json.Linq;
using ProximityTest.PlanetsClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProximityTest.PlanetsClient.Services
{
    public class RestService : IRestService
    {
        private string _baseUrl = string.Empty;

        public RestService()
        {
            this._baseUrl = "http://code-challenge.proximitycr.com";
        }

        public async Task<AuthResponse> AuthAsync()
        {
            string contentType = "application/json";

            JObject jsonObject = new JObject();
            jsonObject.Add("email", "aibarralandeo@outlook.com");
            jsonObject.Add("passphrase", "adolfo-ibarra-xamarin");

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync($"{_baseUrl}/gimme-the-token", new StringContent(jsonObject.ToString(), Encoding.UTF8, contentType));
            response.EnsureSuccessStatusCode();

            AuthResponse authResponse = await response.Content.ReadAsAsync<AuthResponse>();
            return authResponse;
        }

        public async Task<IEnumerable<PlanetResponse>> GetPlanetsAsync()
        {
            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Add("Authorization", await GetTokenAsync());
            var response = await httpClient.GetAsync($"{_baseUrl}/planets");

            response.EnsureSuccessStatusCode();
            List<PlanetResponse> planetResponses = await response.Content.ReadAsAsync<List<PlanetResponse>>();

            return planetResponses;
        }

        public async Task<string> GetTokenAsync()
        {
            string token = null;

            token = await SecureStorage.GetAsync("token");

            if (string.IsNullOrEmpty(token))
            {
                var auth = AuthAsync();
                token = auth.Result.Token;
            }
            return token;
        }

        public async Task SetTokenAsync(string token)
        {
            await SecureStorage.SetAsync("token", token);
        }
    }
}
