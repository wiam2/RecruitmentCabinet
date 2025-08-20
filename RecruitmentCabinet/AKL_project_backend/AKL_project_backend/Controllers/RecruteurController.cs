using AKL_project_backend.DTOS;
using AKL_project_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AKL_project_backend.Controllers
{

    [ApiController]


    [Route("[controller]")]
    public class RecruteurController : ControllerBase
    {



            private readonly RecruteurRepos _RecrRepository;

        public RecruteurController(RecruteurRepos RecruteurRepos)
            {
                _RecrRepository = RecruteurRepos;
            }

            [HttpGet("affichageRecruteurs")]
            public async Task<IActionResult> GetAllInvestisseurs()
            {
                var Candidats = await _RecrRepository.AffichageRECRSs();
                return Ok(Candidats);
            }
            [HttpGet("affichageRecruteur/{id}")]

            public async Task<IActionResult> GetCandidatById(string id)
            {
                var CandidatDTO = await _RecrRepository.AffichageRecruteurById(id);
                if (CandidatDTO == null)
                {
                    return NotFound();
                }

                return Ok(CandidatDTO);
            }
            [HttpDelete("DeleteRecruteur/{id}")]
            public async Task<IActionResult> SupprimerCandidat(string id)
            {
                await _RecrRepository.SupprimerRecruteurById(id);
                return NoContent();
            }
            [HttpPut("UpdateRecruteur/{id}")]
            public async Task<IActionResult> MettreAJourRecruteur(string id, RecruteurDTO RecDTO)
            {

           
                await _RecrRepository.UpdateRecruteurById(id, RecDTO);

                return NoContent();
            }

        }


    }


