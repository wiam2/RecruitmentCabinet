using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class offreDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Entreprise { get; set; }

        [Required]
        [MaxLength(100)]
        public string PostePropose { get; set; }

        [Required]
        [MaxLength(100)]
        public string TitrePoste { get; set; }

        [MaxLength(200)]
        public string CompetencesRequises { get; set; }

        [MaxLength(100)]
        public string Secteur { get; set; }

        [MaxLength(50)]
        public string NiveauDemande { get; set; }

        [MaxLength(50)]
        public string TypeContrat { get; set; }

        [Range(0, double.MaxValue)]
        public double SalairePropose { get; set; }

        [MaxLength(50)]
        public string Pays { get; set; }

        [MaxLength(50)]
        public string Ville { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DatePublication { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateExpiration { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public List<string> CondidatIds { get; set; } = new List<string>();
        public List<string> CondidatIdsvalide { get; set; } = new List<string>();

        // Recruteur ID pour lier l'offre au recruteur
        public string RecruteurId { get; set; }

        
    }
}

