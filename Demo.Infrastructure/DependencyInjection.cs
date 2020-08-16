using Demo.Application.Repos;
using Demo.Infrastructure.RepoImplementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDapperInfrastruction(this IServiceCollection services)
        {

            services.AddTransient<ICategoryRepository, CategoryRepo>();

            return services;
        }
    }
}
