using Microsoft.AspNetCore.Mvc;

namespace crud_demo.Controllers;

public class WildcardController : Controller
{
    // GET
    public IActionResult Index(string? url)
    {
        return View();
    }
}