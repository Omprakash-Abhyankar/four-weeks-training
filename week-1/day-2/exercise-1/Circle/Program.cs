namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            Circle c = new Circle(10);


            Console.WriteLine("Area of my circle is: " + c.GetArea());
            Console.WriteLine("Circumference of my circle is: " + c.GetCircumference());
        }
    }  
    class Circle
    {



        public double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public double GetArea()
        {

            return 3.14 * radius * radius;

        }
        public double GetCircumference()
        {

            return 2 * 3.14 * radius;
        }
    }
}