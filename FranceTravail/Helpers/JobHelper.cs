namespace FranceTravail.Helpers
{
    public class JobHelper
    {
        public static Models.Job JobConvert(Models.FranceTravailAPI.Job franceTravailJob)
        {
            var job = new FranceTravail.Models.Job();
            job.Description = franceTravailJob.Description;
            //job.UrlPostulation = franceTravailJob.Contact.UrlPostulation;
            job.LieuDeTravail = franceTravailJob.LieuTravail.commune;
            job.TypeContrat = franceTravailJob.TypeContrat;
            job.EntrepriseNom = franceTravailJob.Entreprise.Nom;
            return job;
        }
    }
}
