using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class LangueDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NomLangue { get; set; }

        [MaxLength(50)]
        public string NiveauMaitrise { get; set; }

     
    }
}

