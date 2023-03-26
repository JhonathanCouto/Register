using FluentResults;
using MediatR;
using Register.Domain;
using Register.Infrastructure;

namespace Register.Application;

public sealed class AddUserHandler : IRequestHandler<AddUserRequest, Result<long>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserHandler
    (
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<long>> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        if (await _userRepository.EmailExistsAsync(request.Email)) return Result.Fail<long>("Email already exists");

        var user = new User(request.Name, request.Email, request.Cpf, request.AddressId);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Ok(user.Id);
    }
}
