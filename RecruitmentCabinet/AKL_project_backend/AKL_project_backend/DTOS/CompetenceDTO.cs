using System.ComponentModel.DataAnnotations;

namespace AKL_project_backend.DTOS
{
    public class CompetenceDTO
    {
       
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string NomComp { get; set; }

       
        }
    }



