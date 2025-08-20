using AKL_project_backend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AKL_project_backend.model;
using AKL_project_backend.Repository;
using System.Collections.Generic;
using AKL_project_backend.DTOS;

namespace AKL_project_backend.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class AtelierController : ControllerBase
        {
            private readonly AtelierService _atelierService;

            public AtelierController(AtelierService atelierService)
            {
                _atelierService = atelierService;
            }

            // Ajouter un atelier
            [HttpPost("add")]
            public async Task<IActionResult> AddAtelier([FromBody] Atelier atelier)
            {
                if (atelier == null)
                    return BadRequest("Atelier invalide");

                var addedAtelier = await _atelierService.AddAtelierAsync(atelier);
                return Ok(addedAtelier);
            }

            // Récupérer tous les ateliers
            [HttpGet("all")]
            public async Task<IActionResult> GetAllAteliers()
            {
                var ateliers = await _atelierService.GetAllAteliersAsync();
                return Ok(ateliers);
            }

            // Récupérer les 5 derniers ateliers
            [HttpGet("last-five")]
            public async Task<IActionResult> GetLastFiveAteliers()
            {
                var lastFiveAteliers = await _atelierService.GetLastFiveAteliersAsync();
                return Ok(lastFiveAteliers);
            }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAtelier(int id)
        {
            var result = await _atelierService.DeleteAtelierAsync(id);
            if (!result)
            {
                return NotFound(new { message = "Atelier non trouvé." });
            }

            return Ok(new { message = "Atelier supprimé avec succès." });
        }


        [HttpPost("Reserver")]
        public async Task<IActionResult> Reserver([FromBody] affectationIdForm reserveform)
        {
            try
            {
                Console.WriteLine($"offreId: {reserveform.offreId}, candidatId: {reserveform.condidatid}");
                await _atelierService.Reserver(reserveform);
                return Ok(new { Message = "Candidat ajouté avec succès à l'offre." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
    }



