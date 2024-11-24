using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries.GetAllCountryQuery;

/// <summary>
/// Получение всех Country
/// </summary>
public record GetAllCountryQuery : IRequest<List<Country>>;