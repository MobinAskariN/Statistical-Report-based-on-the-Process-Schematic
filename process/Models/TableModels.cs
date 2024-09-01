using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace process.Models
{
    [Table("vwelementposition")]
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
    }

    [Table("vwflowposition")]
    [Keyless]
    public class Flow
    {
        public string ElementType { get; set; }
        public string FLO_STATE { get; set; }
        public string? FLO_NAME { get; set; }
        [NotMapped]
        public List<(int, int)> pairs = new List<(int, int)> ();
        public void set_pairs()
        {
            var coordinates = JsonConvert.DeserializeObject<List<Coordinate>>(FLO_STATE);
            List<(int x, int y)> result = new List<(int x, int y)>();
            foreach (var coord in coordinates)
            {
                pairs.Add((coord.x, coord.y));
            }
        }
    }

    [Table("report")]
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
    public class people
    {

    }
    class Coordinate// this is not a table
    {
        public int x { get; set; }
        public int y { get; set; }
    }

}
