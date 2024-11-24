using Application.Interfaces.Repositories.IUserProfileRepositories;
using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.DeleteUserProfileCommand;

/// <summary>
/// Обработчик DeleteUserProfileCommand
/// </summary>
public class DeleteUserProfileCommandHandler : IRequestHandler<DeleteUserProfileCommand>
{
    private readonly IUserProfileWriteRepository _userProfileWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileWriteRepository">Репозиторий записи UserProfileWriteRepository.</param>
    public DeleteUserProfileCommandHandler(
        IUserProfileWriteRepository userProfileWriteRepository)
    {
        _userProfileWriteRepository = userProfileWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления UserProfile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
    {
        await _userProfileWriteRepository.DeleteAsync(request.UserProfileId, cancellationToken);
    }
}