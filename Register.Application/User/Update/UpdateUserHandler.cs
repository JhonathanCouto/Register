using MediatR;
using Register.Infrastructure;

namespace Register.Application;

public sealed class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler
    (
        IUserRepository userRepository,
        IUnitOfWork unitOfWork
    )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        if (user == null) return Result.Success();

        user.UpdateName(request.Name);

        user.UpdateEmail(request.Email);

        user.UpdateCpf(request.Cpf);

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}