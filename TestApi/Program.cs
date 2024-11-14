// See https://aka.ms/new-console-template for more information

// Authentication on FranceTravail API.
var client = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Post, "https://entreprise.francetravail.fr/connexion/oauth2/access_token?realm=/partenaire");
var collection = new List<KeyValuePair<string, string>>();
collection.Add(new("grant_type", "client_credentials"));
collection.Add(new("client_id", "CLIENT_ID"));
collection.Add(new("client_secret", "CLIENT_SECRET"));
collection.Add(new("scope", "api_offresdemploiv2"));
var content = new FormUrlEncodedContent(collection);
request.Content = content;
var response = await client.SendAsync(request);
response.EnsureSuccessStatusCode();
Console.WriteLine(await response.Content.ReadAsStringAsync());