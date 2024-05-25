using Microsoft.OpenApi.Models;

namespace ProjetosApp.API.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            //habilitando o swagger para ler e adicionar os endpoints criados na API
            services.AddEndpointsApiExplorer();

            //configurando uma descricao para a página do swagger
            services.AddSwaggerGen(options => options.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ProjetosApp - API para controle de projetos",
                Description = "API .NET com EntityFramework",

                Contact = new OpenApiContact
                {
                    Name = "Joao Pedro Tuler",
                    Email = "joaotuler88@gmail.com",
                    Url = new Uri("https://github.com/tulerws")
                }
            })); 
        }
    }
}
