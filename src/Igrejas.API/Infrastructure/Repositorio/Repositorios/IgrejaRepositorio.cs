using Domain.Interfaces.Repositorios;
using Entities.Entidades;
using Infrastructure.Configuracoes;
using Infrastructure.Repositorio.Genericos;

namespace Infrastructure.Repositorio.Repositorios
{
    public sealed class IgrejaRepositorio :
        RepositorioGenerico<Igreja>,
        IIgrejaRepositorio
    {
        public IgrejaRepositorio(ContextoBase context)
            : base(context)
        {
        }
    }
}
