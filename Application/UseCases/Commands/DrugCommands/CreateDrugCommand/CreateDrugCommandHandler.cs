using Application.Interfaces.Repositories.IDrugRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugCommands.CreateDrugCommand;

/// <summary>
/// Обработчик CreateDrugCommand
/// </summary>
public class CreateDrugCommandHandler : IRequestHandler<CreateDrugCommand, Drug>
{
    private readonly IDrugWriteRepository _drugWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugWriteRepository">Репозиторий записи DrugWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateDrugCommandHandler(
        IDrugWriteRepository drugWriteRepository,
        IMapper mapper)
    {
        _drugWriteRepository = drugWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания Drug
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный Drug.</returns>
    public async Task<Drug> Handle(CreateDrugCommand request, CancellationToken cancellationToken)
    {
        var drug = _mapper.Map<Drug>(request);
        await _drugWriteRepository.AddAsync(drug, cancellationToken);
        return drug;
    }
}