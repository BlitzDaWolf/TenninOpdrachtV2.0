using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.BLL
{
    public static class BLLExstention
    {
        public static IServiceCollection AddServices(this IServiceCollection service, string conectionString, string migrationsAssembly)
        {
            return service;
        }
    }
}
