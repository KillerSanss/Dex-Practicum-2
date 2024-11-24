using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugItemQueries.GetByIdDrugItemQuery;

/// <summary>
/// Обработчик GetDrugItemByIdQuery
/// </summary>
public class GetDrugItemByIdQueryHandler : IRequestHandler<GetDrugItemByIdQuery, DrugItem>
{
    private readonly IDrugItemReadRepository _drugItemReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemReadRepository">Репозиторий чтения DrugItemReadRepository.</param>
    public GetDrugItemByIdQueryHandler(
        IDrugItemReadRepository drugItemReadRepository)
    {
        _drugItemReadRepository = drugItemReadRepository;
    }
    
    /// <summary>
    /// Обработка получения DrugItem по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>DrugItem.</returns>
    public async Task<DrugItem> Handle(GetDrugItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _drugItemReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}