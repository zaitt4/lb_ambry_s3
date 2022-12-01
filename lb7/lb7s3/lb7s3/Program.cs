using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Platform;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace lb7s3
{

    class Block
    {
        double[] location = new double[3];
        double[] rotation = new double[3];
        public double R, W;
        int z;
        int rot;
        public Block(ref double[] location_, ref double[] rotation_, double gR, double gW, int z_)
        {
            location = location_;
            rotation = rotation_;
            R = gR;
            W = gW;
            z = z_;
            int step = 0;
            try
            {
                step = 360 / z;
            }
            catch { }
            double r = R;
            double k = 1.1;
            int i;
        }
        public void Draw(Tao.Platform.Windows.SimpleOpenGlControl GlCont, int rot, bool activated)
        {
            Gl.glLoadIdentity(); // поміщаємо стан матриці в стек матриць, подальші трансформації торкнуться лише візуалізації об'єкта
            Gl.glPushMatrix();
            Gl.glTranslated(location[0], location[1], location[2]);
            Gl.glRotated(rotation[0], 1, 0, 0);
            Gl.glRotated(rotation[1], 0, 1, 0);
            Gl.glRotated(rotation[2] + rot, 0, 0, 1);
            for (int i = -1; i <= 1; i += 2)
            {
                if (activated) Gl.glColor3d(1, 0, 0);
                else Gl.glColor3d(0, 1, 0);
                Glut.glutSolidCylinder(1.01 * R, 0.99 * i * W / 2, 64, 64);
                if (activated) Gl.glColor3d(1, 1, 1);
                else Gl.glColor3d(0, 0, 1);
                Glut.glutSolidCylinder(R, i * W / 2, 64, 64);
            }
            Gl.glPopMatrix(); // Повертаємо стан матриці
            Gl.glFlush(); // Завершуємо малювання
            GlCont.Invalidate(); // оновлюємо елемент simpleOpenGlControl1
        }
    }
    class Shaft
    {
        public double[] location = new double[3];
        public double[] rotation = new double[3];
        public double R, W;
        public List<double> xList = new List<double>();
        public List<double> yList = new List<double>();
        public List<double> zList = new List<double>();
        public Shaft(ref double[] location_, ref double[] rotation_, double gR, double gW)
        {
            location = location_;
            rotation = rotation_;
            R = gR;
            W = gW;
        }
        public void Draw(Tao.Platform.Windows.SimpleOpenGlControl GlCont)
        {
            Gl.glLoadIdentity(); // поміщаємо стан матриці в стек матриць, подальші трансформації торкнуться лише візуалізації об'єкта
            Gl.glPushMatrix();
            Gl.glTranslated(location[0], location[1], location[2]);
            Gl.glRotated(rotation[0], 1, 0, 0);
            Gl.glRotated(rotation[1], 0, 1, 0);
            Gl.glRotated(rotation[2], 0, 0, 1);
            for (int i = -1; i <= 1; i += 2)
            {
                Gl.glColor3d(0, 1, 0);
                Glut.glutSolidCylinder(1.01 * R, 0.99 * i * W / 2, 64, 64);
                Gl.glColor3d(0, 0, 1);
                Glut.glutSolidCylinder(R, i * W / 2, 320, 320);
            }
            Gl.glPopMatrix(); // Повертаємо стан матриці
            Gl.glFlush(); // Завершуємо малювання
            //GlCont.Invalidate(); // оновлюємо елемент simpleOpenGlControl1
        }

    }


    class Clock
    {

        double R;
        double[] position = new double[3];
        double[] rotation = new double[3];
        int[] time = new int[3] { 0, 0, 0 };

        public Clock(ref double[] position, ref double[] rotation, ref int[] time, double radius)
        {
            R = radius;
            this.position = position;
            this.rotation = rotation;
            this.time     = time;
        }

        public void Draw()
        {
            Gl.glLoadIdentity(); // поміщаємо стан матриці в стек матриць, подальші трансформації торкнуться лише візуалізації об'єкта
            Gl.glPushMatrix();
            Gl.glTranslated(position[0], position[1], position[2]);
            Gl.glRotated(rotation[0], 1, 0, 0); // Поворот по встановленій осі
            Gl.glRotated(rotation[1], 0, 1, 0);
            Gl.glRotated(rotation[2], 0, 0, 1);

            double x, y;

            //Зовнішня границя
            Gl.glColor3d(1, 0.5, 0.5);
            //Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (int angle = 0; angle <= 360; angle += 10)
            {
                x = R * Math.Cos(angle * Math.PI / 180);
                y = R * Math.Sin(angle * Math.PI / 180);
                Gl.glVertex3d(x, y, -0.3 * R);
                Gl.glVertex3d(x, y, 0);
            }
            Gl.glEnd();

            //Внутрішня границя
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (int angle = 0; angle <= 360; angle += 10)
            {
                x = 0.9 * R * Math.Cos(angle * Math.PI / 180);
                y = 0.9 * R * Math.Sin(angle * Math.PI / 180);
                Gl.glVertex3d(x, y, -0.3 * R);
                Gl.glVertex3d(x, y, 0);
            }
            Gl.glEnd();

            //Внутрішня заливка (заливка дна)
            Gl.glColor3d(0.5, 1, 0.5);
            Gl.glBegin(Gl.GL_POLYGON);
            for (int angle = 0; angle <= 360; angle += 10)
            {
                x = 0.9 * R * Math.Cos(angle * Math.PI / 180);
                y = 0.9 * R * Math.Sin(angle * Math.PI / 180);
                Gl.glVertex3d(x, y, -0.3*R);
            }
            Gl.glEnd();


            //Заливка проміжку між стінками зовнішньої та внутрішньої границі
            Gl.glColor3d(0.5, 0.5, 1);
            Gl.glBegin(Gl.GL_QUAD_STRIP);
            for (int angle = 0; angle <= 360; angle += 10)
            {
                x = 0.9 * R * Math.Cos(angle * Math.PI / 180);
                y = 0.9 * R * Math.Sin(angle * Math.PI / 180);
                Gl.glVertex3d(x, y, 0);
                x = 1 * R * Math.Cos(angle * Math.PI / 180);
                y = 1 * R * Math.Sin(angle * Math.PI / 180);
                Gl.glVertex3d(x, y, 0);
            }
            Gl.glEnd();



            //Циферблат (римський)

            // I Початок
            int ang = 60; 
            double bot_border = 0.7 * R, top_border = 0.9 * R;

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glVertex3d(x + 0.06 * R, y + 0.07 * R, -0.285*R); // 1
            Gl.glVertex3d(x + 0.06 * R, y + 0.1 * R, -0.285*R);  // 2

            Gl.glVertex3d(x - 0.06 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.06 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.01 * R, y + 0.07 * R, -0.285*R);   // 5
            Gl.glVertex3d(x - 0.01 * R, y - 0.07 * R, -0.285*R); // 6

            Gl.glVertex3d(x + 0.01 * R, y - 0.07 * R, -0.285*R); //11
            Gl.glVertex3d(x + 0.01 * R, y + 0.07 * R, -0.285*R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.06 * R, y - 0.07 * R, -0.285*R); //7
            Gl.glVertex3d(x - 0.06 * R, y - 0.1 * R, -0.285*R); // 8

            Gl.glVertex3d(x + 0.06 * R, y - 0.1 * R, -0.285*R); //9
            Gl.glVertex3d(x + 0.06 * R, y - 0.07 * R, -0.285*R); // 10
            Gl.glEnd();

            // I кінець

            ang = 30;

            // II початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glVertex3d(x - 0.06 * R, y + 0.07 * R, -0.285*R); // 1
            Gl.glVertex3d(x - 0.06 * R, y + 0.1 * R, -0.285*R);  // 2

            Gl.glVertex3d(x - 0.18 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.18 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.11 * R, y + 0.07 * R, -0.285*R);   // 5
            Gl.glVertex3d(x - 0.11 * R, y - 0.07 * R, -0.285*R); // 6

            Gl.glVertex3d(x - 0.13 * R, y - 0.07 * R, -0.285*R); //11
            Gl.glVertex3d(x - 0.13 * R, y + 0.07 * R, -0.285*R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.06 * R, y - 0.07 * R, -0.285*R); //7
            Gl.glVertex3d(x - 0.06 * R, y - 0.1 * R, -0.285*R); // 8

            Gl.glVertex3d(x - 0.18 * R, y - 0.1 * R, -0.285*R); //9
            Gl.glVertex3d(x - 0.18 * R, y - 0.07 * R, -0.285*R); // 10
            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285*R); // 1
            Gl.glVertex3d(x + 0.08 * R, y + 0.1 * R, -0.285*R);  // 2

            Gl.glVertex3d(x - 0.04 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.04 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.01 * R, y + 0.07 * R, -0.285*R);   // 5
            Gl.glVertex3d(x + 0.01 * R, y - 0.07 * R, -0.285*R); // 6

            Gl.glVertex3d(x + 0.03 * R, y - 0.07 * R, -0.285*R); //11
            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285*R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.04 * R, y - 0.07 * R, -0.285*R); //7
            Gl.glVertex3d(x - 0.04 * R, y - 0.1 * R, -0.285*R); // 8

            Gl.glVertex3d(x + 0.08 * R, y - 0.1 * R, -0.285*R); //9
            Gl.glVertex3d(x + 0.08 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();

            // ΙΙ кінець

            ang = 0;

            // III початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glVertex3d(x - 0.18 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x - 0.18 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.3 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.3 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.25 * R, y + 0.07 * R, -0.285*R);   // 5
            Gl.glVertex3d(x - 0.25 * R, y - 0.07 * R, -0.285*R); // 6

            Gl.glVertex3d(x - 0.23 * R, y - 0.07 * R, -0.285*R); //11
            Gl.glVertex3d(x - 0.23 * R, y + 0.07 * R, -0.285*R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.18 * R, y - 0.07 * R, -0.285*R); //7
            Gl.glVertex3d(x - 0.18 * R, y - 0.1 * R, -0.285*R); // 8

            Gl.glVertex3d(x - 0.3 * R, y - 0.1 * R, -0.285*R); //9
            Gl.glVertex3d(x - 0.3 * R, y - 0.07 * R, -0.285*R); // 10
            Gl.glEnd();



            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.04 * R, y + 0.07 * R, -0.285*R); // 1
            Gl.glVertex3d(x - 0.04 * R, y + 0.1 * R, -0.285*R);  // 2

            Gl.glVertex3d(x - 0.16 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.16 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.09 * R, y + 0.07 * R, -0.285*R);   // 5
            Gl.glVertex3d(x - 0.09 * R, y - 0.07 * R, -0.285*R); // 6

            Gl.glVertex3d(x - 0.11 * R, y - 0.07 * R, -0.285*R); //11
            Gl.glVertex3d(x - 0.11 * R, y + 0.07 * R, -0.285*R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.04 * R, y - 0.07 * R, -0.285*R); //7
            Gl.glVertex3d(x - 0.04 * R, y - 0.1 * R, -0.285*R); // 8

            Gl.glVertex3d(x - 0.16 * R, y - 0.1 * R, -0.285*R); //9
            Gl.glVertex3d(x - 0.16 * R, y - 0.07 * R, -0.285*R); // 10
            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.09 * R, y + 0.07 * R, -0.285*R); // 1
            Gl.glVertex3d(x + 0.09 * R, y + 0.1 * R, -0.285*R);  // 2

            Gl.glVertex3d(x - 0.03 * R, y + 0.1 * R, -0.285*R);   // 3
            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285*R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.03 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x - 0.03 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.09 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.09 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();

            // III кінець

            ang = 330;
            // IV початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glVertex3d(x - 0.06 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x - 0.06 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.18 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x - 0.18 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.11 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.11 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x - 0.13 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x - 0.13 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.06 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x - 0.06 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x - 0.18 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x - 0.18 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.03 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0.05 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0.05 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x + 0.13 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0.13 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0.08 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x + 0.13 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0.05 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0.05 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();

            // IV кінець


            ang = 300;
            // V Початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.08 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.08 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.03 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.08 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0.08 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0.03 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x + 0 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();

            // V Кінець


            ang = 270;
            // VI Початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.13 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.13 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.08 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.08 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.13 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.05 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.05 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.08 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x + 0.03 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x -0.02 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x -0.02 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.05 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.05 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();







            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.18 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.18 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.04 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.13 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.13 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x + 0.04 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.18 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.18 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();

            // VI Кінець


            ang = 240;

            // VII Початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.21 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.21 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.16 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.16 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.21 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.13 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.13 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.16 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.05 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x -0.10 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x -0.10 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.13 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.13 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.10 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.07 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.07 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.05 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.01 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.01 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.05 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x - 0.05 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.09 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.09 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.18 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.18 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.04 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.13 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.13 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x + 0.04 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.18 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.18 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();
            // VII Кінець



            ang = 210;
            // VIII Початок

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.21 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.21 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.16 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.16 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.21 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.13 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.13 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.16 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);


            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.05 * R, y + 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.10 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.10 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);

            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R); // 1 k L

            Gl.glVertex3d(x - 0.13 * R, y - 0.1 * R, -0.285 * R);  // 2
            Gl.glVertex3d(x - 0.13 * R, y - 0 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.10 * R, y + 0.07 * R, -0.285 * R);  // 2 k R

            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.07 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.07 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.05 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x - 0.05 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.01 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.01 * R, y - 0.07 * R, -0.285 * R);   // 6

            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); // 11
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.05 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x - 0.05 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.09 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.09 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.17 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.17 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.03 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.03 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.09 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.09 * R, y - 0.07 * R, -0.285 * R);   // 6

            Gl.glVertex3d(x + 0.12 * R, y - 0.07 * R, -0.285 * R); // 11
            Gl.glVertex3d(x + 0.12 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.03 * R, y - 0.07 * R, -0.285 * R); // 7
            Gl.glVertex3d(x + 0.03 * R, y - 0.1 * R, -0.285 * R);  // 8

            Gl.glVertex3d(x + 0.17 * R, y - 0.1 * R, -0.285 * R);  // 9
            Gl.glVertex3d(x + 0.17 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();




            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.24 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.24 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.1 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.1* R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.16 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.16 * R, y - 0.07 * R, -0.285 * R);   // 6

            Gl.glVertex3d(x + 0.19 * R, y - 0.07 * R, -0.285 * R); // 11
            Gl.glVertex3d(x + 0.19 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 7
            Gl.glVertex3d(x + 0.1 * R, y - 0.1 * R, -0.285 * R);  // 8

            Gl.glVertex3d(x + 0.24 * R, y - 0.1 * R, -0.285 * R);  // 9
            Gl.glVertex3d(x + 0.24 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();

            // VIII Кінець


            ang = 180;

            // IX Початок


            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_QUADS);


            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glVertex3d(x - 0.03 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x - 0.03 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x - 0.15 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x - 0.15 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.08 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.08 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.03 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x - 0.03 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x - 0.15 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x - 0.15 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();







            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.1 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.14 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.14 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6           
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.14 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();







            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();



            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.1 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.14 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.14 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();



            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.1 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.14 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();

            // IX Кінець

            ang = 150;

            // X Початок

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.1 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.06 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.06 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R); // 6           
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.06 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();







            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.1 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();



            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.06 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.06 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();



            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.06 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.06 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();

            // Χ Кінець

            ang = 120;

            // XI Початок

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.14 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y + 0.07 * R, -0.285 * R); // 6           
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();






            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.14 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();






            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.18 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.18 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.04 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.04 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.1 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.13 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.13 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.04 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x + 0.04 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.18 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.18 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();


            // XI Кінець

            ang = 90;

            // XII Початок

            x = bot_border * Math.Cos(ang * Math.PI / 180);
            y = bot_border * Math.Sin(ang * Math.PI / 180);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.14 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y + 0.07 * R, -0.285 * R); // 6           
            Gl.glVertex3d(x - 0.02 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();






            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.14 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x - 0.14 * R, y - 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x - 0.02 * R, y + 0.07 * R, -0.285 * R); // 6
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x - 0.1 * R, y - 0.07 * R, -0.285 * R);   // 5
            Gl.glEnd();






            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.14 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.14 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.02 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.02 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.08 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.08 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.11 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.11 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.02 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x + 0.02 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.16 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.16 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();





            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.25 * R, y + 0.07 * R, -0.285 * R); // 1
            Gl.glVertex3d(x + 0.25 * R, y + 0.1 * R, -0.285 * R);  // 2

            Gl.glVertex3d(x + 0.11 * R, y + 0.1 * R, -0.285 * R);   // 3
            Gl.glVertex3d(x + 0.11 * R, y + 0.07 * R, -0.285 * R);  // 4

            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.17 * R, y + 0.07 * R, -0.285 * R);   // 5
            Gl.glVertex3d(x + 0.17 * R, y - 0.07 * R, -0.285 * R); // 6

            Gl.glVertex3d(x + 0.2 * R, y - 0.07 * R, -0.285 * R); //11
            Gl.glVertex3d(x + 0.2 * R, y + 0.07 * R, -0.285 * R); // 12
            Gl.glEnd();

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(x + 0.11 * R, y - 0.07 * R, -0.285 * R); //7
            Gl.glVertex3d(x + 0.11 * R, y - 0.1 * R, -0.285 * R); // 8

            Gl.glVertex3d(x + 0.25 * R, y - 0.1 * R, -0.285 * R); //9
            Gl.glVertex3d(x + 0.25 * R, y - 0.07 * R, -0.285 * R); // 10
            Gl.glEnd();
            // XII Кінець





            // Стрілка
            Gl.glColor3d(1, 0, 0);
            Gl.glBegin(Gl.GL_POLYGON);

            y = 0.7 * R * Math.Cos((double)time[1] / 60 * 360 * Math.PI / 180);
            x = 0.7 * R * Math.Sin((double)time[1] / 60 * 360 * Math.PI / 180);

            Gl.glVertex3d(0, 0, -0.29 * R);
            Gl.glVertex3d(x, y, -0.29 * R);

            Gl.glVertex3d(x, y + 0.04 * R, -0.29 * R);
            Gl.glVertex3d(0, 0, -0.29 * R);


            Gl.glEnd();

            Gl.glColor3d(0, 0, 0);
            Gl.glBegin(Gl.GL_POLYGON);

            y = 0.7 * R * Math.Cos((double)time[0] / 12 * 360 * Math.PI / 180);
            x = 0.7 * R * Math.Sin((double)time[0] / 12 * 360 * Math.PI / 180);
            Gl.glVertex3d(0, 0, -0.275 * R);
            Gl.glVertex3d(x, y, -0.275 * R);

            Gl.glVertex3d(x, y + 0.04 * R, -0.29 * R);
            Gl.glVertex3d(0, 0, -0.29 * R);

            Gl.glEnd();

            Gl.glColor3d(0.8, 0, 0.8);
            Gl.glBegin(Gl.GL_POLYGON);

            y = 0.7 * R * Math.Cos((double)time[2] / 60 * 360 * Math.PI / 180);
            x = 0.7 * R * Math.Sin((double)time[2] / 60 * 360 * Math.PI / 180);
            Gl.glVertex3d(0, 0, -0.27 * R);
            Gl.glVertex3d(x, y, -0.27 * R);

            Gl.glVertex3d(x, y + 0.04 * R, -0.29 * R);
            Gl.glVertex3d(0, 0, -0.29 * R);

            Gl.glEnd();


            Gl.glPopMatrix(); // Повертаємо стан матриці
            Gl.glFlush(); // Завершуємо малювання
                          //GlCont.Invalidate(); // оновлюємо елемент simpleOpenGlControl1
        }
        public void setTime(int hh, int mm, int ss)
        {
            time[0] = hh;
            time[1] = mm;
            time[2] = ss;
        }
        public string getTime()
        {
            return (Convert.ToString(time[0]) + ':' + Convert.ToString(time[2]) + ':' + Convert.ToString(time[2]));
        }
        public int getTime(char factor)
        {
            factor = (Char.ToLower(factor));

            switch (factor)
            {
                case ('h'): { return time[0]; }
                case ('m'): { return time[1]; }
                case ('s'): { return time[2]; }
                default: { return 0; }
            }
        }
    }
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
