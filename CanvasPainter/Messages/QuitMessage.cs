using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public class QuitMessage : IMessage
    {
        public bool IsQuit { get; private set; }

        public QuitMessage(string[] inputParameters)
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