using FluentResults;
using MediatR;
using Register.Domain;

namespace Register.Application;

public sealed class ListUserRequest : IRequest<Result<IEnumerable<User>>>
{
}
