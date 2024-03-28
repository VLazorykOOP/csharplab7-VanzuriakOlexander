using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace task3
{
    public partial class Form1 : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        public enum ShapeType
        {
            Rectangle,
            Triangle,
            Circle,
            Rhombus
        }

        public abstract class Shape
        {
            protected int x;
            protected int y;

            public Shape(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public abstract void Draw(Graphics g);
            public void MoveTo(int newX, int newY)
            {
                x = newX;
                y = newY;
            }
        }

        // Похідний клас для трикутника
        // Похідний клас для прямокутника
        public class RectangleShape : Shape
        {
            private readonly int width;
            private readonly int height;

            public RectangleShape(int x, int y, int width, int height) : base(x, y)
            {
                this.width = width;
                this.height = height;
            }

            public override void Draw(Graphics g)
            {
                g.DrawRectangle(Pens.Green, new Rectangle(x, y, width, height));
            }
        }

        // Похідний клас для трикутника
        public class TriangleShape : Shape
        {
            private readonly int sideLength;

            public TriangleShape(int x, int y, int sideLength) : base(x, y)
            {
                this.sideLength = sideLength;
            }

            public override void Draw(Graphics g)
            {
                Point[] points =
                {
            new Point(x + sideLength / 2, y),
            new Point(x, y + sideLength),
            new Point(x + sideLength, y + sideLength)
        };
                g.DrawPolygon(Pens.Red, points);
            }
        }

        // Похідний клас для кола
        public class CircleShape : Shape
        {
            private readonly int radius;

            public CircleShape(int x, int y, int radius) : base(x, y)
            {
                this.radius = radius;
            }

            public override void Draw(Graphics g)
            {
                g.DrawEllipse(Pens.Blue, new Rectangle(x - radius, y - radius, 2 * radius, 2 * radius));
            }
        }

        public class RhombusShape : Shape
        {
            private readonly int sideLength;

            public RhombusShape(int x, int y, int sideLength) : base(x, y)
            {
                this.sideLength = sideLength;
            }

            public override void Draw(Graphics g)
            {
                Point[] points =
                {
            new Point(x, y + sideLength / 2),
            new Point(x + sideLength / 2, y),
            new Point(x + sideLength, y + sideLength / 2),
            new Point(x + sideLength / 2, y + sideLength)
        };
                g.DrawPolygon(Pens.Purple, points);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            random = new Random();
            ShapeType shapeType = (ShapeType)random.Next(4); // Змінено на 4 для врахування ромба

            int x = random.Next(pictureBox1.Width);
            int y = random.Next(pictureBox1.Height);

            // Вибираємо випадкові параметри для фігури
            int param1 = random.Next(10, 100);

            // Створюємо екземпляр фігури
            Shape shape;
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    shape = new RectangleShape(x, y, param1, param1); // Параметри змінені на param1 для квадрата
                    break;
                case ShapeType.Triangle:
                    shape = new TriangleShape(x, y, param1);
                    break;
                case ShapeType.Circle:
                    shape = new CircleShape(x, y, param1);
                    break;
                case ShapeType.Rhombus: // Додано обробку ромба
                    shape = new RhombusShape(x, y, param1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            shapes.Add(shape);

            // Оновлюємо відображення малюнка
            RefreshDrawing();
        }

        private void RefreshDrawing()
        {
            // Створюємо нове зображення
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            // Рисуємо всі фігури на зображенні
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var shape in shapes)
                {
                    shape.Draw(g);
                }
            }

            // Відображаємо зображення на PictureBox
            pictureBox1.Image = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);
            }
        }
    }
}
