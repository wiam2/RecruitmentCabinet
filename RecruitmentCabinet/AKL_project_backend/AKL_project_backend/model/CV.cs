
using AKL_project_backend.DTOS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AKL_project_backend.model
{
    public class CV
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string image { get; set; }
     
        public string condidatId { get; set; }
        [JsonIgnore]

        public Condidat condidat { get; set; }
        public ICollection<Competences> competences { get; set; }
        public ICollection<ExperienceProf> ExperienceProfs { get; set; }
        public ICollection<Langues> Langues { get; set; }
        public ICollection<Formations> Formations { get; set; }

        public ICollection<PermisConduit> PermisConduit { get; set; }

        private List<Competences> MapCompetences(IEnumerable<CompetenceDTO> competencesDto)
        {
            return competencesDto?.Select(c => new Competences
            {
                NomComp = c.NomComp
            }).ToList();
        }

        private List<ExperienceProf> MapExperienceProfs(IEnumerable<ExperienceProfDTO> experienceProfsDto)
        {
            return experienceProfsDto?.Select(e => new ExperienceProf
            {
                EntrepriseAccueil = e.EntrepriseAccueil,
                IntitulePoste = e.IntitulePoste,
                DateDebut = e.DateDebut,
                DateFin = e.DateFin,
                Description = e.Description
            }).ToList();
        }

        private List<Langues> MapLangues(IEnumerable<LangueDTO> languesDto)
        {
            return languesDto?.Select(l => new Langues
            {
                NomLangue = l.NomLangue,
                NiveauMaitrise = l.NiveauMaitrise
            }).ToList();
        }

        private List<Formations> MapFormations(IEnumerable<FormationDTO> formationsDto)
        {
            return formationsDto?.Select(f => new Formations
            {
                Etablissement = f.Etablissement,
                Diplome = f.Diplome,
                Annee = f.Annee,
                Specialite = f.Specialite
            }).ToList();
        }

        private List<PermisConduit> MapPermisConduit(IEnumerable<PermisConduit> permisConduitsDto)
        {
            return permisConduitsDto?.Select(p => new PermisConduit
            {
                type_permis = p.type_permis
            }).ToList();
        }



    }
}
