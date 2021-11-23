using CanvasPainter.Exceptions;
using CanvasPainter.Messages;

namespace CanvasPainter.Drawings
{
    public class EmptyCanvas : Canvas
    {
        public override Canvas Draw(IMessage message)
        {
            throw CommandException.CreateInstance();
        }
    }
}