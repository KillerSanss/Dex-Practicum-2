using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IFavouriteDrugRepositories;

/// <summary>
/// Репозиторий чтения FavouriteDrug
/// </summary>
public interface IFavouriteDrugReadRepository : IReadRepository<FavouriteDrug>
{
}