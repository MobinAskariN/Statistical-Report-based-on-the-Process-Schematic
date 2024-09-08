using Microsoft.AspNetCore.Mvc;
using process.Models;
using System.Drawing;
using static Azure.Core.HttpHeader;

namespace process.Controllers
{
    public class ProcessController : Controller
    {
        // necessary code, no idea what is its use
        private readonly DatabaseMethods _context;
        public ProcessController(DatabaseMethods context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            // getting all elements and flows from database
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
                }
            }

            // setting Task reports and their color
            int min_m_t = -1, max_m_t = -1;
            foreach(Element e in elements)
            {
                if(e.ElementType == "Task")
                {
                    Report? r = _context.getReport(e.ELEMENT_UID);
                    e.report = r;

                    if(min_m_t == -1)
                    {
                        min_m_t = r.m_T;
                        max_m_t = r.m_T;
                    }
                    else
                    {
                        min_m_t = Math.Min(min_m_t, r.m_T);
                        max_m_t = Math.Max(max_m_t, r.m_T);
                    }
                }
            }
            foreach(Element e in elements)
            {
                if (e.ElementType == "Task")
                {
                    double normalized = (double)(e.report.m_T - min_m_t) / (max_m_t - min_m_t);
                    int r = (int)(255.0 * normalized);
                    int g = 0; 
                    int b = (int)(255.0 * (1 - normalized));
                    e.rgb = (r, g, b);
                    Console.WriteLine(normalized);
                }
            }

            // setting all things we need in our page
            ViewBag.elements = elements;
            ViewBag.flows = flows;
            ViewBag.pageInfo = pageInfo;
            return View();
        }

        // important area!!!
        // here you should replace 'people' with actual people associated in 'reports'
        // there is a 'Person' class in TableModels.cs which I made a fake users with it
        public JsonResult GetPeople(string uid)
        {
            List<Person> people = Person.generate_fake_people();
            return Json(new { people = people, n_rows = people.Count });
        }

    }
}
