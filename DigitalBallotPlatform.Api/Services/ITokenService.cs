namespace DigitalBallotPlatform.Api.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
