using ApiEmpresas.Infra.Data.Entities;
using ApiEmpresas.Infra.Data.Interfaces;
using ApiEmpresas.Services.Authorization;
using ApiEmpresas.Services.Requests;
using ApiEmpresas.Services.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmpresas.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly JwtService _jwtService;
        private readonly IUnitOfWork _unitOfWork;

        //construtor para injeção de dependencia
        public LoginController(JwtService jwtService, IUnitOfWork unitOfWork)
        {
            _jwtService = jwtService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult post(LoginPostRequest request)
        {
            try
            {
                //obter o usuario no banco de dados
                var usuario = _unitOfWork.UsuarioRepository
                    .Obter(request.Email, Criptografia.GetMD5(request.Senha));

                //verificando se o usuario foi encontrado
                if(usuario != null)
                {
                    return StatusCode(200, new
                    {
                        message = "autenticação realizada com sucesso.",
                        usuario = usuario.Email,
                        token = _jwtService.GenerateToken(usuario.Email)

                    });
                }
                else
                {
                    return StatusCode(401, new { message = "Acesso negado. Usuário inválido." });
                }

            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
