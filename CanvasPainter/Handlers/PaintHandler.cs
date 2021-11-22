using System;
using System.Collections.Generic;
using CanvasPainter.Commands;
using CanvasPainter.Drawings;

namespace CanvasPainter.Handlers
{
    public class PaintHandler : IHandler
    {
        private Canvas Canvas { get; set; }
        private Stack<Canvas> CanvasHistory { get; }

        public PaintHandler()
        {
            Canvas = new EmptyCanvas();
            CanvasHistory = new Stack<Canvas>();
        }

        public string HandleOn(ICommand command)
        {
            if (command.GetType() == typeof(CreateCommand))
            {
                Canvas = Canvas.CreateFor((CreateCommand) command);
            }
            else if (command.GetType() == typeof(UndoCommand))
            {
                Canvas = PopFromCanvasHistory();
            }
            else
            {
                PushToCanvasHistory();
                Canvas = Canvas.Draw(command);
            }

            return Canvas.DrawBorder();
        }
        
        private void PushToCanvasHistory()
        {
            CanvasHistory.Push(Canvas.Clone());
        }

        private Canvas PopFromCanvasHistory()
        {
            if (CanvasHistory.Count == 0)
            {
                throw new ArgumentException("Canvas history is empty!");
            }
            
            return CanvasHistory.Pop();
        }
    }
}