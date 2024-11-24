using Application.UseCases.Commands.FavouriteDrugCommands.CreateFavouriteDrugCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping;

/// <summary>
/// Маппинг для FavouriteDrug
/// </summary>
public class FavouriteDrugMappingProfile : Profile
{
    public FavouriteDrugMappingProfile()
    {
        CreateMap<CreateFavouriteDrugCommand, FavouriteDrug>();
    }
}