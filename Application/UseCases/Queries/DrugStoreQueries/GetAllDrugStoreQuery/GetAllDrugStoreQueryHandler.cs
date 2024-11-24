using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries.GetAllDrugStoreQuery;

/// <summary>
/// Обработчик GetAllDrugStoreQuery
/// </summary>
public class GetAllDrugStoreQueryHandler : IRequestHandler<GetAllDrugStoreQuery, List<DrugStore>>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий чтения DrugStoreReadRepository.</param>
    public GetAllDrugStoreQueryHandler(
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список DrugStore.</returns>
    public async Task<List<DrugStore>> Handle(GetAllDrugStoreQuery request, CancellationToken cancellationToken)
    {
        return await _drugStoreReadRepository.GetAllAsync(cancellationToken);
    }
}