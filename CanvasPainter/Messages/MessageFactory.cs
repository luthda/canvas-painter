using System;
using System.Linq;
using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public static class MessageFactory
    {
        public static IMessage CreateFor(string inputValues)
        {
            var inputParameters = inputValues.Split(" ");
            var commandChar = inputParameters.First().ToUpper();

            if (!Enum.TryParse(commandChar, out MessageType commandType))
            {
                throw CanvasException.BecauseIsNotAValidCommand();
            }

            return commandType switch
            {
                MessageType.C => new CreateMessage(inputParameters),
                MessageType.L => new LineMessage(inputParameters),
                MessageType.R => new RectangleMessage(inputParameters),
                MessageType.B => new FloodFillMessage(inputParameters),
                MessageType.Q => new QuitMessage(inputParameters),
                _ => throw CanvasException.BecauseIsNotAValidCommand()
            };
        }
    }
}