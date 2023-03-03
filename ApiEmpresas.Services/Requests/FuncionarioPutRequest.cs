﻿using System.ComponentModel.DataAnnotations;

namespace ApiEmpresas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisisção de edção de Funcionario
    /// </summary>
    public class FuncionarioPutRequest
    {
        [Required(ErrorMessage = "Por Favor, infome o ID do funcionário")]
        public Guid IdFuncionario { get; set; }

        [Required(ErrorMessage = "Por Favor, infome o NOME do funcionário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por Favor, infome o CPF do funcionário")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por Favor, infome a MATRICULA do funcionário")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Por Favor, infome a DATA DE ADMISSÃO do funcionário")]
        public DateTime DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por Favor, infome o ID da empresa")]
        public Guid IdEmpresa { get; set; }
    }
}
