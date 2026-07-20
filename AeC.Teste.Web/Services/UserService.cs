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

        public async Task<UserEditViewModel?> GetByIdAsync(int id)
        {
            return await _context.Users
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new UserEditViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username
                })
                .FirstOrDefaultAsync();
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

        public async Task<bool> UsernameExistsAsync(string username, int? ignoreUserId = null)
        {
            var query = _context.Users.Where(x => x.Username == username);

            if (ignoreUserId.HasValue)
            {
                query = query.Where(x => x.Id != ignoreUserId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task UpdateAsync(UserEditViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (user == null)
                throw new InvalidOperationException($"Usuário com ID {model.Id} não encontrado.");

            user.Name = model.Name;
            user.Username = model.Username;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
            }

            _context.Users.Update(user);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new InvalidOperationException($"Usuário com ID {id} não encontrado.");

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();
        }
    }
}
