using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.CountryQueries.GetAllCountryQueryableQuery;

/// <summary>
/// Получение всех Query Country
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableCountryQuery(ODataQueryOptions<Country> QueryOptions) : IRequest<IQueryable<Country>>;