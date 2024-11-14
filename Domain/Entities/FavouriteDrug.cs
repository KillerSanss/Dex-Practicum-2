#nullable enable
using Domain.Validation.Validators;
using FluentValidation;

namespace Domain.Entities;

/// <summary>
/// Сущность любимого лекарства
/// </summary>
public class FavouriteDrug : BaseEntity
{
    /// <summary>
    /// Идентификатор профиля
    /// </summary>
    public Guid ProfileId { get; set; }
    
    /// <summary>
    /// Профиль
    /// </summary>
    public Profile Profile { get; set; }
    
    /// <summary>
    /// Идентификатор лекарства
    /// </summary>
    public Guid DrugId { get; set; }
    
    /// <summary>
    /// Лекарство
    /// </summary>
    public Drug Drug { get; set; }
    
    /// <summary>
    /// Идентификатор аптеки
    /// </summary>
    public Guid? DrugStoreId { get; set; }
    
    /// <summary>
    /// Аптека
    /// </summary>
    public DrugStore? DrugStore { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="profileId">Идентификатор профиля.</param>
    /// <param name="profile">Профиль.</param>
    /// <param name="drugId">Идентификатор лекарства.</param>
    /// <param name="drug">Лекарство.</param>
    /// <param name="drugStoreId">Идентификатор аптеки.</param>
    /// <param name="drugStore">Аптека.</param>
    public FavouriteDrug(
        Guid profileId,
        Profile profile,
        Guid drugId,
        Drug drug,
        Guid drugStoreId,
        DrugStore drugStore)
    {
        ProfileId = profileId;
        Profile = profile;
        DrugId = drugId;
        Drug = drug;
        DrugStoreId = drugStoreId;
        DrugStore = drugStore;
        
        Validate();
    }
    
    private void Validate()
    {
        var validator = new FavouriteDrugValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = string.Join(" || ", result.Errors.Select(x => x.ErrorMessage));
            throw new ValidationException(errors);
        }
    }
}