namespace Infrastructure.Dal.Models;

/// <summary>
/// Класс настроек для базы данных
/// </summary>
public class DatabaseSettings
{
    /// <summary>
    /// Строка подключения
    /// </summary>
    public string ConnectionString { get; set; }
    
    /// <summary>
    /// Таймаут базы данных в секундах
    /// </summary>
    public int CommandTimeout { get; set; }
}