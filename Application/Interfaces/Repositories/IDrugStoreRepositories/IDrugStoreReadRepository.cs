using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugStoreRepositories;

/// <summary>
/// Репозиторий чтения DrugStore
/// </summary>
public interface IDrugStoreReadRepository : IReadRepository<DrugStore>
{
}