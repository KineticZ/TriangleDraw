using System;
using System.Drawing;

namespace TriangleDraw
{
    internal class Triangle
    {
        private Color[] colors;
        private Color color;
        public Point[] points { get; private set; }
        private int normalArea;
        public Rectangle HitBox => UpdateRectangle();

        public Triangle(Point pointA, Point pointB, Point pointC, Color color)
        {
            points = new Point[3];

            points[0] = pointA;
            points[1] = pointB;
            points[2] = pointC;
            this.color = color;

            int x1 = Math.Abs(points[0].X - points[1].X);
            int y1 = Math.Abs(points[0].Y - points[1].Y);

            int x2 = Math.Abs(points[2].X - points[0].X);
            int y2 = Math.Abs(points[2].Y - points[0].Y);

            normalArea = (DotProduct(x1, y1, x2, y2)) / 2;
            normalArea = normalArea == 0 ? 1 : normalArea;

            colors = new Color[normalArea];
        }
        public void UpdateTriangle(Point[] points)
        {
            this.points = points;
            
            int x1 = Math.Abs(points[0].X - points[1].X);
            int y1 = Math.Abs(points[0].Y - points[1].Y);

            int x2 = Math.Abs(points[2].X - points[0].X);
            int y2 = Math.Abs(points[2].Y - points[0].Y);

            normalArea = (DotProduct(x1, y1, x2, y2)) / 2;
            normalArea = normalArea == 0 ? 1 : normalArea;

            UpdateRectangle();
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
            /*
             * | x1 x2 |
             * | y1 y2 |
             */
            return (x1 * y2) - (x2 * y1);
        }
        private bool IsInTriangle(Point pointToCheck)
        {
            int x1 = Math.Abs(points[0].X - points[1].X);
            int y1 = Math.Abs(points[0].Y - points[1].Y);

            int x2 = Math.Abs(pointToCheck.X - points[0].X);
            int y2 = Math.Abs(pointToCheck.Y - points[0].Y);

            int area1 = (DotProduct(x1, y1, x2, y2)) / 2;
            if (area1 < 0) return false;

            x1 = Math.Abs(pointToCheck.X - points[1].X);
            y1 = Math.Abs(pointToCheck.Y - points[1].Y);

            x2 = Math.Abs(points[1].X - points[2].X);
            y2 = Math.Abs(points[1].Y - points[2].Y);

            // should only be negative when starting out.
            int area2 = (DotProduct(x1, y1, x2, y2)) / 2;
            //need to check and fix bug ******************************************
            if (area2 < 0 && pointToCheck.X > points[0].X) return false;

            x1 = Math.Abs(points[0].X - points[2].X);
            y1 = Math.Abs(points[0].Y - points[2].Y);

            x2 = Math.Abs(pointToCheck.X - points[2].X);
            y2 = Math.Abs(pointToCheck.Y - points[2].Y);

            int area3 = (DotProduct(x1, y1, x2, y2)) / 2;

            if (area3 < 0) return false;

            decimal p = (area1 + area2 + area3) / (decimal)normalArea;


            //debugging
            if (pointToCheck.X > 190 && pointToCheck.Y == 0)
            {
                ;
            }

            if (p <= 1 && p >= 0)
            {
                return true;
            }

            return false;
        }

        public void Draw(Bitmap backBuffer)
        {
            for (int x = HitBox.X; x < HitBox.X + HitBox.Width; x++)
            {
                for (int y = HitBox.Y; y < HitBox.Y + HitBox.Height; y++)
                {
                    if (IsInTriangle(new Point(x, y)))
                    {
                        backBuffer.SetPixel(x, y, Color.FromArgb((int)(x / ((decimal)(HitBox.X + HitBox.Width)) * 255),
                                                                 (int)(y / (decimal)(HitBox.Y + HitBox.Height) * 255),
                                                                 (int)((HitBox.Y + HitBox.Height - y) / (decimal)(HitBox.Y + HitBox.Height) * 255)));
                    }
                }

            }
        }
    }
}