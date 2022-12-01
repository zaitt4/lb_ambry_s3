using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;


namespace lb5s3
{
    public partial class Form1 : Form
    {
        double a = 0, b = 0, c = -5, d = 0, zoom = 1;
        double p_1 = 1, p_2 = 1, p_3 = 0, p_4 = 1; // Змінні для роботи з кольором
        int os_x = 1, os_y = 0, os_z = 0; // Вибрані осі

        bool Wire = false; //Режим сіткової візуалізації
        private void timer1_Tick(object sender, EventArgs e)
        {
            Draw(); // Викликаємо функцію відтворення сцени (код якої буде далі)
        }
        private void trackBar1_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            a = (double)trackBar1.Value / 1000.0; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label12.Text = a.ToString(); // записуємо значення в полі перед бігунком
        }
        private void trackBar2_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            b = (double)trackBar2.Value / 1000.0; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label13.Text = b.ToString(); // записуємо значення в полі перед бігунком
        }
        private void trackBar3_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            c = (double)trackBar3.Value / 1; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label14.Text = c.ToString(); // записуємо значення в полі перед бігунком
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            d = (double)trackBar4.Value; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label15.Text = d.ToString(); // записуємо значення в полі перед бігунком
        }
        private void trackBar5_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            zoom = (double)trackBar5.Value; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
            label16.Text = zoom.ToString(); // записуємо значення в полі перед бігунком
        }
        private void trackBar6_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            p_1 = (double)trackBar6.Value / 255; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
        }
        private void trackBar7_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            p_2 = (double)trackBar7.Value / 255; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
        }
        private void trackBar8_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            p_3 = (double)trackBar8.Value / 255; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
        }
        private void trackBar9_Scroll(object sender, EventArgs e) // відповідає за бігунок « Х »
        {
            p_4 = (double)trackBar9.Value / 255; // Перекладаємо значення, що встановилося в елементі trackBar у необхідний формат
        }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex) // встановлюємо необхідну вісь
            {
                case 0:
                    {
                        os_x = 1;
                        os_y = 0;
                        os_z = 0;
                        break;
                    }
                case 1:
                    {
                        os_x = 0;
                        os_y = 1;
                        os_z = 0;
                        break;
                    }
                case 2:
                    {
                        os_x = 0;
                        os_y = 0;
                        os_z = 1;
                        break;
                    }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) // встановлюємо сітковий режим візуалізації
            {
                Wire = true;
            }
            else// інакше - полігональна візуалізація
            {
                Wire = false;
            }
        }

        private void Draw()//
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); // очищення буфера кольору та буфера глибини
            Gl.glClearColor(1, 1, 1, 1); // очищення поточної матриці
            Gl.glLoadIdentity(); // поміщаємо стан матриці в стек матриць, подальші трансформації торкнуться лише візуалізації об'єкта
            Gl.glPushMatrix();
            Gl.glTranslated(a, b, c); //переміщення
            Gl.glRotated(d, os_x, os_y, os_z); // Поворот по встановленій осі
            Gl.glScaled(zoom, zoom, zoom); // масштабування
            
            switch (comboBox2.SelectedIndex) // малюємо потрібний об'єкт, використовуючи функції бібліотеки GLUT
            {
                case 0:
                    {
                        
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glColor3f((float)0.0, (float)0.0, (float)0.0);
                            Glut.glutWireSphere(1, 32, 32);// сіткова сфера
                        }
                        else
                        {
                            Gl.glColor3f((float)0.7, (float)0.7, (float)0.7);
                            Glut.glutSolidSphere(1, 32, 32);// полігональна сфера
                        }
                        break;
                    }
                case 1:
                    {
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glColor3f((float)0.0, (float)0.0, (float)0.0);
                            Glut.glutWireCylinder(0.7, 1.2, 32, 32);// циліндр
                        }
                        else
                        {
                            Gl.glColor3f((float)0.7, (float)0.7, (float)0.7);
                            Glut.glutSolidCylinder(0.7, 1.2, 32, 32);
                        }
                        break;
                    }
                case 2:
                    {
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glColor3f((float)0.0, (float)0.0, (float)0.0);
                            Glut.glutWireCube(0.7);// куб
                        }

                        else
                        {
                            Gl.glColor3f((float)0.7, (float)0.7, (float)0.7);
                            Glut.glutSolidCube(0.7);
                        }
                        break;
                    }
                case 3:
                    {
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glColor3f((float)0.0, (float)0.0, (float)0.0);
                            Glut.glutWireCone(0.7, 1.2, 32, 32);// конус
                        }
                        else
                        {
                            Gl.glColor3f((float)p_1, (float)p_2, (float)p_3);
                            Glut.glutSolidCone(0.7, 1.2, 32, 32);
                        }
                        break;
                    }
                case 4:
                    {
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glColor3f((float)0.0, (float)0.0, (float)0.0);
                            Glut.glutWireTorus(0.2, 0.8, 32, 32); // Тор
                        }
                        else
                        {
                            Gl.glColor3f((float)0.7, (float)0.7, (float)0.7);
                            Glut.glutSolidTorus(0.2, 0.8, 32, 32);
                        }
                        break;
                    }
                case 5:
                    {
                        if (Wire)// якщо встановлено сітковий режим візуалізації
                        {
                            Gl.glBegin(Gl.GL_LINE_LOOP);//face 1
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_LINE_LOOP);//face 2
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_LINE_LOOP); //face 3
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_LINE_LOOP);//face 4
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_LINE_LOOP);//face 5
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_LINE_LOOP);//face 6
                            Gl.glColor3ub(0, 0, 0);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glEnd();
                        }
                        else
                        {
                            Gl.glBegin(Gl.GL_QUADS);//face 1
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glColor3d(p_3, p_4, p_1);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glColor3d(p_4, p_1, p_2);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);//face 2
                            Gl.glColor3d(p_3, p_4, p_1);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glColor3d(p_4, p_3, p_2);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);//face 3
                            Gl.glColor3d(p_4, p_1, p_2);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glColor3d(p_3, p_4, p_1);
                            Gl.glVertex3d(-1, -1, -1);
                            Gl.glColor3d(p_4, p_3, p_2);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);//face 4
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, -1, -1);
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);//face 5
                            Gl.glColor3d(p_4, p_1, p_2);
                            Gl.glVertex3d(-1, 1, -1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, 1, -1);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);//face 6
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(-1, 1, 1);
                            Gl.glColor3d(p_4, p_3, p_2);
                            Gl.glVertex3d(-1, -1, 1);
                            Gl.glColor3d(p_1, p_2, p_3);
                            Gl.glVertex3d(1, -1, 1);
                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glVertex3d(1, 1, 1);
                            Gl.glEnd();
                        }
                        break;
                    }
                case 6:
                    {
                        if (Wire) {

                            double x, y;
                            Gl.glColor3d(0,0,0);
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            // Закрашивание внешних стен
                            for (int angle = 0, k = 0; angle <= 360; angle += 10, k++)
                            {                                
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);

                                if (k % 2 == 0) 
                                {
                                    //Gl.glVertex3d(0, 0, -0.3);
                                    Gl.glVertex3d(x, y, -0.3);
                                    Gl.glVertex3d(x, y, 0);
                                }
                                else
                                {
                                    //Gl.glVertex3d(0, 0, -0.3);
                                    Gl.glVertex3d(x, y, 0);
                                    Gl.glVertex3d(x, y, -0.3);                                    
                                }                                    

                            }
                            Gl.glEnd();

                            //Нижний контур
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, -0.3);
                            }
                            Gl.glEnd();

                            //Нижний внутренний контур поменьше
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, -0.3);
                                Gl.glVertex3d(0, 0, -0.3);
                                Gl.glVertex3d(x, y, -0.3);
                            }
                            Gl.glEnd();

                            //Верхний внутренний контур поменьше
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0, k = 0; angle <= 360; angle += 10, k++)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                if (k % 2 == 0)
                                {
                                    //Gl.glVertex3d(0, 0, -0.3);
                                    Gl.glVertex3d(x, y, -0.3);
                                    Gl.glVertex3d(x, y, 0);
                                }
                                else
                                {
                                    //Gl.glVertex3d(0, 0, -0.3);
                                    Gl.glVertex3d(x, y, 0);
                                    Gl.glVertex3d(x, y, -0.3);
                                }


                            }
                            Gl.glEnd();

                            //Верхний внутренний контур
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);

                            }
                            Gl.glEnd();

                            //Верхний внутренний контур
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);

                            }
                            Gl.glEnd();
                            //Закрашивание промежутка стенок сверху
                            Gl.glBegin(Gl.GL_LINE_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                            }
                            Gl.glEnd();

                        }

                        else
                        {
                            double x, y;
                            Gl.glColor3d(p_1, p_2, p_3);
                            //Gl.glBegin(Gl.GL_LINE_STRIP);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, -0.3);
                                Gl.glVertex3d(x, y, 0);
                            }
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_POLYGON);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, -0.3);
                            }
                            Gl.glEnd();

                            Gl.glColor3d(p_2, p_3, p_4);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, -0.3);
                                Gl.glVertex3d(x, y, 0);
                            }
                            Gl.glEnd();

                            Gl.glColor3d(p_3, p_4, p_1);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                            }
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_QUAD_STRIP);
                            for (int angle = 0; angle <= 360; angle += 10)
                            {
                                // Координаты x, y повёрнутые на заданный угол относительно начала координат.
                                x = 0.9 * Math.Cos(angle * Math.PI / 180);
                                y = 0.9 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                                x = 1 * Math.Cos(angle * Math.PI / 180);
                                y = 1 * Math.Sin(angle * Math.PI / 180);
                                Gl.glVertex3d(x, y, 0);
                            }
                            Gl.glEnd();

                            Gl.glColor3d(0, 0, 0);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.7, -0.25, -0.29);
                            Gl.glVertex3d(0.7, 0.25, -0.29);
                            Gl.glVertex3d(0.4, 0.25, -0.29);
                            Gl.glVertex3d(0.4, -0.25, -0.29);
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
                            Gl.glVertex3d(0.66, -0.21, -0.28);
                            Gl.glVertex3d(0.66, 0.21, -0.28);
                            Gl.glVertex3d(0.44, 0.21, -0.28);
                            Gl.glVertex3d(0.44, -0.21, -0.28);
                            Gl.glEnd();

                            Gl.glColor3d(0, 0, 0);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.35, -0.25, -0.29);
                            Gl.glVertex3d(0.35, 0.25, -0.29);
                            Gl.glVertex3d(0.05, 0.25, -0.29);
                            Gl.glVertex3d(0.05, -0.25, -0.29);
                            Gl.glEnd();


                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.35, 0.21, -0.28);
                            Gl.glVertex3d(0.09, 0.21, -0.28);
                            Gl.glVertex3d(0.09, 0.02, -0.28);
                            Gl.glVertex3d(0.35, 0.02, -0.28);
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.31, -0.02, -0.28);
                            Gl.glVertex3d(0.31, -0.21, -0.28);
                            Gl.glVertex3d(0.04, -0.21, -0.28);
                            Gl.glVertex3d(0.04, -0.02, -0.28);
                            Gl.glEnd();

                            Gl.glColor3d(0, 0, 0);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.01, -0.06, -0.29);
                            Gl.glVertex3d(0.01, 0.06, -0.29);
                            Gl.glVertex3d(-0.02, 0.06, -0.29);
                            Gl.glVertex3d(-0.02, -0.06, -0.29);
                            Gl.glEnd();


                            Gl.glColor3d(0, 0, 0);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(-0.36, 0.25, -0.29);
                            Gl.glVertex3d(-0.36, -0.25, -0.29);
                            Gl.glVertex3d(-0.06, -0.25, -0.29);
                            Gl.glVertex3d(-0.06, 0.25, -0.29);
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(-0.32, 0.21, -0.28);
                            Gl.glVertex3d(-0.32, 0.02, -0.28);
                            Gl.glVertex3d(-0.02, 0.02, -0.28);
                            Gl.glVertex3d(-0.02, 0.21, -0.28);
                            Gl.glEnd();

                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(-0.32, -0.02, -0.28);
                            Gl.glVertex3d(-0.32, -0.21, -0.28);
                            Gl.glVertex3d(-0.09, -0.21, -0.28);
                            Gl.glVertex3d(-0.09, -0.02, -0.28);
                            Gl.glEnd();


                            Gl.glColor3d(0, 0, 0);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(-0.4, -0.25, -0.29);
                            Gl.glVertex3d(-0.4, 0.25, -0.29);
                            Gl.glVertex3d(-0.7, 0.25, -0.29);
                            Gl.glVertex3d(-0.7, -0.25, -0.29);
                            Gl.glEnd();

                            Gl.glColor3d(0.7, 0.7, 0.7);
                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(-0.44, -0.21, -0.28);
                            Gl.glVertex3d(-0.44, 0.21, -0.28);
                            Gl.glVertex3d(-0.665, 0.21, -0.28);
                            Gl.glVertex3d(-0.665, -0.21, -0.28);
                            Gl.glEnd();


                            Gl.glBegin(Gl.GL_QUADS);
                            Gl.glVertex3d(0.7, -0.25, -0.29);
                            Gl.glVertex3d(0.7, 0.25, -0.29);
                            Gl.glVertex3d(0.4, 0.25, -0.29);
                            Gl.glVertex3d(0.4, -0.25, -0.29);
                            Gl.glEnd();
                        }
                        break;
                    }
            }

            Gl.glPopMatrix();// повертаємо стан матриці
            Gl.glFlush();// завершуємо малювання
            simpleOpenGlControl1.Invalidate(); // оновлюємо елемент simpleOpenGlControl1
        }



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
            comboBox1.SelectedIndex = 0;// встановлення перших елементів у списках combobox
            comboBox2.SelectedIndex = 0;
            timer1.Start(); // активація таймера, що викликає функцію для візуалізації
        }
    }
}

