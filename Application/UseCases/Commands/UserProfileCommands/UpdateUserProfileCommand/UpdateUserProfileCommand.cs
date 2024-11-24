using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.UpdateUserProfileCommand;

/// <summary>
/// Обновление UserProfile
/// </summary>
/// <param name="UserProfileId">Идентификатор UserProfile.</param>
/// <param name="ExternalId">Внешний идентификатор (телеграм).</param>
/// <param name="Email">Электронная почта.</param>
public record UpdateUserProfileCommand(Guid UserProfileId, string ExternalId, Email Email) : IRequest<UserProfile>;