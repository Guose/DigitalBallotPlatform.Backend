using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalBallotPlatform.Api.Services
{
    internal class TokenService : ITokenService
    {
        private readonly string secret;
        private readonly string issuer;
        private readonly string audience;

        public TokenService(IConfiguration config)
        {
            secret = config.GetValue<string>("JwtSettings:SecretKey")!;
            issuer = config.GetValue<string>("JwtSettings:Issuer")!;
            audience = config.GetValue<string>("JwtSettings:Audience")!;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("username", username) }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
