﻿using Application.CQRS.TimeEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class TimeEntryController(IMediator mediator) : APIv1Controller
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
}
