using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.ICountryRepositories;

/// <summary>
/// Репозиторий записи Country
/// </summary>
public interface ICountryWriteRepository : IWriteRepository<Country>
{
}