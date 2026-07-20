using System.ComponentModel.DataAnnotations;

namespace AeC.Teste.Web.ViewModels
{
    public class UserEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o usuário.")]
        [Display(Name = "Usuário")]
        public string Username { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string? Password { get; set; }
    }
}
