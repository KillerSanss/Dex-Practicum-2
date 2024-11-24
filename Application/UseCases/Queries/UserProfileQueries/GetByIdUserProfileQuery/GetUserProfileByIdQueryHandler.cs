using Application.Interfaces.Repositories.IUserProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.UserProfileQueries.GetByIdUserProfileQuery;

/// <summary>
/// Обработчик GetUserProfileByIdQuery
/// </summary>
public class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
{
    private readonly IUserProfileReadRepository _userProfileReadRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileReadRepository">Репозиторий чтения UserProfileReadRepository.</param>
    public GetUserProfileByIdQueryHandler(
        IUserProfileReadRepository userProfileReadRepository)
    {
        _userProfileReadRepository = userProfileReadRepository;
    }
    
    /// <summary>
    /// Обработка получения UserProfile по идентификатору
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>UserProfile.</returns>
    public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userProfileReadRepository.GetByIdAsync(request.Id, cancellationToken);
    }
}