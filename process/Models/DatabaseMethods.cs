using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using static System.Collections.Specialized.BitVector32;

namespace process.Models
{
    public class DatabaseMethods
    {
        private readonly ApplicationDbContext _context;

        public DatabaseMethods(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Element> getElements()
        {
            List<Element> v = _context.Element.ToList();
            return v;
        }
        public List<Flow> getFlows()
        {
            List<Flow> v = _context.Flow.ToList();
            foreach (Flow f in v)
                f.set_pairs();
            return v;
        }
        public Report? getReport(String UID)
        {
            Report? report = _context.Report
                   .FirstOrDefault(s => s.UID == UID);
            return report;
        }
    }

}