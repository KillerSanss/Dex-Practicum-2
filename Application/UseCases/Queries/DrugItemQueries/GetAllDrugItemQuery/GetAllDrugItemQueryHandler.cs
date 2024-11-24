using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries.GetAllDrugItemQuery;

/// <summary>
/// Обработчик GetAllDrugItemQuery
/// </summary>
public class GetAllDrugItemQueryHandler : IRequestHandler<GetAllDrugItemQuery, List<DrugItem>>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemReadRepository">Репозиторий чтения DrugItemReadRepository.</param>
    public GetAllDrugItemQueryHandler(
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список DrugItem.</returns>
    public async Task<List<DrugItem>> Handle(GetAllDrugItemQuery request, CancellationToken cancellationToken)
    {
        return await _drugItemReadRepository.GetAllAsync(cancellationToken);
    }
}