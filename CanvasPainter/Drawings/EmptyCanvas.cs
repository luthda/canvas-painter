using System;
using CanvasPainter.Commands;
using CanvasPainter.Exceptions;

namespace CanvasPainter.Drawings
{
    public class EmptyCanvas : Canvas
    {
        public override Canvas Draw(ICommand command)
        {
            throw new CommandException();
        }
    }
}