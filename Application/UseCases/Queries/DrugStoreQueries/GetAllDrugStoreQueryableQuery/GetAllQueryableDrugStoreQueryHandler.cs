using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries.GetAllDrugStoreQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableDrugStoreQuery
/// </summary>
public class GetAllQueryableDrugStoreQueryHandler : IRequestHandler<GetAllQueryableDrugStoreQuery, IQueryable<DrugStore>>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий чтения DrugStoreReadRepository.</param>
    public GetAllQueryableDrugStoreQueryHandler(
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query DrugStore.</returns>
    public async Task<IQueryable<DrugStore>> Handle(GetAllQueryableDrugStoreQuery request, CancellationToken cancellationToken)
    {
        return await _drugStoreReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}