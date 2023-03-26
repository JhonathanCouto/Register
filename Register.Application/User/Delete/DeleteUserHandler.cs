using FluentResults;
using MediatR;
using Register.Infrastructure;

namespace Register.Application;

public sealed class DeleteUserHandler : IRequestHandler<DeleteUserRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserHandler
    (
        IUserRepository userRepository, 
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
