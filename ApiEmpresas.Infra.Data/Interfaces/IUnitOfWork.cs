using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEmpresas.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        #region Método para controle de transação

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Métodos para acesso aos repositórios

        public IEmpresaRepository EmpresaRepository { get; }
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IUsuarioRepository UsuarioRepository { get; }

        #endregion
    }
}
