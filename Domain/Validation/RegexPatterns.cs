using System.Text.RegularExpressions;

namespace Domain.Validation;

public static class RegexPatterns
{ 
    /// <summary>
    /// Строки (только буквы)
    /// </summary>
    public static readonly Regex LettersPattern = new ("\\p{L}'?$");
    public static readonly Regex NoSpecialSymbolsPattern = new ("^[a-zA-Zа-яА-Я0-9 ]*$");
    public static readonly Regex OnlyNumbersPattern = new (@"^\d$");
}