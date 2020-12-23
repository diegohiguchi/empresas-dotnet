using empresas_dotnet.Application.Ators;
using empresas_dotnet.Application.Ators.Interfaces;
using empresas_dotnet.Application.Filmes;
using empresas_dotnet.Application.Filmes.Interfaces;
using empresas_dotnet.Application.Votos;
using empresas_dotnet.Application.Votos.Interfaces;
using empresas_dotnet.Domain.Interfaces;
using empresas_dotnet.Domain.Interfaces.Repositories;
using empresas_dotnet.Domain.Interfaces.Services;
using empresas_dotnet.Domain.Notificacoes;
using empresas_dotnet.Domain.Services;
using empresas_dotnet.Extensions;
using empresas_dotnet.Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace empresas_dotnet.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IVotoRepository, VotoRepository>();
            services.AddScoped<IAtorRepository, AtorRepository>();
            services.AddScoped<IAtorFilmeRepository, AtorFilmeRepository>();

            services.AddScoped<IFilmeService, FilmeService>();
            services.AddScoped<IVotoService, VotoService>();
            services.AddScoped<IAtorService, AtorService>();

            services.AddScoped<IFilmeApplication, FilmeApplication>();
            services.AddScoped<IVotoApplication, VotoApplication>();
            services.AddScoped<IAtorApplication, AtorApplication>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            return services;
        }
    }
}
