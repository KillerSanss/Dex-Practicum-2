using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;

/// <summary>
/// Создание DrugItem
/// </summary>
/// <param name="DrugId">Идентификатор Drug.</param>
/// <param name="Drug">Drug.</param>
/// <param name="DrugStoreId">Идентификатор DrugStore</param>
/// <param name="DrugStore">DrugStore.</param>
/// <param name="Price">Цена.</param>
/// <param name="Amount">Кол-во.</param>
public record CreateDrugItemCommand(Guid DrugId, Drug Drug, Guid DrugStoreId, DrugStore DrugStore, decimal Price, double Amount) : IRequest<DrugItem>;