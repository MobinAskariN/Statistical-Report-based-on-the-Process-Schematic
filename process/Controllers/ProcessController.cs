using Microsoft.AspNetCore.Mvc;
using process.Models;

namespace process.Controllers
{
    public class ProcessController : Controller
    {
        public IActionResult Index()
        {
            Shapes shapes = new Shapes();


            ViewBag.Shapes = shapes;
            return View();
        }
    }
}
