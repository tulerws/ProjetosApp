using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ProjetosApp.API.Models.Usuarios.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjetosApp.Tests
{
    public class UsuarioTest
    {
        [Fact]
        public CriarUsuarioPostRequestModel Criar_Usuario_Com_Sucesso()
        {
            #region Gerar os dados do usuário

            var faker = new Faker("pt_BR");

            var request = new CriarUsuarioPostRequestModel
            {
                Nome = faker.Person.FullName,
                Email = faker.Internet.Email(),
                Senha = "@Admin123",
                SenhaConfirmacao = "@Admin123"
            };

            var json = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            #endregion

            #region Enviando a requisição para a API

            var client = new WebApplicationFactory<Program>().CreateClient();
            var result = client.PostAsync("/api/usuario/criar", json).Result;

            #endregion

            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Content.ReadAsStringAsync().Result
                .Should().Contain("Usuário cadastrado com sucesso");

            return request;
        }

        [Fact]
        public void Autenticar_Usuario_Com_Sucesso()
        {
            #region Criando um usuário na API

            var request = Criar_Usuario_Com_Sucesso();

            //serializando os dados em JSON
            var json = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            #endregion

            #region Enviando a requisição para a API

            var client = new WebApplicationFactory<Program>().CreateClient();
            var result = client.PostAsync("/api/usuario/login", json).Result;

            #endregion

            #region Verificar a resposta

            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Content.ReadAsStringAsync().Result
                .Should().Contain("Usuário autenticado com sucesso");

            #endregion
        }

        [Fact]
        public void Email_Ja_Cadastrado()
        {
            #region Criando um usuário na API

            var request = Criar_Usuario_Com_Sucesso();

            //serializando os dados em JSON
            var json = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            #endregion

            #region Enviando a requisição para a API

            var client = new WebApplicationFactory<Program>().CreateClient();
            var result = client.PostAsync("/api/usuario/criar", json).Result;

            #endregion

            #region Verificar a resposta

            result.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            result.Content.ReadAsStringAsync().Result
                .Should().Contain("O email informado já está cadastrado. Tente outro.");

            #endregion
        }

        [Fact]
        public void Usuario_Nao_Encontrado()
        {
            #region Tentando uma autenticação de um usuário inexistente na API

            var request = new LoginUsuarioPostRequestModel
            {
                Email = "faker@faker.com",
                Senha = "@Admin1234"
            };

            //serializando os dados em JSON
            var json = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            #endregion

            #region Enviando a requisição para a API

            var client = new WebApplicationFactory<Program>().CreateClient();
            var result = client.PostAsync("/api/usuario/login", json).Result;

            #endregion

            #region Verificar a resposta

            result.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            result.Content.ReadAsStringAsync().Result
                .Should().Contain("Acesso negado. Usuário não encontrado.");

            #endregion


        }
    }
}
