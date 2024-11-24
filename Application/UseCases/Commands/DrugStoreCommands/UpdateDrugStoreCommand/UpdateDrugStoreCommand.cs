using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.UpdateDrugStoreCommand;

/// <summary>
/// Обновление DrugStore
/// </summary>
/// <param name="DrugStoreId">Идентификатор DrugStore.</param>
/// <param name="Network">Аптечная сеть.</param>
/// <param name="Number">Номер аптеки.</param>
/// <param name="Address">Адрес.</param>
/// <param name="Phone">Номер телефона.</param>
public record UpdateDrugStoreCommand(Guid DrugStoreId, string Network, int Number, Address Address, string Phone) : IRequest<DrugStore>;