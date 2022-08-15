using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            /*
             Dz�ki temu framework ASP.net Core  b�dzie wiedzia� �e je�li gdziekolwiek na wej�ciu np.w parametrze konstruktora
             dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 

             */
            services.AddScoped<IPostService, PostService>();


            /* 
             Metoda AddSingleton zapewni nam �e implementacja interfejsu  b�dzie tworzona tylko jeden raz na samym pocz�tku
             jako argument przekazujemy instancj� konfiguracji automappera. 
             Framework Asp.Net Core b�dzie wiedzia� �e je�li gdziekolwiek  na wej�ciu np w parametrze kostruktora dostanie 
             interfejs IMapper to wstrzyknie implementacj� pochodz�c� z klasy AutoMapperConfig.
             */

            services.AddSingleton(AutoMapperConfig.Initialize());


            services.AddControllers();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
