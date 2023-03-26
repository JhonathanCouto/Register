using FluentResults;
using MediatR;
using Register.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user == null) return Result.Fail("Id can't be null");

        user.UpdateName(request.Name);

        user.UpdateEmail(request.Email);

        user.UpdateCpf(request.Cpf);    

        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Ok();
    }
}
