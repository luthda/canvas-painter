using CanvasPainter.Messages;

namespace CanvasPainter.Handlers
{
    public interface IHandler
    {
        public string HandleOn(IMessage message);
    }
}