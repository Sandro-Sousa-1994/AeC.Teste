using AeC.Teste.Web.Services.Dtos;
using AeC.Teste.Web.Services.Interfaces;
using System.Text.Json;

namespace AeC.Teste.Web.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://viacep.com.br/ws";

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponseDto?> GetAddressByCepAsync(string cep)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep))
                    return null;

                // Remove caracteres especiais (hífen, etc)
                var cleanCep = new string(cep.Where(char.IsDigit).ToArray());

                if (cleanCep.Length != 8)
                    return null;

                var url = $"{BaseUrl}/{cleanCep}/json";

                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    return null;

                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<ViaCepResponseDto>(content, options);

                // Se houver erro na resposta da API
                if (result?.Erro != null)
                    return null;

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
