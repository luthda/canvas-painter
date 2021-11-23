using System;
using System.Text;
using CanvasPainter.Messages;

namespace CanvasPainter.Drawings
{
    public class Canvas
    {
        private const char EmptyColor = ' ';
        private const char LineColor = 'x';
        public int Width { get; }
        public int Height { get; }
        public char[,] CanvasBody { get; }

        private Canvas(CreateMessage message)
        {
            Width = message.Width;
            Height = message.Height;
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

        public static Canvas CreateFor(CreateMessage message)
        {
            return new Canvas(message);
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

        public virtual Canvas Draw(IMessage message)
        {
            if (message.GetType() == typeof(LineMessage))
            {
                var lineCommand = (LineMessage) message;
                DrawLine(lineCommand.StartPoint, lineCommand.EndPoint);
            }

            if (message.GetType() == typeof(RectangleMessage))
            {
                var rectangleCommand = (RectangleMessage) message;
                DrawRectangle(rectangleCommand.StartPoint, rectangleCommand.EndPoint);
            }

            if (message.GetType() == typeof(FloodFillMessage))
            {
                var floodFillCommand = (FloodFillMessage) message;
                FloodFill(floodFillCommand.ColorPoint, floodFillCommand.FillColor);
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
            if (startPoint.X >= endPoint.X)
            {
                InsertXAxisLineColor(startPoint.Y, endPoint.X, startPoint.X);
            }
            else
            {
                InsertXAxisLineColor(startPoint.Y, startPoint.X, endPoint.X);
            }
        }

        private void DrawVerticalLine(Point startPoint, Point endPoint)
        {
            if (startPoint.Y >= endPoint.Y)
            {
                InsertYAxisLineColor(startPoint.X, endPoint.Y, startPoint.Y);
            }
            else
            {
                InsertYAxisLineColor(startPoint.X, startPoint.Y, endPoint.Y);
            }
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