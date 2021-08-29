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

            triangle = new Triangle(pointA: new Point(0, 0), pointB: new Point(200, 0), pointC: new Point(100, 200), color: Color.Red); 

            Draw();
        }

        private void Draw()
        {
            triangle.Draw(backBuffer);

            canvas.Image = backBuffer;
        }
    }
}
