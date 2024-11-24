using Application.Interfaces.Repositories.IDrugItemRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugItemCommands.CreateDrugItemCommand;

/// <summary>
/// Обработчик CreateDrugItemCommand
/// </summary>
public class CreateDrugItemCommandHandler : IRequestHandler<CreateDrugItemCommand, DrugItem>
{
    private readonly IDrugItemWriteRepository _drugItemWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugItemWriteRepository">Репозиторий чтения DrugItemWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateDrugItemCommandHandler(
        IDrugItemWriteRepository drugItemWriteRepository,
        IMapper mapper)
    {
        _drugItemWriteRepository = drugItemWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания DrugItem
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный DrugItem.</returns>
    public async Task<DrugItem> Handle(CreateDrugItemCommand request, CancellationToken cancellationToken)
    {
        var drugItem = _mapper.Map<DrugItem>(request);
        await _drugItemWriteRepository.AddAsync(drugItem, cancellationToken);
        return drugItem;
    }
}