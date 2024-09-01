using Microsoft.AspNetCore.Mvc;
using process.Models;
using static Azure.Core.HttpHeader;

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

            // setting page informations
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

            // edditing coordinates of elements based on their lanes
            List<Element> lanes = new List<Element>();
            foreach (Element e in elements)
                if(e.ElementType == "Lane")
                    lanes.Add(e);
            Element laneset = new Element();
            foreach (Element e in elements)
                if (e.ElementType == "Laneset")
                    laneset = e;
            foreach(Element e in lanes)
            {
                e.BOU_X += laneset.BOU_X;
                e.BOU_Y += laneset.BOU_Y;
            }
            foreach (Element e in elements)
            {
                if (e.ElementType == "Gateway")
                {
                    e.BOU_X += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_X+2;
                    e.BOU_Y += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_Y+2;
                }
                else if (e.ElementType == "Event")
                {
                    e.BOU_X += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_X+2;
                    e.BOU_Y += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_Y+2;
                }
                else if (e.ElementType == "Task")
                {
                    e.BOU_X += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_X+2;
                    e.BOU_Y += lanes.FirstOrDefault(lane => lane.ELEMENT_UID == e.BOU_ELEMENT).BOU_Y+2;
                    Report? r = _context.getReport(e.ELEMENT_UID);
                    e.report = r;
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