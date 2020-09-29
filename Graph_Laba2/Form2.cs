using System;
using System.Windows.Forms;

namespace Graph_Laba2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
        }
    }
}
