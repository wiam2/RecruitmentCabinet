using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKL_project_backend.model
{
    public class Atelier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Organisateur { get; set; }

       
        public string LieuOrganisation { get; set; }

  
        public DateTime DateOrganisation { get; set; }

   
       
        public string Theme { get; set; }

       
        public string Image { get; set; }  // Peut contenir une URL ou un chemin vers l'image
        public string Deroulement_atelier { get; set; }

        public List<string> IdReservateur { get; set; } = new List<string>();

        // Constructeur si nécessaire
        public Atelier() { }
    }
}
