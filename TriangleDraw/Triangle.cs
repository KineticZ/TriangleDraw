using System;
using System.Drawing;

namespace TriangleDraw
{
    internal class Triangle
    {
        private int width;
        private int height;
        private Color color;
        private Point pointA;
        private Point pointB;
        private Point pointC;     

        public Triangle(Point pointA, Point pointB, Point pointC, Color color)
        {
            this.pointA = pointA;
            this.pointB = pointB;
            this.pointC = pointC;
            this.color = color;

            width = pointB.X - pointA.X;
            height = pointC.Y - pointA.Y;
        }

        private int DotProduct(int x1, int y1, int x2, int y2)
        {
            return (x1 * y2) - (x2 * y1);
        }
        private bool IsInTriangle(Point pointToCheck)
        {
            int x1 = Math.Abs(pointToCheck.X - pointB.X);
            int y1 = Math.Abs(pointToCheck.Y - pointB.Y);

            int x2 = Math.Abs(pointToCheck.X - pointA.X);
            int y2 = Math.Abs(pointToCheck.Y - pointA.Y);

            int area1 = (DotProduct(x1, y1, x2, y2)) / 2;

            x1 = Math.Abs(pointToCheck.X - pointA.X);
            y1 = Math.Abs(pointToCheck.Y - pointA.Y);

            x2 = Math.Abs(pointToCheck.X - pointC.X);
            y2 = Math.Abs(pointToCheck.Y - pointC.Y);

            int area2 = (DotProduct(x1, y1, x2, y2)) / 2;

            x1 = Math.Abs(pointToCheck.X - pointC.X);
            y1 = Math.Abs(pointToCheck.Y - pointC.Y);

            x2 = Math.Abs(pointToCheck.X - pointB.X);
            y2 = Math.Abs(pointToCheck.Y - pointB.Y);

            int area3 = (DotProduct(x1, y1, x2, y2)) / 2;

            

            return false;
        }

        public void Draw(Bitmap backBuffer)
        {

        }
    }
}