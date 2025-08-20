using System;


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AKL_project_backend.model
{
    public class Recruteur : User
    {
      
        public string NomEntreprise { get; set; }

    
        public string RaisonSocial { get; set; }

    
        public string Succursal { get; set; }

    
        public string SecteurActivite { get; set; }

        public string Adresse { get; set; }

     
        public string Fax { get; set; }

       
        public string Commune { get; set; }

    
        public string TailleEnEffectif { get; set; }

   
        public string StatutJuridique { get; set; }

        public string TypeCnss { get; set; }

      
        public double? NumRegistre { get; set; }

       
        public DateTime? DateCreation { get; set; }
        [JsonIgnore]

        public ICollection<Offre> offres { get; set; }

        // Constructor if needed
        public Recruteur() { }
    }
}
