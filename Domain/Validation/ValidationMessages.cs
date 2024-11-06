namespace Domain.Validation;

public static class ValidationMessages
{
    public const string NullError = "{PropertyName} не может быть null";
    public const string EmptyError = "{PropertyName} не может быть пустым";
    public const string MinimumLengthError = "{PropertyName} должен быть длинее 2х символов";
    public const string MaximumLengthError = "{PropertyName} должен быть не длинее 20ти символов";
    public const string NegativeOrZeroNumberError = "{PropertyName} не может быть отрицательным или ноль";
}