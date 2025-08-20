using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKL_project_backend.model
{
    public class Reclamation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string NomPersonne { get; set; }

       
        public string Email { get; set; }

     
        public string Sujet { get; set; }

       
        public string Message { get; set; }

        public Reclamation() { }
    }
}
