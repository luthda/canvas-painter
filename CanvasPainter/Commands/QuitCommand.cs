using CanvasPainter.Exceptions;

namespace CanvasPainter.Commands
{
    public class QuitCommand : ICommand
    {
        public bool IsQuit { get; private set; }

        public QuitCommand(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (inputParameters.Length == 1)
            {
                IsQuit = true;
            }
            else
            {
                throw ValidationException.CreateInstance();
            }
        }
    }
}