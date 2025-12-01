using Microsoft.AspNetCore.Mvc;

namespace SqlInjectionLab.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}