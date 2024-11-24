using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries.GetAllDrugQuery;

/// <summary>
/// Получение всех Drug
/// </summary>
public record GetAllDrugQuery : IRequest<List<Drug>>;