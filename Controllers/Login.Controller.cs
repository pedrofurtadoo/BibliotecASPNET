
using Microsoft.AspNetCore.Mvc;

namespace Bibliotec_MVC.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}