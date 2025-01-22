using AutoMapper;
using DiaryTech.Domain.Dto.User;
using DiaryTech.Domain.Entity;

namespace DiaryTech.Application.Mapping;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}