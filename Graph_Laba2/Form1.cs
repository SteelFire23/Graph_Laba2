using System;
using System.Drawing;
using System.Windows.Forms;

namespace Graph_Laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.White);
            Form2 form = new Form2();
            form.Owner = this;
            form.ShowDialog();
            // Запоминаем цвет пользователя
            //
            if (form.button1.DialogResult == DialogResult.OK)
            {
                if (int.Parse(form.textBox1.Text) < 255 && int.Parse(form.textBox2.Text) < 255 && int.Parse(form.textBox3.Text) < 255)
                {
                    Global.color = Color.FromArgb(int.Parse(form.textBox1.Text), int.Parse(form.textBox2.Text), int.Parse(form.textBox3.Text));
                }
                else
                {
                    MessageBox.Show("Числа должны быть меньше или равны 255");
                    form.ShowDialog();
                }
            }
            //
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Pixel;

            printMain(g, 800, 400, 1);//ширина и высота pictureBox1
            showGraphics(g, 800, 400, Global.color, 1);
        }
        public static void printMain(Graphics g,float Width, float Height,int n)
        {
            //Определяем каким пером выводить систему кооднинат
            //
            Pen pen = new Pen(Color.Red, 0);
            if (n == 1) pen = new Pen(Color.Red, 1);
            else if (n == 2) pen = new Pen(Color.Red, 0.3f);
            else if (n == 3) pen = new Pen(Color.Red, 0.005f);
            //
            //Рисуем её
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            g.DrawLine(pen, (Width -1) / 2, 0, (Width-1) / 2, Height-1);
            g.DrawLine(pen, 0, (Height-1) / 2, Width-1, (Height-1) / 2);
            //
        }
        public static void showGraphics(Graphics g, float MaxX, float MaxY, Color color, int n)
        {
            //Определяем каким пером выводить график
            //
            Pen p = new Pen(color, 0);
            if (n == 1) p = new Pen(color, 1.8f);
            else if (n == 2) p = new Pen(color, 0.5f);
            else if (n == 3) p = new Pen(color, 0.01f);
            //
            
            g.TranslateTransform(MaxX/2, MaxY/2);// начало координат в центре

            PointF[] point = new PointF[(int)MaxX];

            //Правая часть
            for (int i = 0; i < point.Length; i++)
            {
                point[i].X = i;
                point[i].Y = (float)(1 - (Math.Cos(i * (4 * Math.PI / MaxX) - 1)) * MaxY / 4) - Math.Abs(i);
            }
            g.DrawLines(p, point);
            //Левая часть
            for (int i = 0; i < point.Length; i++)
            {
                point[i].X = -i;
                point[i].Y = (float)(1 - (Math.Cos(i * (4 * Math.PI / MaxX) + 1)) * MaxY / 4) + Math.Abs(i);
            }
            g.DrawLines(p, point);
            //
            p.Dispose();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();           
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Millimeter;

            float width_M = (float)(((pictureBox1.Width - 1) / g.DpiX * 25.4) + 1);//ширина в миллиметрах
            float height_M = (float)(((pictureBox1.Height - 1) / g.DpiY * 25.4) + 1);//высота в миллиметрах
            
            printMain(g, width_M, height_M, 2);            
            showGraphics(g,width_M,height_M, Global.color, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Inch;

            float width_I = (float)(((pictureBox1.Width - 1) / g.DpiX) + 1);//ширина в дюймах
            float height_I = (float)(((pictureBox1.Height - 1) / g.DpiY) + 1);//высота в дюймах           
            printMain(g, width_I, height_I, 3);

            showGraphics(g,width_I - 2, height_I - 2, Global.color, 3); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Global.color);
        }
    }
    class Global
    {
        public static Color color;
    }

}
