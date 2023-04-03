using FluentValidation;

namespace Register.Application;

public sealed class AddUserRequestValidator : AbstractValidator<AddUserRequest>
{
    public AddUserRequestValidator()
    {
        RuleFor(request => request.Name).Name();
        RuleFor(request => request.Email).Email();
        RuleFor(request => request.Cpf).Cpf();
    }
}