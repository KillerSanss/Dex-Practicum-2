using Application.Interfaces.Repositories.ICountryRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.CountryCommands.CreateCountryCommand;

/// <summary>
/// Обработчик CreateCountryCommand
/// </summary>
public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Country>
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="countryWriteRepository">Репозиторий записи CountryWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateCountryCommandHandler(
        ICountryWriteRepository countryWriteRepository,
        IMapper mapper)
    {
        _countryWriteRepository = countryWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания Country
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Country.</returns>
    public async Task<Country> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = _mapper.Map<Country>(request);
        await _countryWriteRepository.AddAsync(country, cancellationToken);
        return country;
    }
}