using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using MediatR;

namespace Application.UseCases.Commands.FavouriteDrugCommands.DeleteFavouriteDrugCommand;

/// <summary>
/// Обработчик DeleteFavouriteDrugCommand
/// </summary>
public class DeleteFavouriteDrugCommandHandler : IRequestHandler<DeleteFavouriteDrugCommand>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugWriteRepository">Репозиторий чтения FavouriteDrugWriteRepository.</param>
    public DeleteFavouriteDrugCommandHandler(
        IFavouriteDrugWriteRepository favouriteDrugWriteRepository)
    {
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
    }
    
    /// <summary>
    /// Обработка удаления FavouriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task Handle(DeleteFavouriteDrugCommand request, CancellationToken cancellationToken)
    {
        await _favouriteDrugWriteRepository.DeleteAsync(request.FavouriteDrugId, cancellationToken);
    }
}