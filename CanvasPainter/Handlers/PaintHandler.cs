using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                return Canvas.DrawBorder();
            }

            if (command.GetType() == typeof(LineCommand))
            {
                return Canvas.Draw((LineCommand) command);
            }

            throw new ArgumentException("Not a command");
        }
    }
}