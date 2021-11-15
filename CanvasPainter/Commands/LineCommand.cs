using System;
using CanvasPainter.Drawings;

namespace CanvasPainter.Commands
{
    public class LineCommand : ICommand
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }

        public LineCommand(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 5 && int.TryParse(inputParameters[1], out int x1) &&
                  int.TryParse(inputParameters[2], out int y1) && int.TryParse(inputParameters[3], out int x2) &&
                  int.TryParse(inputParameters[4], out int y2)))
            {
                throw new ArgumentException(
                    "Line command needs 5 parameters: L x1 y1 x2 y2 (only integer allowed)");
            }

            if (!(x1 == x2 || y1 == y2))
            {
                throw new ArgumentException("Only straight lines are possible: x1 == x2 or y1 == y2");
            }

            StartPoint = Point.CreateFor(x1, y1);
            EndPoint = Point.CreateFor(x2, y2);
        }
    }
}