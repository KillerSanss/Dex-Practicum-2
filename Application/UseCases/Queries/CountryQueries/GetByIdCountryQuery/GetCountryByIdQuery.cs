using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries.GetByIdCountryQuery;

/// <summary>
/// Получение Country по идентификатору
/// </summary>
/// <param name="Id">Идентификатор.</param>
public record GetByIdCountryQuery(Guid Id) : IRequest<Country>;