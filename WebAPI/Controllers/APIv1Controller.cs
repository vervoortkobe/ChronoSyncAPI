﻿using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class APIv1Controller : ControllerBase
    {
    }
}