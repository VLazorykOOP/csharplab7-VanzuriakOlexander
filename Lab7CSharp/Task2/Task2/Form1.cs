namespace Task2
{
    public partial class Form1 : Form
    {
        private Font drawFont = new Font("Arial", 10);
        private Color drawColor = Color.Black;
        public Form1()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.White);

                Pen pen = new Pen(drawColor);

                for (float x = 0.1f; x < 4; x += 0.1f)
                {
                    float y = (float)(Math.Sin(x) / x);
                    g.DrawEllipse(pen, x * 50, (float)(pictureBox1.Height / 2 - y * 50), 1, 1);
                }

                string func = "y = sin(x)/x";
                g.DrawString(func, drawFont, new SolidBrush(drawColor), new PointF(10, 10));
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            {
                drawColor = fontDialog1.Color;
                drawFont = fontDialog1.Font;
            }
        }
    }
}
