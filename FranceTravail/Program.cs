using FranceTravail.AppDataContext;

// App must do
// Connect to FranceTravail API : https://entreprise.francetravail.fr/connexion/oauth2/access_token?realm=/partenaire

var client = new FranceTravailApiClient();
var clientIsConnected = await client.GetAuth();
// Retrieve list of city : https://api.francetravail.io/partenaire/offresdemploi /v2/referentiel/communes
// Retrieve job in city Rennes, Bordeaux and Paris: https://api.francetravail.io/partenaire/offresdemploi /v2/offres/search
// Store job in local db SQLite with Description and URL to sign in
// Mutate DB with new Job
// Print JSON with result of search in local DB with selected values Contrat, Entreprise, Pays
