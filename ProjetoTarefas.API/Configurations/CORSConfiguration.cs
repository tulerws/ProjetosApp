
namespace ProjetosApp.API.Configurations
{
    public class CORSConfiguration
    {
        public static string PolicyName => "DefaultPolicy";

        public static void Configure(IServiceCollection services)
        {
            services.AddCors(cfg => cfg.AddPolicy(PolicyName, builder =>
            {
                builder.WithOrigins("http://localhost:5078/")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        }
    }
}