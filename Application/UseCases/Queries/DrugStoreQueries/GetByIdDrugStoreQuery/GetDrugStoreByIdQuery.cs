using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries.GetByIdDrugStoreQuery;

/// <summary>
/// Получение DrugStore по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugStoreByIdQuery(Guid Id) : IRequest<DrugStore>;