using CanvasPainter.Drawings;
using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public class LineMessage : IMessage
    {
        public Point? StartPoint { get; private set; }
        public Point? EndPoint { get; private set; }

        public LineMessage(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 5 && int.TryParse(inputParameters[1], out int x1) &&
                  int.TryParse(inputParameters[2], out int y1) && int.TryParse(inputParameters[3], out int x2) &&
                  int.TryParse(inputParameters[4], out int y2)))
            {
                throw CanvasException.BecauseOfInvalidInput();
            }

            if (!(x1 == x2 || y1 == y2))
            {
                throw CanvasException.BecauseCoordinatesAreNotALine();
            }

            StartPoint = Point.CreateFor(x1, y1);
            EndPoint = Point.CreateFor(x2, y2);
        }
    }
}