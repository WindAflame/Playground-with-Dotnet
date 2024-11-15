using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranceTravail.Models.FranceTravailAPI
{
    /// <summary>
    /// Definition of a commune from the referential
    /// See more : https://francetravail.io/produits-partages/catalogue/offres-emploi/documentation#/api-reference/operations/recupererReferentielCommunes
    /// </summary>
    public class City
    {
        public string Code { get; set; }
        public string Libelle { get; set; }
        public string CodePostal { get; set; }
        public string CodeDepartement { get; set; }
    }
}
