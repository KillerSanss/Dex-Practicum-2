using Application.Interfaces.Repositories.ICountryRepositories;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.UpdateCountryCommand;

/// <summary>
/// Обработчик UpdateCountryCommand
/// </summary>
public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Country>
{
    private readonly ICountryWriteRepository _countryWriteRepository;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий записи CountryWriteRepository.</param>
    public UpdateCountryCommandHandler(
        ICountryWriteRepository countryWriteRepository)
    {
        _countryWriteRepository = countryWriteRepository;
    }
    
    /// <summary>
    /// Обработка обновления Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный Country.</returns>
    public async Task<Country> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await _countryWriteRepository.ReadRepository.GetByIdAsync(request.CountryId, cancellationToken);
        country.Update(
            request.Name,
            request.Code);
        await _countryWriteRepository.UpdateAsync(country, cancellationToken);
        return country;
    }
}