using Application.UseCases.Commands.UserProfileCommands.CreateUserProfileCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Маппинг для UserProfile
/// </summary>
public class UserProfileMappingProfile : Profile
{
    public UserProfileMappingProfile()
    {
        CreateMap<CreateUserProfileCommand, UserProfile>();
    }
}