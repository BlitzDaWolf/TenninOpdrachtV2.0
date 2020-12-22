using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.DAL.Context;

namespace Tennis.DAL
{
    public static class DALExtenstion
    {
        public static IServiceCollection AddContext(this IServiceCollection service, string conectionString, string migrationsAssembly)
        {
            service.AddDbContext<TennisContext>(opt => {
                opt.UseSqlServer(conectionString, b => b.MigrationsAssembly(migrationsAssembly));
            });

            return service;
        }
    }
}
