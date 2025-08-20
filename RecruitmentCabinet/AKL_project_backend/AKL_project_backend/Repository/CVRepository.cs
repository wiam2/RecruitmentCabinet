using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using Microsoft.EntityFrameworkCore;

namespace AKL_project_backend.Repository
{
    public class CVRepository
    {
        private readonly AppDbContext _context;

        public CVRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<CV> CreateCVAsync(CVDTO cvDto)
        {
            // Vérifiez que le candidat existe
            var candidat = await _context.condidat
                .FirstOrDefaultAsync(c => c.Id == cvDto.CondidatId);

            if (candidat == null)
            {
                throw new Exception("Candidat non trouvé.");
            }
            // Vérifiez si le candidat a déjà un CV
            if (candidat.CVId != 0)
            {
                // Si un CV est déjà associé, appelez la méthode Update
                return await UpdateCVAsync(candidat.CVId, cvDto);
            }

            // Créez l'entité CV à partir du DTO
            var cv = new CV
            {
                image = cvDto.Image,
                condidatId = cvDto.CondidatId,
                
                competences = cvDto.Competences?.Select(c => new Competences
                {
                    NomComp = c.NomComp
                }).ToList(),
                ExperienceProfs = cvDto.ExperienceProfs?.Select(e => new ExperienceProf
                {
                    EntrepriseAccueil = e.EntrepriseAccueil,
                    IntitulePoste = e.IntitulePoste,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin,
                    Description = e.Description
                }).ToList(),
                Langues = cvDto.Langues?.Select(l => new Langues
                {
                    NomLangue = l.NomLangue,
                    NiveauMaitrise = l.NiveauMaitrise
                }).ToList(),
                Formations = cvDto.Formations?.Select(f => new Formations
                {
                    Etablissement = f.Etablissement,
                    Diplome = f.Diplome,
                    Annee = f.Annee,
                    Specialite = f.Specialite,
                  
                }).ToList(),
                PermisConduit = cvDto.PermisConduits?.Select(p => new PermisConduit
                {
                    type_permis = p.type
                }).ToList()
            };

            // Ajouter le CV dans la base de données
            await _context.CV.AddAsync(cv);
            await _context.SaveChangesAsync();

            candidat.Cv = cv; // Assurez-vous que la relation entre Condidat et CV est configurée dans votre modèle.
            candidat.CVId = cv.Id;  // Ajoutez le CV Id au candidat si vous avez cette propriété dans votre modèle Condidat.

            // Sauvegardez les modifications du candidat
            _context.condidat.Update(candidat);
            await _context.SaveChangesAsync();

            return cv;
        }

        public async Task<CV> UpdateCVAsync(int cvId, CVDTO cvDto)
        {
            // Récupérez le CV à mettre à jour
            var cv = await _context.CV
                .Include(c => c.competences)
                .Include(c => c.ExperienceProfs)
                .Include(c => c.Langues)
                .Include(c => c.Formations)
                .Include(c => c.PermisConduit)
                .FirstOrDefaultAsync(c => c.Id == cvId);

            if (cv == null)
            {
                throw new Exception("CV non trouvé.");
            }

            // Vérifiez que le candidat existe toujours
            var candidat = await _context.condidat
                .FirstOrDefaultAsync(c => c.Id == cvDto.CondidatId);

            if (candidat == null)
            {
                throw new Exception("Candidat non trouvé.");
            }

            // Mettez à jour les propriétés du CV
            cv.image = cvDto.Image ?? cv.image;
            cv.condidatId = cvDto.CondidatId;

            // Mettez à jour les compétences
            if (cvDto.Competences != null)
            {
                cv.competences = cvDto.Competences.Select(c => new Competences
                {
                    NomComp = c.NomComp
                }).ToList();
            }

            // Mettez à jour les expériences professionnelles
            if (cvDto.ExperienceProfs != null)
            {
                cv.ExperienceProfs = cvDto.ExperienceProfs.Select(e => new ExperienceProf
                {
                    EntrepriseAccueil = e.EntrepriseAccueil,
                    IntitulePoste = e.IntitulePoste,
                    DateDebut = e.DateDebut,
                    DateFin = e.DateFin,
                    Description = e.Description
                }).ToList();
            }

            // Mettez à jour les langues
            if (cvDto.Langues != null)
            {
                cv.Langues = cvDto.Langues.Select(l => new Langues
                {
                    NomLangue = l.NomLangue,
                    NiveauMaitrise = l.NiveauMaitrise
                }).ToList();
            }

            // Mettez à jour les formations
            if (cvDto.Formations != null)
            {
                cv.Formations = cvDto.Formations.Select(f => new Formations
                {
                    Etablissement = f.Etablissement,
                    Diplome = f.Diplome,
                    Annee = f.Annee,
                    Specialite = f.Specialite
                }).ToList();
            }

            // Mettez à jour les permis de conduire
            if (cvDto.PermisConduits != null)
            {
                cv.PermisConduit = cvDto.PermisConduits.Select(p => new PermisConduit
                {
                    type_permis = p.type
                }).ToList();
            }

            // Sauvegardez les modifications du CV
            _context.CV.Update(cv);
            await _context.SaveChangesAsync();

            // Si nécessaire, mettre à jour le candidat
            candidat.Cv = cv;
            candidat.CVId = cv.Id;
            _context.condidat.Update(candidat);
            await _context.SaveChangesAsync();

            return cv;
        }




        public async Task<CV> GetCVByIdAsync(int id)
        {
            return await _context.CV
                .Include(c => c.competences)
                .Include(c => c.ExperienceProfs)
                .Include(c => c.Langues)
                .Include(c => c.Formations)
                .Include(c => c.PermisConduit)
                
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
