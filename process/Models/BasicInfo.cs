namespace process.Models
{
    public class BasicInfo : Position
    {
        public int height { get; set; }
        public int width { get; set; }
        public int radius { get; set; }
    }

    public class Position
    {
        public int position_x { get; set; }
        public int position_y { get; set; }
    }

    public class PageInfo
    {
        public int p_width { get; set; }
        public int p_height { get; set; }
    }
}
