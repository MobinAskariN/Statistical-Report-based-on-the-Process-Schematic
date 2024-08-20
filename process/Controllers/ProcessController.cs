using Microsoft.AspNetCore.Mvc;
using process.Models;

namespace process.Controllers
{
    public class ProcessController : Controller
    {
        public IActionResult Index()
        {
            Shapes shapes = new Shapes();
            PageInfo pageInfo = new PageInfo();

            pageInfo.p_height = 400;
            pageInfo.p_width = 1700;

            shapes.add_rectangle(new Rectangle(10, 10, 50, 50));
            shapes.add_rectangle(new Rectangle(10, 50, 50, 70));
            shapes.add_circle(new Circle(60, 90, 80));

            ViewBag.Shapes = shapes;
            ViewBag.PageInfo = pageInfo;
            return View();
        }
    }
}
