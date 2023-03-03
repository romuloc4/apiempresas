using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositoris para operações de empresa
    /// </summary>
    public interface IEmpresaRepository :IBaseRepository<Empresa>
    {
        /// <summary>
        /// método para consultar 1 Empresa atraves do CNPJ
        /// </summary>
        Empresa ObterPorCnpj(string cnpj);

    }
}
