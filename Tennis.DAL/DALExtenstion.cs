using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tennis.DAL.Attributes;
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

        public static IServiceCollection AddMapping(this IServiceCollection service)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TennisMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            service.AddSingleton(mapper);

            return service;

        }

        public static IEnumerable<Type> GetTypes(Assembly assembly, Type attribyte)
        {
            return from type in assembly.GetTypes()
                   where type.IsDefined(attribyte, false)
                   select type;
        }
    }

    public class TennisMapper : Profile
    {
        public TennisMapper()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            // ReadDTOS
            {
                IEnumerable<Type> typesWithHelpAttribute = DALExtenstion.GetTypes(assembly, typeof(ReadDTOAttribute));
                typesWithHelpAttribute.ToList().ForEach(x =>
                {
                    ReadDTOAttribute res = ReadDTOAttribute.GetAttribute(x);
                    CreateMap(x, res.ReadType).ReverseMap();
                });
            }
            // UpdateDTOS
            {
                IEnumerable<Type> typesWithHelpAttribute = DALExtenstion.GetTypes(assembly, typeof(UpdateDTOAttribute));
                typesWithHelpAttribute.ToList().ForEach(x =>
                {
                    ReadDTOAttribute res = ReadDTOAttribute.GetAttribute(x);
                    CreateMap(x, res.ReadType).ReverseMap();
                });
            }
            // CreateDTOS
            {
                IEnumerable<Type> typesWithHelpAttribute = DALExtenstion.GetTypes(assembly, typeof(CreateDTOAttribute));
                typesWithHelpAttribute.ToList().ForEach(x =>
                {
                    ReadDTOAttribute res = ReadDTOAttribute.GetAttribute(x);
                    CreateMap(x, res.ReadType).ReverseMap();
                });
            }
        }
    }
}
