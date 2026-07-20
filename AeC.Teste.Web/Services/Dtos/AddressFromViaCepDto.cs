namespace AeC.Teste.Web.Services.Dtos
{
    public class AddressFromViaCepDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Street { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
