using Application.Interfaces.Repositories.IUserProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.UserProfileQueries.GetAllUserProfileQuery;

/// <summary>
/// Обработчик GetAllProfileQuery
/// </summary>
public class GetAllUserProfileQueryHandler : IRequestHandler<GetAllUserProfileQuery, List<UserProfile>>
{
    private readonly IUserProfileReadRepository _userProfileReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileReadRepository">Репозиторий чтения UserProfileReadRepository.</param>
    public GetAllUserProfileQueryHandler(
        IUserProfileReadRepository userProfileReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех UserProfile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список UserProfile.</returns>
    public async Task<List<UserProfile>> Handle(GetAllUserProfileQuery request, CancellationToken cancellationToken)
    {
        return await _userProfileReadRepository.GetAllAsync(cancellationToken);
    }
}