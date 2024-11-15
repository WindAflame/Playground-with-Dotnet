using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FranceTravail.AppDataContext;
using FranceTravail.Models.FranceTravailAPI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;

namespace FranceTravail.Repository
{
    public class FranceTravailJobRepository
    {
        private HttpClient _httpClient;
        private string _url = "https://api.francetravail.io/partenaire/offresdemploi";

        public FranceTravailJobRepository(FranceTravailContext context)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", context.BearerToken);
        }

        /// <summary>
        /// List all cities in the reference system
        /// See more : https://francetravail.io/produits-partages/catalogue/offres-emploi/documentation#/api-reference/schemas/Commune
        /// </summary>
        /// <returns></returns>
        public async Task<List<City>> GetCitiesAsync()
        {
            var endpoint = "/v2/referentiel/communes";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_url + endpoint),
                Headers =
                {
                    { "Accept", "application/json" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(body))
                {
                    return new List<City> { };
                }
                return JsonSerializer.Deserialize<List<City>>(body);
            }
        }

        /// <summary>
        /// List of all jobs for a specific city
        /// param City must be a code INSEE
        /// See more : https://francetravail.io/produits-partages/catalogue/offres-emploi/documentation#/api-reference/operations/recupererListeOffre
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public async Task<List<Job>> GetJobsByCityAsync(string city)
        {
            var endpoint = "/v2/offres/search";
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_url + endpoint + $"?commune={city}"),
                Headers =
                {
                    { "Accept", "application/json" },
                },
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrEmpty(body))
                {
                    return new List<Job> { };
                }
                // TODO Url always null when deserialize, why ?
                var result = JsonSerializer.Deserialize<JobResponse>(body, new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true
                });
                return result.Resultats;
            }
        }
    }

}
