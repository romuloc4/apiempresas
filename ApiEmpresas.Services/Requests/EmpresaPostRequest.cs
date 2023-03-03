using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de cadastro de empresa
    /// </summary>
    public class EmpresaPostRequest
    {
        [Required(ErrorMessage = "Infome o Nome Fantasia.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ.")]
        public string? Cnpj { get; set; }
    }
}
