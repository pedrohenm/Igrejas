using Domain.Interfaces.Repositorios;
using Infrastructure.Configuracoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Infrastructure.Repositorio.Genericos
{
    public abstract class RepositorioGenerico<T> :
        IDisposable where T : class
    {
        protected readonly ContextoBase Contexto;

        public RepositorioGenerico(ContextoBase contexto)
        {
            Contexto = contexto;
        }

        public async Task Adicionar(T objeto)
        {
            await Contexto
                .Set<T>()
                .AddAsync((T)objeto)
                .ConfigureAwait(false);
        }

        public void Atualizar(T objeto)
        {
            Contexto
                .Set<T>()
                .Update((T)objeto);
        }

        public void Deletar(T objeto)
        {
            Contexto
                .Set<T>()
                .Remove((T)objeto);
        }
        
        public async Task<T> ObterEntidadePeloId(Guid id)
        {
            var entity = await Contexto
               .Set<T>()
               .FindAsync(id)
               .ConfigureAwait(false);

            return entity;
        }

        public async Task<IReadOnlyCollection<T>> ObterTodas()
        {
            var entities = await Contexto
                .Set<T>()
                .ToListAsync()
                .ConfigureAwait(false);

            var readonlyList = new ReadOnlyCollection<T>(entities);
            return readonlyList;
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }
    }
}
