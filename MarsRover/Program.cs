using Rower;
using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover rover1 = new Rover(5, 5, 1, 2, "N", "LMLMLMLMM");
            Way lastPosition1 = rover1.calculatePosition();

            Console.WriteLine(lastPosition1.X + " " + lastPosition1.Y + " " + lastPosition1.Pole);

            Rover rover2 = new Rover(5, 5, 3, 3, "E", "MMRMMRMRRM");
            Way lastPosition2 = rover2.calculatePosition();
            Console.WriteLine(lastPosition2.X + " " + lastPosition2.Y + " " + lastPosition2.Pole);
            Console.ReadKey();
        }
    }
}
