namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface IUpdateCommand<T>
    {
        Task ExecuteUpdateAsync(T obj);
    }
}
