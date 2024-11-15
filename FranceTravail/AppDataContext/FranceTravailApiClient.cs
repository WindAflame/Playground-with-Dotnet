using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DotNetEnv;
using FranceTravail.Models.FranceTravailAPI;
using FranceTravail.Settings;

namespace FranceTravail.AppDataContext
{
    public class FranceTravailApiClient
    {
        private string _clientId;
        private string _clientSecret;
        private string _bearerToken = "";
        private HttpClient _httpClient;

        public FranceTravailApiClient()
        {
            var settings = new AppSettings();
            _clientId = settings.ClientId;
            _clientSecret = settings.ClientSecret;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.francetravail.io/partenaire/offresdemploi");
        }

        public async Task<bool> GetAuth()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://entreprise.francetravail.fr/connexion/oauth2/access_token?realm=/partenaire");
            var collection = new List<KeyValuePair<string, string>>
            {
                 new("grant_type", "client_credentials"),
                 new("client_id", _clientId),
                 new("client_secret", _clientSecret),
                 // Only use this feature of API
                 new("scope", "api_offresdemploiv2")
            };
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;

            try
            {
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var oauth2Response = JsonSerializer.Deserialize<OAuth2>(result);
                _bearerToken = $"{oauth2Response.TokenType} {oauth2Response.AccessToken}";
                Console.WriteLine($"Connection Successfull: {_bearerToken}");
                _httpClient.DefaultRequestHeaders.Add("Authorization", _bearerToken);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Une erreur s'est produite lors de la requête : {e.Message}");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Erreur de désérialisation : {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Une erreur inattendue s'est produite : {e.Message}");
            }

            return !string.IsNullOrEmpty(_bearerToken);
        }

        public async Task<string> GetDataAsync(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostDataAsync(string endpoint, string jsonData)
        {
            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
