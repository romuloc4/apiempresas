using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Infra.Data.Repositories;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuncionariosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post(FuncionarioPostRequest request)
        {
            try
            {
                if (_unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf) != null)
                    return StatusCode(422, new { message = "O CPF informadojá está cadastrado." });

                if (_unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula) != null)
                    return StatusCode(422, new { message = "Essa matricula ja se encrontra cadastrada" });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
                if (empresa == null)
                    return StatusCode(422, new { message = "A Empresa informada não está cadastrada." });

                var funcionario = _mapper.Map<Funcionario>(request);
                funcionario.IdFuncionario = Guid.NewGuid();

                _unitOfWork.FuncionarioRepository.Inserir(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(FuncionarioPutRequest request)
        {
            try
            {
                //pesquisando o funcionario atraves do id
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(request.IdFuncionario);

                //verificando se a Funcionario não foi encontrada
                if (funcionario == null)
                    //HTTP 422 -> UNPROCESSABLE ENTITY
                    return StatusCode(422, new { message = "Funcionario não encontrado, verfique o ID informado." });

                var registroCpf = _unitOfWork.FuncionarioRepository.ObterPorCpf(request.Cpf);
                if (registroCpf != null && registroCpf.IdFuncionario != funcionario.IdFuncionario)
                    return StatusCode(422, new { message = "O CPF informado já está cadastrado para outro funcionario." });

                var registroMatricula = _unitOfWork.FuncionarioRepository.ObterPorMatricula(request.Matricula);
                if (registroMatricula != null && registroMatricula.IdFuncionario != funcionario.IdFuncionario)
                    return StatusCode(422, new { message = "A Matrícula informada já está cadastrada para outro funcionario. " });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(request.IdEmpresa);
                if (empresa == null)
                    return StatusCode(422, new { message = "A Empresa informada nao está cadastrada." });

                funcionario = _mapper.Map<Funcionario>(request);
                _unitOfWork.FuncionarioRepository.Alterar(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(200, response);

            }
            catch (Exception e)
            {
                //retornando status e mensagem de erro
                //HTTP 500 -> ERRO INTERNO DE SERVIDOR
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idFuncionario}")]
        public IActionResult Delete(Guid idFuncionario)
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);

                if (funcionario == null)
                    return StatusCode(422, new { message = "Funcionario não encontrado, verfique o ID informado." });

                var empresa = _unitOfWork.EmpresaRepository.ObterPorId(funcionario.IdEmpresa);
                _unitOfWork.FuncionarioRepository.Excluir(funcionario);

                var response = _mapper.Map<FuncionarioResponse>(funcionario);
                response.Empresa = _mapper.Map<EmpresaResponse>(empresa);

                return StatusCode(200, response);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.Consultar();
                var lista = _mapper.Map<List<FuncionarioResponse>>(funcionario);

                if (lista.Count > 0)
                    return StatusCode(200, lista);
                else
                    return StatusCode(204);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idFuncionario}")]
        public IActionResult GetById(Guid idFuncionario)
        {
            try
            {
                var funcionario = _unitOfWork.FuncionarioRepository.ObterPorId(idFuncionario);

                if (funcionario != null)
                {
                    var response = _mapper.Map<FuncionarioResponse>(funcionario);
                    return StatusCode(200, response);
                }
                else
                    return StatusCode(204);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
