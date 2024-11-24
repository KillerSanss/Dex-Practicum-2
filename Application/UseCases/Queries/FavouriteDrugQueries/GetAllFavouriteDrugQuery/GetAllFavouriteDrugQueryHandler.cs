using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetAllFavouriteDrugQuery;

/// <summary>
/// Обработчик GetAllFavouriteDrugQuery
/// </summary>
public class GetAllFavouriteDrugQueryHandler : IRequestHandler<GetAllFavouriteDrugQuery, List<FavouriteDrug>>
{
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugReadRepository">Репозиторий чтения FavouriteDrugReadRepository.</param>
    public GetAllFavouriteDrugQueryHandler(
        IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех FavouriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список FavouriteDrug.</returns>
    public async Task<List<FavouriteDrug>> Handle(GetAllFavouriteDrugQuery request, CancellationToken cancellationToken)
    {
        return await _favouriteDrugReadRepository.GetAllAsync(cancellationToken);
    }
}