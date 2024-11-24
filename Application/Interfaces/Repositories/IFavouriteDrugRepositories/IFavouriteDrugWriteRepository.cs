using Application.Interfaces.Repositories.IBaseRepositories;
using Domain.Entities;

namespace Application.Interfaces.Repositories.IFavouriteDrugRepositories;

/// <summary>
/// Репозиторий записи FavouriteDrug
/// </summary>
public interface IFavouriteDrugWriteRepository : IWriteRepository<FavouriteDrug>
{
}