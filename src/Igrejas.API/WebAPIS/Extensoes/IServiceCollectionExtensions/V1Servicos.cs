using Domain.Interfaces.Servicos;
using Domain.Servicos;

namespace WebAPIS.Extensoes.IServiceCollectionExtensions
{
    internal static class V1Servicos
    {
        public static void IncluirV1Servicos(this IServiceCollection services)
        {
            IncluirIgrejaServico(ref services);
        }

        private static void IncluirIgrejaServico(ref IServiceCollection services)
        {
            services.AddScoped<IIgrejaServico, IgrejaServico>();
        }
    }
}
