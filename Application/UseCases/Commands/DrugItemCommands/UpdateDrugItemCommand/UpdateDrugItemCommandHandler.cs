using Application.Interfaces.Repositories.IDrugItemRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.UpdateDrugItemCommand;

/// <summary>
/// Обработчик UpdateDrugItemCommand
/// </summary>
public class UpdateDrugItemCommandHandler : IRequestHandler<UpdateDrugItemCommand, DrugItem>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий чтения DrugItemWriteRepository.</param>
    public UpdateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный DrugItem.</returns>
    public async Task<DrugItem> Handle(UpdateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = await _drugItemWriteRepository.ReadRepository.GetByIdAsync(request.DrugItemId, cancellationToken);
        drugItem.Update(
            request.DrugId,
            request.Drug,
            request.DrugStoreId,
            request.DrugStore,
            request.Price,
            request.Amount);
        await _drugItemWriteRepository.UpdateAsync(drugItem, cancellationToken);
        return drugItem;
    }
}