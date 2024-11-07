namespace Domain.Validation;

public static class ValidationMessages
{
    public const string NullError = "{PropertyName} не может быть null";
    public const string EmptyError = "{PropertyName} не может быть пустым";
    public const string MinimumLengthError = "{PropertyName} слишком короткий";
    public const string MaximumLengthError = "{PropertyName} слишком длинный";
    public const string NegativeOrZeroNumberError = "{PropertyName} не может быть отрицательным или ноль";
    public const string NegativeNumberError = "{PropertyName} не может быть отрицательным";
    public const string GreaterThenNumberError = "{PropertyName} слишком большое число";
    public const string OnlyLettersError = "{PropertyName} должен содержать только буквы";
    public const string StrictLengthError = "{PropertyName} должен быть содержать ровно 2 символа";
    public const string SpecialSymbolsError = "{PropertyName} не должен содержать специальных символов";
    public const string DecimalPlacesError = "{PropertyName} не должен содержать более 2х знаков после запятой";
    public const string OnlyNumbersError = "{PropertyName} должен содержать только цифры";
    public const string CountryCodeError = "Неверный код страны";
}