using Application.UseCases.Commands.CountryCommands.CreateCountryCommand;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Mapping;

/// <summary>
/// Маппинг для Country
/// </summary>
public class CountryMappingProfile : Profile
{
    public CountryMappingProfile()
    {
        CreateMap<CreateCountryCommand, Country>();
    }
}