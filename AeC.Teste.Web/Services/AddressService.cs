using AeC.Teste.Web.Data;
using AeC.Teste.Web.Models;
using AeC.Teste.Web.Services.Interfaces;
using AeC.Teste.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AeC.Teste.Web.Services
{
    public class AddressService : IAddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<AddressListViewModel>> GetAllAsync()
        {
            return await _context.Addresses
                .AsNoTracking()
                .Include(x => x.User)
                .OrderBy(x => x.City)
                .ThenBy(x => x.Street)
                .Select(x => new AddressListViewModel
                {
                    Id = x.Id,
                    Cep = x.Cep,
                    Street = x.Street,
                    Number = x.Number,
                    Complement = x.Complement,
                    District = x.District,
                    City = x.City,
                    State = x.State,
                    UserName = x.User.Name,
                    UserId = x.UserId
                })
                .ToListAsync();
        }

        public async Task<AddressEditViewModel?> GetByIdAsync(int id)
        {
            return await _context.Addresses
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new AddressEditViewModel
                {
                    Id = x.Id,
                    Cep = x.Cep,
                    Street = x.Street,
                    Number = x.Number,
                    Complement = x.Complement,
                    District = x.District,
                    City = x.City,
                    State = x.State,
                    UserId = x.UserId
                })
                .FirstOrDefaultAsync();
        }

        public async Task CreateAsync(AddressCreateViewModel model)
        {
            var address = new Address
            {
                Cep = model.Cep,
                Street = model.Street,
                Number = model.Number,
                Complement = model.Complement,
                District = model.District,
                City = model.City,
                State = model.State,
                UserId = model.UserId
            };

            _context.Addresses.Add(address);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddressEditViewModel model)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (address == null)
                throw new InvalidOperationException($"Endereço com ID {model.Id} não encontrado.");

            address.Cep = model.Cep;
            address.Street = model.Street;
            address.Number = model.Number;
            address.Complement = model.Complement;
            address.District = model.District;
            address.City = model.City;
            address.State = model.State;
            address.UserId = model.UserId;

            _context.Addresses.Update(address);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);

            if (address == null)
                throw new InvalidOperationException($"Endereço com ID {id} não encontrado.");

            _context.Addresses.Remove(address);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetUsersSelectListAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                })
                .ToListAsync();
        }
    }
}
