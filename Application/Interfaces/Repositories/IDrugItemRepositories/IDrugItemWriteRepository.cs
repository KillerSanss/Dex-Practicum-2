using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugItemRepositories;

/// <summary>
/// Репозиторий записи DrugItem
/// </summary>
public interface IDrugItemWriteRepository : IWriteRepository<DrugItem>
{
}