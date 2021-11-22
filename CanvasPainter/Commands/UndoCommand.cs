using CanvasPainter.Exceptions;

namespace CanvasPainter.Commands
{
    public class UndoCommand : ICommand
    {
        public UndoCommand(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }
        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (inputParameters.Length != 1)
            {
                throw CommandException.CreateInstance();
            }
        }
    }
}