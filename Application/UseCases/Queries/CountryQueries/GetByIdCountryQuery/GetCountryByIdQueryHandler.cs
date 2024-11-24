using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries.GetByIdCountryQuery;

/// <summary>
/// Обработчик GetCountryByIdQuery
/// </summary>
public class GetCountryByIdQueryHandler : IRequestHandler<GetByIdCountryQuery, Country>
{
    private readonly ICountryReadRepository _countryReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryReadRepository">Репозиторий чтения CountryReadRepository.</param>
    public GetCountryByIdQueryHandler(
        ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обработка получения Country по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Country.</returns>
    public async Task<Country> Handle(GetByIdCountryQuery request, CancellationToken cancellationToken)
    {
        return await _countryReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}