using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Color currentColor = Color.Black; 
        private Point previousPoint;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.MouseDown += PictureBoxMouseDown;
            pictureBox1.MouseMove += PictureBoxMouseMove;
            pictureBox1.Paint += PictureBoxPaint;
        }

        private void PictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                previousPoint = e.Location;
            }
        }

        private void PictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawLine(new Pen(currentColor, 2), previousPoint, e.Location);
                }
                previousPoint = e.Location;
            }
        }

        private void PictureBoxPaint(object sender, PaintEventArgs e)
        {
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currentColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentColor = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentColor = Color.Green;
        }
    }
}
