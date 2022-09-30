using CanvasPainter.Drawings;
using CanvasPainter.Messages;

namespace CanvasPainter.Handlers
{
    public class PaintHandler
    {
        private Canvas Canvas { get; set; }

        public PaintHandler()
        {
            Canvas = new EmptyCanvas();
        }

        public string HandleOn(IMessage message)
        {
            if (message is CreateMessage createMessage)
            {
                Canvas = Canvas.CreateFor(createMessage);
            }
            else
            {
                Canvas = Canvas.Draw(message);
            }

            return Canvas.ToString();
        }
    }
}