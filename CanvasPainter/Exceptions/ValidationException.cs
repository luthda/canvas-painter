using System;

namespace CanvasPainter.Exceptions
{
    public class ValidationException : Exception
    {
        private const string Message = "Your input is not valid! Check on which input is allowed for each command.";
        public ValidationException() : base(Message)
        {
        }

        public static ValidationException CreateInstance()
        {
            return new ValidationException();
        }
    }
}