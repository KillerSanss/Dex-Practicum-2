using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries.GetAllCountryQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableCountryQuery
/// </summary>
public class GetAllQueryableCountryQueryHandler : IRequestHandler<GetAllQueryableCountryQuery, IQueryable<Country>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryReadRepository">Репозиторий чтения CountryReadRepository.</param>
    public GetAllQueryableCountryQueryHandler(
        ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query Country.</returns>
    public async Task<IQueryable<Country>> Handle(GetAllQueryableCountryQuery request, CancellationToken cancellationToken)
    {
        return await _countryReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}