using System.ComponentModel.DataAnnotations;

namespace AeC.Teste.Web.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o usuário.")]
        [Display(Name = "Usuário")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; } = string.Empty;
    }
}
