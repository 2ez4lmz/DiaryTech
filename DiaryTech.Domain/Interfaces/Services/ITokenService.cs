using System.Security.Claims;

namespace DiaryTech.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();
}