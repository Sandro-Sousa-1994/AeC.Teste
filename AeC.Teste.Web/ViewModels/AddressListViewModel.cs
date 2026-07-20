using System.ComponentModel.DataAnnotations;

namespace AeC.Teste.Web.ViewModels
{
    public class AddressListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;

        [Display(Name = "Rua")]
        public string Street { get; set; } = string.Empty;

        [Display(Name = "Número")]
        public string Number { get; set; } = string.Empty;

        [Display(Name = "Complemento")]
        public string? Complement { get; set; }

        [Display(Name = "Bairro")]
        public string District { get; set; } = string.Empty;

        [Display(Name = "Cidade")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Estado")]
        public string State { get; set; } = string.Empty;

        [Display(Name = "Usuário")]
        public string UserName { get; set; } = string.Empty;

        public int UserId { get; set; }
    }
}
