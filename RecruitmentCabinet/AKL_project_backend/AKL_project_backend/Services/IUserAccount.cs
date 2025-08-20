using AKL_project_backend.DTOS;
using static AKL_project_backend.DTOS.ServiceResponces.ServiceResponses;

namespace AKL_project_backend.Services
{
    public interface IUserAccount
    {
       Task<GeneralResponse> CreateRecruteur(RecruteurDTO RecruteurDTO);
        Task<GeneralResponse> CreateAccountCondidat(CondidatDto CondidatDto);
        Task<GeneralResponse> CreateAccountAdmin(AdminDTO AdminDto);
        Task<LoginResponse> LoginAccount(LoginDTO loginDTO);
    }
}
