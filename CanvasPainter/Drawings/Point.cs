namespace CanvasPainter.Drawings
{
    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }

        private Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsPointInBodyRange(int width, int height)
        {
            return X > 0 && X <= width && Y > 0 && Y <= height;
        }

        public static Point CreateFor(int x, int y)
        {
            return new Point(x, y);
        }
    }
}