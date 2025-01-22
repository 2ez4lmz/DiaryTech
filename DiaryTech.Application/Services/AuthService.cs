using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using DiaryTech.Application.Resources;
using DiaryTech.Domain.Dto.User;
using DiaryTech.Domain.Entity;
using DiaryTech.Domain.Enum;
using DiaryTech.Domain.Interfaces.Repositories;
using DiaryTech.Domain.Interfaces.Services;
using DiaryTech.Domain.Result;
using Serilog;

namespace DiaryTech.Application.Services;

public class AuthService : IAuthService
{
    private readonly IBaseRepository<User> _userRepository;
    private readonly ILogger _logger;
    private readonly IMapper _mapper;

    public AuthService(
        IBaseRepository<User> userRepository,
        ILogger logger,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _logger = logger;
        _mapper = mapper;
    }
    
    public async Task<BaseResult<UserDto>> Register(RegisterUserDto dto)
    {
        if (dto.Password != dto.PasswordConfirm)
        {
            return new BaseResult<UserDto>()
            {
                ErrorMessage = ErrorMessage.PasswordNotEqualsPasswordConfirm,
                ErrorCode = (int)ErrorCodes.PasswordNotEqualsPasswordConfirm
            };
        }

        try
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Login == dto.Login);
            if (user != null)
            {
                return new BaseResult<UserDto>()
                {
                    ErrorMessage = ErrorMessage.UserAlreadyExists,
                    ErrorCode = (int)ErrorCodes.UserAlreadyExists
                };
            }

            var hashUserPassword = HashPassword(dto.Password);

            user = new User()
            {
                Login = dto.Login,
                Password = hashUserPassword
            };

            await _userRepository.CreateAsync(user);
            return new BaseResult<UserDto>()
            {
                Data = _mapper.Map<UserDto>(user)
            };
        }
        catch (Exception ex)
        {
            _logger.Error(ex, ex.Message);

            return new BaseResult<UserDto>()
            {
                ErrorMessage = ErrorMessage.InternalServerError,
                ErrorCode = (int)ErrorCodes.InternalServerError
            };
        }
    }

    public Task<BaseResult<TokenDto>> Login(LoginUserDto dto)
    {
        throw new NotImplementedException();
    }

    private string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(bytes).ToLower();
    }
}