namespace Domain.Interfaces.Repositorios
{
    public interface IRepositorioGenerico<T>
    {
        Task Adicionar(T objeto);
        void Atualizar(T objeto);
        void Deletar(T objeto);
        Task<T> ObterEntidadePeloId(Guid id);
        Task<IReadOnlyCollection<T>> ObterTodas();
    }
}
