using Application.CQRS.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeEntryController : Controller
{
    private IMediator _mediator;
    public TimeEntryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllTimeEntriesQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await _mediator.Send(new GetTimeEntryByIdQuery { Id = id }));
    }
}
