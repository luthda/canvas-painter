using System;
using System.Collections.Generic;
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
                Canvas = new Canvas((CreateCommand) command);
                return Canvas.DrawBorder();
            }

            throw new ArgumentException("Not a command");
        }
    }
}