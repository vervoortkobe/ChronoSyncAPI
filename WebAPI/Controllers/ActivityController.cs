using Application.CQRS.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : Controller
{
    private IMediator mediator;
    public ActivityController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await mediator.Send(new GetAllQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await mediator.Send(new GetByIdQuery { Id = id }));
    }
}
