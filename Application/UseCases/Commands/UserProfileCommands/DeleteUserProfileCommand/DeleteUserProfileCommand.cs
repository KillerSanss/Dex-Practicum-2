using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.DeleteUserProfileCommand;

/// <summary>
/// Удаление UserProfile
/// </summary>
/// <param name="UserProfileId">Идентификатор UserProfile.</param>
public record DeleteUserProfileCommand(Guid UserProfileId) : IRequest;