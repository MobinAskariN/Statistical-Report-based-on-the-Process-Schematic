namespace process.Models
{
    public class Shapes
    {
        public List<Rectangle> rectangles {  get; }
        public List<Rhombus> rhombuses { get; }
        public List<Circle> circles { get; }

        public Shapes()
        {
            rectangles = new List<Rectangle>();
            rhombuses = new List<Rhombus>();
            circles = new List<Circle>();
        }

        public void add_rectangle(Rectangle rectangle)
        {
            rectangles.Add(rectangle);
        }
        public void add_rhombus(Rhombus rhombus)
        {
            rhombuses.Add(rhombus);
        }
        public void add_circle(Circle circle)
        {
            circles.Add(circle);
        }

    }

    public class Rectangle : BasicInfo
    {
        public Rectangle(int position_x, int position_y, int height, int width)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.height = height;
            this.width = width;
        }
    }

    public class Rhombus : BasicInfo
    {
        public Rhombus(int position_x, int position_y, int height, int width)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.height = height;
            this.width = width;
        }
    }

    public class Circle : BasicInfo
    {
        public Circle(int position_x, int position_y, int radius)
        {
            this.position_x = position_x;
            this.position_y = position_y;
            this.radius = radius;
        }

    }

    public class Line
    {
        // point's order matters
        public List<Position> sections { get; }
        public Line()
        {
            sections = new List<Position>();
        }
        public void add_section(Position p)
        {
            sections.Add(p);
        }
    }

}
