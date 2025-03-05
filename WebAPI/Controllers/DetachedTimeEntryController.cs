using Application.CQRS.DetachedTimeEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class DetachedTimeEntryController(IMediator mediator) : APIv1Controller
{
    [HttpGet()]
    public async Task<IActionResult> GetAll([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(await mediator.Send(new GetAllQuery() { PageNr = pageNr, PageSize = pageSize }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await mediator.Send(new GetByIdQuery { Id = id }));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DetachedTimeEntryDTO o)
    {
        return Created("", await mediator.Send(new AddCommand() { DetachedTimeEntry = o }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] DetachedTimeEntryDTO o)
    {
        return Ok(await mediator.Send(new UpdateCommand() { DetachedTimeEntry = o }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mediator.Send(new DeleteCommand() { Id = id });
        return NoContent();
    }
}
