namespace FranceTravail.Models.FranceTravailAPI
{
    /// <summary>
    /// Job
    /// Trop long ...
    /// </summary>
    public class Job
    {
        public string Id { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public string DateCreation { get; set; }
        public string DateActualisation { get; set; }
        public LieuTravail LieuTravail { get; set; }
        public string RomeCode { get; set; }
        public string RomeLibelle { get; set; }
        public string Appellationlibelle { get; set; }
        public Entreprise Entreprise { get; set; }
        public string TypeContrat { get; set; }
        public string TypeContratLibelle { get; set; }
        public string NatureContrat { get; set; }
        public string ExperienceExige { get; set; }
        public string ExperienceLibelle { get; set; }
        public string ExperienceCommentaire { get; set; }
        //public List<Formation> Formations { get; set; }
        //public List<Language> Langues { get; set; }
        //public List<permis> Permis { get; set; }
        public List<string> OutilsBureautiques { get; set; }
        //public List<Competences> Competences { get; set; }
        //public Salaire Salaire { get; set; }
        public string DureeTravailLibelle { get; set; }
        public string DureeTravailLibelleConverti { get; set; }
        public string ComplementExercice { get; set; }
        public string ConditionExercice { get; set; }
        public bool Alternance { get; set; }
        public Contact? Contact { get; set; }
        //public Agence Agence { get; set; }
        public int NombrePostes { get; set; }
        public bool AccessibleTH { get; set; }
        public string DeplacementCode { get; set; }
        public string DeplacementLibelle { get; set; }
        public string QualificationLibelle { get; set; }
        public string CodeNAF { get; set; }
        public string SecteurActivite { get; set; }
        public string SecteurActiviteLibelle { get; set; }
        //public List<QualiteProfesionnelle> QualitesProfessionnelles { get; set; }
        public string TrancheEffectifEtab { get; set; }
        //public OrigineOffre OrigineOffre { get; set; }
        public bool OffresManqueCandidats { get; set; }

    }

    public class Contact
    {
        public string UrlPostulation { get; set; }

    }

    public class LieuTravail
    {
        public string commune { get; set; }
    }

    public class Entreprise
    {
        public string Nom { get; set; }
        public string Url { get; set; }
    }
}
