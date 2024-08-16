using Infra.Interfaces;
using Infra.Repository;

namespace LivrosApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {

            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAssuntoRepository, AssuntoRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ILivroAssuntoRepository, LivroAssuntoRepository>();
            services.AddScoped<ILivroAutorRepository, LivroAutorRepository>();
            services.AddScoped<ITpVendaRepository, TpVendaRepository>();
            services.AddScoped<ITpVendaLivroRepository, TpVendaLivroRepository>();
            
            return services;
        }


    }
}
