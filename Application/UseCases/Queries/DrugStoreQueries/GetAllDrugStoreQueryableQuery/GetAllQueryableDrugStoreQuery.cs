using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Application.UseCases.Queries.DrugStoreQueries.GetAllDrugStoreQueryableQuery;

/// <summary>
/// Получение всех Query DrugStore
/// </summary>
/// <param name="QueryOptions">Опции Query.</param>
public record GetAllQueryableDrugStoreQuery(ODataQueryOptions<DrugStore> QueryOptions) : IRequest<IQueryable<DrugStore>>;