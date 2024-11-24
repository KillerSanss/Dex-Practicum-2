using MediatR;

namespace Application.UseCases.Commands.FavouriteDrugCommands.DeleteFavouriteDrugCommand;

/// <summary>
/// Удаление FavouriteDrug
/// </summary>
/// <param name="FavouriteDrugId">Идентификатор FavouriteDrug.</param>
public record DeleteFavouriteDrugCommand(Guid FavouriteDrugId) : IRequest;