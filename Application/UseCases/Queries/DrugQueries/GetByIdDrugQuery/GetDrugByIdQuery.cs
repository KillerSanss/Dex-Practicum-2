using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries.GetByIdDrugQuery;

/// <summary>
/// Получение Drug по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetDrugByIdQuery(Guid Id) : IRequest<Drug>;