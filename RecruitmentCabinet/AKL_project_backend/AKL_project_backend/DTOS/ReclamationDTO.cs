using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class ReclamationDTO
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomPersonne { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Sujet { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}

