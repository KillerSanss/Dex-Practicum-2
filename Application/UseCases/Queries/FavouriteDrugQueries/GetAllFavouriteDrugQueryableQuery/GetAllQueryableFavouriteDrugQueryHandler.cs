using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetAllFavouriteDrugQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableFavouriteDrugQuery
/// </summary>
public class GetAllQueryableFavouriteDrugQueryHandler : IRequestHandler<GetAllQueryableFavouriteDrugQuery, IQueryable<FavouriteDrug>>
{
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugReadRepository">Репозиторий чтения FavouriteDrugReadRepository.</param>
    public GetAllQueryableFavouriteDrugQueryHandler(
        IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query FavouriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query FavouriteDrug.</returns>
    public async Task<IQueryable<FavouriteDrug>> Handle(GetAllQueryableFavouriteDrugQuery request, CancellationToken cancellationToken)
    {
        return await _favouriteDrugReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}