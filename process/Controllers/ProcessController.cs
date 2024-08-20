using Microsoft.AspNetCore.Mvc;

namespace process.Controllers
{
    public class ProcessController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
