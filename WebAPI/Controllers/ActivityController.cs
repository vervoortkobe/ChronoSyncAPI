using Application.CQRS.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : Controller
{
    private IMediator _mediator;
    public ActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllActivitiesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _mediator.Send(new GetActivityByIdQuery { Id = id }));
    }
}
