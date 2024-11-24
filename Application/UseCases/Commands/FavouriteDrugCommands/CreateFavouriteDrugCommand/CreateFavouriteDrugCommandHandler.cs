using Application.Interfaces.Repositories.IFavouriteDrugRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.FavouriteDrugCommands.CreateFavouriteDrugCommand;

/// <summary>
/// Обработчик CreateFavouriteDrugCommand
/// </summary>
public class CreateFavouriteDrugCommandHandler : IRequestHandler<CreateFavouriteDrugCommand, FavouriteDrug>
{
    private readonly IFavouriteDrugWriteRepository _favouriteDrugWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="favouriteDrugWriteRepository">Репозиторий чтения FavouriteDrugWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateFavouriteDrugCommandHandler(
        IFavouriteDrugWriteRepository favouriteDrugWriteRepository,
        IMapper mapper)
    {
        _favouriteDrugWriteRepository = favouriteDrugWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания FavouriteDrug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный FavouriteDrug.</returns>
    public async Task<FavouriteDrug> Handle(CreateFavouriteDrugCommand request, CancellationToken cancellationToken)
    {
        var favouriteDrug = _mapper.Map<FavouriteDrug>(request);
        await _favouriteDrugWriteRepository.AddAsync(favouriteDrug, cancellationToken);
        return favouriteDrug;
    }
}