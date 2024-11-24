using Application.Interfaces.Repositories.IUserProfileRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.UpdateUserProfileCommand;

/// <summary>
/// Обработчик UpdateUserProfileCommand
/// </summary>
public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UserProfile>
{
    private readonly IUserProfileWriteRepository _userProfileWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileWriteRepository">Репозиторий записи UserProfileWriteRepository.</param>
    public UpdateUserProfileCommandHandler(
        IUserProfileWriteRepository userProfileWriteRepository)
    {
        _userProfileWriteRepository = userProfileWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления UserProfile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный UserProfile.</returns>
    public async Task<UserProfile> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = await _userProfileWriteRepository.ReadRepository.GetByIdAsync(request.UserProfileId, cancellationToken);
        userProfile.Update(
            request.ExternalId,
            request.Email);
        await _userProfileWriteRepository.UpdateAsync(userProfile, cancellationToken);
        return userProfile;
    }
}