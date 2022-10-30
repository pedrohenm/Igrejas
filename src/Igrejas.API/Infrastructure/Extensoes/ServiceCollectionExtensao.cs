using Domain.Interfaces.Repositorios;
using Domain.Interfaces.UnitOfWorks;
using Infrastructure.Configuracoes;
using Infrastructure.Repositorio.Repositorios;
using Infrastructure.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensoes
{
    public static class ServiceCollectionExtensao
    {
        public static void IncluirPostgreSqlServico(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ContextoBase>(
                options => options.UseNpgsql(configuration.GetConnectionString("IgrejasPostgreSqlDb"))
                                  .EnableSensitiveDataLogging());

            services.AddScoped<IIgrejaRepositorio, IgrejaRepositorio>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
