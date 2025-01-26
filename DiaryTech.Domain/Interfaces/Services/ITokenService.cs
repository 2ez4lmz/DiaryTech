using System.Security.Claims;
using DiaryTech.Domain.Dto.User;
using DiaryTech.Domain.Result;

namespace DiaryTech.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim> claims);

    string GenerateRefreshToken();

    ClaimsPrincipal GetPrincipalFromExpiredToken(string accessToken);
    
    Task<BaseResult<TokenDto>> RefreshToken(TokenDto dto);
}