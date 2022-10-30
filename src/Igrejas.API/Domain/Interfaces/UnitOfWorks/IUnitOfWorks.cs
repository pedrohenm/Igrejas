namespace Domain.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
