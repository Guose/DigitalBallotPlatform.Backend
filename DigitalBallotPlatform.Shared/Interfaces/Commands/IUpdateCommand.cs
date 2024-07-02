namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface IUpdateCommand<T>
    {
        Task<T> ExecuteUpdateAsync(T obj);
    }
}
