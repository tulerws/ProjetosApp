using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosApp.Domain.Helpers;
using ProjetosApp.API.Models.Usuarios.Request;
using ProjetosApp.Domain.Entities;
using ProjetosApp.Infra.Data.Repositories;
using ProjetosApp.API.Models.Usuarios.Response;
using ProjetosApp.API.Security;
using Microsoft.AspNetCore.Authorization;

namespace ProjetosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("criar")]
        public IActionResult Criar(CriarUsuarioPostRequestModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();

                if (usuarioRepository.GetByEmail(model.Email) != null)
                {
                    throw new ApplicationException("O email informado já está cadastrado. Tente outro.");
                }

                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = CryptoHelper.EncryptSHA1(model.Senha)
                };

                usuarioRepository.Add(usuario);

                var response = new CriarUsuarioPostResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email
                };

                return StatusCode(201, new
                {
                    message = "Usuário cadastrado com sucesso", response
                });
            }
            catch(ApplicationException e)
            {
                //HTTP 422 (UNPROCESSABLE ENTITY)
                return UnprocessableEntity(new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUsuarioPostRequestModel model)
        {
            try
            {
                var usuarioRepository = new UsuarioRepository();
                var usuario = usuarioRepository.GetByEmailAndPassword(model.Email, CryptoHelper.EncryptSHA1(model.Senha));


                if(usuario == null)
                {
                    //HTTP 401 (UNAUTHORIZED)
                   throw new ApplicationException("Acesso negado. Usuário não encontrado.");
                }
                else
                {
                    var response = new LoginUsuarioPostResponseModel
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        DataHoraAcesso = DateTime.Now,
                        AccessToken = JWTTokenSecurity.GenerateToken(usuario.Id),
                        DataHoraExpiracao = DateTime.Now.AddHours(JWTTokenSecurity.ExpirationInHours)
                    };

                    return Ok(new { message = "Usuário autenticado com sucesso", response });
                }
            }
            catch(ApplicationException e)
            {
                //HTTP 401 (UNAUTHORIZED)
                return Unauthorized(new { e.Message});
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
