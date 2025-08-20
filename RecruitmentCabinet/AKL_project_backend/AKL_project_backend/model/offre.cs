using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKL_project_backend.model
{
    public class Offre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string Entreprise { get; set; }

   
        public string PostePropose { get; set; }


        public string TitrePoste { get; set; }

       
        public string CompetencesRequises { get; set; }

      
        public string Secteur { get; set; }

        public string NiveauDemande { get; set; }

  
        public string TypeContrat { get; set; }

        public double SalairePropose { get; set; }

    
        public string Pays { get; set; }

     
        public string Ville { get; set; }

     
        public DateTime DatePublication { get; set; }

    
        public DateTime? DateExpiration { get; set; }

   
        public string Description { get; set; }

        public string RECRUTEURID { get; set; }

        // Navigation property back to Category
        public Recruteur RECRUTEUR { get; set; }

        public List<string> CondidatIds { get; set; } = new List<string>();
        public List<string> CondidatIdsvalide { get; set; } = new List<string>();


        public Offre() { }
    }
}
