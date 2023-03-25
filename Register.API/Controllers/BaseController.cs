using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Register.API;

[ApiController]
public abstract class BaseController : ControllerBase
{
    protected IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();   
}
