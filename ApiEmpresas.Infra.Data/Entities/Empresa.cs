using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Entities
{
    public class Empresa
    {
        #region Propiedades
        public Guid IdEmpresa { get; set; }
        public string Nomefantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        #endregion

        #region Relacionamentos
        public List<Funcionario> Funcionarios { get; set; }
        #endregion
    }
}
