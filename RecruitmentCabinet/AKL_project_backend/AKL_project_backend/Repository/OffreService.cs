using AKL_project_backend.model;

namespace AKL_project_backend.Repository
{
    using AKL_project_backend.DTOS;
    using Microsoft.EntityFrameworkCore;
    using SendGrid.Helpers.Mail;


    public class OffreService
    {
        private readonly AppDbContext _context;

        public OffreService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Offre>> GetAllAsync()
        {
            return await _context.offre.ToListAsync();
        }

        public async Task<Offre> GetByIdAsync(int id)
        {
            return await _context.offre.FindAsync(id);
        }

        public async Task<Offre> CreateAsync(offreDTO offreDTO)
        {
            // Rechercher le recruteur dans la base de données par son ID
            var recruteur = await _context.Recruteur.FirstOrDefaultAsync(r => r.Id == offreDTO.RecruteurId);
            if (recruteur == null)
            {
                throw new KeyNotFoundException("Recruteur introuvable avec l'ID fourni.");
            }

            // Créer une nouvelle entité Offre à partir de offreDTO
            var offre = new Offre
            {
                Entreprise = offreDTO.Entreprise,
                PostePropose = offreDTO.PostePropose,
                TitrePoste = offreDTO.TitrePoste,
                CompetencesRequises = offreDTO.CompetencesRequises,
                Secteur = offreDTO.Secteur,
                NiveauDemande = offreDTO.NiveauDemande,
                TypeContrat = offreDTO.TypeContrat,
                SalairePropose = offreDTO.SalairePropose,
                Pays = offreDTO.Pays,
                Ville = offreDTO.Ville,
                DatePublication = offreDTO.DatePublication,
                DateExpiration = offreDTO.DateExpiration,
                Description = offreDTO.Description,
                RECRUTEURID = offreDTO.RecruteurId,
                RECRUTEUR = recruteur 


            };

            // Ajouter l'offre à la base de données
            _context.offre.Add(offre);
            await _context.SaveChangesAsync();

            return offre;
        }

        public async Task AjouterCandidatAsync(affectationIdForm postuleform)
        {
            if (string.IsNullOrWhiteSpace(postuleform.condidatid))
            {
                throw new ArgumentException("L'ID du candidat ne peut pas être null ou vide.", nameof(postuleform.condidatid));
            }

            var offre = await _context.offre.FindAsync(postuleform.offreId);

            if (offre == null)
            {
                throw new InvalidOperationException($"Aucune offre trouvée avec l'ID {postuleform.offreId}.");
            }

            if (!offre.CondidatIds.Contains(postuleform.condidatid))
            {
                offre.CondidatIds.Add(postuleform.condidatid);
                _context.offre.Update(offre);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Le candidat avec l'ID {postuleform.condidatid} est déjà lié à cette offre.");
            }
        }


        public async Task AjouterCandidatVAL(affectationIdForm postuleform)
        {
            if (string.IsNullOrWhiteSpace(postuleform.condidatid))
            {
                throw new ArgumentException("L'ID du candidat ne peut pas être null ou vide.", nameof(postuleform.condidatid));
            }

            var offre = await _context.offre.FindAsync(postuleform.offreId);

            if (offre == null)
            {
                throw new InvalidOperationException($"Aucune offre trouvée avec l'ID {postuleform.offreId}.");
            }

            if (!offre.CondidatIdsvalide.Contains(postuleform.condidatid))
            {
                offre.CondidatIdsvalide.Add(postuleform.condidatid);
                _context.offre.Update(offre);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Le candidat avec l'ID {postuleform.condidatid} est déjà lié à cette offre.");
            }
        }

        public async Task<Offre> UpdateAsync(int id, offreDTO updatedOffre)
        {
            var existingOffre = await _context.offre.FindAsync(id);
            if (existingOffre == null) return null;

            // Mise à jour des propriétés
            existingOffre.Entreprise = updatedOffre.Entreprise;
            existingOffre.PostePropose = updatedOffre.PostePropose;
            existingOffre.TitrePoste = updatedOffre.TitrePoste;
            existingOffre.CompetencesRequises = updatedOffre.CompetencesRequises;
            existingOffre.Secteur = updatedOffre.Secteur;
            existingOffre.NiveauDemande = updatedOffre.NiveauDemande;
            existingOffre.TypeContrat = updatedOffre.TypeContrat;
            existingOffre.SalairePropose = updatedOffre.SalairePropose;
            existingOffre.Pays = updatedOffre.Pays;
            existingOffre.Ville = updatedOffre.Ville;
            existingOffre.DatePublication = updatedOffre.DatePublication;
            existingOffre.DateExpiration = updatedOffre.DateExpiration;
            existingOffre.Description = updatedOffre.Description;
            existingOffre.RECRUTEURID = updatedOffre.RecruteurId;

            await _context.SaveChangesAsync();
            return existingOffre;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var offre = await _context.offre.FindAsync(id);
            if (offre == null) return false;

            _context.offre.Remove(offre);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<List<Offre>> GetByRecruteurIdAsync(string recruteurId)
        {
            return await _context.offre
                .Where(o => o.RECRUTEURID == recruteurId)
                .ToListAsync();
        }

        public async Task<List<Condidat>> GetCondidatsByOffreIdAsync(int offreId)
        {
            // Récupère l'offre avec l'ID donné
            var offre = await _context.Set<Offre>()
                .FirstOrDefaultAsync(o => o.Id == offreId);

            if (offre == null)
            {
                throw new ArgumentException("Offre introuvable.");
            }

            // Récupère la liste des candidats associés
            var condidats = await _context.Set<Condidat>()
                .Where(c => offre.CondidatIds.Contains(c.Id))
                .ToListAsync();

            return condidats;
        }




    }


}



