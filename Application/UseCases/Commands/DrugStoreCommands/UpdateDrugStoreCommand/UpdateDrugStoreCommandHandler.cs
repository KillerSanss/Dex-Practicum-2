using Application.Interfaces.Repositories.IDrugStoreRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateDrugStoreCommand;

/// <summary>
/// Обработчик UpdateDrugStoreCommand
/// </summary>
public class UpdateDrugStoreCommandHandler : IRequestHandler<UpdateDrugStoreCommand, DrugStore>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий чтения DrugStoreWriteRepository.</param>
    public UpdateDrugStoreCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный DrugStore.</returns>
    public async Task<DrugStore> Handle(UpdateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = await _drugStoreWriteRepository.ReadRepository.GetByIdAsync(request.DrugStoreId, cancellationToken);
        drugStore.Update(
            request.Network,
            request.Number,
            request.Address,
            request.Phone);
        await _drugStoreWriteRepository.UpdateAsync(drugStore, cancellationToken);
        return drugStore;
    }
}