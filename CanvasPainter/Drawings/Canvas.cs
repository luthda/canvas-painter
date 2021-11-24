using System.Text;
using CanvasPainter.Exceptions;
using CanvasPainter.Messages;

namespace CanvasPainter.Drawings
{
    public class Canvas
    {
        private const char EmptyColor = ' ';
        private const char LineColor = 'x';
        private int Width { get; }
        private int Height { get; }
        private char[,]? CanvasBody { get; }

        private Canvas(CreateMessage createMessage)
        {
            Width = createMessage.Width;
            Height = createMessage.Height;
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

        public static Canvas CreateFor(CreateMessage createMessage)
        {
            return new Canvas(createMessage);
        }

        public override string ToString()
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

                stringBuilder.AppendLine("|");
            }

            stringBuilder.AppendLine(horizontalBorder);
            return stringBuilder.ToString();
        }

        public virtual Canvas Draw(IMessage message)
        {
            switch (message)
            {
                case LineMessage lineMessage:
                    DrawLine(lineMessage.StartPoint, lineMessage.EndPoint);
                    break;
                case RectangleMessage rectangleMessage:
                    DrawRectangle(rectangleMessage.StartPoint, rectangleMessage.EndPoint);
                    break;
                case FloodFillMessage floodFillMessage:
                    FloodFill(floodFillMessage.ColorPoint, floodFillMessage.FillColor);
                    break;
            }

            return (Canvas) MemberwiseClone();
        }

        private void DrawLine(Point? startPoint, Point? endPoint)
        {
            if (!startPoint.IsPointInBodyRange(Width, Height) || !endPoint.IsPointInBodyRange(Width, Height))
            {
                throw CanvasException.BecauseCoordinateIsNotInCanvas();
            }

            if (startPoint.X == endPoint.X)
            {
                DrawVerticalLine(startPoint, endPoint);
            }
            else
            {
                DrawHorizontalLine(startPoint, endPoint);
            }
        }

        private void DrawRectangle(Point? startPoint, Point? endPoint)
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

        private void DrawHorizontalLine(Point? startPoint, Point? endPoint)
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

        private void DrawVerticalLine(Point? startPoint, Point? endPoint)
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