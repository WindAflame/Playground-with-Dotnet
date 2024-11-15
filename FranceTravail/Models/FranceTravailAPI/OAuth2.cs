using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FranceTravail.Models.FranceTravailAPI
{
    /// <summary>
    /// Information received by api about OAuth2 authentication
    /// See more : https://francetravail.io/produits-partages/documentation/utilisation-api-france-travail/generer-access-token
    /// </summary>
    public class OAuth2
    {
        public string Scope { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}
