using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    public class EmpresaPutRequest
    {
        [Required(ErrorMessage ="Informe o Id da empresa.")]
        public Guid IdEmpresa { get; set; }

        [Required(ErrorMessage = "Infome o Nome Fantasia.")]
        public string? NomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe a Razão Social.")]
        public string? RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ.")]
        public string? Cnpj { get; set; }
    }
}
