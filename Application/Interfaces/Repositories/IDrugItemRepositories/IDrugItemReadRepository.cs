using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugItemRepositories;

/// <summary>
/// Репозиторий чтения DrugItem
/// </summary>
public interface IDrugItemReadRepository : IReadRepository<DrugItem>
{
}