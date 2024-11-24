using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries.GetAllDrugItemQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableDrugItemQuery
/// </summary>
public class GetAllQueryableDrugItemQueryHandler : IRequestHandler<GetAllQueryableDrugItemQuery, IQueryable<DrugItem>>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemReadRepository">Репозиторий чтения DrugItemReadRepository.</param>
    public GetAllQueryableDrugItemQueryHandler(
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query DrugItem.</returns>
    public async Task<IQueryable<DrugItem>> Handle(GetAllQueryableDrugItemQuery request, CancellationToken cancellationToken)
    {
        return await _drugItemReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}