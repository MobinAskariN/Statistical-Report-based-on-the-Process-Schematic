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

        public List<vwelementposition> getVwelements()
        {
            List<vwelementposition> v = _context.vwelementposition.ToList();
            return v;
        }
        public List<vwflowposition> getVwflow()
        {
            List<vwflowposition> v = _context.vwflowposition.ToList();
            return v;
        }

    }
}