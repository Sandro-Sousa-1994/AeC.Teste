using AeC.Teste.Web.Services.Dtos;

namespace AeC.Teste.Web.Services.Interfaces
{
    public interface IViaCepService
    {
        Task<ViaCepResponseDto?> GetAddressByCepAsync(string cep);
    }
}
