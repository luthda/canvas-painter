using System;

namespace CanvasPainter.Exceptions
{
    public class ValidationException : Exception
    {
        private const string SpecificMessage = "Your input is not valid! Check on which input is allowed for each command.";

        private ValidationException() : base(SpecificMessage)
        {
        }

        public static ValidationException CreateInstance()
        {
            return new ValidationException();
        }
    }
}