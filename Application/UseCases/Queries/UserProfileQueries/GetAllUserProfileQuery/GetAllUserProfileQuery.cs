using Domain.Entities;
using MediatR;

namespace Application.UseCases.Queries.UserProfileQueries.GetAllUserProfileQuery;

/// <summary>
/// Получение всех UserProfile
/// </summary>
public record GetAllUserProfileQuery : IRequest<List<UserProfile>>;