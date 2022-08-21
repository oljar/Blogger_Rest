using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;


namespace WebAPI.Installers
{
    public class SwaggerIstaller : IInstaller

    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

        }
    }
}
