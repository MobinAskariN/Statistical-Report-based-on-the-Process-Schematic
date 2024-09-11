using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace process.Models
{
    [Table("vwelementposition")] // replace with actual table name for elements
    [Keyless]
    public class Element
    {
        public string ELEMENT_UID { get; set; }
        public string ElementType { get; set; }
        public int BOU_X { get; set; }
        public int BOU_Y { get; set; }
        public int BOU_WIDTH { get; set; }
        public int BOU_HEIGHT { get; set; }
        public string? EName { get; set; }
        public string? EType { get; set; }
        public string BOU_ELEMENT {  get; set; }
        [NotMapped]
        public Report? report { get; set; }
        [NotMapped]
        public (int, int, int) rgb { get; set; }
    }

    [Table("vwflowposition")] // replace with actual table name for flows
    [Keyless]
    public class Flow
    {
        public string ElementType { get; set; }
        public string FLO_STATE { get; set; }
        public string? FLO_NAME { get; set; }
        [NotMapped]
        public List<(int, int)> pairs = new List<(int, int)> ();
        [NotMapped]
        public (int, int) FLO_NAME_position { get; set; }


        public void set_pairs()
        {
            var coordinates = JsonConvert.DeserializeObject<List<Coordinate>>(FLO_STATE);
            List<(int x, int y)> result = new List<(int x, int y)>();
            foreach (var coord in coordinates)
            {
                pairs.Add((coord.x, coord.y));
            }
        }
        public (int, int) GetMiddlePointOfLongestLine(List<(int x, int y)> pairs)
        {
            double maxLength = 0;
            (int x, int y) middlePoint = (0, 0);

            // Loop through pairs of points to compute the lengths of the lines
            for (int i = 0; i < pairs.Count - 1; i++)
            {
                var p1 = pairs[i];
                var p2 = pairs[i + 1];

                // Calculate the length of the current line segment
                double length = 0;
                if (p1.x == p2.x) // Vertical line
                {
                    length = Math.Abs(p2.y - p1.y);
                }
                else if (p1.y == p2.y) // Horizontal line
                {
                    length = Math.Abs(p2.x - p1.x);
                }

                // Check if this is the longest line so far
                if (length > maxLength)
                {
                    maxLength = length;

                    // Calculate the middle point of the longest line
                    middlePoint = ((p1.x + p2.x) / 2, (p1.y + p2.y) / 2);
                }
            }

            return middlePoint;
        }

    }

    [Table("report")] // replace with actual table name for reports
    public class Report
    {
        [Key]
        public string UID { get; set; }
        public int m_T { get; set; }
        public int v_T { get; set; }
        public int m_D { get; set; }
        public int v_D { get; set; }
        public int m_W { get; set; }
        public int v_W { get; set; }
        public int Gty {  get; set; }
    }
    public class Person
    {
        public string name { get; set; }
        public string UID { get; set; }
        public int m_T { get; set; }
        public int v_T { get; set; }
        public int m_D { get; set; }
        public int v_D { get; set; }
        public int m_W { get; set; }
        public int v_W { get; set; }
        public int gty { get; set; }
        public Person(string name, string UID, int m_T, int v_T, int m_D, int v_D, int m_W, int v_W, int Gty)
        {
            this.name = name;
            this.UID = UID;
            this.m_T = m_T;
            this.v_T = v_T;
            this.m_D = m_D;
            this.v_D = v_D;
            this.m_W = m_W;
            this.v_W = v_W;
            this.gty = Gty;
        }
        public static List<Person> generate_fake_people()
        {
            List<Person> list = new List<Person>();
            Person p1 = new Person("ali", "1e21", 1, 1, 1, 1, 1, 1, 1);
            Person p2 = new Person("mamad", "1e21", 1, 1, 1, 1, 1, 1, 1);
            Person p3 = new Person("hesam", "1e21", 1, 1, 1, 1, 1, 1, 1);
            Person p4 = new Person("hasan", "1e21", 1, 1, 1, 1, 1, 1, 1);
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            return list;
        }
    }

}
