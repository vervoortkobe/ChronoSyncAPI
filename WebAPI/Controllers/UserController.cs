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

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _mediator.Send(new GetUserByIdQuery { Id = id } ));
    }
}
