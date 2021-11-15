using System.Collections.Generic;

namespace CanvasPainter.Commands
{
    public interface ICommand
    {
        public void ValidateAndSetProperties(string[] inputParameters);
    }
}