﻿using FluentResults;
using MediatR;

namespace Register.Application;

public sealed class UpdateUserRequest : IRequest<Result>
{
    public UpdateUserRequest
    (
        long id, 
        string name, 
        string email, 
        string cpf,
        long addressId
    )
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
        AddressId = addressId;
    }

    public long Id { get; private set; }

    public string Name { get; private set; }

    public string Email { get; private set; }

    public string Cpf { get; private set; }

    public long AddressId { get; private set; }
}
