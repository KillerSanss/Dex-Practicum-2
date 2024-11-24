using System.Text.RegularExpressions;

namespace Domain.Validation;

public static class RegexPatterns
{ 
    /// <summary>
    /// Только буквы
    /// </summary>
    public static readonly Regex LettersPattern = new ("\\p{L}'?$");
    
    /// <summary>
    /// Без спец. символов
    /// </summary>
    public static readonly Regex NoSpecialSymbolsPattern = new ("^[a-zA-Zа-яА-Я0-9 ]*$");
    
    /// <summary>
    /// Только цифры
    /// </summary>
    public static readonly Regex OnlyNumbersPattern = new (@"^\d$");
    
    /// <summary>
    /// Электронная почта
    /// </summary>
    public static readonly Regex EmailPattern = new (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");
}