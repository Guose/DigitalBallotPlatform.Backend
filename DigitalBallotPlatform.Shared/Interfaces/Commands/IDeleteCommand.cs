namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface IDeleteCommand<T>
    {
        Task<bool> ExecuteDeleteAsync(int id);
    }
}
