using MediatR;
using Register.Domain;
using Register.Infrastructure;

namespace Register.Application;

public sealed class GetUserHandler : IRequestHandler<GetUserRequest, Result<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Result<User>> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(request.Id);

        return Result<User>.Success(user);
    }
}