using MediatR;

namespace Register.Application;

public sealed class AddUserRequest : IRequest<Result<long>>
{
    public AddUserRequest
    (
        string name,
        string email,
        string cpf
    )
    {
        Name = name;
        Email = email;
        Cpf = cpf;
    }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Cpf { get; private set; }

}