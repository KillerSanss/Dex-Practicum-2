using Application.Interfaces.Repositories.IUserProfileRepositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Commands.UserProfileCommands.CreateUserProfileCommand;

/// <summary>
/// Обработчик CreateUserProfileCommand
/// </summary>
public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, UserProfile>
{
    private readonly IUserProfileWriteRepository _userProfileWriteRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userProfileWriteRepository">Репозиторий записи UserProfileWriteRepository.</param>
    /// <param name="mapper">Автомаппер.</param>
    public CreateUserProfileCommandHandler(
        IUserProfileWriteRepository userProfileWriteRepository,
        IMapper mapper)
    {
        _userProfileWriteRepository = userProfileWriteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// Обработка создания UserProfile
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный UserProfile.</returns>
    public async Task<UserProfile> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
    {
        var userProfile = _mapper.Map<UserProfile>(request);
        await _userProfileWriteRepository.AddAsync(userProfile, cancellationToken);
        return userProfile;
    }
}