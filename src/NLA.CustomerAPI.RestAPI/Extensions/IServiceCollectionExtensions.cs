using System;
using System.Reflection;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NLA.CustomerAPI.Apis.Mapping;
using NLA.CustomerAPI.Apis.Mapping.Interfaces;
using System.Linq;

namespace NLA.CustomerAPI.Apis.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IMapperConfigurationBuilder AddAutoMapperWithDefaultConfiguration(this IServiceCollection services, params Assembly[] assemblies)
        {
            var builder = new MapperConfigurationBuilder();

            services.AddSingleton<AutoMapper.IConfigurationProvider>(sp => new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;

                foreach (Type profileType in builder.ProfileTypes)
                {
                    cfg.AddProfile(profileType);
                }

                if (assemblies?.Any() == true)
                {
                    cfg.AddMaps(assemblies);
                }
            }));

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            return builder;
        }
    }
}