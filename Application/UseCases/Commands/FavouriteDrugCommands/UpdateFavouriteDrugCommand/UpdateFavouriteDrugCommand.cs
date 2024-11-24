using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavouriteDrugCommands.UpdateFavouriteDrugCommand;

/// <summary>
/// Создание FavoriteDrug
/// </summary>
/// <param name="FavouriteDrugId">Идентификатор FavouriteDrug.</param>
/// <param name="ProfileId">Идентификатор UserProfile.</param>
/// <param name="UserProfile">UserProfile.</param>
/// <param name="DrugId">Идентификатор Drug.</param>
/// <param name="Drug">Drug.</param>
/// <param name="DrugStoreId">Идентификатор DrugStore.</param>
/// <param name="DrugStore">DrugStore.</param>
public record UpdateFavouriteDrugCommand(Guid FavouriteDrugId, Guid ProfileId, UserProfile UserProfile, Guid DrugId, Drug Drug, Guid DrugStoreId, DrugStore DrugStore) : IRequest<FavouriteDrug>;