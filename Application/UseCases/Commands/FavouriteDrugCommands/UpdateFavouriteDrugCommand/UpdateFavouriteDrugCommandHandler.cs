using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavouriteDrugCommands.UpdateFavouriteDrugCommand;

/// <summary>
/// Обработчик UpdateFavouriteDrugCommand
/// </summary>
public class UpdateFavouriteDrugCommandHandler : IRequestHandler<UpdateFavouriteDrugCommand, FavouriteDrug>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugWriteRepository">Репозиторий чтения FavouriteDrugWriteRepository.</param>
    public UpdateFavouriteDrugCommandHandler(
        IFavouriteDrugWriteRepository favouriteDrugWriteRepository)
    {
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления FavouriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный FavouriteDrug.</returns>
    public async Task<FavouriteDrug> Handle(UpdateFavouriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favouriteDrug = await _favouriteDrugWriteRepository.ReadRepository.GetByIdAsync(request.FavouriteDrugId, cancellationToken);
        favouriteDrug.Update(
            request.ProfileId,
            request.UserProfile,
            request.DrugId,
            request.Drug,
            request.DrugStoreId,
            request.DrugStore);
        await _favouriteDrugWriteRepository.UpdateAsync(favouriteDrug, cancellationToken);
        return favouriteDrug;
    }
}