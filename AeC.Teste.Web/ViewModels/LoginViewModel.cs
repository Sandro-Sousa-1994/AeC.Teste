using System.ComponentModel.DataAnnotations;

namespace AeC.Teste.Web.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "Informe o usuário.")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
