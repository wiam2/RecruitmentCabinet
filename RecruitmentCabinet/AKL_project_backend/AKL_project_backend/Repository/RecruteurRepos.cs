using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AKL_project_backend.Repository
{
    public class RecruteurRepos
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public RecruteurRepos(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<List<RecruteurDTO>> AffichageRECRSs()
        {
            var recruteurs = await _context.Recruteur.ToListAsync();
            return recruteurs.Select(recruteur => new RecruteurDTO
            {
                Nom = recruteur.Nom,
                Prenom = recruteur.Prenom,
                Email = recruteur.Email,
                Telephone = recruteur.Telephone,
                Password = recruteur.PasswordHash,
                Ville = recruteur.Ville,
                Pays = recruteur.Pays,
                Civilite = recruteur.Civilite,
                DateDeNaissance = recruteur.DateDeNaissance,
                NomEntreprise = recruteur.NomEntreprise,
                RaisonSocial = recruteur.RaisonSocial,
                Succursal = recruteur.Succursal,
                SecteurActivite = recruteur.SecteurActivite,
                Adresse = recruteur.Adresse,
                Fax = recruteur.Fax,
                Commune = recruteur.Commune,
                TailleEnEffectif = recruteur.TailleEnEffectif,
                StatutJuridique = recruteur.StatutJuridique,
                TypeCnss = recruteur.TypeCnss,
                NumRegistre = recruteur.NumRegistre,
                DateCreation = recruteur.DateCreation,

                // Mapping offres to offreDTO
                
            }).ToList();
        }


        public async Task<RecruteurDTO> AffichageRecruteurById(string id)
        {
            // Fetch the recruteur by ID along with their offres
            var recruteur = await _context.Recruteur
                .Where(r => r.Id == id)
                .Include(r => r.offres)  // Ensure you include the offres in the query
                .FirstOrDefaultAsync();

            if (recruteur == null)
            {
                return null; // Or handle the case where the recruteur is not found
            }

            // Map the recruteur and their offres to a RecruteurDTO
            return new RecruteurDTO
            {
                Nom = recruteur.Nom,
                Prenom = recruteur.Prenom,
                Email = recruteur.Email,
                Telephone = recruteur.Telephone,
                Password = recruteur.PasswordHash,
                Ville = recruteur.Ville,
                Pays = recruteur.Pays,
                Civilite = recruteur.Civilite,
                DateDeNaissance = recruteur.DateDeNaissance,
                NomEntreprise = recruteur.NomEntreprise,
                RaisonSocial = recruteur.RaisonSocial,
                Succursal = recruteur.Succursal,
                SecteurActivite = recruteur.SecteurActivite,
                Adresse = recruteur.Adresse,
                Fax = recruteur.Fax,
                Commune = recruteur.Commune,
                TailleEnEffectif = recruteur.TailleEnEffectif,
                StatutJuridique = recruteur.StatutJuridique,
                TypeCnss = recruteur.TypeCnss,
                NumRegistre = recruteur.NumRegistre,
                DateCreation = recruteur.DateCreation,
                // Mapping offres to offreDTO
                Offres = recruteur.offres.Select(offre => new offreDTO
                {
                    Id = offre.Id,
                    Entreprise = offre.Entreprise,
                    PostePropose = offre.PostePropose,
                    TitrePoste = offre.TitrePoste,
                    CompetencesRequises = offre.CompetencesRequises,
                    Secteur = offre.Secteur,
                    NiveauDemande = offre.NiveauDemande,
                    TypeContrat = offre.TypeContrat,
                    SalairePropose = offre.SalairePropose,
                    Pays = offre.Pays,
                    Ville = offre.Ville,
                    DatePublication = offre.DatePublication,
                    DateExpiration = offre.DateExpiration,
                    Description = offre.Description,
                    RecruteurId = offre.RECRUTEURID
                }).ToList()
            };
        }

        public async Task SupprimerRecruteurById(string id)
        {
            var recruteur = await _context.condidat.FindAsync(id);
            if (recruteur == null)
            {
                return;
            }

            _context.condidat.Remove(recruteur);

            await _context.SaveChangesAsync();
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        public async Task<RecruteurDTO> UpdateRecruteurById(string id, RecruteurDTO recruteurDTO)
        {
            // Fetch the recruteur by ID
            var recruteur = await _context.Recruteur
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            

            // Update recruteur properties (excluding offres)
            recruteur.Nom = recruteurDTO.Nom;
            recruteur.Prenom = recruteurDTO.Prenom;
            recruteur.Email = recruteurDTO.Email;
            recruteur.Telephone = recruteurDTO.Telephone;
            recruteur.PasswordHash = recruteurDTO.Password;
            recruteur.Ville = recruteurDTO.Ville;
            recruteur.Pays = recruteurDTO.Pays;
            recruteur.Civilite = recruteurDTO.Civilite;
            recruteur.DateDeNaissance = recruteurDTO.DateDeNaissance;
            recruteur.NomEntreprise = recruteurDTO.NomEntreprise;
            recruteur.RaisonSocial = recruteurDTO.RaisonSocial;
            recruteur.Succursal = recruteurDTO.Succursal;
            recruteur.SecteurActivite = recruteurDTO.SecteurActivite;
            recruteur.Adresse = recruteurDTO.Adresse;
            recruteur.Fax = recruteurDTO.Fax;
            recruteur.Commune = recruteurDTO.Commune;
            recruteur.TailleEnEffectif = recruteurDTO.TailleEnEffectif;
            recruteur.StatutJuridique = recruteurDTO.StatutJuridique;
            recruteur.TypeCnss = recruteurDTO.TypeCnss;
            recruteur.NumRegistre = recruteurDTO.NumRegistre;
            recruteur.DateCreation = recruteurDTO.DateCreation;

            // Save the changes to the database
            await _context.SaveChangesAsync();

            // Return the updated RecruteurDTO
            return new RecruteurDTO
            {
                Nom = recruteur.Nom,
                Prenom = recruteur.Prenom,
                Email = recruteur.Email,
                Telephone = recruteur.Telephone,
                Password = recruteur.PasswordHash,
                Ville = recruteur.Ville,
                Pays = recruteur.Pays,
                Civilite = recruteur.Civilite,
                DateDeNaissance = recruteur.DateDeNaissance,
                NomEntreprise = recruteur.NomEntreprise,
                RaisonSocial = recruteur.RaisonSocial,
                Succursal = recruteur.Succursal,
                SecteurActivite = recruteur.SecteurActivite,
                Adresse = recruteur.Adresse,
                Fax = recruteur.Fax,
                Commune = recruteur.Commune,
                TailleEnEffectif = recruteur.TailleEnEffectif,
                StatutJuridique = recruteur.StatutJuridique,
                TypeCnss = recruteur.TypeCnss,
                NumRegistre = recruteur.NumRegistre,
                DateCreation = recruteur.DateCreation
            };
        }
    }
}