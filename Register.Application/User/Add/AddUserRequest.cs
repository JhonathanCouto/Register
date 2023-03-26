using FluentResults;
using MediatR;

namespace Register.Application;

public sealed class AddUserRequest : IRequest<Result<long>>
{
    public AddUserRequest(string name, string email, string cpf, long addressId)
    {
        Name = name;
        Email = email;
        Cpf = cpf;
        AddressId = addressId;
    }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Cpf { get; private set; }

    public long AddressId { get; private set; }
}
