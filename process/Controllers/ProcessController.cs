using Microsoft.AspNetCore.Mvc;
using process.Models;

namespace process.Controllers
{
    public class ProcessController : Controller
    {
        private readonly DatabaseMethods _context;
        public ProcessController(DatabaseMethods context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Element> elements = _context.getElements();
            List<Flow> flows = _context.getFlows();

            PageInfo pageInfo = new PageInfo();
            foreach (Element element in elements)
            { 
                if(element.ElementType == "Laneset")
                {
                    pageInfo.p_height = element.BOU_HEIGHT;
                    pageInfo.p_width = element.BOU_WIDTH;
                    pageInfo.p_name = element.EName;
                }
            }


            ViewBag.elements = elements;
            ViewBag.flows = flows;
            ViewBag.pageInfo = pageInfo;
            return View();
        }
    }
}


/*
Shapes shapes = new Shapes();
PageInfo pageInfo = new PageInfo();

pageInfo.p_height = 400;
pageInfo.p_width = 1700;

shapes.add_rectangle(new Rectangle(10, 10, 50, 50));
shapes.add_rectangle(new Rectangle(10, 50, 50, 70));
shapes.add_circle(new Circle(60, 90, 80));

ViewBag.Shapes = shapes;
ViewBag.PageInfo = pageInfo;
*/