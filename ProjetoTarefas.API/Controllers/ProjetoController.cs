using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetosApp.API.Models.Projetos.Request;
using ProjetosApp.API.Models.Projetos.Response;
using ProjetosApp.Domain.Entities;
using ProjetosApp.Domain.Enums;
using ProjetosApp.Domain.Interfaces.Repositories;
using ProjetosApp.Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace ProjetosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        /// <summary>
        /// Serviço da API para cadastro de projetos
        /// </summary>
        [HttpPost]
        [Route("criar")]
        [ProducesResponseType(typeof(ProjetoPostResponseModel), 201)]
        public IActionResult Criar(ProjetoPostRequestModel model)
        {
            try
            {
                var projetoRepository = new ProjetoRepository();

                //criando as informações do cadastro de um projeto
                var projeto = new Projeto
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Descricao = model.Descricao,
                    Categoria = (CategoriaProjeto)model.Categoria,
                    DataInicio = model.DataInicio,
                    DataEntrega = model.DataEntrega,
                    Status = (Status)1
                };

                projetoRepository.Add(projeto);

                return StatusCode(201, new
                {
                    Message = "Projeto cadastrado com sucesso.",
                    ProjetoId = projeto.Id,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha ao cadastrar projeto:" + e.Message);
            }
        }


        /// <summary>
        /// Serviço da API para edição de projetos
        /// </summary>
        [HttpPut]
        [Route("atualizar")]
        [ProducesResponseType(typeof(ProjetoPutResponseModel), 200)]
        public IActionResult Atualizar(ProjetoPutRequestModel model)
        {
            try
            {
                var projetoRepository = new ProjetoRepository();
                var projeto = projetoRepository.GetById(model.Id.Value);

                if (projeto != null)
                {
                    projeto.Nome = model.Nome;
                    projeto.Descricao = model.Descricao;
                    projeto.Categoria = (CategoriaProjeto)model.Categoria;
                    projeto.DataInicio = model.DataInicio;
                    projeto.DataEntrega = model.DataEntrega;
                    projeto.Status = (Status)1;

                    projetoRepository.Update(projeto);

                    return StatusCode(200, new { Message = "Projeto atualizado com sucesso." });
                }
                else
                {
                    return StatusCode(400, new { message = "Projeto não encontrado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha ao atualizar projeto:" + e.Message);
            }
        }

        /// <summary>
        /// Serviço da API para exclusão dos projetos
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjetoDeleteResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var projetoRepository = new ProjetoRepository();
                var projeto = projetoRepository.GetById(id);

                if (projeto != null)
                {
                    projetoRepository.Delete(projeto);

                    return StatusCode(200, new { message = "Projeto excluído com sucesso, Data e hora da exclusão: " + DateTime.Now });
                }
                else
                {
                    return StatusCode(400, new { message = "Projeto não encontrado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Serviço da API para consulta de todos os projetos
        /// </summary>
        [HttpGet]
        [Route("dashboard")]
        [ProducesResponseType(typeof(List<ProjetoGetResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                var projetoRepository = new ProjetoRepository();
                var model = projetoRepository.GetAll();

                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço da API para consulta de um projeto pelo nome
        /// </summary>
        [HttpGet("{nome}")]
        [ProducesResponseType(typeof(ProjetoGetResponseModel), 200)]
        public IActionResult GetByName(string nome)
        {
            try
            {
                var projetoRepository = new ProjetoRepository();
                var projeto = projetoRepository.GetByName(nome);

                if (projeto != null)
                {
                    return StatusCode(200, projeto);
                }
                else
                {
                    //No content
                    return StatusCode(204, new { message = "Nenhum projeto encontrado." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Concluir(Guid id)
        {
            var projetoRepository = new ProjetoRepository();
            var projeto = projetoRepository.GetById(id);

            if(projeto == null)
            {
                return NotFound();
            }

            projeto.Status = Status.CONCLUÍDO; 
            projetoRepository.Update(projeto);
            
            return StatusCode(200);
            
        }
    }
}
