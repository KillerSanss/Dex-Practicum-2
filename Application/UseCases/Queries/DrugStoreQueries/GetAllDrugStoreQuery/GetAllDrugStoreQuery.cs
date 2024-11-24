using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries.GetAllDrugStoreQuery;

/// <summary>
/// Получение всех DrugStore
/// </summary>
public record GetAllDrugStoreQuery : IRequest<List<DrugStore>>;