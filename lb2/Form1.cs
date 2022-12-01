using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb2s3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Red;
            panel2.BackColor = Color.LightGray;
            panel3.BackColor = Color.LightGray;

            textBox2.Visible = false;
            label3.Visible   = false;
            label4.Visible   = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.LightGray;
            panel2.BackColor = Color.LightGray;
            panel3.BackColor = Color.Red;

            textBox2.Visible = true;
            label3.Visible   = true;
            label4.Visible   = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.LightGray;
            panel2.BackColor = Color.Red;
            panel3.BackColor = Color.LightGray;

            textBox2.Visible = true;
            label3.Visible   = true;
            label4.Visible   = true;
        }

        private void вычислитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double k, b = 0.0;
            double R = Convert.ToDouble(textBox1.Text);

            if (panel1.BackColor != Color.Red)
                b = Convert.ToDouble(textBox2.Text);
             
            double L1 = Convert.ToDouble(textBox3.Text);
            double L2 = Convert.ToDouble(textBox4.Text);
            double E1 = Convert.ToDouble(textBox5.Text);

            label9.Text = Convert.ToString(L1) + " мм";
            label10.Text  = Convert.ToString(L2) + " мм";
            double S  = 0;

            if (panel1.BackColor == Color.Red) S = 3.14159265 * R * R;
            if (panel2.BackColor == Color.Red) S = R * b;
            if (panel3.BackColor == Color.Red) S = 0.5 * (R * b);

            double k1 = E1 * S / L1;
            double k2 = E1 * S / L2;
            k = (k1 * k2 / (k1 + k2));

            richTextBox1.AppendText("Жорсткості ділянок дорівнюють:\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("k1: " + Convert.ToString(k1) + "\n");
            richTextBox1.AppendText("k2: " + Convert.ToString(k2) + "\n");
            richTextBox1.AppendText("k: "  + Convert.ToString(k)  + "\n");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("~~~~~~~~~~~~~~~~~~");
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText("\n");
        }
    }
}
