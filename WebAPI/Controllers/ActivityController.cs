using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
