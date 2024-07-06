namespace DigitalBallotPlatform.Shared.Interfaces.Commands
{
    public interface IDeleteCommand
    {
        Task<bool> ExecuteDeleteAsync(int id);
    }
}
