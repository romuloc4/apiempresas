using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Services.Responses;
using AutoMapper;

namespace ApiEmpresas.Services.Mappings
{
    /// <summary>
    /// Mapeamendo de objeto ENTITY para RESPONSE (OUTPUT da API)
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        public EntityToResponseMap()
        {
            CreateMap<Empresa, EmpresaResponse>();
            CreateMap<Funcionario, FuncionarioResponse>();
        }
    }
}
