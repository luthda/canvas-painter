using CanvasPainter.Commands;
using CanvasPainter.Drawings;

namespace CanvasPainter.Handlers
{
    public class PaintHandler : IHandler
    {
        private Canvas Canvas { get; set; }

        public PaintHandler()
        {
            Canvas = new EmptyCanvas();
        }

        public string HandleOn(ICommand command)
        {
            if (command.GetType() == typeof(CreateCommand))
            {
                Canvas = Canvas.CreateFor((CreateCommand) command);
            }
            else
            {
                Canvas = Canvas.Draw(command);
            }

            return Canvas.DrawBorder();
        }
    }
}