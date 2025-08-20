using AKL_project_backend.DTOS;
using AKL_project_backend.model;

namespace AKL_project_backend.Repository
{
    public class ReclamationRepos
    {
        private readonly AppDbContext _context;

        public ReclamationRepos(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ReclamationDTO> CreerReclamation(ReclamationDTO reclamation)
        {
            // Vérifiez si les données de réclamation sont valides
            if (reclamation == null)
            {
                throw new ArgumentNullException(nameof(reclamation));
            }

            // Créez un modèle de réclamation à partir du DTO
            var reclamationEntity = new Reclamation
            {
                NomPersonne = reclamation.NomPersonne,
                Email = reclamation.Email,
                Sujet = reclamation.Sujet,
                Message = reclamation.Message
            };

            // Ajoutez la réclamation à la base de données
            _context.Reclamation.Add(reclamationEntity);
            await _context.SaveChangesAsync();

            // Retournez le DTO après l'ajout (si nécessaire, vous pouvez retourner l'entité)
            return reclamation;
        }
    }
}

