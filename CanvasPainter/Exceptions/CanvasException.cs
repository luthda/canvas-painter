using System;

namespace CanvasPainter.Exceptions
{
    public class CanvasException : Exception
    {
        private CanvasException(string message) : base(message)
        {
        }

        public static CanvasException BecauseOfInvalidInput()
        {
            return new CanvasException("Your input is not valid! Check which input is allowed for each command.");
        }

        public static CanvasException BecauseCoordinateNotInCanvas()
        {
            return new CanvasException("Your coordination are not inside the canvas! Check your canvas size.");
        }

        public static CanvasException BecauseCoordinatesAreNotALine()
        {
            return new CanvasException("Your coordination have to be on a line to be drawn.");
        }
        
        public static CanvasException BecauseIsNotAValidCommand()
        {
            return new CanvasException("This command is not allowed. Choose C, L, R, B or Q.");
        }

        public static CanvasException BecauseIsEmpty()
        {
            return new CanvasException("Impossible to draw on empty canvas. Create a canvas first");
        }
    }
}