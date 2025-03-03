using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeEntryController : Controller
{
    private IMediator _mediator;
    public TimeEntryController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    public async Task<IActionResult> GetEmailDomainById()
    {
        return Ok(await _mediator.Send(new GetEmailDomainByIdQuery()));
    }
}
