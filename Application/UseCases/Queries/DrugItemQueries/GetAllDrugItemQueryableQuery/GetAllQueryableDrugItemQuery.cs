using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.DrugItemQueries.GetAllDrugItemQueryableQuery;

/// <summary>
/// Получение всех Query DrugItem
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableDrugItemQuery(ODataQueryOptions<DrugItem> QueryOptions) : IRequest<IQueryable<DrugItem>>;