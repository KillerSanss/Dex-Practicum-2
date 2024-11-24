using Application.UseCases.Commands.DrugCommands.CreateDrugCommand;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Mapping;

/// <summary>
/// Маппинг для Drug
/// </summary>
public class DrugMappingProfile : Profile
{
    public DrugMappingProfile()
    {
        CreateMap<CreateDrugCommand, Drug>();
    }
}