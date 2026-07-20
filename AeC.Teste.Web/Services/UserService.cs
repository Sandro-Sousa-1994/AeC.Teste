using AeC.Teste.Web.Data;
using AeC.Teste.Web.Models;
using AeC.Teste.Web.Services.Interfaces;
using AeC.Teste.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AeC.Teste.Web.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(AppDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<IReadOnlyList<UserListViewModel>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new UserListViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username
                })
                .ToListAsync();
        }

        public Task<UserEditViewModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(UserCreateViewModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Username = model.Username
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _context.Users
                .AnyAsync(x => x.Username == username);
        }

        public Task UpdateAsync(UserEditViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
