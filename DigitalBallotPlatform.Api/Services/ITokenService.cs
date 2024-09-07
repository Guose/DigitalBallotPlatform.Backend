using System.Security.Claims;

namespace DigitalBallotPlatform.Api.Services
{
    public interface ITokenService
    {
        string GenerateToken(string username, Guid userId, double interval);

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }
}
