using Application.UseCases.Commands.DrugStoreCommands.CreateDrugStoreCommand;
using Domain.Entities;
using Profile = AutoMapper.Profile;

namespace Application.Mapping;

/// <summary>
/// Маппинг для DrugStore
/// </summary>
public class DrugStoreMappingProfile : Profile
{
    public DrugStoreMappingProfile()
    {
        CreateMap<CreateDrugStoreCommand, DrugStore>();
    }
}