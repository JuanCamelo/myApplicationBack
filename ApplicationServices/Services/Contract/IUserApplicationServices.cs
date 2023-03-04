using ApplicationServices.DTOs.Models;
using ApplicationServices.DTOs.ViewModels;

namespace ApplicationServices.Services.Contract
{
    public interface IUserApplicationServices
    {
        Task<IEnumerable<UserViewModel>> GetUserAsync(UserFilters filters);
        Task<string> PostUserAsync(UserModel userModel);
        Task<UserViewModel> GetByIdUserAsync(string idUser);
    }
}
