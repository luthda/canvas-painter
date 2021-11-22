using System;

namespace CanvasPainter.Exceptions
{
    public class CommandException : Exception
    {
        private const string SpecificMessage = "This is not a command! Choose C, L, R, B or Q";

        private CommandException() : base(SpecificMessage)
        {
        }

        public static CommandException CreateInstance()
        {
            return new CommandException();
        }
    }
}