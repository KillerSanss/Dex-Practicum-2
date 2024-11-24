using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries.GetAllDrugItemQuery;

/// <summary>
/// Получение всех DrugItem
/// </summary>
public record GetAllDrugItemQuery : IRequest<List<DrugItem>>;