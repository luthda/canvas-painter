using CanvasPainter.Drawings;
using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public class FloodFillMessage : IMessage
    {
        public Point? ColorPoint { get; set; }
        public char FillColor { get; set; }

        public FloodFillMessage(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 4 && int.TryParse(inputParameters[1], out int x) &&
                  int.TryParse(inputParameters[2], out int y) && char.TryParse(inputParameters[3], out char color)))
            {
                throw CanvasException.BecauseOfInvalidInput();
            }

            ColorPoint = Point.CreateFor(x, y);
            FillColor = color;
        }
    }
}