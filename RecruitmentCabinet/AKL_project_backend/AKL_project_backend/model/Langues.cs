using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AKL_project_backend.model
{
    public class Langues
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string NomLangue { get; set; }

      
        public string NiveauMaitrise { get; set; }

        // Foreign key to Category
        public int CvId { get; set; }
        [JsonIgnore]
        // Navigation property back to Category
        public CV CV { get; set; }

        public Langues() { }
    }
}
