namespace DigitalBallotPlatform.Domain.Data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExecuteCreateAsync(T model);
        Task SaveAsync();
        bool HasChanges();
        Task<bool> ExecuteDeleteAsync(T model);
    }
}
