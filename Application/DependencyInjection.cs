using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Application
{
    public static class DependencyInjection

    {
        public static IServiceCollection AddApplication (this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            /*
            Dzęki temu framework ASP.net Core  będzie wiedział że jeśli gdziekolwiek na wejściu np.w parametrze konstruktora
            dotanie interfejs IPostService  to automatycznie przypisze implementacje klasy PostService. 
           Zostanie stworzona referencja - odniesienie
            */

            services.AddScoped<IPostService, PostService>();



           

           

            return services;
        }
    }
}
