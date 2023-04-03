using MediatR;
using Register.Domain;

namespace Register.Application;

public sealed class GetUserRequest : IRequest<Result<User>>
{
    public long Id { get; private set; }

    public GetUserRequest(long id) => Id = id;
}