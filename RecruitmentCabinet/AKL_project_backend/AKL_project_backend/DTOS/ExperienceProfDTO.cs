using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class ExperienceProfDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string EntrepriseAccueil { get; set; }

        [Required]
        [MaxLength(100)]
        public string IntitulePoste { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateFin { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

     
    }
}
