using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public static List<(int x, int y)> ExtractPairs(string jsonString)
        {
            var coordinates = JsonConvert.DeserializeObject<List<Coordinate>>(jsonString);
            List<(int x, int y)> result = new List<(int x, int y)>();

            foreach (var coord in coordinates)
            {
                result.Add((coord.x, coord.y));
            }

            return result;
        }

    }
    class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }
    }

}