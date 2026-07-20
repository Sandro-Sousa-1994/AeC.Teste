using AeC.Teste.Web.ViewModels;

namespace AeC.Teste.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserListViewModel>> GetAllAsync();

        Task<UserEditViewModel?> GetByIdAsync(int id);

        Task<bool> UsernameExistsAsync(string username);

        Task CreateAsync(UserCreateViewModel model);

        Task UpdateAsync(UserEditViewModel model);

        Task DeleteAsync(int id);
    }
}
