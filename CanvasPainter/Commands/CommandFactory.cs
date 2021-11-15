using System;
using System.Linq;

namespace CanvasPainter.Commands
{
    public class CommandFactory
    {
        public static ICommand CreateFor(string inputValues)
        {
            var inputParameters = inputValues.Split(" ");
            var commandChar = inputParameters.First().ToUpper();

            if (!Enum.TryParse(commandChar, out CommandType commandType))
                throw new ArgumentException("This is not a valid command, choose: C, L, R, B or Q");

            return commandType switch
            {
                CommandType.C => new CreateCommand(inputParameters),
                CommandType.L => new LineCommand(inputParameters),
                CommandType.R => new RectangleCommand(inputParameters),
                CommandType.Q => new QuitCommand(inputParameters)
            };
        }
    }
}