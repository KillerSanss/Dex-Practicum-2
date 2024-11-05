namespace Domain.Entities;

/// <summary>
/// Сущность страны
/// </summary>
public class Country : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Код страны
    /// </summary>
    public string Code { get; set; }
    
    /// <summary>
    /// Список лекарств
    /// </summary>
    public ICollection<Drug> Drugs { get; set; } = new List<Drug>();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название.</param>
    /// <param name="code">Код страны.</param>
    public Country(
        string name,
        string code)
    {
        Name = name;
        Code = code;
    }
}