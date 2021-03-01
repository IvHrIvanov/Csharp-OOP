using System;

namespace _01.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                Box box = new Box(length, width, height);

                Console.WriteLine(box.SurfaceArea(length, width, height));
                Console.WriteLine(box.LateralSurfaceArea(length, width, height));
                Console.WriteLine(box.Volume(length, width, height));

            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
