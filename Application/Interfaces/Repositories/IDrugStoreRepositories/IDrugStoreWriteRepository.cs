using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugStoreRepositories;

/// <summary>
/// Репозиторий записи DrugStore
/// </summary>
public interface IDrugStoreWriteRepository : IWriteRepository<DrugStore>
{
}