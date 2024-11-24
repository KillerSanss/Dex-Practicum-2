using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugRepositories;

/// <summary>
/// Репозиторий записи Drug
/// </summary>
public interface IDrugWriteRepository : IWriteRepository<Drug>
{
}