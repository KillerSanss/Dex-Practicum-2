using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.DrugQueries.GetAllDrugQuery;

/// <summary>
/// Обработчик GetAllDrugQuery
/// </summary>
public class GetAllDrugQueryHandler : IRequestHandler<GetAllDrugQuery, List<Drug>>
{
    private readonly IDrugReadRepository _drugReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugReadRepository">Репозиторий чтения DrugReadRepository.</param>
    public GetAllDrugQueryHandler(
        IDrugReadRepository drugReadRepository)
    {
        _drugReadRepository = drugReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Drug.</returns>
    public async Task<List<Drug>> Handle(GetAllDrugQuery request, CancellationToken cancellationToken)
    {
        return await _drugReadRepository.GetAllAsync(cancellationToken);
    }
}