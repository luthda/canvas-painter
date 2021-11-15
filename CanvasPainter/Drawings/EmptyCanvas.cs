using System;
using CanvasPainter.Commands;

namespace CanvasPainter.Drawings
{
    public class EmptyCanvas : Canvas
    {
        public override Canvas Draw(ICommand command)
        {
            throw new ArgumentException("Create a canvas first: C width, height");
        }
    }
}