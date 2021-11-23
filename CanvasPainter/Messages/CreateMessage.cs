using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public class CreateMessage : IMessage
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private const int UpperLimit = 50;
        private const int LowerLimit = 1;

        public CreateMessage(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 3 && int.TryParse(inputParameters[1], out int width) &&
                  int.TryParse(inputParameters[2], out int height)))
            {
                throw CanvasException.BecauseOfInvalidInput();
            }

            if (!(IsInLimitedArea(width) && IsInLimitedArea(height)))
            {
                throw CanvasException.BecauseCoordinateNotInCanvas();
            }

            Width = width;
            Height = height;
        }

        private bool IsInLimitedArea(int size)
        {
            return size >= LowerLimit && size <= UpperLimit;
        }
    }
}