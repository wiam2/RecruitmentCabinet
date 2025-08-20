

using Microsoft.AspNetCore.Identity;


namespace AKL_project_backend.model
{
    public class User : IdentityUser
    {
      
        public string Nom { get; set; }

      
        public string Prenom { get; set; }

        public string Civilite { get; set; }

      
        public DateTime DateDeNaissance { get; set; }

     
        public string Poste { get; set; }

       
        public string Pays { get; set; }

       
        public string Ville { get; set; }

 
        public string Telephone { get; set; }
        public string image { get; set; }

        // Ajoutez un constructeur si vous avez des valeurs par défaut ou initialisations spéciales
        public User() { }

        public User(string nom, string prenom, string civilite, DateTime dateDeNaissance,
                    string poste, string pays, string ville, string telephone ,string imaget)
        {
            Nom = nom;
            Prenom = prenom;
            Civilite = civilite;
            DateDeNaissance = dateDeNaissance;
            Poste = poste;
            Pays = pays;
            Ville = ville;
            Telephone = telephone;
            image = imaget;

        }
    }
}
