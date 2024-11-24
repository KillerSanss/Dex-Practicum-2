using Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Маппинг для DrugItem
/// </summary>
public class DrugItemMappingProfile : Profile
{
    public DrugItemMappingProfile()
    {
        CreateMap<CreateDrugItemCommand, DrugItem>();
    }
}