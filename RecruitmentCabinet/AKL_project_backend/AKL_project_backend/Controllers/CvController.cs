using AKL_project_backend.DTOS;
using AKL_project_backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AKL_project_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CvController : ControllerBase
    {
        private readonly CVRepository _cvRepository;

        public CvController(CVRepository cvRepository)
        {
            _cvRepository = cvRepository;
        }

        /// <summary>
        /// Crée un nouveau CV.
        /// </summary>
        /// <param name="cvDto">Données du CV à créer.</param>
        /// <returns>Le CV créé.</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateCV([FromBody] CVDTO cvDto)
        {
            Console.WriteLine("le cv " + cvDto);
            try
            {
                if (cvDto == null)
                {
                    return BadRequest("Les données du CV sont invalides.");
                }

                // Créer le CV en appelant le repository
                var createdCV = await _cvRepository.CreateCVAsync(cvDto);

                return CreatedAtAction(nameof(GetCVById), new { id = createdCV.Id }, createdCV);
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                return StatusCode(500, $"Erreur lors de la création du CV : {ex.Message}");
            }
        }
            [HttpPut("up/{id}")]

            public async Task<IActionResult> UpdateCV([FromBody] CVDTO cvDto, int id)
            {
                Console.WriteLine("le cv " + cvDto);

                try
                {
                    if (cvDto == null)
                    {
                        return BadRequest("Les données du CV sont invalides.");
                    }

                    // Appelez le repository pour mettre à jour le CV
                    var updatedCV = await _cvRepository.UpdateCVAsync(id, cvDto);

                    if (updatedCV == null)
                    {
                        return NotFound("Le CV avec l'ID spécifié n'a pas été trouvé.");
                    }

                    // Retournez un statut 200 OK avec le CV mis à jour
                    return Ok(updatedCV);
                }
                catch (Exception ex)
                {
                    // Gérez les erreurs
                    return StatusCode(500, $"Erreur lors de la mise à jour du CV : {ex.Message}");
                }
            }

            [HttpGet("{id}")]
        public async Task<IActionResult> GetCVById(int id)
        {
            try
            {
                var cv = await _cvRepository.GetCVByIdAsync(id);

                if (cv == null)
                {
                    return NotFound($"CV avec l'ID {id} non trouvé.");
                }

                return Ok(cv);
            }
            catch (Exception ex)
            {
                // Gérer les erreurs
                return StatusCode(500, $"Erreur lors de la récupération du CV : {ex.Message}");
            }
        }
    }

}

