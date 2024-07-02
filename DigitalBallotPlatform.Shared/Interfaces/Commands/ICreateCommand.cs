namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface ICreateCommand<T>
    {
        Task<T> ExecuteCreateAsync(T obj);
    }
}
