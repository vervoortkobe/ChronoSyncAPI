using Application.CQRS.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("id/{userId}")]
    public async Task<IActionResult> GetModuleToSolve(string userId)
    {
        return Ok(await _mediator.Send(new GetUserByIdQuery { Id = userId } ));
    }
}
