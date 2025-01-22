using DiaryTech.Domain.Dto.User;
using DiaryTech.Domain.Result;

namespace DiaryTech.Domain.Interfaces.Services;

/// <summary>
/// Сервис предназначенный для авторизации/регистрации
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Регистрация пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<UserDto>> Register(RegisterUserDto dto);

    /// <summary>
    /// Авторизация пользователя
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<BaseResult<TokenDto>> Login(LoginUserDto dto);
}