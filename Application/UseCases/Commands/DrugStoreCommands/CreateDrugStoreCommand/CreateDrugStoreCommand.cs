using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.CreateDrugStoreCommand;

/// <summary>
/// Создание DrugStore
/// </summary>
/// <param name="Network">Аптечная сеть.</param>
/// <param name="Number">Номер аптеки.</param>
/// <param name="Address">Адрес.</param>
/// <param name="Phone">Номер телефона.</param>
public record CreateDrugStoreCommand(string Network, int Number, Address Address, string Phone) : IRequest<DrugStore>;