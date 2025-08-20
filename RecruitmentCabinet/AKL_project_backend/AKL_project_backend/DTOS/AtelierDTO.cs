using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class AtelierDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nom de l'organisateur de l'atelier
        [Required]
        [MaxLength(100)]
        public string Organisateur { get; set; }

        // Lieu où se déroule l'atelier
        [Required]
        [MaxLength(200)]
        public string LieuOrganisation { get; set; }

        // Date de l'atelier
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOrganisation { get; set; }

        // Thème de l'atelier (obligatoire)
        [Required]
        [MaxLength(100)]
        public string Theme { get; set; }

        // URL ou chemin de l'image associée à l'atelier
        [MaxLength(500)]
        public string Image { get; set; }  // Peut contenir une URL ou un chemin vers l'image

        public string Deroulement_atelier { get; set; }

        // Constructeur par défaut (si nécessaire)
        public List<string> IdReservateur { get; set; } = new List<string>();

    }
}

