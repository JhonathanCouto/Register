using FluentResults;
using MediatR;

namespace Register.Application;

public sealed class DeleteUserRequest : IRequest<Result>
{
    public DeleteUserRequest(long id) => Id = id;

    public long Id { get; private set; }
}
