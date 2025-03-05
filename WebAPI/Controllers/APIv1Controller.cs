using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class APIv1Controller : ControllerBase
    {
    }
}