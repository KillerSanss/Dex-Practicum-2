using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IDrugRepositories;

/// <summary>
/// Репозиторий чтения Drug
/// </summary>
public interface IDrugReadRepository : IReadRepository<Drug>
{
}