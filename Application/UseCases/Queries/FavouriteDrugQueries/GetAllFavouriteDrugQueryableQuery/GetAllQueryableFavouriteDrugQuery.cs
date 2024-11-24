using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetAllFavouriteDrugQueryableQuery;

/// <summary>
/// Получение всех Query FavouriteDrug
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableFavouriteDrugQuery(ODataQueryOptions<FavouriteDrug> QueryOptions) : IRequest<IQueryable<FavouriteDrug>>;