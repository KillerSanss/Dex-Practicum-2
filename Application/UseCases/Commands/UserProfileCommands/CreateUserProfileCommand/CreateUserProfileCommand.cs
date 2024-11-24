using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.CreateUserProfileCommand;

/// <summary>
/// Создание UserProfile
/// </summary>
/// <param name="ExternalId">Внешний идентификатор (телеграм).</param>
/// <param name="Email">Электронная почта.</param>
public record CreateUserProfileCommand(string ExternalId, Email Email) : IRequest<UserProfile>;