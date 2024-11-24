using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetByIdFavouriteDrugQuery;

/// <summary>
/// Получение FavouriteDrug по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetFavouriteDrugByIdQuery(Guid Id) : IRequest<FavouriteDrug>;