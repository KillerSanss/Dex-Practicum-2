using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IUserProfileRepositories;

/// <summary>
/// Репозиторий записи UserProfile
/// </summary>
public interface IUserProfileWriteRepository : IWriteRepository<UserProfile>
{
}