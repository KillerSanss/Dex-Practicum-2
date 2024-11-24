using Application.Interfaces.Repositories.IUserProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.UserProfileQueries.GetAllUserProfileQueryableQuery;

/// <summary>
/// Обработчик GetAllQueryableProfileQuery
/// </summary>
public class GetAllQueryableUserProfileQueryHandler : IRequestHandler<GetAllQueryableUserProfileQuery, IQueryable<UserProfile>>
{
    private readonly IUserProfileReadRepository _userProfileReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileReadRepository">Репозиторий чтения UserProfileReadRepository.</param>
    public GetAllQueryableUserProfileQueryHandler(
        IUserProfileReadRepository userProfileReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
    }
    
    /// <summary>
    /// Обработка получения всех Query UserProfile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список Query UserProfile.</returns>
    public async Task<IQueryable<UserProfile>> Handle(GetAllQueryableUserProfileQuery request, CancellationToken cancellationToken)
    {
        return await _userProfileReadRepository.GetQueryableAsync(request.QueryOptions, cancellationToken);
    }
}