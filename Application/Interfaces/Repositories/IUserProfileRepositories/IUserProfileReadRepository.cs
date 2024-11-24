using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IUserProfileRepositories;

/// <summary>
/// Репозиторий чтения UserProfile
/// </summary>
public interface IUserProfileReadRepository : IReadRepository<UserProfile>
{
}