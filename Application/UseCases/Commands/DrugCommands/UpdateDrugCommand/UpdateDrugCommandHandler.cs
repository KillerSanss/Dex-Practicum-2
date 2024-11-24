using Application.Interfaces.Repositories.IDrugRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.UpdateDrugCommand;

/// <summary>
/// Обработчик UpdateDrugCommand
/// </summary>
public class UpdateDrugCommandHandler : IRequestHandler<UpdateDrugCommand, Drug>
{
    private readonly IDrugWriteRepository _drugWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи DrugWriteRepository.</param>
    public UpdateDrugCommandHandler(
        IDrugWriteRepository drugWriteRepository)
    {
        _drugWriteRepository = drugWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Drug.</returns>
    public async Task<Drug> Handle(UpdateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = await _drugWriteRepository.ReadRepository.GetByIdAsync(request.DrugId, cancellationToken);
        drug.Update(
            request.Name,
            request.Manufacturer,
            request.CountryCodeId,
            request.Country);
        await _drugWriteRepository.UpdateAsync(drug, cancellationToken);
        return drug;
    }
}