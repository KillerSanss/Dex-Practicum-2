using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.DrugQueries.GetAllDrugQueryableQuery;

/// <summary>
/// Получение всех Query Drug
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableDrugQuery(ODataQueryOptions<Drug> QueryOptions) : IRequest<IQueryable<Drug>>;