using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection  AddInfrastructure(this IServiceCollection services)
        {

            /*
            Dzęki temu framework ASP.net Core  będzie wiedział że jeśli gdziekolwiek na wejściu np.w parametrze konstruktora
            dotanie interfejs IPostRepository to automatycznie przypisze implementacje klasy PostRepository. 
            Zostanie stworzona referencja - odniesienie       */

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    

            
    }
}
