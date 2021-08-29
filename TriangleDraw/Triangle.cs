using System;
using System.Drawing;

namespace TriangleDraw
{
    internal class Triangle
    {
        private Color color;
        private Point[] points;
        public Rectangle HitBox => UpdateRectangle();

        public Triangle(Point pointA, Point pointB, Point pointC, Color color)
        {
            points = new Point[3];

            points[0] = pointA;
            points[1] = pointB;
            points[2] = pointC;
            this.color = color;

        }
        private Rectangle UpdateRectangle()
        {
            Point location = new Point(points[0].X, points[0].Y);
            int width = 0;
            int height = 0;
            for (int i = 1; i < points.Length; i++)
            {
                int xDifference = Math.Abs(points[0].X - points[i].X);
                if (xDifference > width)
                {
                    width = xDifference;
                }
                int yDifference = Math.Abs(points[0].Y - points[i].Y);
                if (yDifference > height)
                {
                    height = yDifference;
                }
                // update location
                if (points[i].X < location.X)
                {
                    location.X = points[i].X;
                }
                if (points[i].Y < location.Y)
                {
                    location.Y = points[i].Y;
                }
            }
            return new Rectangle(location, new Size(width, height));
        }
        private int DotProduct(int x1, int y1, int x2, int y2)
        {
            return (x1 * y2) - (x2 * y1);
        }
        private bool IsInTriangle(Point pointToCheck)
        {
            int x1 = Math.Abs(pointToCheck.X - points[1].X);
            int y1 = Math.Abs(pointToCheck.Y - points[1].Y);

            int x2 = Math.Abs(pointToCheck.X - points[0].X);
            int y2 = Math.Abs(pointToCheck.Y - points[0].Y);

            int area1 = (DotProduct(x1, y1, x2, y2)) / 2;

            x1 = Math.Abs(pointToCheck.X - points[0].X);
            y1 = Math.Abs(pointToCheck.Y - points[0].Y);

            x2 = Math.Abs(pointToCheck.X - points[2].X);
            y2 = Math.Abs(pointToCheck.Y - points[2].Y);

            int area2 = (DotProduct(x1, y1, x2, y2)) / 2;

            x1 = Math.Abs(pointToCheck.X - points[2].X);
            y1 = Math.Abs(pointToCheck.Y - points[2].Y);

            x2 = Math.Abs(pointToCheck.X - points[1].X);
            y2 = Math.Abs(pointToCheck.Y - points[1].Y);

            int area3 = (DotProduct(x1, y1, x2, y2)) / 2;

            x1 = Math.Abs(points[2].X - points[0].X);
            y1 = Math.Abs(points[2].Y - points[0].Y);
                               
            x2 = Math.Abs(points[2].X - points[1].X);
            y2 = Math.Abs(points[2].Y - points[1].Y);

            int normalArea = (DotProduct(x1, y1, x2, y2)) / 2;

            if ((area1 + area2 + area3) / normalArea == 1)
            {
                return true;
            }

            return false;
        }

        public void Draw(Bitmap backBuffer)
        {
            for (int x = HitBox.X; x < HitBox.Width; x++)
            {
                for (int y = HitBox.Y; y < HitBox.Height; y++)
                {
                    if (IsInTriangle(new Point(x, y)))
                    {
                        backBuffer.SetPixel(x, y, color);
                    }
                }
            }
        }
    }
}