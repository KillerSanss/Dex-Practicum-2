using Application.Interfaces.Repositories.IDrugStoreRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.DrugStoreCommands.CreateDrugStoreCommand;

/// <summary>
/// Обработчик CreateDrugStoreCommand
/// </summary>
public class CreateDrugStoreCommandHandler : IRequestHandler<CreateDrugStoreCommand, DrugStore>
{
    private readonly IDrugStoreWriteRepository _drugStoreWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="drugStoreWriteRepository">Репозиторий чтения DrugStoreWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateDrugStoreCommandHandler(
        IDrugStoreWriteRepository drugStoreWriteRepository,
        IMapper mapper)
    {
        _drugStoreWriteRepository = drugStoreWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания DrugStore
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный DrugStore.</returns>
    public async Task<DrugStore> Handle(CreateDrugStoreCommand request, CancellationToken cancellationToken)
    {
        var drugStore = _mapper.Map<DrugStore>(request);
        await _drugStoreWriteRepository.AddAsync(drugStore, cancellationToken);
        return drugStore;
    }
}