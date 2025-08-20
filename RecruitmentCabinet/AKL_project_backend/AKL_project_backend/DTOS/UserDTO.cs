using System;

using System.ComponentModel.DataAnnotations;




    

    namespace AKL_project_backend.DTOS
    {
        public class UserDTO
        {
         

            [Required]
            [MaxLength(50)]
            public string Nom { get; set; }

            [Required]
            [MaxLength(50)]
            public string Prenom { get; set; }

            [Required]
            public string Civilite { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime DateDeNaissance { get; set; }

        [Required]

        [MaxLength(100)]
            public string Poste { get; set; }
        [Required]
        [MaxLength(50)]
            public string Pays { get; set; }
        [Required]

        [MaxLength(50)]
            public string Ville { get; set; }
        [Required]

        [Phone]
            public string Telephone { get; set; }

        public string image { get; set; }


        // Si vous souhaitez inclure l'email et d'autres détails, ajoutez-les ici

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    }


