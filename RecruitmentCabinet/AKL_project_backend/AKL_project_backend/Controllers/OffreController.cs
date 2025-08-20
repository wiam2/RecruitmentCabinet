using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using AKL_project_backend.Repository;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace AKL_project_backend.Controllers
{
    [ApiController]
    [Route("api/offre")]
    public class OffreController : ControllerBase
    {
        private readonly OffreService _offreService;

        public OffreController(OffreService offreService)
        {
            _offreService = offreService;
        }

        // GET: api/offre/get
        [HttpGet("get")]
        public async Task<IActionResult> GetAll()
        {
            var offres = await _offreService.GetAllAsync();
            return Ok(offres);
        }

        // GET: api/offre/get/{id}
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var offre = await _offreService.GetByIdAsync(id);
            if (offre == null)
                return NotFound(new { message = "Offre introuvable avec l'ID fourni." });

            return Ok(offre);
        }

        // POST: api/offre/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] offreDTO offre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdOffre = await _offreService.CreateAsync(offre);
            return CreatedAtAction(nameof(GetById), new { id = createdOffre.Id }, createdOffre);
        }

        // PUT: api/offre/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] offreDTO updatedOffre)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var offre = await _offreService.UpdateAsync(id, updatedOffre);
            if (offre == null)
                return NotFound(new { message = "Offre introuvable avec l'ID fourni pour la mise à jour." });

            return Ok(offre);
        }

        // DELETE: api/offre/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _offreService.DeleteAsync(id);
            if (!success)
                return NotFound(new { message = "Offre introuvable avec l'ID fourni pour la suppression." });

            return NoContent();
        }




        [HttpPost("ajouter-candidat")]
        public async Task<IActionResult> AjouterCandidat( [FromBody] affectationIdForm  postuleform)
        {
            try
            {
                Console.WriteLine($"offreId: {postuleform.offreId}, candidatId: {postuleform.condidatid}");
                await _offreService.AjouterCandidatAsync(postuleform);
                return Ok(new { Message = "Candidat ajouté avec succès à l'offre." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        [HttpPost("validerCondidat")]
        public async Task<IActionResult> validerCondidat([FromBody] affectationIdForm postuleform)
        {
            try
            {
                Console.WriteLine($"offreId: {postuleform.offreId}, candidatId: {postuleform.condidatid}");
                await _offreService.AjouterCandidatVAL(postuleform);
                return Ok(new { Message = "Candidat ajouté avec succès à l'offre." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }


        [HttpGet("by-recruteur/{recruteurId}")]
    public async Task<ActionResult<List<Offre>>> GetByRecruteurId(string recruteurId)
    {
        try
        {
            var offres = await _offreService.GetByRecruteurIdAsync(recruteurId);

            if (offres == null || offres.Count == 0)
            {
                return NotFound(new { Message = $"No offers found for recruiter with ID {recruteurId}." });
            }

            return Ok(offres);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An error occurred while retrieving the offers.", Details = ex.Message });
        }
    }



        [HttpGet("{offreId}/candidats")]
        public async Task<IActionResult> GetCandidatsByOffreId(int offreId)
        {
            try
            {
                // Récupère la liste des candidats associés à l'ID de l'offre
                var candidats = await _offreService.GetCondidatsByOffreIdAsync(offreId);

                // Si aucun candidat n'est trouvé, retourner une réponse avec un code 404
                if (candidats == null || candidats.Count == 0)
                {
                    return NotFound(new { Message = "Aucun candidat trouvé pour cette offre." });
                }

                // Retourne la liste des candidats trouvés
                return Ok(candidats);
            }
            catch (ArgumentException ex)
            {
                // Si une erreur se produit, on retourne un code 400 avec un message d'erreur
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // Retourne une erreur interne si une exception inattendue survient
                return StatusCode(500, new { Message = "Une erreur s'est produite.", Details = ex.Message });
            }
        }
    }
}
    




