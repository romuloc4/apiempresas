using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisisção de cadastro de usuario
    /// </summary>
    public class RegisterPostRequest
    {
        [Required(ErrorMessage = "Informe o nome do usuáio.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe o email do usuáio.")]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Informe no máximo {20} caracteres.")]
        [Required(ErrorMessage = "Informe a senha do usuaio.")]
        public string Senha { get; set; }
    }
}
