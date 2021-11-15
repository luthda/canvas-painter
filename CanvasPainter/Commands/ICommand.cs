using System.Collections.Generic;

namespace CanvasPainter.Commands
{
    public interface ICommand
    {
        public void ValidateAndSetParameters(string[] inputParameters);
    }
}