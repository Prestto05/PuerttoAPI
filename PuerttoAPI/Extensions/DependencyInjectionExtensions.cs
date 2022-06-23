﻿using AutoMapper;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Repositories.GeneralRepository;
using PuerttoAPI.Interfaces;
using PuerttoAPI.Services;

namespace PuerttoAPI.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void InjectAutomapperService(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => { cfg.AddProfile(new AutomapperProfile()); });
            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }

        public static void InjectApiServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IExample, ExampleServices>();
        }

        public static void InjectRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IExaampleRepository, ExampleRepository>();
        }
    }
}