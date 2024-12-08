using System.Xml.XPath;

namespace Infrastructure.Dal.Configurations;

/// <summary>
/// Класс получения аннотации
/// </summary>
public static class GetPropertyAnnotation
{
    /// <summary>
    /// Извлекает комментарий из XML-документации.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    /// <param name="propertyName">Имя свойства.</param>
    /// <returns>Текст комментария.</returns>
    public static string GetPropertyComment<T>(string propertyName)
    {
        var domainAssembly = typeof(T).Assembly;
        var domainAssemblyPath = domainAssembly.Location;
        var xmlPath = Path.ChangeExtension(domainAssemblyPath, ".xml");

        if (!File.Exists(xmlPath))
            return null;

        var xml = new XPathDocument(xmlPath);
        var navigator = xml.CreateNavigator();
        var query = $"/doc/members/member[@name='P:{typeof(T).FullName}.{propertyName}']/summary";
        var node = navigator.SelectSingleNode(query);
        return node?.Value.Trim();
    }
}