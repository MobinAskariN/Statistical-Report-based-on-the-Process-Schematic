namespace process.Models
{
    public class BasicInfo : Position
    {
        public int height { get; set; }
        public int width { get; set; }

    }

    public class Position
    {
        public int position_x { get; set; }
        public int position_y { get; set; }
    }
}
