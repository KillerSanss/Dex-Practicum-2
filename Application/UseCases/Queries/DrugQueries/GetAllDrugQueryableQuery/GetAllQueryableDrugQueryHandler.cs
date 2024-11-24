using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries.GetAllDrugQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableDrugQuery
/// </summary>
public class GetAllQueryableDrugQueryHandler : IRequestHandler<GetAllQueryableDrugQuery, IQueryable<Drug>>
{
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugReadRepository">Репозиторий чтения DrugReadRepository.</param>
    public GetAllQueryableDrugQueryHandler(
        IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query Drug.</returns>
    public async Task<IQueryable<Drug>> Handle(GetAllQueryableDrugQuery request, CancellationToken cancellationToken)
    {
        return await _drugReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}