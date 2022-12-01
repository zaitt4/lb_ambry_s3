using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace lb7s3
{
    public partial class Form1 : Form
    {
        double a = 0, b = 0, c = -5, dx = 0, dy = 0, dz = 0, R = 1;
        int hh = 0, mm = 0, ss = 0;

       
        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit(); // ініціалізація бібліотеки Glut
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE); // ініціалізація режиму екрану
            Gl.glClearColor(1, 1, 1, 1); // встановлення кольору очищення екрану (RGBA)
            Gl.glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);// встановлення порту виведення
            Gl.glMatrixMode(Gl.GL_PROJECTION); // активація проекційної матриці
            Gl.glLoadIdentity(); // очищення матриці
                                 // Встановлення перспективи
            Glu.gluPerspective(45, (float)simpleOpenGlControl1.Width / (float)simpleOpenGlControl1.Height, 0.1, 200);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            // початкове налаштування параметрів openGL (тест глибини, перше джерело світла)
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            //Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            //timer1.Start();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            a = (double)trackBar1.Value / 1000.0; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label1.Text = a.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = (double)trackBar2.Value / 1000.0;
            label2.Text = b.ToString();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            c = (double)trackBar3.Value;
            label3.Text = c.ToString();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            dx = (double)trackBar4.Value;
            label5.Text = dx.ToString();
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            dy = (double)trackBar5.Value;
            label6.Text = dy.ToString();
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            dz = (double)trackBar6.Value;
            label7.Text = dz.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Draw() //
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); // очищення буфера кольору та буфера глибини
            Gl.glClearColor(1, 1, 1, 1); // очищення поточної матриці
            Gl.glLoadIdentity(); // поміщаємо стан матриці в стек матриць, подальші трансформації торкнуться лише візуалізації об'єкта
            Gl.glPushMatrix();

            Gl.glTranslated(a, b, c); //переміщення

            Gl.glRotated(dx, 1, 0, 0); // Поворот по встановленій осі
            Gl.glRotated(dy, 0, 1, 0);
            Gl.glRotated(dz, 0, 0, 1);
           
            double[] pos = new double[3] { a, b, c};
            double[] pos1 = new double[3] { a - 1, b, c + 4};
            double[] rot = new double[3] { dx, dy, dz};
            int[] Time = new int[3] { hh, mm, ss };
            int[] Time1 = new int[3] { 6, 14, 55 };
            getEntryTxt();
            //Glut.glutWireTeapot(1);
            //Shaft k = new Shaft(ref pos, ref rot, 0.1, 0.8);
            //k.Draw(simpleOpenGlControl1);


            Clock c1 = new Clock(ref pos, ref rot, ref Time, R);
            
            c1.Draw();
            Clock c2 = new Clock(ref pos1, ref rot, ref Time1, R);
            c2.Draw();
            

            Gl.glPopMatrix();// повертаємо стан матриці
            Gl.glFlush();// завершуємо малювання
            simpleOpenGlControl1.Invalidate(); // оновлюємо елемент simpleOpenGlControl1
        }

        public void getEntryTxt()
        {
            try { R = Convert.ToDouble(textBox1.Text); }
            catch { R = 1; }

            try { hh = Convert.ToInt32(textBox2.Text); }
            catch { hh = 0; }

            try { mm = Convert.ToInt32(textBox3.Text); }
            catch { mm = 0; }

            try { ss = Convert.ToInt32(textBox4.Text); }
            catch { ss = 0; }
        }
    }
}
