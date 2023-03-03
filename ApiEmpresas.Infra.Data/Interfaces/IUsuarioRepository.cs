using ApiEmpresas.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositorio para operaões de usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        /// <summary>
        /// Consulta 1 usuário atraés do email
        /// </summary>
        Usuario Obter(string email);

        /// <summary>
        /// Consulta 1 usuário atraés do email e senha
        /// </summary>
        Usuario Obter(string email, string senha);
    }
}
