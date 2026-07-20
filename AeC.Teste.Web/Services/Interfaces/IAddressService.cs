using AeC.Teste.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AeC.Teste.Web.Services.Interfaces
{
    public interface IAddressService
    {
        Task<IReadOnlyList<AddressListViewModel>> GetAllAsync();

        Task<AddressEditViewModel?> GetByIdAsync(int id);

        Task CreateAsync(AddressCreateViewModel model);

        Task UpdateAsync(AddressEditViewModel model);

        Task DeleteAsync(int id);

        Task<IEnumerable<SelectListItem>> GetUsersSelectListAsync();
    }
}
