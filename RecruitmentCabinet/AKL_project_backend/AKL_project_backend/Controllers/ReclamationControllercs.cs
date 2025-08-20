namespace AKL_project_backend.Controllers
{ 
    using global::AKL_project_backend.DTOS;
    using global::AKL_project_backend.Repository;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    namespace AKL_project_backend.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class ReclamationController : ControllerBase
        {
            private readonly ReclamationRepos _RecRepository;

            public ReclamationController(ReclamationRepos RecRepository)
            {
                _RecRepository = RecRepository;
            }
            // POST: api/Reclamation
            [HttpPost]
            public async Task<ActionResult<ReclamationDTO>> CreerReclamation(ReclamationDTO reclamationDTO)
            {
                try
                {
                    // Appelez la méthode de service pour créer la réclamation
                    var reclamation = await _RecRepository.CreerReclamation(reclamationDTO);

                    // Retourner une réponse avec le statut HTTP 201 (créé) et le DTO
                    return CreatedAtAction(nameof(CreerReclamation), new { id = reclamation.Id }, reclamation);
                }
                catch (Exception ex)
                {
                    // En cas d'erreur, retournez une réponse d'erreur
                    return StatusCode(500, "Erreur lors de la création de la réclamation: " + ex.Message);
                }
            }
        }
    }

}
