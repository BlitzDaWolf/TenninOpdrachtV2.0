using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.BLL
{
    public static class BLLExstention
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            service.AddScoped<UnitOfWork>();

            return service;
        }
    }
}
