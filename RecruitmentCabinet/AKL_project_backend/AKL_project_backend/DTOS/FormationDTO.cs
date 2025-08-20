using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class FormationDTO
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Etablissement { get; set; }

        [MaxLength(50)]
        public string Diplome { get; set; }

      
        public string Annee { get; set; }

        
        public string Specialite { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

      
    }
}

