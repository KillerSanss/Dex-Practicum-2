using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.CountryQueries.GetAllCountryQuery;

/// <summary>
/// Обработчик GetAllCountryQuery
/// </summary>
public class GetAllCountryQueryHandler : IRequestHandler<GetAllCountryQuery, List<Country>>
{
    private readonly ICountryReadRepository _countryReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryReadRepository">Репозиторий чтения CountryReadRepository.</param>
    public GetAllCountryQueryHandler(
        ICountryReadRepository countryReadRepository)
    {
        _countryReadRepository = countryReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Country.</returns>
    public async Task<List<Country>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
    {
        return await _countryReadRepository.GetAllAsync(cancellationToken);
    }
}