using MediatR;
using Register.Domain;
using Register.Infrastructure;

namespace Register.Application;

public sealed class ListUserHandler : IRequestHandler<ListUserRequest, Result<IEnumerable<User>>>
{
    private readonly IUserRepository _userRepository;

    public ListUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Result<IEnumerable<User>>> Handle(ListUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.ListAsync();

        return Result<IEnumerable<User>>.Success(users);
    }
}