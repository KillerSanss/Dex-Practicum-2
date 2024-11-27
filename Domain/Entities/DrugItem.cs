using Domain.DomainEvents;
using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Служебная таблица связи лекарства и магазина
/// </summary>
public class DrugItem : BaseEntity
{
    /// <summary>
    /// Идентификатор лекарства
    /// </summary>
    public Guid DrugId { get; set; }
    
    /// <summary>
    /// Навигационное поле для Drug
    /// </summary>
    public Drug Drug { get; set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid DrugStoreId { get; set; }
    
    /// <summary>
    /// Навигационное поле для DrugStore
    /// </summary>
    public DrugStore DrugStore { get; set; }
    
    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Кол-во
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStoreId">Идентификатор аптеки.</param>
    /// <param name="drugStore">Аптека.</param>
    /// <param name="price">Цена.</param>
    /// <param name="amount">Кол-во.</param>
    public DrugItem(
        Guid drugId,
        Drug drug,
        Guid drugStoreId,
        DrugStore drugStore,
        decimal price,
        double amount)
    {
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        Price = price;
        Amount = amount;

        Validate();
    }

    /// <summary>
    /// Метод обновления DrugItem
    /// </summary>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStoreId">Идентификатор аптеки.</param>
    /// <param name="drugStore">Аптека.</param>
    /// <param name="price">Цена.</param>
    /// <param name="amount">Кол-во.</param>
    public void Update(
        Guid drugId,
        Drug drug,
        Guid drugStoreId,
        DrugStore drugStore,
        decimal price,
        double amount)
    {
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        Price = price;
        Amount = amount;

        Validate();
    }

    /// <summary>
    /// Обновление кол-ва DrugItem
    /// </summary>
    /// <param name="amount">Новое кол-во.</param>
    public void UpdateDrugAmount(double amount)
    {
        Amount = amount;
        
        AddDomainEvent(new DrugItemUpdatedEvent(this.Id, amount));
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new DrugItemValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    public DrugItem()
    {
    }
}