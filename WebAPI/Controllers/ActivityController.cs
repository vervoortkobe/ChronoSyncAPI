using Application.CQRS.Activities;
using Application.CQRS.TimeEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class ActivityController(IMediator mediator) : APIv1Controller
{
    [HttpGet()]
    public async Task<IActionResult> GetAll([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(await mediator.Send(new Application.CQRS.Activities.GetAllQuery() { PageNr = pageNr, PageSize = pageSize }));
    }

    [HttpGet("{activityId}")]
    public async Task<IActionResult> GetById(string activityId)
    {
        return Ok(await mediator.Send(new Application.CQRS.Activities.GetByIdQuery { Id = activityId }));
    }

    [HttpGet("{activityId}/timeentries")]
    public async Task<IActionResult> GetTimeEntries(string activityId)
    {
        return Ok(await mediator.Send(new GetTimeEntriesByActivityIdQuery() { ActivityId = activityId }));
    }

    [HttpPost("{activityId}/timeentries")]
    public async Task<IActionResult> CreateTimeEntry(string activityId, [FromBody] TimeEntryDTO o)
    {
        return Created("", await mediator.Send(new AddCommand() { ActivityId = activityId, TimeEntry = o }));
    }

    [HttpGet("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> GetTimeEntry(string activityId, string timeEntryId)
    {
        return Ok(await mediator.Send(new GetTimeEntryByActivityIdQuery { ActivityId = activityId, TimeEntryId = timeEntryId }));
    }

    [HttpPut("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> UpdateTimeEntry(string activityId, string timeEntryId, [FromBody] TimeEntryDTO o)
    {
        return Ok(await mediator.Send(new UpdateCommand() { ActivityId = activityId, TimeEntryId = timeEntryId, TimeEntry = o }));
    }

    [HttpDelete("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> DeleteTimeEntry(string activityId, string timeEntryId)
    {
        await mediator.Send(new DeleteCommand() { ActivityId = activityId, TimeEntryId = timeEntryId });
        return NoContent();
    }
}
