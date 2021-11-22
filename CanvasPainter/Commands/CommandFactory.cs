using System;
using System.Linq;
using CanvasPainter.Exceptions;

namespace CanvasPainter.Commands
{
    public static class CommandFactory
    {
        public static ICommand CreateFor(string inputValues)
        {
            var inputParameters = inputValues.Split(" ");
            var commandChar = inputParameters.First().ToUpper();

            if (!Enum.TryParse(commandChar, out CommandType commandType))
            {
                throw CommandException.CreateInstance();
            }

            return commandType switch
            {
                CommandType.C => new CreateCommand(inputParameters),
                CommandType.L => new LineCommand(inputParameters),
                CommandType.R => new RectangleCommand(inputParameters),
                CommandType.B => new FloodFillCommand(inputParameters),
                CommandType.Q => new QuitCommand(inputParameters),
                _ => throw CommandException.CreateInstance()
            };
        }
    }
}