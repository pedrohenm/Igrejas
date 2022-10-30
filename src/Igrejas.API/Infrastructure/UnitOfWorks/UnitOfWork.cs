using Domain.Interfaces.UnitOfWorks;
using Infrastructure.Configuracoes;

namespace Infrastructure.UnitOfWorks
{
    public sealed class UnitOfWork :
        IUnitOfWork
    {
        private readonly ContextoBase _dbContext;
        public UnitOfWork(ContextoBase dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
