using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AKL_project_backend.Repository
{
    public class CondidatRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;

        public CondidatRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, AppDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
            _context = context;
        }

        public async Task<List<CondidatDto>> AffichageCondidats()
        {

            var Condidats = await _context.condidat.ToListAsync();
            return Condidats.Select(Condidat => new CondidatDto
            {
                image=Condidat.image,

                Nom = Condidat.Nom,
                Prenom = Condidat.Prenom,
                Email = Condidat.Email,
                Telephone = Condidat.Telephone,
                CVPDF = Condidat.CVPDF,
                Password = Condidat.PasswordHash,
                Ville=Condidat.Ville,
                Pays=Condidat.Pays,
                Civilite=Condidat.Civilite,
                DateDeNaissance=Condidat.DateDeNaissance,
              
               

            }).ToList(); ;
        }


        public async Task<CondidatDto> AffichageCondidatById(string id)
        {
            var Condidat = await _context.condidat.FindAsync(id);
            if (Condidat == null)
            {
                return null;
            }

            return new CondidatDto
            {
                image =Condidat.image,
                Nom = Condidat.Nom,
                Prenom = Condidat.Prenom,
                Email = Condidat.Email,
                Telephone = Condidat.Telephone,
                Poste = Condidat.Poste,
                Password = Condidat.PasswordHash,
                Ville = Condidat.Ville,
                Pays = Condidat.Pays,
                Civilite = Condidat.Civilite,
                DateDeNaissance = Condidat.DateDeNaissance,

                CVId = Condidat.CVId,
                 CVPDF= Condidat.CVPDF
            };

        }
        public async Task SupprimerCandidatById(string id)
        {
            var condidat = await _context.condidat.FindAsync(id);
            if (condidat == null)
            {
                return;
            }

            _context.condidat.Remove(condidat);

            await _context.SaveChangesAsync();
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }
        }
        public async Task MettreAJourcondidat(string id, CondidatDto condidatDTO)
        {
            var condidat = await _context.condidat.FindAsync(id);
            if (condidat == null)
            {
                return;
            }
            condidat.image = condidatDTO.image;
            condidat.Nom = condidatDTO.Nom;
            condidat.Prenom = condidatDTO.Prenom;
            condidat.Email = condidatDTO.Email;
            condidat.Telephone = condidatDTO.Telephone;


            condidat.Ville = condidatDTO.Ville;
            condidat.Pays = condidatDTO.Pays;
            condidat.Civilite = condidatDTO.Civilite;
            condidat.DateDeNaissance = condidatDTO.DateDeNaissance;


           User user = await _userManager.FindByIdAsync(id);
            user.Email = condidat.Email;

            _userManager.UpdateNormalizedEmailAsync(user);
            _userManager.UpdateNormalizedUserNameAsync(user);
          condidat.PasswordHash = _userManager.PasswordHasher.HashPassword(user, condidatDTO.Password);



            // Mettre à jour l'utilisateur dans la base de données


            await _context.SaveChangesAsync();

        }
    }
}

