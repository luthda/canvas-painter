using CanvasPainter.Exceptions;

namespace CanvasPainter.Commands
{
    public class CreateCommand : ICommand
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private const int UpperLimit = 50;
        private const int LowerLimit = 1;

        public CreateCommand(string[] inputParameters)
        {
            ValidateAndSetProperties(inputParameters);
        }

        public void ValidateAndSetProperties(string[] inputParameters)
        {
            if (!(inputParameters.Length == 3 && int.TryParse(inputParameters[1], out int width) &&
                  int.TryParse(inputParameters[2], out int height)))
            {
                throw ValidationException.CreateInstance();
            }

            if (width < LowerLimit || width > UpperLimit && height < LowerLimit || height > UpperLimit)
            {
                throw ValidationException.CreateInstance();
            }

            Width = width;
            Height = height;
        }
    }
}