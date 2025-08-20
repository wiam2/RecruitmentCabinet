using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AKL_project_backend.model
{
    public class ExperienceProf
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string EntrepriseAccueil { get; set; }

        public string IntitulePoste { get; set; }

        
        public DateTime DateDebut { get; set; }

        public DateTime? DateFin { get; set; }

     
        public string Description { get; set; }

        // Foreign key to Category
        public int CvId { get; set; }
        [JsonIgnore]
        // Navigation property back to Category
        public CV CV { get; set; }
        public ExperienceProf() { }
    }
}
