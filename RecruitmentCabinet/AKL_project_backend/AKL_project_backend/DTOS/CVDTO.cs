namespace AKL_project_backend.DTOS
{
    public class CVDTO
    {
        
        public int Id { get; set; }
        public string Image { get; set; }
        public string CondidatId { get; set; } // ID du candidat

        // Collections associées
        public List<CompetenceDTO> Competences { get; set; }
        public List<ExperienceProfDTO> ExperienceProfs { get; set; }
        public List<LangueDTO> Langues { get; set; }
        public List<FormationDTO> Formations { get; set; }
        public List<PermisDTOcs> PermisConduits { get; set; }
    }
}
