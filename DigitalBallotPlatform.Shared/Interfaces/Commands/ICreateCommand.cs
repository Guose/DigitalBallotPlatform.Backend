namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface ICreateCommand<T>
    {
        Task ExecuteCreateAsync(T obj);
    }
}
