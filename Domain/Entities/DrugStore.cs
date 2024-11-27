using Domain.Validation.Validators;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность аптеки
/// </summary>
public class DrugStore : BaseEntity
{
    /// <summary>
    /// Аптечная сеть
    /// </summary>
    public string DrugNetwork { get; set; }
    
    /// <summary>
    /// Номер аптеки в сети
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Адрес
    /// </summary>
    public Address Address { get; set; }
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// Список связей DrugItem
    /// </summary>
    public ICollection<DrugItem> DrugItems { get; set; } = new List<DrugItem>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugNetwork">Аптечная сеть.</param>
    /// <param name="number">Номер аптеки в сети.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="phone">Номер телефона.</param>
    public DrugStore(
        string drugNetwork,
        int number,
        Address address,
        string phone)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        Phone = phone;
        
        Validate();
    }
    
    /// <summary>
    /// Метод обновления DrugStore
    /// </summary>
    /// <param name="drugNetwork">Аптечная сеть.</param>
    /// <param name="number">Номер аптеки в сети.</param>
    /// <param name="address">Адрес.</param>
    /// <param name="phone">Номер телефона.</param>
    public void Update(
        string drugNetwork,
        int number,
        Address address,
        string phone)
    {
        DrugNetwork = drugNetwork;
        Number = number;
        Address = address;
        Phone = phone;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new DrugStoreValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
    
    public DrugStore()
    {
    }
}