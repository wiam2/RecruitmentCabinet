using AKL_project_backend.DTOS;
using AKL_project_backend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AKL_project_backend.Controllers
{

    [ApiController]


    [Route("[controller]")]
    
    public class CondidatController : ControllerBase
    {
        private readonly CondidatRepository _condidatRepository;

        public CondidatController(CondidatRepository candidatRepository)
        {
            _condidatRepository = candidatRepository;
        }

        [HttpGet("affichageCandidats")]
        public async Task<IActionResult> GetAllInvestisseurs()
        {
            var Candidats = await _condidatRepository.AffichageCondidats();
            return Ok(Candidats);
        }
        [HttpGet("affichageCandidat/{id}")]

        public async Task<IActionResult> GetCandidatById(string id)
        {
            var CandidatDTO = await _condidatRepository.AffichageCondidatById(id);
            if (CandidatDTO == null)
            {
                return NotFound();
            }

            return Ok(CandidatDTO);
        }
        [HttpDelete("DeleteCandidat/{id}")]
        public async Task<IActionResult> SupprimerCandidat(string id)
        {
            await _condidatRepository.SupprimerCandidatById(id);
            return NoContent();
        }
        [HttpPut("UpdateCandidat/{id}")]
        public async Task<IActionResult> MettreAJourInvestisseur(string id, CondidatDto CandidatDTO)
        {

            await _condidatRepository.MettreAJourcondidat(id, CandidatDTO);

            return NoContent();
        }

    }
}

