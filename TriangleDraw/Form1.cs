using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleDraw
{
    public partial class MainFrom : Form
    {
        Graphics graphics;
        Bitmap backBuffer;

        Triangle triangle;

        public MainFrom()
        {
            InitializeComponent();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            backBuffer = new Bitmap(canvas.Width, canvas.Height);
            graphics = Graphics.FromImage(backBuffer);

            int width = 200;
            int height = 200;
            int x = 0;// canvas.Width / 2 - width / 2;
            int y = 0;// canvas.Height / 2 - height / 2;

            Point[] points = new Point[3] 
            { 
                new Point(x, y), 
                new Point(x + width, y), 
                new Point(x + width / 2, y + height) 
            };

            Point1XTextBox.Text = points[0].X.ToString();
            Point1YTextBox.Text = points[0].Y.ToString();
            Point2XTextBox.Text = points[1].X.ToString();
            Point2YTextBox.Text = points[1].Y.ToString();
            Point3XTextBox.Text = points[2].X.ToString();
            Point3YTextBox.Text = points[2].Y.ToString();

            triangle = new Triangle(pointA: points[0],
                                    pointB: points[1],
                                    pointC: points[2], color: Color.Red);
//            triangle = new Triangle(pointA: new Point(0, 0), pointB: new Point(190, 0), pointC: new Point(200, 200), color: Color.Red);
            Draw();
        }

        private void Draw()
        {
            graphics.Clear(canvas.BackColor);

            triangle.Draw(backBuffer);

            canvas.Image = backBuffer;
        }

        private void Point1XButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Point1XTextBox.Text);
            Point[] points = { new Point(x, triangle.points[0].Y),
                               new Point(triangle.points[1].X, triangle.points[1].Y),
                               new Point(triangle.points[2].X, triangle.points[2].Y)};
            triangle.UpdateTriangle(points);
            Draw();            
        }

        private void Point1YButton_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Point1YTextBox.Text);
            Point[] points = { new Point(triangle.points[0].X, y),
                               new Point(triangle.points[1].X, triangle.points[1].Y),
                               new Point(triangle.points[2].X, triangle.points[2].Y)};
            triangle.UpdateTriangle(points);
            Draw();
        }

        private void Point2XButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Point2XTextBox.Text);
            Point[] points = { new Point(triangle.points[0].X, triangle.points[0].Y),
                               new Point(x, triangle.points[1].Y),
                               new Point(triangle.points[2].X, triangle.points[2].Y)};
            triangle.UpdateTriangle(points);
            Draw();
        }

        private void Point2YButton_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Point2YTextBox.Text);
            Point[] points = { new Point(triangle.points[0].X, triangle.points[0].Y),
                               new Point(triangle.points[1].X, y),
                               new Point(triangle.points[2].X, triangle.points[2].Y)};
            triangle.UpdateTriangle(points);
            Draw();
        }

        private void Point3XButton_Click(object sender, EventArgs e)
        {
            int x = int.Parse(Point3XTextBox.Text);
            Point[] points = { new Point(triangle.points[0].X, triangle.points[0].Y),
                               new Point(triangle.points[1].X, triangle.points[1].Y),
                               new Point(x, triangle.points[2].Y)};
            triangle.UpdateTriangle(points);
            Draw();
        }

        private void Point3YButton_Click(object sender, EventArgs e)
        {
            int y = int.Parse(Point3YTextBox.Text);
            Point[] points = { new Point(triangle.points[0].X, triangle.points[0].Y),
                               new Point(triangle.points[1].X, triangle.points[1].Y),
                               new Point(triangle.points[2].X, y)};
            triangle.UpdateTriangle(points);
            Draw();
        }
    }
}
