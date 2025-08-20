using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using AKL_project_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace AKL_project_backend.Controllers
{
    public class AccountController(IUserAccount userAccount , UserManager<User> userManager) : ControllerBase
    {
      

        [HttpPost("registerRecruteur")]
        public async Task<IActionResult> RegisterInvestisseur([FromBody]  RecruteurDTO RecruteurDTO)
        {
          
            var response = await userAccount.CreateRecruteur(RecruteurDTO);
            return Ok(response);
        }

        [HttpPost("registerCondidat")]
        public async Task<IActionResult> RegisterCondidat([FromBody] CondidatDto CondidatDTO)
        {
            var response = await userAccount.CreateAccountCondidat(CondidatDTO);
            return Ok(response);
        }


        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] AdminDTO AdminDTO)
        {
            var response = await userAccount.CreateAccountAdmin(AdminDTO);
            return Ok(response);
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            // Vérifiez si le corps de la requête est null
            if (loginDTO == null)
            {
                Console.WriteLine("Requête reçue : null");
                return BadRequest("Le corps de la requête est vide.");
            }

            // Vérifiez les champs Email et Password
            if (string.IsNullOrEmpty(loginDTO.Email) || string.IsNullOrEmpty(loginDTO.Password))
            {
                Console.WriteLine($"Requête reçue avec des champs manquants : {loginDTO}");
                return BadRequest("Les champs Email et Password sont requis.");
            }

            // Log des informations reçues
            Console.WriteLine($"Requête reçue : Email = {loginDTO.Email}, Password = (caché)");

            // Appeler le service utilisateur pour effectuer la connexion
            var response = await userAccount.LoginAccount(loginDTO);

            // Vérifiez la réponse du service
            if (response == null)
            {
                return Unauthorized("Échec de la connexion. Vérifiez vos informations.");
            }

            return Ok(response);
        }
       [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok("Email confirmé avec succès !");

            return BadRequest("Erreur lors de la confirmation.");
        }

        [HttpGet("test-email")]
        public async Task<IActionResult> TestEmail([FromServices] EmailService emailService)
        {
            await emailService.SendEmailAsync("test@example.com", "Test Mailtrap", "<p>Hello depuis Mailtrap 🎉</p>");
            return Ok("Email envoyé !");
        }




    }


}

