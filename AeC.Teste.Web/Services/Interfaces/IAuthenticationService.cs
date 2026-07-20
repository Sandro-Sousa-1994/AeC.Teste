using System.Security.Claims;

namespace AeC.Teste.Web.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ClaimsPrincipal?> AuthenticateAsync(string username, string password);
    }
}
