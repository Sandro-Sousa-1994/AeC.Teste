namespace AeC.Teste.Web.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Cep { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string? Complement { get; set; }

        public string District { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public int UserId { get; set; }

        public User User { get; set; } = null!;
    }
}
