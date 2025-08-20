
using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class RecruteurDTO :UserDTO
    {

      
        [Required]
        [MaxLength(100)]
        public string NomEntreprise { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string RaisonSocial { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Succursal { get; set; } = string.Empty;

        [Required]
        public string  SecteurActivite { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Adresse { get; set; } = string.Empty;

        [Phone]
        public string Fax { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Commune { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public string TailleEnEffectif { get; set; } = string.Empty;

        [Required]
        public string StatutJuridique { get; set; } = string.Empty;

        [MaxLength(50)]
        public string TypeCnss { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double? NumRegistre { get; set; } = null;

        [DataType(DataType.Date)]
        public DateTime? DateCreation { get; set; } = null;

        // Collection des offres
        public ICollection<offreDTO> Offres { get; set; }
    }
}

