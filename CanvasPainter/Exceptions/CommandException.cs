using System;

namespace CanvasPainter.Exceptions
{
    public class CommandException : Exception
    {
        private const string Message = "This is not a command! Choose C, L, R, B or Q";
        public CommandException() : base(Message)
        {
        }

        public static CommandException CreateInstance()
        {
            return new CommandException();
        }
    }
}