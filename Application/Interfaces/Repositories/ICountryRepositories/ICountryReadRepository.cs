using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.ICountryRepositories;

/// <summary>
/// Репозиторий чтения Country
/// </summary>
public interface ICountryReadRepository : IReadRepository<Country>
{
}
