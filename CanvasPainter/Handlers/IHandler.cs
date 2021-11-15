using CanvasPainter.Commands;

namespace CanvasPainter.Handlers
{
    public interface IHandler
    {
        public string HandleOn(ICommand command);
    }
}