namespace DigitalBallotPlatform.Shared.Interfaces.Queries
{
    public interface IRetrieveQuery<T>
    {
        Task<IEnumerable<T>> GetAllEntitiesAsync();
        Task<T> GetEntityByIdAsync(int id);
    }
}
