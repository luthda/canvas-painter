using CanvasPainter.Commands;

namespace CanvasPainter.Handlers
{
    public class QuitHandler
    {
        public bool HandleQuit(QuitCommand command)
        {
            return command.IsQuit;
        }
    }
}