using System;
using System.Text;
using CanvasPainter.Commands;

namespace CanvasPainter.Drawings
{
    public class Canvas
    {
        private const char EmptyColor = ' ';
        private const char LineColor = 'x';
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char[,] CanvasBody { get; set; }

        public Canvas(CreateCommand command)
        {
            Width = command.Width;
            Height = command.Height;
            CanvasBody = new char[Width, Height];

            for (int x = 1; x <= Width; x++)
            {
                for (int y = 1; y <= Height; y++)
                {
                    SetColorInCanvasBody(new Point(x, y), EmptyColor);
                }
            }
        }

        protected Canvas()
        {
        }

        public string DrawBorder()
        {
            var stringBuilder = new StringBuilder();
            var horizontalBorder = new string('-', Width + 2);
            stringBuilder.AppendLine(horizontalBorder);

            for (int y = 1; y <= Height; y++)
            {
                stringBuilder.Append('|');
                for (int x = 1; x <= Width; x++)
                {
                    stringBuilder.Append(GetFieldInCanvasBody(new Point(x, y)));
                }

                stringBuilder.Append("|\n");
            }

            stringBuilder.AppendLine(horizontalBorder);
            return stringBuilder.ToString();
        }
        public char GetFieldInCanvasBody(Point point)
        {
            return CanvasBody[point.X - 1, point.Y - 1];
        }
        
        public virtual string Draw(ICommand command)
        {
            return DrawBorder();
        }

        private void DrawLine(Point startPoint, Point endPoint)
        {
            if (!startPoint.IsPointInBodyRange(Width, Height) || !endPoint.IsPointInBodyRange(Width, Height))
            {
                throw new ArgumentException(
                    $"Your coordinate must be in canvas body area, width: {Width}, height: {Height}");
            }

            if (startPoint.X == endPoint.X) DrawVerticalLine(startPoint, endPoint);
            else DrawHorizontalLine(startPoint, endPoint);
        }

        private void DrawRectangle(Point startPoint, Point endPoint)
        {
            DrawLine(startPoint, new Point(endPoint.X, startPoint.Y));
            DrawLine(new Point(startPoint.X, endPoint.Y), endPoint);
            DrawLine(startPoint, new Point(startPoint.X, endPoint.Y));
            DrawLine(new Point(endPoint.X, startPoint.Y), endPoint);
        }

        private void ColorizeCanvasBody(Point point, char fillColorChar)
        {
            if (!point.IsPointInBodyRange(Width, Height) || GetFieldInCanvasBody(point) != EmptyColor)
            {
                return;
            }

            SetColorInCanvasBody(point, fillColorChar);

            ColorizeCanvasBody(new Point(point.X, point.Y - 1), fillColorChar);
            ColorizeCanvasBody(new Point(point.X, point.Y + 1), fillColorChar);
            ColorizeCanvasBody(new Point(point.X - 1, point.Y), fillColorChar);
            ColorizeCanvasBody(new Point(point.X + 1, point.Y), fillColorChar);
        }

        private void SetColorInCanvasBody(Point point, char color)
        {
            CanvasBody[point.X - 1, point.Y - 1] = color;
        }

        private void DrawHorizontalLine(Point startPoint, Point endPoint)
        {
            if (startPoint.X >= endPoint.X) InsertXAxisLineSymbol(startPoint.Y, endPoint.X, startPoint.X);
            else InsertXAxisLineSymbol(startPoint.Y, startPoint.X, endPoint.X);
        }

        private void DrawVerticalLine(Point startPoint, Point endPoint)
        {
            if (startPoint.Y >= endPoint.Y) InsertYAxisLineSymbol(startPoint.X, endPoint.Y, startPoint.Y);
            else InsertYAxisLineSymbol(startPoint.X, startPoint.Y, endPoint.Y);
        }

        private void InsertYAxisLineSymbol(int x, int lower, int upper)
        {
            for (int i = lower; i <= upper; i++)
            {
                SetColorInCanvasBody(new Point(x, i), LineColor);
            }
        }

        private void InsertXAxisLineSymbol(int y, int lower, int upper)
        {
            for (int i = lower; i <= upper; i++)
            {
                SetColorInCanvasBody(new Point(i, y), LineColor);
            }
        }
    }
}