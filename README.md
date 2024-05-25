# ProjetosApp

ProjetosApp é uma solução em C# .NET, composta por uma API ASP.NET com operações CRUD para projetos e uma classe para teste de usuário. A solução é dividida em quatro projetos:

1. **ProjetosApp.API**: Este é o projeto da API, responsável por expor os endpoints para as operações CRUD de projetos.

2. **ProjetosApp.Domain**: Este projeto contém as classes de domínio e as interfaces dos repositórios.

3. **ProjetosApp.Infra.Data**: Este projeto implementa os repositórios definidos em ProjetosApp.Domain e contém a lógica para a persistência de dados.

4. **ProjetosApp.Tests**: Este projeto contém os testes unitários e de integração para a solução.

## Como executar a solução

Para executar esta solução localmente, siga estas etapas:

1. Clone o repositório para a sua máquina local.
2. Abra a solução no Visual Studio.
3. Restaure os pacotes NuGet (isso pode ser feito automaticamente pelo Visual Studio).
4. Compile a solução.
5. Defina o projeto ProjetosApp.API como o projeto de inicialização.
6. Execute a solução.
