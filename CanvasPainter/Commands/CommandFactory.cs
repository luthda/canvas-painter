using System;
using System.Linq;

namespace CanvasPainter.Commands
{
    public class CommandFactory
    {
        public ICommand CreateCommandFor(string inputValues)
        {
            var inputParameters = inputValues.Split(" ");
            var commandChar = inputParameters.First().ToUpper();

            if (!Enum.TryParse(commandChar, out CommandType commandType))
                throw new ArgumentException("This is not a valid command, choose: C, L, R, B or Q");

            return commandType switch
            {
                CommandType.C => new CreateCommand(inputParameters),
                CommandType.Q => new QuitCommand(inputParameters)
            };
        }
    }
}