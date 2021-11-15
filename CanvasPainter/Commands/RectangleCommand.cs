using System;
using CanvasPainter.Drawings;

namespace CanvasPainter.Commands
{
    public class RectangleCommand : ICommand
    {
        public Point StartPoint { get; private set; }
        public Point EndPoint { get; private set; }

        public RectangleCommand(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }
        
        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 5 && int.TryParse(inputParameters[1], out int x1) &&
                  int.TryParse(inputParameters[2], out int y1) && int.TryParse(inputParameters[3], out int x2) &&
                  int.TryParse(inputParameters[4], out int y2)))
                throw new ArgumentException(
                    "Rectangle command needs 5 parameters: R x1 y1 x2 y2 (only integer allowed)");
            
            StartPoint = Point.CreateFor(x1, y1);
            EndPoint = Point.CreateFor(x2, y2);
        }
    }
}