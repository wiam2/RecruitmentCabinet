using AKL_project_backend.DTOS;
using AKL_project_backend.model;
using AKL_project_backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static AKL_project_backend.DTOS.ServiceResponces.ServiceResponses;

namespace AKL_project_backend.Repository
{

  

    public class AcountRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, EmailService emailService) : IUserAccount
        {
            public IConfiguration Config { get; } = config;

            private readonly EmailService _emailService = emailService;


        public async Task<GeneralResponse> CreateAccountAdmin(AdminDTO AdminDto)
        {
            if (AdminDto is null) return new GeneralResponse(false, "Model is empty");

            var newUser = new Admin()
            {
                image = AdminDto.image,
                // Attributs de AdminDTO
                Pays = AdminDto.Pays,
                Ville = AdminDto.Ville,
                Telephone = AdminDto.Telephone,
                Prenom = AdminDto.Prenom,
                Nom = AdminDto.Nom,
                DateDeNaissance = AdminDto.DateDeNaissance,
                Civilite = AdminDto.Civilite,
                Poste = AdminDto.Poste,

                // Attributs supplémentaires pour l'authentification
                Email = AdminDto.Email,
                PasswordHash = AdminDto.Password,
                UserName = AdminDto.Email
            };

            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, AdminDto.Password);
            if (!createUser.Succeeded)
            {
                var errorMessages = string.Join(", ", createUser.Errors.Select(e => e.Description));
                return new GeneralResponse(false, $"Error occurred.. please try again. Details: {errorMessages}");
            }

            // Créer le rôle RAdmin s'il n'existe pas déjà
            var role = new IdentityRole("RAdmin");
            await roleManager.CreateAsync(role);

            // Ajouter l'utilisateur au rôle Admin
            var addToRoleResult = await userManager.AddToRoleAsync(newUser, "RAdmin");
            if (!addToRoleResult.Succeeded)
            {
                return new GeneralResponse(false, "Failed to assign role to user.");
            }
          /*  var verificationToken = Guid.NewGuid().ToString();
            var verificationLink = $"https://votre-application.com/verify?token={verificationToken}";
            // Envoyer l'e-mail de vérification
            var subject = "Vérifiez votre adresse e-mail";
            var body = $"<p>Merci pour votre inscription. Cliquez sur le lien suivant pour vérifier votre adresse e-mail :</p><p><a href='{verificationLink}'>Vérifier l'e-mail</a></p>";
            Console.WriteLine(AdminDto.Email);
            await _emailService.SendEmailAsync(AdminDto.Email, subject, body);*/


            return new GeneralResponse(true, "Admin account created");
        }


        public async Task<GeneralResponse> CreateAccountCondidat(CondidatDto CondidatDto)
        {
            if (CondidatDto is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new Condidat()
            {
                CVPDF = CondidatDto.CVPDF,

                image = CondidatDto.image,
                //des elements de userDTO
                Pays = CondidatDto.Pays,
                Ville = CondidatDto.Ville,
                Telephone = CondidatDto.Telephone,
                Prenom = CondidatDto.Prenom,
                Nom = CondidatDto.Nom,
                DateDeNaissance = CondidatDto.DateDeNaissance,
                Civilite = CondidatDto.Civilite,
                Poste =CondidatDto.Poste,

                // Additional properties for the User (Identity-related)
                Email = CondidatDto.Email,
                PasswordHash = CondidatDto.Password,
                UserName = CondidatDto.Email
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User registered already");

            var createUser = await userManager.CreateAsync(newUser!, CondidatDto.Password);
            if (!createUser.Succeeded)
            {
                // Il y a eu une erreur lors de la création de l'utilisateur
                var errorMessages = string.Join(", ", createUser.Errors.Select(e => e.Description));
                return new GeneralResponse(false, $"Error occured.. please try again. Details: {errorMessages}");
            }

            // Créer le rôle RInvestisseur s'il n'existe pas déjà
            var role = new IdentityRole("RCondidat");
            await roleManager.CreateAsync(role);

            // Ajouter l'utilisateur au rôle Investisseur
            var addToRoleResult = await userManager.AddToRoleAsync(newUser, "RCondidat");
            if (!addToRoleResult.Succeeded)
            {
                return new GeneralResponse(false, "Failed to assign role to user.");
            }
   

            

            return new GeneralResponse(true, "Account Created");
        }


    

    public async Task<GeneralResponse> CreateRecruteur(RecruteurDTO recruteurDTO)
            {
                if (recruteurDTO is null) return new GeneralResponse(false, "Model is empty");

            Console.WriteLine(recruteurDTO.Civilite);
            var newUser = new Recruteur()
                {
                
                image = recruteurDTO.image,
                NomEntreprise = recruteurDTO.NomEntreprise,
                    RaisonSocial = recruteurDTO.RaisonSocial,
                    Succursal = recruteurDTO.Succursal,
                    SecteurActivite = recruteurDTO.SecteurActivite,
                    Adresse = recruteurDTO.Adresse,
                    Fax = recruteurDTO.Fax,
                    Commune = recruteurDTO.Commune,
                    TailleEnEffectif = recruteurDTO.TailleEnEffectif,
                    StatutJuridique = recruteurDTO.StatutJuridique,
                    TypeCnss = recruteurDTO.TypeCnss,
                    NumRegistre = recruteurDTO.NumRegistre,
                    DateCreation = recruteurDTO.DateCreation,
                    Poste = recruteurDTO.Poste,
          //des elements de userDTO
                    Pays = recruteurDTO.Pays,
                    Ville = recruteurDTO.Ville,
                    Telephone = recruteurDTO.Telephone,
                    Prenom = recruteurDTO.Prenom,
                    Nom = recruteurDTO.Nom,
                    DateDeNaissance = recruteurDTO.DateDeNaissance,
                    Civilite = recruteurDTO.Civilite,

                    // Additional properties for the User (Identity-related)
                    Email = recruteurDTO.Email,
                    PasswordHash = recruteurDTO.Password,
                    UserName = recruteurDTO.Email
                };
                var user = await userManager.FindByEmailAsync(newUser.Email);
                if (user is not null) return new GeneralResponse(false, "User registered already");

                var createUser = await userManager.CreateAsync(newUser!, recruteurDTO.Password);
                if (!createUser.Succeeded)
                {
                    // Il y a eu une erreur lors de la création de l'utilisateur
                    var errorMessages = string.Join(", ", createUser.Errors.Select(e => e.Description));
                    return new GeneralResponse(false, $"Error occured.. please try again. Details: {errorMessages}");
                }

                // Créer le rôle RInvestisseur s'il n'existe pas déjà
                var investisseurRole = new IdentityRole("RRecruteur");
                await roleManager.CreateAsync(investisseurRole);

                // Ajouter l'utilisateur au rôle Investisseur
                var addToRoleResult = await userManager.AddToRoleAsync(newUser, "RRecruteur");
                if (!addToRoleResult.Succeeded)
                {
                    return new GeneralResponse(false, "Failed to assign role to user.");
                }
          /*  var token = await userManager.GenerateEmailConfirmationTokenAsync(newUser);

            // 🔗 Construire le lien de confirmation
            var encodedToken = Uri.EscapeDataString(token);
            var confirmationLink = $"https://localhost:4200/confirm-email?userId={newUser.Id}&token={encodedToken}";

            // 📬 Envoyer l’email
            var subject = "Confirmez votre compte";
            var body = $"<p>Bonjour {newUser.Nom},</p><p>Merci pour votre inscription.</p>" +
                       $"<p>Cliquez sur le lien suivant pour confirmer votre email :</p>" +
                       $"<p><a href='{confirmationLink}'>Confirmer mon compte</a></p>";

            await _emailService.SendEmailAsync(newUser.Email, subject, body);*/


            return new GeneralResponse(true, "Account Created");
            }



   

        public async Task<LoginResponse> LoginAccount(LoginDTO loginDTO)
            {
                if (loginDTO == null)
                    return new LoginResponse(false, null!, "Login container is empty");

                var getUser = await userManager.FindByEmailAsync(loginDTO.Email);
                if (getUser is null)
                    return new LoginResponse(false, null!, "User not found");

                bool checkUserPasswords = await userManager.CheckPasswordAsync(getUser, loginDTO.Password);
                if (!checkUserPasswords)
                    return new LoginResponse(false, null!, "Invalid email/password");

                var getUserRole = await userManager.GetRolesAsync(getUser);
                var userSession = new UserSession(getUser.Id, getUser.Email, getUserRole.First());
                string token = GenerateToken(userSession);
                return new LoginResponse(true, token!, "Login completed");
            }



            private string GenerateToken(UserSession user)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var userClaims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
                var token = new JwtSecurityToken(
                    issuer: config["Jwt:Issuer"],
                    audience: config["Jwt:Audience"],
                    claims: userClaims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }

        }
    }

