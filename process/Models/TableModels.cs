using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace process.Models
{
    [Table("vwelementposition")]
    [Keyless]
    public class Element
    {
        public string ElementType { get; set; }
        public int BOU_X { get; set; }
        public int BOU_Y { get; set; }
        public int BOU_WIDTH { get; set; }
        public int BOU_HEIGHT { get; set; }
        public string? EName { get; set; }
        public string? EType { get; set; }
    }

    [Table("vwflowposition")]
    [Keyless]
    public class Flow
    {
        public string ElementType { get; set; }
        public string FLO_STATE { get; set; }
        public string? FLO_NAME { get; set; }

    }
}
