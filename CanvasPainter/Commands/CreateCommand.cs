using System;
using System.Collections.Generic;

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
            ValidateAndSetParameters(inputParameters);
        }

        public void ValidateAndSetParameters(string[] inputParameters)
        {
            if (!(inputParameters.Length == 3 && int.TryParse(inputParameters[1], out int width) &&
                  int.TryParse(inputParameters[2], out int height)))
                throw new ArgumentException("Create command needs 3 parameters: C width height (only integer allowed)");
            
            if (width < LowerLimit || width > UpperLimit && height < LowerLimit || height > UpperLimit)
                throw new ArgumentException("Size limits: Min = 1, Max = 50");

            Width = width;
            Height = height;
        }
    }
}