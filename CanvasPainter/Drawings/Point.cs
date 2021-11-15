namespace CanvasPainter.Drawings
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsPointInBodyRange(int width, int height)
        {
            return X > 0 && X <= width && Y > 0 && Y <= height;
        }
    }
}