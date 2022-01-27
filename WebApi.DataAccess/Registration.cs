using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.Data.Contexts;

namespace WebApi.DataAccess
{
    public static class Registration
    {
        public static IServiceCollection AddWebApiDataAccess(this IServiceCollection services)
        {
            services.AddDbContext<AdministrationDbContext>();
            return services;
        }
    }
}
