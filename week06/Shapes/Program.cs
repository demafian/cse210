using System;
using System.Collections.Generic;
using Shapes;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        // Polymorphism: Adding different subtypes to a base-type list
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 10));
        shapes.Add(new Circle("Green", 3));

        Console.WriteLine("Shape Report:");
        Console.WriteLine("-------------------------");

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();

            // :F2 formats the area to 2 decimal places
            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}