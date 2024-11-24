using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugStoreQueries.GetByIdDrugStoreQuery;

/// <summary>
/// Обработчик GetDrugStoreByIdQuery
/// </summary>
public class GetDrugStoreByIdQueryHandler : IRequestHandler<GetDrugStoreByIdQuery, DrugStore>
{
    private readonly IDrugStoreReadRepository _drugStoreReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreReadRepository">Репозиторий чтения DrugStoreReadRepository.</param>
    public GetDrugStoreByIdQueryHandler(
        IDrugStoreReadRepository drugStoreReadRepository)
    {
        _drugStoreReadRepository = drugStoreReadRepository;
    }
    
    /// <summary>
    /// Обработка получения DrugStore по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>DrugStore.</returns>
    public async Task<DrugStore> Handle(GetDrugStoreByIdQuery request, CancellationToken cancellationToken)
    {
        return await _drugStoreReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}