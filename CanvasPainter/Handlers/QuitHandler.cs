using CanvasPainter.Messages;

namespace CanvasPainter.Handlers
{
    public class QuitHandler
    {
        public bool HandleQuit(QuitMessage message)
        {
            return message.IsQuit;
        }
    }
}