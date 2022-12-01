using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lb3s3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private int SHIFT = 395;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = CreateGraphics();
            Pen BlPen   = new Pen(Color.Black);       // Створити новий об'єкт класу олівець
            BlPen.Width = 8.0F;                     // Визначаємо його товщину
            gr.DrawLine(BlPen, 100, 100, 500, 100); // Відображаємо лінію (вісь балки)
            BlPen.Width = 2.0F;                     // Змінюємо товщину

            // Малюємо умовне позначення рівномірно діючого тиску
            for (int i = 0; i < 10; i++)
            {
                gr.DrawLine(BlPen, 120 + i * 400 / 10, 100, 120 + i * 400 / 10, 60);
                gr.DrawLine(BlPen, 120 + i * 400 / 10, 100, 120 + i * 400 / 10 - 5, 85);
                gr.DrawLine(BlPen, 120 + i * 400 / 10, 100, 120 + i * 400 / 10 + 5, 85);
            };
            gr.DrawLine(BlPen, 120, 60, 480, 60);

            // Малюємо трикутник, що позначає «Шарнір» на лівому краю балки
            if (checkBox1.Checked == true)
            {
                gr.DrawLine(BlPen, 102, 104, 80, 120);
                gr.DrawLine(BlPen, 80, 120, 120, 120);
                gr.DrawLine(BlPen, 120, 120, 102, 104);
            }

            if (checkBox2.Checked == true)
            {
                gr.DrawLine(BlPen, 100, 70, 100, 130);
            }

            if (checkBox3.Checked == true) {

                gr.DrawLine(BlPen, 100 + SHIFT + 5, 70, 100 + SHIFT + 5, 130);
            }

            if (checkBox4.Checked == true) {

                gr.DrawLine(BlPen, 102 + SHIFT, 104, 80  + SHIFT, 120);
                gr.DrawLine(BlPen, 80  + SHIFT, 120, 120 + SHIFT, 120);
                gr.DrawLine(BlPen, 120 + SHIFT, 120, 102 + SHIFT, 104);
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false; // Відзначити checkBox1 невиділеним
            }
            this.Refresh(); // Якщо checkBox2 виділено
            Application.DoEvents();
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false; // Відзначити checkBox1 невиділеним
            }
            this.Refresh(); // Якщо checkBox2 виділено
            Application.DoEvents();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Перевірка натискання правої кнопки миші
            //і попадання курсора в цей момент у прямокутник, що обмежує лівий край балки
            
            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (e.X > 75) && (e.X < 130) && (e.Y > 75) && (e.Y < 135))
            {
                panel1.Visible = true; // Відобразити панель
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel1.Visible = false;
            }

            if ((e.Button == System.Windows.Forms.MouseButtons.Right) && (e.X > 75 + SHIFT) && (e.X < 130 + SHIFT) && (e.Y > 75) && (e.Y < 135))
            {
                panel2.Visible = true; // Відобразити панель
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                panel2.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Checked = false; // Відзначити checkBox1 невиділеним
            }
            this.Refresh(); // Якщо checkBox2 виділено
            Application.DoEvents();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox4.Checked = false; // Відзначити checkBox1 невиділеним
            }
            this.Refresh(); // Якщо checkBox2 виділено
            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = CreateGraphics();
            Pen BLPen = new Pen(Color.Red);
            BLPen.Width = 2.0F;
            richTextBox1.Clear();
            richTextBox1.AppendText("Sector Clear\n");

            char[][] boxes = new char[4][];

            boxes[0] = Convert.ToString(textBox1.Text).ToCharArray();
            boxes[1] = Convert.ToString(textBox2.Text).ToCharArray();
            boxes[2] = Convert.ToString(textBox3.Text).ToCharArray();
            boxes[3] = Convert.ToString(textBox4.Text).ToCharArray();
  
            if (Coma(boxes) == true)
            {
                string[] textBoxes = new string[] { new string(boxes[0]), new string(boxes[1]), new string(boxes[2]), new string(boxes[3]) };
                float Q, L, I, E, b, h, y, y_max;
                Q = (float)Math.Pow(10, 3) * (float)Convert.ToDouble(textBoxes[0]); // розподілкна нагрузка, у Н ~1000000
                L = (float)Convert.ToDouble(textBoxes[1]); // довжина балки (10 м)
                b = (float)Convert.ToDouble(textBoxes[2]); // попер.переріз (0,1м)
                h = (float)Convert.ToDouble(textBoxes[3]); // попер.переріз (0,1м)
                E = (float)(2 * Math.Pow(10, 11));          // Модуль пружності (2000000000)
                I = (float)(h * Math.Pow(b, 3)) / 12;       // момент інерції 

                if (checkBox1.Checked == true && checkBox4.Checked == true)//v
                {
                    this.Refresh();
                    y_max = Function_hingle(L / 2, I, E, Q, L);
                    for (float x = 0; x < L; x += 1f)
                    {
                        y = Function_hingle(x, I, E, Q, L);
                        //gr.DrawRectangle(BLPen, (float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                        gr.DrawArc(BLPen,(float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100),3f,3f,0,360);
                        //gr.DrawEllipse(BLPen, (float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                    }

                    richTextBox1.AppendText("I =" + Convert.ToString(I) + "\n");
                    richTextBox1.AppendText("Максимальный прогиб = " + Convert.ToString(y_max) + "\n");
                }
                if (checkBox2.Checked == true && checkBox3.Checked == true)//v
                {
                    this.Refresh();
                    y_max = Function_seal(2, I, E, Q, L);
                    for (float x = 0; x < L; x += 0.03f)
                    {
                        y = Function_seal(x, I, E, Q, L);
                        gr.DrawRectangle(BLPen, (float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                    }
                    richTextBox1.AppendText("I = " + Convert.ToString(I) + "\n");
                    richTextBox1.AppendText("Максимальный прогиб = " + Convert.ToString(y_max) + "\n");
                }

                if (checkBox1.Checked == true && checkBox3.Checked == true)
                {
                    this.Refresh();
                    y_max = Function_hingle_seal(2, I, E, Q, L);
                    for (float x = 0; x < L; x += 0.03f)
                    {
                        y = Function_hingle_seal(x, I, E, Q, L);
                        gr.DrawRectangle(BLPen, (float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                    }
                    richTextBox1.AppendText("I = " + Convert.ToString(I) + "\n");
                    richTextBox1.AppendText("Максимальный прогиб = " + Convert.ToString(y_max) + "\n");
                }

                //if (checkBox1.Checked == true && checkBox3.Checked == true)
                //{
                //    this.Refresh();
                //    y_max = Function_one_seal(2, I, E, Q, L);
                //    for (float x = 0; x < L; x += 0.03f)
                //    {
                //        y = Function_one_seal(x, I, E, Q, L);
                //        gr.DrawRectangle(BLPen, (float)((x / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                //    }
                //    richTextBox1.AppendText("I = " + Convert.ToString(I) + "\n");
                //    richTextBox1.AppendText("Максимальный прогиб = " + Convert.ToString(y_max) + "\n");
                //}

                if (checkBox2.Checked == true && checkBox4.Checked == true)
                {
                    this.Refresh();
                    y_max = Function_hingle_seal(2, I, E, Q, L);
                    for (float x = L; x > 0; x -= 0.03f)
                    {
                        y = Function_hingle_seal(x, I, E, Q, L);
                        gr.DrawRectangle(BLPen, (float)((Math.Abs(x - L) / L) * 4 * 100 + 100), (float)((y) * 100 + 100), 1f, 1f);
                    }
                    richTextBox1.AppendText("I = " + Convert.ToString(I) + "\n");
                    richTextBox1.AppendText("Максимальный прогиб =" + Convert.ToString(y_max) + "\n");
                }

            }
            else { MessageBox.Show("Ведите все значения корректно!"); }
        }

        private float Function_hingle(float x, float I, float E, float q, float L) // шарнір-шарнір
        {
            return (float)(q * Math.Pow(x, 4) - 2 * q * L * Math.Pow(x, 3) + q * Math.Pow(L, 3) * x) / (24 * E * I);
        }

        private float Function_seal(float x, float I, float E, float q, float L) // закріплення-закріплення
        {
            return (float)(q * Math.Pow(x, 2) * Math.Pow(x - L, 2)) / (24 * E * I);
        }

        private float Function_hingle_seal(float x, float I, float E, float q, float L) // шарнір-закріплення
        {
            return (float)((q * x * (2 * Math.Pow(x, 3) - 3 * L * x * x + Math.Pow(L, 3))) / (48 * E * I));
        }

        private float Function_one_seal(float x, float I, float E, float q, float L) // не розглядаємо
        {
            return (float)(-((q * Math.Pow(x, 2)) / (12 * E * I)) * (2 * L * x - 3 * Math.Pow(L, 2) - (Math.Pow(x, 2) / 2)));
        }

        private bool Coma(char[][] args)
        {
            for (int i = 0; i < 4; i++)
            {
                int k = args[i].Length;
                bool coma = true; // [0,1] true (2...) false


                for (int j = 0; j < args[i].Length; j++)
                {
                    if (args[i][j] < 48 || args[i][j] > 57)
                    {
                        if ((args[i][j] == '.' || args[i][j] == ',') && j != 0)
                        {
                            if (coma)
                            {
                                args[i][j] = ',';
                                coma = false;
                            }
                            else
                                return false;
                        }
                    }


                 }


            }

            return true;
        }
    }
}
