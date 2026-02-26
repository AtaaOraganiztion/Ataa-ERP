using Application.Features.Identities.Dtos;
using AutoMapper;

namespace Application.Mapping.User;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<Domain.Entities.User, BaseUserDto>();
    }
}