using System;
using System.Text;
using CanvasPainter.Commands;

namespace CanvasPainter.Drawings
{
    public class Canvas
    {
        private const char EmptyColor = ' ';
        private const char LineColor = 'x';
        public int Width { get; }
        public int Height { get; }
        public char[,] CanvasBody { get; }

        private Canvas(CreateCommand command)
        {
            Width = command.Width;
            Height = command.Height;
            CanvasBody = new char[Width, Height];

            for (int x = 1; x <= Width; x++)
            {
                for (int y = 1; y <= Height; y++)
                {
                    SetColorFor(Point.CreateFor(x, y), EmptyColor);
                }
            }
        }

        protected Canvas()
        {
        }
        
        public static Canvas CreateFor(CreateCommand command)
        {
            return new Canvas(command);
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
                    stringBuilder.Append(GetColorAt(Point.CreateFor(x, y)));
                }

                stringBuilder.Append("|\n");
            }

            stringBuilder.AppendLine(horizontalBorder);
            return stringBuilder.ToString();
        }

        public virtual Canvas Draw(ICommand command)
        {
            if (command.GetType() == typeof(LineCommand))
            {
                var lineCommand = (LineCommand) command;
                DrawLine(lineCommand.StartPoint, lineCommand.EndPoint);
            }

            if (command.GetType() == typeof(RectangleCommand))
            {
                var rectangleCommand = (RectangleCommand) command;
                DrawRectangle(rectangleCommand.StartPoint, rectangleCommand.EndPoint);
            }

            return (Canvas) MemberwiseClone();
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
            DrawLine(startPoint, Point.CreateFor(endPoint.X, startPoint.Y));
            DrawLine(Point.CreateFor(startPoint.X, endPoint.Y), endPoint);
            DrawLine(startPoint, Point.CreateFor(startPoint.X, endPoint.Y));
            DrawLine(Point.CreateFor(endPoint.X, startPoint.Y), endPoint);
        }

        private void FloodFill(Point point, char fillColorChar)
        {
            if (!point.IsPointInBodyRange(Width, Height) || GetColorAt(point) != EmptyColor)
            {
                return;
            }

            SetColorFor(point, fillColorChar);

            FloodFill(Point.CreateFor(point.X, point.Y - 1), fillColorChar);
            FloodFill(Point.CreateFor(point.X, point.Y + 1), fillColorChar);
            FloodFill(Point.CreateFor(point.X - 1, point.Y), fillColorChar);
            FloodFill(Point.CreateFor(point.X + 1, point.Y), fillColorChar);
        }

        private void DrawHorizontalLine(Point startPoint, Point endPoint)
        {
            if (startPoint.X >= endPoint.X) InsertXAxisLineColor(startPoint.Y, endPoint.X, startPoint.X);
            else InsertXAxisLineColor(startPoint.Y, startPoint.X, endPoint.X);
        }

        private void DrawVerticalLine(Point startPoint, Point endPoint)
        {
            if (startPoint.Y >= endPoint.Y) InsertYAxisLineColor(startPoint.X, endPoint.Y, startPoint.Y);
            else InsertYAxisLineColor(startPoint.X, startPoint.Y, endPoint.Y);
        }

        private void InsertYAxisLineColor(int x, int lower, int upper)
        {
            for (int i = lower; i <= upper; i++)
            {
                SetColorFor(Point.CreateFor(x, i), LineColor);
            }
        }

        private void InsertXAxisLineColor(int y, int lower, int upper)
        {
            for (int i = lower; i <= upper; i++)
            {
                SetColorFor(Point.CreateFor(i, y), LineColor);
            }
        }
        
        private char GetColorAt(Point point)
        {
            return CanvasBody[point.X - 1, point.Y - 1];
        }
        
        private void SetColorFor(Point point, char color)
        {
            CanvasBody[point.X - 1, point.Y - 1] = color;
        }
    }
}