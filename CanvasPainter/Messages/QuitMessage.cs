using CanvasPainter.Exceptions;

namespace CanvasPainter.Messages
{
    public class QuitMessage : IMessage
    {
        public QuitMessage(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (inputParameters.Length != 1)
            {
                throw ValidationException.CreateInstance();
            }
        }
    }
}