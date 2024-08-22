using Microsoft.EntityFrameworkCore;
using System;

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
            return v;
        }

    }
}