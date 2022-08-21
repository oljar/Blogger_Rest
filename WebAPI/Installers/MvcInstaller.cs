using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace WebAPI.Installers
{
    public class MvcInstaller : IInstaller

    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {

           



            services.AddApplication();
            services.AddInfrastructure();




            services.AddControllers();
        }
    }
}
