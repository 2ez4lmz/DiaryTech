using DiaryTech.Domain.Dto.User;
using DiaryTech.Domain.Interfaces.Services;
using DiaryTech.Domain.Result;
using Microsoft.AspNetCore.Mvc;

namespace DiaryTech.WebApi.Controllers;

[ApiController]
public class TokenController : Controller
{
    private readonly ITokenService _tokenService;

    public TokenController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    [Route("refresh")]
    public async Task<ActionResult<BaseResult<TokenDto>>> RefreshToken([FromBody] TokenDto tokenDto)
    {
        var response = await _tokenService.RefreshToken(tokenDto);
        if (response.IsSuccess)
        {
            return Ok(response);
        }

        return BadRequest(response);
    }
}