using Application.CQRS.AdminActivities;
using Application.CQRS.DetachedTimeEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AdminActivityController(IMediator mediator) : APIv1Controller
{
    [HttpGet()]
    public async Task<IActionResult> GetAll([FromQuery] int pageNr = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(await mediator.Send(new Application.CQRS.AdminActivities.GetAllQuery() { PageNr = pageNr, PageSize = pageSize }));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        return Ok(await mediator.Send(new Application.CQRS.AdminActivities.GetByIdQuery { Id = id }));
    }

    [HttpGet("{activityId}/timeentries")]
    public async Task<IActionResult> GetTimeEntries(string activityId)
    {
        return Ok(await mediator.Send(new GetDetachedTimeEntriesByActivityIdQuery() { ActivityId = activityId }));
    }

    [HttpPost("{activityId}/timeentries")]
    public async Task<IActionResult> CreateTimeEntry(string activityId, [FromBody] DetachedTimeEntryDTO o)
    {
        return Created("", await mediator.Send(new AddCommand() { ActivityId = activityId, DetachedTimeEntry = o }));
    }

    [HttpGet("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> GetTimeEntry(string activityId, string timeEntryId)
    {
        return Ok(await mediator.Send(new GetDetachedTimeEntryByActivityIdQuery { ActivityId = activityId, TimeEntryId = timeEntryId }));
    }

    [HttpPut("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> UpdateTimeEntry(string activityId, string timeEntryId, [FromBody] DetachedTimeEntryDTO o)
    {
        return Ok(await mediator.Send(new UpdateCommand() { ActivityId = activityId, TimeEntryId = timeEntryId, DetachedTimeEntry = o }));
    }

    [HttpDelete("{activityId}/timeentries/{timeEntryId}")]
    public async Task<IActionResult> DeleteTimeEntry(string activityId, string timeEntryId)
    {
        await mediator.Send(new DeleteCommand() { ActivityId = activityId, TimeEntryId = timeEntryId });
        return NoContent();
    }
}
