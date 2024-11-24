using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.FavouriteDrugQueries.GetByIdFavouriteDrugQuery;

/// <summary>
/// Обработчик GetFavouriteDrugByIdQuery
/// </summary>
public class GetFavouriteDrugByIdQueryHandler : IRequestHandler<GetFavouriteDrugByIdQuery, FavouriteDrug>
{
    private readonly IFavouriteDrugReadRepository _favouriteDrugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugReadRepository">Репозиторий чтения FavouriteDrugReadRepository.</param>
    public GetFavouriteDrugByIdQueryHandler(
        IFavouriteDrugReadRepository favouriteDrugReadRepository)
    {
        _favouriteDrugReadRepository = favouriteDrugReadRepository;
    }
    
    /// <summary>
    /// Обработка получения FavouriteDrug по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>FavouriteDrug.</returns>
    public async Task<FavouriteDrug> Handle(GetFavouriteDrugByIdQuery request, CancellationToken cancellationToken)
    {
        return await _favouriteDrugReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}