using System;
using System.Linq;

namespace Rower
{
    public class Way
    {
        public string Pole { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class Rover
    {
        public char[] poles = { 'L', 'R' };

        private int xDimention { get; set; }
        private int yDimention { get; set; }

        private int xRoverPosition { get; set; }
        private int yRoverPosition { get; set; }

        private string currentPole { get; set; }
        private string roverPath { get; set; }

        public Rover(int xDimention, int yDimention, int xRoverPosition, int yRoverPosition, string currentPole, string roverPath)
        {
            this.xDimention = xDimention;
            this.yDimention = yDimention;
            this.xRoverPosition = xRoverPosition;
            this.yRoverPosition = yRoverPosition;
            this.currentPole = currentPole;
            this.roverPath = roverPath;
        }

        public Way calculatePosition()
        {
            Way newDirection = new Way();

            foreach (char path in roverPath)
            {
                if (poles.Contains(path))
                {
                    currentPole = getNewPole(currentPole, path);
                    continue;
                }

                newDirection = getNewDirection(currentPole);
                xRoverPosition = xRoverPosition + newDirection.X;
                yRoverPosition = yRoverPosition + newDirection.Y;

                if (xRoverPosition > xDimention || xRoverPosition < 0 || yRoverPosition > yDimention || yRoverPosition < 0)
                    throw new ArgumentException(string.Format("Invalid value: {0}", path));
            }

            newDirection.Pole = currentPole;
            newDirection.X = xRoverPosition;
            newDirection.Y = yRoverPosition;

            return newDirection;
        }

        private static Way getNewDirection(string pole)
        {
            Way val = new Way();

            val.X = 0;
            val.Y = 0;

            switch (pole)
            {
                case "N":
                    val.X = 0;
                    val.Y = 1;

                    break;
                case "S":
                    val.X = 0;
                    val.Y = -1;

                    break;
                case "E":
                    val.X = 1;
                    val.Y = 0;

                    break;
                case "W":
                    val.X = -1;
                    val.Y = 0;

                    break;
            }

            return val;
        }

        private string getNewPole(string pole, char direciton)
        {
            string newPole = "";

            switch (pole)
            {
                case "N":
                    if (direciton == 'R')
                        newPole = "E";
                    else
                        newPole = "W";
                    break;
                case "S":
                    if (direciton == 'R')
                        newPole = "W";
                    else
                        newPole = "E";
                    break;
                case "E":
                    if (direciton == 'R')
                        newPole = "S";
                    else
                        newPole = "N";
                    break;
                case "W":
                    if (direciton == 'R')
                        newPole = "N";
                    else
                        newPole = "S";
                    break;
            }

            return newPole;
        }
    }
}
