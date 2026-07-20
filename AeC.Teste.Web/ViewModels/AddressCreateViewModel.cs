using System.ComponentModel.DataAnnotations;

namespace AeC.Teste.Web.ViewModels
{
    public class AddressCreateViewModel
    {
        [Required(ErrorMessage = "Informe o CEP.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a rua.")]
        [Display(Name = "Rua")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o número.")]
        [Display(Name = "Número")]
        public string Number { get; set; } = string.Empty;

        [Display(Name = "Complemento")]
        public string? Complement { get; set; }

        [Required(ErrorMessage = "Informe o bairro.")]
        [Display(Name = "Bairro")]
        public string District { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a cidade.")]
        [Display(Name = "Cidade")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o estado.")]
        [Display(Name = "Estado")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione um usuário.")]
        [Display(Name = "Usuário")]
        public int UserId { get; set; }
    }
}
