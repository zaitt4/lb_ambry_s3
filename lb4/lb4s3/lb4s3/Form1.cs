using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;


namespace lb4s3
{
    public partial class Form1 : Form
    {

        double PX = 51.5,
               PY = 30.0,
               SHIFT_X = 20.0,
               SHIFT_Y = 3.0;
        public Form1()
        {
            InitializeComponent();
           
            simpleOpenGlControl1.InitializeContexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Glut.glutInit();// ініціалізація Glut
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Gl.glClearColor(0, 0, 0, 1); // Очищення вікна (0,0,0 - чорний; 1,1,1 - білий)
            Gl.glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height); // встановлення порту виведення
            //відповідно до розмірів елемента
            Gl.glMatrixMode(Gl.GL_PROJECTION); // Налаштування проекції
            Gl.glLoadIdentity(); // Налаштування параметрів OpenGL для візуалізації
                                 // коректно налаштовуємо 2D ортогональну проекцію залежно від розмірів сторін вікна візуалізації
            if ((float)simpleOpenGlControl1.Width <= (float)simpleOpenGlControl1.Height)
            {
                //Налаштування 2D ортогональної проекції
                Glu.gluOrtho2D(0.0, 30.0f * (float)simpleOpenGlControl1.Height / (float)simpleOpenGlControl1.Width, 0.0, 30);
            }
            else
            {
                //Налаштування 2D ортогональної проекції
                Glu.gluOrtho2D(0.0, 30.0f * (float)simpleOpenGlControl1.Width / (float)simpleOpenGlControl1.Height, 0.0, 30);
                // Glu.gluOrtho2D поміщає початок координат у лівий нижній квадрат, а спостерігач у разі перебувати на осі Z
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT); // Очищаємо буфер кольору
            Gl.glLoadIdentity(); // очищаємо поточну матрицю
            Gl.glColor3f(1, 1, 1);

            DrawTop();
            DrawNose();
            DrawTopJaw();
            DrawBotJaw();
            DrawEyes();
            DrawRest();
            Gl.glFlush(); //Чекаємо кінця візуалізації кадру
            simpleOpenGlControl1.Invalidate(); // посилаємо сигнал перемальовування елемента simpleOpenGlControl1
        }
        private void DrawRest()
        {
            //x,y 7

            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glColor3f(0.65f, 0.65f, 0.65f);
            Gl.glVertex2d(13.8 / PX + SHIFT_X, 266 / PY + SHIFT_Y);
            Gl.glVertex2d(20 / PX + SHIFT_X, 285 / PY + SHIFT_Y);
            Gl.glVertex2d(28.8 / PX + SHIFT_X, 291.6 / PY + SHIFT_Y);
            Gl.glVertex2d(38 / PX + SHIFT_X, 291.6 / PY + SHIFT_Y);
            Gl.glVertex2d(50.5 / PX + SHIFT_X, 284.5 / PY + SHIFT_Y);
            Gl.glVertex2d(60.4 / PX + SHIFT_X, 283.7 / PY + SHIFT_Y);
            Gl.glVertex2d(73.7 / PX + SHIFT_X, 290 / PY + SHIFT_Y);
            Gl.glVertex2d(75.5 / PX + SHIFT_X, 296.5 / PY + SHIFT_Y);
            Gl.glVertex2d(76 / PX + SHIFT_X, 306.1 / PY + SHIFT_Y);
            Gl.glVertex2d(87.8 / PX + SHIFT_X, 323.7 / PY + SHIFT_Y);
            Gl.glVertex2d(92.9 / PX + SHIFT_X, 333.1 / PY + SHIFT_Y);
            Gl.glVertex2d(92.1 / PX + SHIFT_X, 337.2 / PY + SHIFT_Y);
            Gl.glVertex2d(83.8 / PX + SHIFT_X, 331 / PY + SHIFT_Y);
            Gl.glVertex2d(76 / PX + SHIFT_X, 322.8 / PY + SHIFT_Y);
            Gl.glVertex2d(60 / PX + SHIFT_X, 324.1 / PY + SHIFT_Y);
            Gl.glVertex2d(54.4 / PX + SHIFT_X, 331.3 / PY + SHIFT_Y);
            Gl.glVertex2d(45.5 / PX + SHIFT_X, 327.9 / PY + SHIFT_Y);
            Gl.glVertex2d(33.6 / PX + SHIFT_X, 314.1 / PY + SHIFT_Y);
            Gl.glVertex2d(9.62787 / PX + SHIFT_X, 307.90697 / PY + SHIFT_Y);
            Gl.glVertex2d(33.6 / PX + SHIFT_X, 314.1 / PY + SHIFT_Y);
            Gl.glVertex2d(45.3 / PX + SHIFT_X, 311.1 / PY + SHIFT_Y);
            Gl.glVertex2d(60 / PX + SHIFT_X, 324.1 / PY + SHIFT_Y);

            Gl.glEnd();

            //x,y 8
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(263.4 / PX + SHIFT_X, 272.6 / PY + SHIFT_Y);
            Gl.glVertex2d(248 / PX + SHIFT_X, 268 / PY + SHIFT_Y);
            Gl.glVertex2d(231.5 / PX + SHIFT_X, 267 / PY + SHIFT_Y);
            Gl.glVertex2d(222.4 / PX + SHIFT_X, 282.4 / PY + SHIFT_Y);
            Gl.glVertex2d(218.8 / PX + SHIFT_X, 296 / PY + SHIFT_Y);
            Gl.glVertex2d(208 / PX + SHIFT_X, 308 / PY + SHIFT_Y);
            Gl.glVertex2d(200.4 / PX + SHIFT_X, 318.4 / PY + SHIFT_Y);
            Gl.glVertex2d(189.6 / PX + SHIFT_X, 306.7 / PY + SHIFT_Y);
            Gl.glVertex2d(178 / PX + SHIFT_X, 297.6 / PY + SHIFT_Y);
            Gl.glVertex2d(165.498 / PX + SHIFT_X, 295.302 / PY + SHIFT_Y);
            Gl.glVertex2d(178 / PX + SHIFT_X, 297.6 / PY + SHIFT_Y);
            Gl.glVertex2d(189.6 / PX + SHIFT_X, 306.7 / PY + SHIFT_Y);
            Gl.glVertex2d(200.4 / PX + SHIFT_X, 318.4 / PY + SHIFT_Y);
            Gl.glVertex2d(209.8 / PX + SHIFT_X, 321.4 / PY + SHIFT_Y);
            Gl.glVertex2d(224.4 / PX + SHIFT_X, 320 / PY + SHIFT_Y);
            Gl.glVertex2d(238.7 / PX + SHIFT_X, 315 / PY + SHIFT_Y);
            Gl.glVertex2d(243 / PX + SHIFT_X, 323.4 / PY + SHIFT_Y);
            Gl.glVertex2d(259 / PX + SHIFT_X, 317.9 / PY + SHIFT_Y);
            Gl.glVertex2d(268.6 / PX + SHIFT_X, 310 / PY + SHIFT_Y);
            Gl.glVertex2d(272.7 / PX + SHIFT_X, 298.3 / PY + SHIFT_Y);
            Gl.glVertex2d(299.1 / PX + SHIFT_X, 277 / PY + SHIFT_Y);
            Gl.glVertex2d(312.2 / PX + SHIFT_X, 264.3 / PY + SHIFT_Y);
            Gl.glVertex2d(329.3 / PX + SHIFT_X, 232 / PY + SHIFT_Y);
            Gl.glVertex2d(339 / PX + SHIFT_X, 219.4 / PY + SHIFT_Y);
            Gl.glVertex2d(364.46 / PX + SHIFT_X, 217.97 / PY + SHIFT_Y);
            Gl.glVertex2d(339 / PX + SHIFT_X, 219.4 / PY + SHIFT_Y);
            Gl.glVertex2d(329.3 / PX + SHIFT_X, 232 / PY + SHIFT_Y);
            Gl.glVertex2d(354 / PX + SHIFT_X, 270 / PY + SHIFT_Y);
            Gl.glVertex2d(312 / PX + SHIFT_X, 264.3 / PY + SHIFT_Y);
            Gl.glVertex2d(354 / PX + SHIFT_X, 270 / PY + SHIFT_Y);
            Gl.glVertex2d(357.5 / PX + SHIFT_X, 285 / PY + SHIFT_Y);
            Gl.glVertex2d(354.3 / PX + SHIFT_X, 331.5 / PY + SHIFT_Y);
            Gl.glVertex2d(369.5 / PX + SHIFT_X, 317 / PY + SHIFT_Y);
            Gl.glVertex2d(390.5 / PX + SHIFT_X, 303.5 / PY + SHIFT_Y);
            Gl.glVertex2d(400 / PX + SHIFT_X, 261.8 / PY + SHIFT_Y);
            Gl.glVertex2d(419.3 / PX + SHIFT_X, 261.8 / PY + SHIFT_Y);
            Gl.glVertex2d(435.9 / PX + SHIFT_X, 247.8 / PY + SHIFT_Y);
            Gl.glVertex2d(467.1 / PX + SHIFT_X, 262.4 / PY + SHIFT_Y);
            Gl.glVertex2d(478.6 / PX + SHIFT_X, 271.6 / PY + SHIFT_Y);
            Gl.glVertex2d(485.5 / PX + SHIFT_X, 290.3 / PY + SHIFT_Y);
            Gl.glVertex2d(496 / PX + SHIFT_X, 315.2 / PY + SHIFT_Y);
            Gl.glVertex2d(487 / PX + SHIFT_X, 355 / PY + SHIFT_Y);
            Gl.glVertex2d(481.3 / PX + SHIFT_X, 366.4 / PY + SHIFT_Y);
            Gl.glVertex2d(478.1 / PX + SHIFT_X, 379.8 / PY + SHIFT_Y);
            Gl.glVertex2d(473.7 / PX + SHIFT_X, 384.7 / PY + SHIFT_Y);
            Gl.glVertex2d(469.7 / PX + SHIFT_X, 388.35 / PY + SHIFT_Y);
            Gl.glVertex2d(459.15 / PX + SHIFT_X, 392.8 / PY + SHIFT_Y);
            Gl.glVertex2d(458.8 / PX + SHIFT_X, 395.2 / PY + SHIFT_Y);
            Gl.glVertex2d(450.15 / PX + SHIFT_X, 400.5 / PY + SHIFT_Y);
            Gl.glVertex2d(450.8 / PX + SHIFT_X, 411.8 / PY + SHIFT_Y);
            Gl.glVertex2d(453 / PX + SHIFT_X, 409.7 / PY + SHIFT_Y);
            Gl.glVertex2d(453.54 / PX + SHIFT_X, 414.1 / PY + SHIFT_Y);
            Gl.glVertex2d(450.4 / PX + SHIFT_X, 420 / PY + SHIFT_Y);
            Gl.glVertex2d(446.1 / PX + SHIFT_X, 423.2 / PY + SHIFT_Y);
            Gl.glVertex2d(441.9 / PX + SHIFT_X, 429.65 / PY + SHIFT_Y);
            Gl.glVertex2d(437.16 / PX + SHIFT_X, 428.8 / PY + SHIFT_Y);
            Gl.glVertex2d(429.85 / PX + SHIFT_X, 428 / PY + SHIFT_Y);
            Gl.glVertex2d(426.6 / PX + SHIFT_X, 427 / PY + SHIFT_Y);
            Gl.glVertex2d(424 / PX + SHIFT_X, 427 / PY + SHIFT_Y);
            Gl.glVertex2d(422.3 / PX + SHIFT_X, 425.1 / PY + SHIFT_Y);
            Gl.glVertex2d(424.84 / PX + SHIFT_X, 424.35 / PY + SHIFT_Y);
            Gl.glVertex2d(425.4 / PX + SHIFT_X, 422.3 / PY + SHIFT_Y);
            Gl.glVertex2d(423.6 / PX + SHIFT_X, 420.65 / PY + SHIFT_Y);
            Gl.glVertex2d(421.35 / PX + SHIFT_X, 420.65 / PY + SHIFT_Y);
            Gl.glVertex2d(418 / PX + SHIFT_X, 415.76 / PY + SHIFT_Y);
            Gl.glVertex2d(411.3 / PX + SHIFT_X, 426.7 / PY + SHIFT_Y);
            Gl.glVertex2d(386.4 / PX + SHIFT_X, 400 / PY + SHIFT_Y);
            Gl.glVertex2d(371.5 / PX + SHIFT_X, 372 / PY + SHIFT_Y);
            Gl.glVertex2d(359.3 / PX + SHIFT_X, 354.7 / PY + SHIFT_Y);
            Gl.glVertex2d(353.5 / PX + SHIFT_X, 352.6 / PY + SHIFT_Y);
            Gl.glVertex2d(354.3 / PX + SHIFT_X, 331.5 / PY + SHIFT_Y);
            Gl.glVertex2d(353.5 / PX + SHIFT_X, 352.6 / PY + SHIFT_Y);
            Gl.glVertex2d(349.1 / PX + SHIFT_X, 376.9 / PY + SHIFT_Y);
            Gl.glVertex2d(353.1 / PX + SHIFT_X, 397.8 / PY + SHIFT_Y);
            Gl.glVertex2d(344.3 / PX + SHIFT_X, 402.6 / PY + SHIFT_Y);
            Gl.glVertex2d(336 / PX + SHIFT_X, 396.5 / PY + SHIFT_Y);
            Gl.glVertex2d(324.67 / PX + SHIFT_X, 402.36 / PY + SHIFT_Y);
            Gl.glVertex2d(329 / PX + SHIFT_X, 409 / PY + SHIFT_Y);
            Gl.glVertex2d(330.7 / PX + SHIFT_X, 417.17 / PY + SHIFT_Y);
            Gl.glVertex2d(338.1 / PX + SHIFT_X, 410.4 / PY + SHIFT_Y);
            Gl.glVertex2d(345.7 / PX + SHIFT_X, 408.6 / PY + SHIFT_Y);
            Gl.glVertex2d(358.4 / PX + SHIFT_X, 418.5 / PY + SHIFT_Y);
            Gl.glVertex2d(356.87 / PX + SHIFT_X, 406.1 / PY + SHIFT_Y);
            Gl.glVertex2d(353.1 / PX + SHIFT_X, 397.8 / PY + SHIFT_Y);
            Gl.glVertex2d(356.87 / PX + SHIFT_X, 406.1 / PY + SHIFT_Y);
            Gl.glVertex2d(358.4 / PX + SHIFT_X, 418.5 / PY + SHIFT_Y);
            Gl.glVertex2d(357.9 / PX + SHIFT_X, 453.6 / PY + SHIFT_Y);
            Gl.glVertex2d(370.1 / PX + SHIFT_X, 456.7 / PY + SHIFT_Y);
            Gl.glVertex2d(382 / PX + SHIFT_X, 455.6 / PY + SHIFT_Y);
            Gl.glVertex2d(395.4 / PX + SHIFT_X, 454.4 / PY + SHIFT_Y);
            Gl.glVertex2d(402 / PX + SHIFT_X, 446.4 / PY + SHIFT_Y);
            Gl.glVertex2d(411.3 / PX + SHIFT_X, 426.7 / PY + SHIFT_Y);
            Gl.glVertex2d(402 / PX + SHIFT_X, 446.4 / PY + SHIFT_Y);
            Gl.glVertex2d(395.4 / PX + SHIFT_X, 454.4 / PY + SHIFT_Y);
            Gl.glVertex2d(405 / PX + SHIFT_X, 476.8 / PY + SHIFT_Y);
            Gl.glVertex2d(412.9 / PX + SHIFT_X, 484.6 / PY + SHIFT_Y);
            Gl.glVertex2d(419.2 / PX + SHIFT_X, 505.2 / PY + SHIFT_Y);
            Gl.glVertex2d(423.3 / PX + SHIFT_X, 528.7 / PY + SHIFT_Y);
            Gl.glVertex2d(408 / PX + SHIFT_X, 530.5 / PY + SHIFT_Y);
            Gl.glVertex2d(352 / PX + SHIFT_X, 480.8 / PY + SHIFT_Y);
            Gl.glVertex2d(357.9 / PX + SHIFT_X, 453.6 / PY + SHIFT_Y);

            Gl.glEnd();

            //x,y 9
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(129 / PX + SHIFT_X, 432.8 / PY + SHIFT_Y);
            Gl.glVertex2d(136.6 / PX + SHIFT_X, 436.1 / PY + SHIFT_Y);
            Gl.glVertex2d(144 / PX + SHIFT_X, 454.8 / PY + SHIFT_Y);
            Gl.glVertex2d(148.7 / PX + SHIFT_X, 472.2 / PY + SHIFT_Y);
            Gl.glVertex2d(135 / PX + SHIFT_X, 474.7 / PY + SHIFT_Y);
            Gl.glVertex2d(116 / PX + SHIFT_X, 489.4 / PY + SHIFT_Y);
            Gl.glVertex2d(102.3 / PX + SHIFT_X, 497 / PY + SHIFT_Y);
            Gl.glVertex2d(85 / PX + SHIFT_X, 491.2 / PY + SHIFT_Y);
            Gl.glVertex2d(77.6 / PX + SHIFT_X, 471.1 / PY + SHIFT_Y);
            Gl.glEnd();

            //x,y 10
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(148.7 / PX + SHIFT_X, 472.2 / PY + SHIFT_Y);
            Gl.glVertex2d(156.2 / PX + SHIFT_X, 478.1 / PY + SHIFT_Y);
            Gl.glVertex2d(164.3 / PX + SHIFT_X, 474 / PY + SHIFT_Y);
            Gl.glVertex2d(166 / PX + SHIFT_X, 466.8 / PY + SHIFT_Y);
            Gl.glVertex2d(176.8 / PX + SHIFT_X, 458.5 / PY + SHIFT_Y);
            Gl.glVertex2d(201.7 / PX + SHIFT_X, 475.3 / PY + SHIFT_Y);
            Gl.glVertex2d(220.8 / PX + SHIFT_X, 478 / PY + SHIFT_Y);
            Gl.glVertex2d(235.7 / PX + SHIFT_X, 488 / PY + SHIFT_Y);
            Gl.glVertex2d(252 / PX + SHIFT_X, 479.6 / PY + SHIFT_Y);
            Gl.glEnd();

            //x,y 11
            Gl.glBegin(Gl.GL_LINE_STRIP);
            Gl.glVertex2d(184.6 / PX + SHIFT_X, 430.6 / PY + SHIFT_Y);
            Gl.glVertex2d(179.2 / PX + SHIFT_X, 428.1 / PY + SHIFT_Y);
            Gl.glVertex2d(174.3 / PX + SHIFT_X, 416.3 / PY + SHIFT_Y);
            Gl.glVertex2d(169.6 / PX + SHIFT_X, 409.8 / PY + SHIFT_Y);
            Gl.glVertex2d(149.71 / PX + SHIFT_X, 407.61 / PY + SHIFT_Y);
            Gl.glEnd();

            //x,y 12

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(260 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(263.8 / PX + SHIFT_X, 225.9 / PY + SHIFT_Y);
            Gl.glVertex2d(269.3 / PX + SHIFT_X, 250.5 / PY + SHIFT_Y);
            Gl.glVertex2d(279.7 / PX + SHIFT_X, 258 / PY + SHIFT_Y);
            Gl.glVertex2d(284 / PX + SHIFT_X, 266.8 / PY + SHIFT_Y);
            Gl.glVertex2d(299.1 / PX + SHIFT_X, 277 / PY + SHIFT_Y);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(275.8 / PX + SHIFT_X, 276.5 / PY + SHIFT_Y);
            Gl.glVertex2d(263.4 / PX + SHIFT_X, 272.6 / PY + SHIFT_Y);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(40 / PX + SHIFT_X, 219 / PY + SHIFT_Y);
            Gl.glVertex2d(49.6 / PX + SHIFT_X, 245 / PY + SHIFT_Y);
            Gl.glVertex2d(57.7 / PX + SHIFT_X, 256.3 / PY + SHIFT_Y);
            Gl.glVertex2d(47 / PX + SHIFT_X, 265.7 / PY + SHIFT_Y);
            Gl.glVertex2d(35.4 / PX + SHIFT_X, 264.7 / PY + SHIFT_Y);
            Gl.glVertex2d(20 / PX + SHIFT_X, 245 / PY + SHIFT_Y);

            Gl.glEnd();

            //x,y 13

            Gl.glColor3f(1, 1, 1);
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(30 / PX + SHIFT_X, 180 / PY + SHIFT_Y);
            Gl.glVertex2d(45.6 / PX + SHIFT_X, 120.7 / PY + SHIFT_Y);
            Gl.glVertex2d(15.8 / PX + SHIFT_X, 63 / PY + SHIFT_Y);
            Gl.glVertex2d(14.6 / PX + SHIFT_X, 51.5 / PY + SHIFT_Y);
            Gl.glVertex2d(30.6 / PX + SHIFT_X, 55.3 / PY + SHIFT_Y);
            Gl.glVertex2d(49 / PX + SHIFT_X, 55.8 / PY + SHIFT_Y);
            Gl.glVertex2d(58.5 / PX + SHIFT_X, 46.6 / PY + SHIFT_Y);
            Gl.glVertex2d(98.9 / PX + SHIFT_X, 44.6 / PY + SHIFT_Y);
            Gl.glVertex2d(110.3 / PX + SHIFT_X, 52.2 / PY + SHIFT_Y);
            Gl.glVertex2d(158.8 / PX + SHIFT_X, 30.2 / PY + SHIFT_Y);
            Gl.glVertex2d(191 / PX + SHIFT_X, 18 / PY + SHIFT_Y);
            Gl.glVertex2d(228.3 / PX + SHIFT_X, 7.3 / PY + SHIFT_Y);
            Gl.glVertex2d(259.2 / PX + SHIFT_X, 19.3 / PY + SHIFT_Y);
            Gl.glVertex2d(273.2 / PX + SHIFT_X, 13 / PY + SHIFT_Y);
            Gl.glVertex2d(287 / PX + SHIFT_X, 13.3 / PY + SHIFT_Y);
            Gl.glVertex2d(298.6 / PX + SHIFT_X, 25.2 / PY + SHIFT_Y);
            Gl.glVertex2d(312.7 / PX + SHIFT_X, 22.1 / PY + SHIFT_Y);
            Gl.glVertex2d(316.7 / PX + SHIFT_X, 31.8 / PY + SHIFT_Y);
            Gl.glVertex2d(315.9 / PX + SHIFT_X, 42.2 / PY + SHIFT_Y);
            Gl.glVertex2d(313 / PX + SHIFT_X, 48.8 / PY + SHIFT_Y);
            Gl.glVertex2d(319.5 / PX + SHIFT_X, 86.6 / PY + SHIFT_Y);
            Gl.glVertex2d(336.3 / PX + SHIFT_X, 121 / PY + SHIFT_Y);
            Gl.glVertex2d(353.6 / PX + SHIFT_X, 139.6 / PY + SHIFT_Y);
            Gl.glVertex2d(388 / PX + SHIFT_X, 163 / PY + SHIFT_Y);
            Gl.glVertex2d(410 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(390 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(380.6 / PX + SHIFT_X, 188 / PY + SHIFT_Y);
            Gl.glVertex2d(350.1 / PX + SHIFT_X, 173.4 / PY + SHIFT_Y);

            Gl.glVertex2d(341.5 / PX + SHIFT_X, 175.2 / PY + SHIFT_Y);
            Gl.glVertex2d(346 / PX + SHIFT_X, 187.9 / PY + SHIFT_Y);
            Gl.glVertex2d(331.67 / PX + SHIFT_X, 210 / PY + SHIFT_Y);
            Gl.glVertex2d(310 / PX + SHIFT_X, 210 / PY + SHIFT_Y);
            Gl.glVertex2d(331.67 / PX + SHIFT_X, 210 / PY + SHIFT_Y);
            Gl.glVertex2d(298.7 / PX + SHIFT_X, 212.2 / PY + SHIFT_Y);
            Gl.glVertex2d(297.7 / PX + SHIFT_X, 175.3 / PY + SHIFT_Y);
            Gl.glVertex2d(282 / PX + SHIFT_X, 143.4 / PY + SHIFT_Y);
            Gl.glVertex2d(257.6 / PX + SHIFT_X, 101 / PY + SHIFT_Y);
            Gl.glVertex2d(228.8 / PX + SHIFT_X, 97.7 / PY + SHIFT_Y);
            Gl.glVertex2d(239 / PX + SHIFT_X, 120 / PY + SHIFT_Y);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(14.5 / PX + SHIFT_X, 51.5 / PY + SHIFT_Y);
            Gl.glVertex2d(18 / PX + SHIFT_X, 37 / PY + SHIFT_Y);
            Gl.glVertex2d(31 / PX + SHIFT_X, 25.6 / PY + SHIFT_Y);
            Gl.glVertex2d(53.6 / PX + SHIFT_X, 20 / PY + SHIFT_Y);
            Gl.glVertex2d(120.7 / PX + SHIFT_X, 9.4 / PY + SHIFT_Y);
            Gl.glVertex2d(157.1 / PX + SHIFT_X, 6.9 / PY + SHIFT_Y);
            Gl.glVertex2d(208.8 / PX + SHIFT_X, 4.3 / PY + SHIFT_Y);
            Gl.glVertex2d(228.3 / PX + SHIFT_X, 7.3 / PY + SHIFT_Y);

            Gl.glEnd();

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(239 / PX + SHIFT_X, 120 / PY + SHIFT_Y);
            Gl.glVertex2d(228.8 / PX + SHIFT_X, 97.7 / PY + SHIFT_Y);
            Gl.glVertex2d(221.5 / PX + SHIFT_X, 93 / PY + SHIFT_Y);
            Gl.glVertex2d(215 / PX + SHIFT_X, 102.2 / PY + SHIFT_Y);
            Gl.glVertex2d(227 / PX + SHIFT_X, 128 / PY + SHIFT_Y);

            Gl.glEnd();


            //x,y 15
            Gl.glColor3f(0.65f, 0.65f, 0.65f);

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(202.8 / PX + SHIFT_X, 107.2 / PY + SHIFT_Y);
            Gl.glVertex2d(197.3 / PX + SHIFT_X, 98 / PY + SHIFT_Y);
            Gl.glVertex2d(186.8 / PX + SHIFT_X, 96.7 / PY + SHIFT_Y);
            Gl.glVertex2d(179.2 / PX + SHIFT_X, 102.2 / PY + SHIFT_Y);
            Gl.glVertex2d(178.6 / PX + SHIFT_X, 114.3 / PY + SHIFT_Y);
            Gl.glVertex2d(170.6 / PX + SHIFT_X, 119.4 / PY + SHIFT_Y);
            Gl.glVertex2d(161.4 / PX + SHIFT_X, 120.5 / PY + SHIFT_Y);
            Gl.glVertex2d(153.4 / PX + SHIFT_X, 124.6 / PY + SHIFT_Y);
            Gl.glVertex2d(149.8 / PX + SHIFT_X, 128.7 / PY + SHIFT_Y);
            Gl.glVertex2d(138 / PX + SHIFT_X, 127.2 / PY + SHIFT_Y);
            Gl.glVertex2d(129.7 / PX + SHIFT_X, 131 / PY + SHIFT_Y);
            Gl.glVertex2d(123.2 / PX + SHIFT_X, 137.9 / PY + SHIFT_Y);
            Gl.glVertex2d(103.9 / PX + SHIFT_X, 144.4 / PY + SHIFT_Y);
            Gl.glVertex2d(94.4 / PX + SHIFT_X, 143 / PY + SHIFT_Y);
            Gl.glVertex2d(88.5 / PX + SHIFT_X, 145 / PY + SHIFT_Y);
            Gl.glVertex2d(78 / PX + SHIFT_X, 141.8 / PY + SHIFT_Y);
            Gl.glVertex2d(63.5 / PX + SHIFT_X, 136.8 / PY + SHIFT_Y);
            Gl.glVertex2d(50 / PX + SHIFT_X, 132 / PY + SHIFT_Y);

            Gl.glEnd();


            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(69.8 / PX + SHIFT_X, 117.7 / PY + SHIFT_Y);
            Gl.glVertex2d(91.2 / PX + SHIFT_X, 111.7 / PY + SHIFT_Y);
            Gl.glVertex2d(125.3 / PX + SHIFT_X, 106.4 / PY + SHIFT_Y);

            Gl.glEnd();

            //x,y 16
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(394 / PX + SHIFT_X, 91 / PY + SHIFT_Y);
            Gl.glVertex2d(383.6 / PX + SHIFT_X, 112 / PY + SHIFT_Y);
            Gl.glVertex2d(369.8 / PX + SHIFT_X, 112.8 / PY + SHIFT_Y);
            Gl.glVertex2d(358.3 / PX + SHIFT_X, 117.7 / PY + SHIFT_Y);
            Gl.glVertex2d(373.8 / PX + SHIFT_X, 119.7 / PY + SHIFT_Y);
            Gl.glVertex2d(385 / PX + SHIFT_X, 128.9 / PY + SHIFT_Y);
            Gl.glVertex2d(385.8 / PX + SHIFT_X, 136.2 / PY + SHIFT_Y);
            Gl.glVertex2d(384.5 / PX + SHIFT_X, 142.3 / PY + SHIFT_Y);
            Gl.glVertex2d(392.5 / PX + SHIFT_X, 145.8 / PY + SHIFT_Y);
            Gl.glVertex2d(402.4 / PX + SHIFT_X, 147.8 / PY + SHIFT_Y);
            Gl.glVertex2d(416.7 / PX + SHIFT_X, 153 / PY + SHIFT_Y);
            Gl.glVertex2d(430 / PX + SHIFT_X, 160 / PY + SHIFT_Y);

            Gl.glEnd();


            //x,y 17
            Gl.glColor3f(1, 1, 1);

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(315.56 / PX + SHIFT_X, 63.24 / PY + SHIFT_Y);
            Gl.glVertex2d(326.7 / PX + SHIFT_X, 62 / PY + SHIFT_Y);
            Gl.glVertex2d(340.3 / PX + SHIFT_X, 64.8 / PY + SHIFT_Y);
            Gl.glVertex2d(350 / PX + SHIFT_X, 65.3 / PY + SHIFT_Y);
            Gl.glVertex2d(362.1 / PX + SHIFT_X, 64.3 / PY + SHIFT_Y);
            Gl.glVertex2d(369.8 / PX + SHIFT_X, 66.2 / PY + SHIFT_Y);
            Gl.glVertex2d(375.7 / PX + SHIFT_X, 71 / PY + SHIFT_Y);
            Gl.glVertex2d(385 / PX + SHIFT_X, 78.1 / PY + SHIFT_Y);
            Gl.glVertex2d(389.7 / PX + SHIFT_X, 83.7 / PY + SHIFT_Y);
            Gl.glVertex2d(394 / PX + SHIFT_X, 91 / PY + SHIFT_Y);
            Gl.glVertex2d(400.6 / PX + SHIFT_X, 99 / PY + SHIFT_Y);
            Gl.glVertex2d(408.4 / PX + SHIFT_X, 111.6 / PY + SHIFT_Y);
            Gl.glVertex2d(415.3 / PX + SHIFT_X, 123.8 / PY + SHIFT_Y);
            Gl.glVertex2d(422.7 / PX + SHIFT_X, 138.5 / PY + SHIFT_Y);
            Gl.glVertex2d(430.5 / PX + SHIFT_X, 156.6 / PY + SHIFT_Y);
            Gl.glVertex2d(432.97 / PX + SHIFT_X, 162.36 / PY + SHIFT_Y);

            Gl.glEnd();

            //x,y 18

            Gl.glColor3f(0.65f, 0.65f, 0.65f);

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(40 / PX + SHIFT_X, 219 / PY + SHIFT_Y);
            Gl.glVertex2d(48.3 / PX + SHIFT_X, 225.2 / PY + SHIFT_Y);
            Gl.glVertex2d(63.2 / PX + SHIFT_X, 234 / PY + SHIFT_Y);
            Gl.glVertex2d(78.8 / PX + SHIFT_X, 241.6 / PY + SHIFT_Y);
            Gl.glVertex2d(93.2 / PX + SHIFT_X, 246.3 / PY + SHIFT_Y);
            Gl.glVertex2d(100.8 / PX + SHIFT_X, 243.1 / PY + SHIFT_Y);
            Gl.glVertex2d(124.5 / PX + SHIFT_X, 246 / PY + SHIFT_Y);
            Gl.glVertex2d(132 / PX + SHIFT_X, 242 / PY + SHIFT_Y);
            Gl.glVertex2d(149.8 / PX + SHIFT_X, 238 / PY + SHIFT_Y);
            Gl.glVertex2d(164.6 / PX + SHIFT_X, 229.7 / PY + SHIFT_Y);
            Gl.glVertex2d(185.7 / PX + SHIFT_X, 215 / PY + SHIFT_Y);
            Gl.glVertex2d(204.7 / PX + SHIFT_X, 199.8 / PY + SHIFT_Y);
            Gl.glVertex2d(222.2 / PX + SHIFT_X, 183.8 / PY + SHIFT_Y);
            Gl.glVertex2d(231.2 / PX + SHIFT_X, 175 / PY + SHIFT_Y);
            Gl.glVertex2d(249.77 / PX + SHIFT_X, 161 / PY + SHIFT_Y);
            
            Gl.glEnd();
        }
        private void DrawBotJaw()
        {
            //x,y 14

            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glColor3f(1, 1, 1);
            Gl.glVertex2d(228.8 / PX + SHIFT_X, 97.7 / PY + SHIFT_Y);
            Gl.glVertex2d(221.5 / PX + SHIFT_X, 93 / PY + SHIFT_Y);
            Gl.glVertex2d(215 / PX + SHIFT_X, 102.2 / PY + SHIFT_Y);
            Gl.glVertex2d(227 / PX + SHIFT_X, 128 / PY + SHIFT_Y);
            Gl.glVertex2d(214.6 / PX + SHIFT_X, 142 / PY + SHIFT_Y);
            Gl.glVertex2d(214 / PX + SHIFT_X, 132.9 / PY + SHIFT_Y);
            Gl.glVertex2d(210.9 / PX + SHIFT_X, 122.8 / PY + SHIFT_Y);
            Gl.glVertex2d(202.8 / PX + SHIFT_X, 107.2 / PY + SHIFT_Y);
            Gl.glVertex2d(215 / PX + SHIFT_X, 102.2 / PY + SHIFT_Y);
            Gl.glVertex2d(202.8 / PX + SHIFT_X, 107.2 / PY + SHIFT_Y);
            Gl.glVertex2d(188.3 / PX + SHIFT_X, 119.3 / PY + SHIFT_Y);
            Gl.glVertex2d(201.7 / PX + SHIFT_X, 140.5 / PY + SHIFT_Y);
            Gl.glVertex2d(202.9 / PX + SHIFT_X, 148.2 / PY + SHIFT_Y);
            Gl.glVertex2d(202.5 / PX + SHIFT_X, 151.9 / PY + SHIFT_Y);

            Gl.glVertex2d(194.2 / PX + SHIFT_X, 164.8 / PY + SHIFT_Y);
            Gl.glVertex2d(186 / PX + SHIFT_X, 163.2 / PY + SHIFT_Y);
            Gl.glVertex2d(181.4 / PX + SHIFT_X, 149 / PY + SHIFT_Y);
            Gl.glVertex2d(175 / PX + SHIFT_X, 134.8 / PY + SHIFT_Y);
            Gl.glVertex2d(174.4 / PX + SHIFT_X, 126.9 / PY + SHIFT_Y);
            Gl.glVertex2d(180 / PX + SHIFT_X, 121.3 / PY + SHIFT_Y);
            Gl.glVertex2d(188.3 / PX + SHIFT_X, 119.3 / PY + SHIFT_Y);
            Gl.glVertex2d(180 / PX + SHIFT_X, 121.3 / PY + SHIFT_Y);
            Gl.glVertex2d(174.4 / PX + SHIFT_X, 126.9 / PY + SHIFT_Y);
            Gl.glVertex2d(165 / PX + SHIFT_X, 130.6 / PY + SHIFT_Y);
            Gl.glVertex2d(156 / PX + SHIFT_X, 135.2 / PY + SHIFT_Y);
            Gl.glVertex2d(149.7 / PX + SHIFT_X, 146 / PY + SHIFT_Y);
            Gl.glVertex2d(155.1 / PX + SHIFT_X, 155 / PY + SHIFT_Y);
            Gl.glVertex2d(158.3 / PX + SHIFT_X, 172 / PY + SHIFT_Y);
            Gl.glVertex2d(160.6 / PX + SHIFT_X, 174.7 / PY + SHIFT_Y);
            Gl.glVertex2d(150 / PX + SHIFT_X, 188.5 / PY + SHIFT_Y);
            Gl.glVertex2d(135.6 / PX + SHIFT_X, 181.9 / PY + SHIFT_Y);
            Gl.glVertex2d(134.5 / PX + SHIFT_X, 175.1 / PY + SHIFT_Y);
            Gl.glVertex2d(132.8 / PX + SHIFT_X, 161.7 / PY + SHIFT_Y);
            Gl.glVertex2d(130.8 / PX + SHIFT_X, 156.9 / PY + SHIFT_Y);
            Gl.glVertex2d(139.3 / PX + SHIFT_X, 146.8 / PY + SHIFT_Y);
            Gl.glVertex2d(149.7 / PX + SHIFT_X, 146 / PY + SHIFT_Y);
            Gl.glVertex2d(139.3 / PX + SHIFT_X, 146.8 / PY + SHIFT_Y);
            Gl.glVertex2d(130.8 / PX + SHIFT_X, 156.9 / PY + SHIFT_Y);
            Gl.glVertex2d(123.4 / PX + SHIFT_X, 150.8 / PY + SHIFT_Y);
            Gl.glVertex2d(115.4 / PX + SHIFT_X, 150.2 / PY + SHIFT_Y);
            Gl.glVertex2d(109.4 / PX + SHIFT_X, 151.9 / PY + SHIFT_Y);
            Gl.glVertex2d(104.6 / PX + SHIFT_X, 155.6 / PY + SHIFT_Y);
            Gl.glVertex2d(104.3 / PX + SHIFT_X, 169.2 / PY + SHIFT_Y);
            Gl.glVertex2d(106 / PX + SHIFT_X, 182 / PY + SHIFT_Y);
            Gl.glVertex2d(108.7 / PX + SHIFT_X, 189 / PY + SHIFT_Y);
            Gl.glVertex2d(97 / PX + SHIFT_X, 198.2 / PY + SHIFT_Y);
            Gl.glVertex2d(84 / PX + SHIFT_X, 193.4 / PY + SHIFT_Y);
            Gl.glVertex2d(84.3 / PX + SHIFT_X, 185.7 / PY + SHIFT_Y);
            Gl.glVertex2d(85 / PX + SHIFT_X, 173 / PY + SHIFT_Y);
            Gl.glVertex2d(87.1 / PX + SHIFT_X, 159.2 / PY + SHIFT_Y);
            Gl.glVertex2d(90.8 / PX + SHIFT_X, 154.4 / PY + SHIFT_Y);
            Gl.glVertex2d(97.2 / PX + SHIFT_X, 152.2 / PY + SHIFT_Y);
            Gl.glVertex2d(101.9 / PX + SHIFT_X, 153.2 / PY + SHIFT_Y);
            Gl.glVertex2d(104.6 / PX + SHIFT_X, 155.6 / PY + SHIFT_Y);
            Gl.glVertex2d(101.9 / PX + SHIFT_X, 153.2 / PY + SHIFT_Y);
            Gl.glVertex2d(97.2 / PX + SHIFT_X, 152.2 / PY + SHIFT_Y);
            Gl.glVertex2d(90.8 / PX + SHIFT_X, 154.4 / PY + SHIFT_Y);
            Gl.glVertex2d(83.7 / PX + SHIFT_X, 151.7 / PY + SHIFT_Y);
            Gl.glVertex2d(76 / PX + SHIFT_X, 153.4 / PY + SHIFT_Y);
            Gl.glVertex2d(70.6 / PX + SHIFT_X, 163.3 / PY + SHIFT_Y);
            Gl.glVertex2d(68.6 / PX + SHIFT_X, 174.6 / PY + SHIFT_Y);
            Gl.glVertex2d(67.2 / PX + SHIFT_X, 188 / PY + SHIFT_Y);
            Gl.glVertex2d(58.2 / PX + SHIFT_X, 196 / PY + SHIFT_Y);
            Gl.glVertex2d(48.7 / PX + SHIFT_X, 184.5 / PY + SHIFT_Y);
            Gl.glVertex2d(50.6 / PX + SHIFT_X, 174.1 / PY + SHIFT_Y);
            Gl.glVertex2d(52.8 / PX + SHIFT_X, 164.3 / PY + SHIFT_Y);
            Gl.glVertex2d(56.6 / PX + SHIFT_X, 148.2 / PY + SHIFT_Y);
            Gl.glVertex2d(71.1 / PX + SHIFT_X, 150 / PY + SHIFT_Y);
            Gl.glVertex2d(76 / PX + SHIFT_X, 153.6 / PY + SHIFT_Y);
            Gl.glVertex2d(71.1 / PX + SHIFT_X, 150 / PY + SHIFT_Y);
            Gl.glVertex2d(64.6 / PX + SHIFT_X, 147.3 / PY + SHIFT_Y);
            Gl.glVertex2d(56.6 / PX + SHIFT_X, 148.2 / PY + SHIFT_Y);
            Gl.glVertex2d(47.4 / PX + SHIFT_X, 146.5 / PY + SHIFT_Y);
            Gl.glVertex2d(37.87 / PX + SHIFT_X, 150.3 / PY + SHIFT_Y);

            Gl.glEnd();
        }
        private void DrawTopJaw()
        {
            //x,y 2
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(239 / PX + SHIFT_X, 120 / PY + SHIFT_Y);
            Gl.glVertex2d(232.2 / PX + SHIFT_X, 123.8 / PY + SHIFT_Y);
            Gl.glVertex2d(227 / PX + SHIFT_X, 128.3 / PY + SHIFT_Y);
            Gl.glVertex2d(240.5 / PX + SHIFT_X, 162.6 / PY + SHIFT_Y);
            Gl.glVertex2d(227 / PX + SHIFT_X, 128.3 / PY + SHIFT_Y);
            Gl.glVertex2d(214.6 / PX + SHIFT_X, 142 / PY + SHIFT_Y);
            Gl.glVertex2d(227.4 / PX + SHIFT_X, 157.1 / PY + SHIFT_Y);
            Gl.glVertex2d(229.4 / PX + SHIFT_X, 176.6 / PY + SHIFT_Y);
            Gl.glVertex2d(227.4 / PX + SHIFT_X, 157.1 / PY + SHIFT_Y);
            Gl.glVertex2d(214.6 / PX + SHIFT_X, 142 / PY + SHIFT_Y);
            Gl.glVertex2d(202.5 / PX + SHIFT_X, 151.9 / PY + SHIFT_Y);
            Gl.glVertex2d(216.7 / PX + SHIFT_X, 164.3 / PY + SHIFT_Y);
            Gl.glVertex2d(219.8 / PX + SHIFT_X, 181.8 / PY + SHIFT_Y);
            Gl.glVertex2d(216.7 / PX + SHIFT_X, 164.3 / PY + SHIFT_Y);
            Gl.glVertex2d(202.5 / PX + SHIFT_X, 151.9 / PY + SHIFT_Y);
            Gl.glVertex2d(194.2 / PX + SHIFT_X, 164.8 / PY + SHIFT_Y);
            Gl.glVertex2d(204.6 / PX + SHIFT_X, 183.2 / PY + SHIFT_Y);
            Gl.glVertex2d(205 / PX + SHIFT_X, 197 / PY + SHIFT_Y);
            Gl.glVertex2d(204.6 / PX + SHIFT_X, 183.2 / PY + SHIFT_Y);
            Gl.glVertex2d(194.2 / PX + SHIFT_X, 164.8 / PY + SHIFT_Y);
            Gl.glVertex2d(186 / PX + SHIFT_X, 163.2 / PY + SHIFT_Y);
            Gl.glVertex2d(175.5 / PX + SHIFT_X, 181.5 / PY + SHIFT_Y);
            
            Gl.glVertex2d(182.2 / PX + SHIFT_X, 193.3 / PY + SHIFT_Y);
            Gl.glVertex2d(184.6 / PX + SHIFT_X, 204.1 / PY + SHIFT_Y);
            Gl.glVertex2d(185.5 / PX + SHIFT_X, 213.5 / PY + SHIFT_Y);
            Gl.glVertex2d(184.6 / PX + SHIFT_X, 204.1 / PY + SHIFT_Y);
            Gl.glVertex2d(182.2 / PX + SHIFT_X, 193.3 / PY + SHIFT_Y);

            Gl.glVertex2d(175.5 / PX + SHIFT_X, 181.5 / PY + SHIFT_Y);
            Gl.glVertex2d(160.6 / PX + SHIFT_X, 174.7 / PY + SHIFT_Y);
            Gl.glVertex2d(150 / PX + SHIFT_X, 188.5 / PY + SHIFT_Y);
            Gl.glVertex2d(151.7 / PX + SHIFT_X, 205.3 / PY + SHIFT_Y);
            

            Gl.glVertex2d(161.5 / PX + SHIFT_X, 229.5 / PY + SHIFT_Y);


            Gl.glVertex2d(151.7 / PX + SHIFT_X, 205.3 / PY + SHIFT_Y);
            Gl.glVertex2d(150 / PX + SHIFT_X, 188.5 / PY + SHIFT_Y);
            Gl.glVertex2d(135.6 / PX + SHIFT_X, 181.9 / PY + SHIFT_Y);
            Gl.glVertex2d(125.5 / PX + SHIFT_X, 193.7 / PY + SHIFT_Y);
            
            
            Gl.glVertex2d(140.8 / PX + SHIFT_X, 239.2 / PY + SHIFT_Y);

            Gl.glVertex2d(125.5 / PX + SHIFT_X, 193.7 / PY + SHIFT_Y);
            Gl.glVertex2d(108.7 / PX + SHIFT_X, 189 / PY + SHIFT_Y);
            Gl.glVertex2d(97 / PX + SHIFT_X, 198.2 / PY + SHIFT_Y);
            
            
            Gl.glVertex2d(104 / PX + SHIFT_X, 220 / PY + SHIFT_Y);
            Gl.glVertex2d(110.3 / PX + SHIFT_X, 242.4 / PY + SHIFT_Y);
            Gl.glVertex2d(104 / PX + SHIFT_X, 220 / PY + SHIFT_Y);
   
            Gl.glVertex2d(97 / PX + SHIFT_X, 198.2 / PY + SHIFT_Y);
            Gl.glVertex2d(84 / PX + SHIFT_X, 193.4 / PY + SHIFT_Y);
            Gl.glVertex2d(73.6 / PX + SHIFT_X, 203.6 / PY + SHIFT_Y);
            
            //
            Gl.glVertex2d(74 / PX + SHIFT_X, 215.1 / PY + SHIFT_Y);
            Gl.glVertex2d(78.3 / PX + SHIFT_X, 229.5 / PY + SHIFT_Y);
            Gl.glVertex2d(83.5 / PX + SHIFT_X, 242.1 / PY + SHIFT_Y);
            Gl.glVertex2d(78.3 / PX + SHIFT_X, 229.5 / PY + SHIFT_Y);
            Gl.glVertex2d(74 / PX + SHIFT_X, 215.1 / PY + SHIFT_Y);
            //
            
            Gl.glVertex2d(73.6 / PX + SHIFT_X, 203.6 / PY + SHIFT_Y);
            Gl.glVertex2d(67.2 / PX + SHIFT_X, 188 / PY + SHIFT_Y);
            Gl.glVertex2d(58.2 / PX + SHIFT_X, 196 / PY + SHIFT_Y);
            Gl.glVertex2d(63.7 / PX + SHIFT_X, 232.5 / PY + SHIFT_Y);
            Gl.glVertex2d(58.2 / PX + SHIFT_X, 196 / PY + SHIFT_Y);
            Gl.glVertex2d(48.7 / PX + SHIFT_X, 184.5 / PY + SHIFT_Y);
            Gl.glVertex2d(44.2 / PX + SHIFT_X, 192.3 / PY + SHIFT_Y);
            Gl.glVertex2d(48.8 / PX + SHIFT_X, 222 / PY + SHIFT_Y);
            Gl.glVertex2d(44.2 / PX + SHIFT_X, 192.3 / PY + SHIFT_Y);
            Gl.glVertex2d(48.7 / PX + SHIFT_X, 184.5 / PY + SHIFT_Y);
            Gl.glVertex2d(44.2 / PX + SHIFT_X, 192.3 / PY + SHIFT_Y);
            Gl.glVertex2d(30 / PX + SHIFT_X, 180 / PY + SHIFT_Y);
            Gl.glEnd();// завершуємо режим малювання

        }
        private void DrawTop()
        {
            //x,y 1
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(30 / PX + SHIFT_X, 180 / PY + SHIFT_Y);
            Gl.glVertex2d(40 / PX + SHIFT_X, 219 / PY + SHIFT_Y);
            Gl.glVertex2d(33 / PX + SHIFT_X, 245 / PY + SHIFT_Y);
            Gl.glVertex2d(20 / PX + SHIFT_X, 245 / PY + SHIFT_Y);
            Gl.glVertex2d(16 / PX + SHIFT_X, 255 / PY + SHIFT_Y);
            Gl.glVertex2d(12 / PX + SHIFT_X, 276 / PY + SHIFT_Y);
            Gl.glVertex2d(15 / PX + SHIFT_X, 290 / PY + SHIFT_Y);
            Gl.glVertex2d(0 + SHIFT_X, 340 / PY + SHIFT_Y);
            Gl.glVertex2d(20 / PX + SHIFT_X, 370 / PY + SHIFT_Y);
            Gl.glVertex2d(40 / PX + SHIFT_X, 415 / PY + SHIFT_Y);
            Gl.glVertex2d(30 / PX + SHIFT_X, 440 / PY + SHIFT_Y);
            Gl.glVertex2d(35 / PX + SHIFT_X, 460 / PY + SHIFT_Y);
            Gl.glVertex2d(46 / PX + SHIFT_X, 480 / PY + SHIFT_Y);
            Gl.glVertex2d(65 / PX + SHIFT_X, 500 / PY + SHIFT_Y);
            Gl.glVertex2d(70 / PX + SHIFT_X, 520 / PY + SHIFT_Y);
            Gl.glVertex2d(87 / PX + SHIFT_X, 555 / PY + SHIFT_Y);
            Gl.glVertex2d(113 / PX + SHIFT_X, 600 / PY + SHIFT_Y);
            Gl.glVertex2d(150 / PX + SHIFT_X, 640 / PY + SHIFT_Y);
            Gl.glVertex2d(180 / PX + SHIFT_X, 655 / PY + SHIFT_Y);
            Gl.glVertex2d(200 / PX + SHIFT_X, 660 / PY + SHIFT_Y);
            Gl.glVertex2d(270 / PX + SHIFT_X, 658 / PY + SHIFT_Y);
            Gl.glVertex2d(320 / PX + SHIFT_X, 642 / PY + SHIFT_Y);
            Gl.glVertex2d(350 / PX + SHIFT_X, 625 / PY + SHIFT_Y);
            Gl.glVertex2d(400 / PX + SHIFT_X, 582 / PY + SHIFT_Y);
            Gl.glVertex2d(450 / PX + SHIFT_X, 520 / PY + SHIFT_Y);
            Gl.glVertex2d(500 / PX + SHIFT_X, 420 / PY + SHIFT_Y);
            Gl.glVertex2d(500 / PX + SHIFT_X, 280 / PY + SHIFT_Y);
            Gl.glVertex2d(483 / PX + SHIFT_X, 225 / PY + SHIFT_Y);
            Gl.glVertex2d(480 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(430 / PX + SHIFT_X, 160 / PY + SHIFT_Y);
            Gl.glVertex2d(415 / PX + SHIFT_X, 190 / PY + SHIFT_Y);
            Gl.glVertex2d(410 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(390 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(400 / PX + SHIFT_X, 220 / PY + SHIFT_Y);
            Gl.glVertex2d(390 / PX + SHIFT_X, 232 / PY + SHIFT_Y);
            Gl.glVertex2d(350 / PX + SHIFT_X, 210 / PY + SHIFT_Y);
            Gl.glVertex2d(310 / PX + SHIFT_X, 210 / PY + SHIFT_Y);
            Gl.glVertex2d(290 / PX + SHIFT_X, 230 / PY + SHIFT_Y);
            Gl.glVertex2d(260 / PX + SHIFT_X, 200 / PY + SHIFT_Y);
            Gl.glVertex2d(239 / PX + SHIFT_X, 120 / PY + SHIFT_Y);

            Gl.glEnd();// завершуємо режим малювання

        }
        private void DrawNose()
        {
            //x,y 3
            Gl.glBegin(Gl.GL_LINE_LOOP);

            Gl.glVertex2d(119.6 / PX + SHIFT_X, 315.2 / PY + SHIFT_Y);
            Gl.glVertex2d(114.5 / PX + SHIFT_X, 312.5 / PY + SHIFT_Y);
            Gl.glVertex2d(111.3 / PX + SHIFT_X, 300.6 / PY + SHIFT_Y);
            Gl.glVertex2d(104.5 / PX + SHIFT_X, 294.3 / PY + SHIFT_Y);
            Gl.glVertex2d(95.8 / PX + SHIFT_X, 299.9 / PY + SHIFT_Y);
            Gl.glVertex2d(92 / PX + SHIFT_X, 309.2 / PY + SHIFT_Y);
            Gl.glVertex2d(113.9 / PX + SHIFT_X, 370.9 / PY + SHIFT_Y);
            Gl.glVertex2d(116.7 / PX + SHIFT_X, 404.5 / PY + SHIFT_Y);
            Gl.glVertex2d(122 / PX + SHIFT_X, 412.4 / PY + SHIFT_Y);
            Gl.glVertex2d(128.4 / PX + SHIFT_X, 412.4 / PY + SHIFT_Y);
            Gl.glVertex2d(141 / PX + SHIFT_X, 413.2 / PY + SHIFT_Y);
            Gl.glVertex2d(148.2 / PX + SHIFT_X, 410.7 / PY + SHIFT_Y);
            Gl.glVertex2d(152.3 / PX + SHIFT_X, 402.3 / PY + SHIFT_Y);
            Gl.glVertex2d(152.6 / PX + SHIFT_X, 371 / PY + SHIFT_Y);
            Gl.glVertex2d(168.3 / PX + SHIFT_X, 339.2 / PY + SHIFT_Y);
            Gl.glVertex2d(170.9 / PX + SHIFT_X, 326 / PY + SHIFT_Y);
            Gl.glVertex2d(169 / PX + SHIFT_X, 314.4 / PY + SHIFT_Y);
            Gl.glVertex2d(165.5 / PX + SHIFT_X, 295.3 / PY + SHIFT_Y);
            Gl.glVertex2d(159.2 / PX + SHIFT_X, 289.1 / PY + SHIFT_Y);
            Gl.glVertex2d(146.5 / PX + SHIFT_X, 288.3 / PY + SHIFT_Y);
            Gl.glVertex2d(136 / PX + SHIFT_X, 293 / PY + SHIFT_Y);
            Gl.glVertex2d(129.2 / PX + SHIFT_X, 301.9 / PY + SHIFT_Y);
            Gl.glVertex2d(124 / PX + SHIFT_X, 311.8 / PY + SHIFT_Y);
            Gl.glEnd();
        }
        private void DrawEyes()
        {
        RightEye:
            Gl.glColor3f(1, 0, 0);
            //x,y 4
            Gl.glBegin(Gl.GL_LINE_LOOP);
            Gl.glVertex2d(116.3 / PX + SHIFT_X, 413.6 / PY + SHIFT_Y);
            Gl.glVertex2d(111.7 / PX + SHIFT_X, 384.3 / PY + SHIFT_Y);
            Gl.glVertex2d(90.3 / PX + SHIFT_X, 358 / PY + SHIFT_Y);
            Gl.glVertex2d(39 / PX + SHIFT_X, 355 / PY + SHIFT_Y);
            Gl.glVertex2d(31.4 / PX + SHIFT_X, 363.5 / PY + SHIFT_Y);
            Gl.glVertex2d(50 / PX + SHIFT_X, 410.3 / PY + SHIFT_Y);
            Gl.glVertex2d(41.5 / PX + SHIFT_X, 440.2 / PY + SHIFT_Y);
            Gl.glVertex2d(42.3 / PX + SHIFT_X, 451 / PY + SHIFT_Y);
            Gl.glVertex2d(50.7 / PX + SHIFT_X, 463.5 / PY + SHIFT_Y);
            Gl.glVertex2d(62.5 / PX + SHIFT_X, 469.3 / PY + SHIFT_Y);
            Gl.glVertex2d(77.6 / PX + SHIFT_X, 471.1 / PY + SHIFT_Y);
            Gl.glVertex2d(85.7 / PX + SHIFT_X, 477 / PY + SHIFT_Y);
            Gl.glVertex2d(97.6 / PX + SHIFT_X, 480.6 / PY + SHIFT_Y);
            Gl.glVertex2d(106.5 / PX + SHIFT_X, 479 / PY + SHIFT_Y);
            Gl.glVertex2d(129 / PX + SHIFT_X, 432.8 / PY + SHIFT_Y);
            Gl.glEnd();

        LeftEye:

            //x,y 5
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2d(192.3 / PX + SHIFT_X, 438.1 / PY + SHIFT_Y);
            Gl.glVertex2d(201.5 / PX + SHIFT_X, 436 / PY + SHIFT_Y);
            Gl.glVertex2d(208.7 / PX + SHIFT_X, 429.8 / PY + SHIFT_Y);
            Gl.glVertex2d(218 / PX + SHIFT_X, 453.3 / PY + SHIFT_Y);
            Gl.glVertex2d(252 / PX + SHIFT_X, 479.6 / PY + SHIFT_Y);
            Gl.glVertex2d(293 / PX + SHIFT_X, 453.6 / PY + SHIFT_Y);
            Gl.glVertex2d(296.6 / PX + SHIFT_X, 454.8 / PY + SHIFT_Y);
            Gl.glVertex2d(310 / PX + SHIFT_X, 449 / PY + SHIFT_Y);
            Gl.glVertex2d(330 / PX + SHIFT_X, 432.7 / PY + SHIFT_Y);
            Gl.glVertex2d(332 / PX + SHIFT_X, 423.3 / PY + SHIFT_Y);
            Gl.glVertex2d(329 / PX + SHIFT_X, 409 / PY + SHIFT_Y);
            Gl.glVertex2d(319 / PX + SHIFT_X, 393.7 / PY + SHIFT_Y);
            Gl.glVertex2d(313 / PX + SHIFT_X, 348.8 / PY + SHIFT_Y);
            Gl.glVertex2d(303.6 / PX + SHIFT_X, 339.3 / PY + SHIFT_Y);
            Gl.glVertex2d(283 / PX + SHIFT_X, 332.4 / PY + SHIFT_Y);
            Gl.glVertex2d(266.9 / PX + SHIFT_X, 333.7 / PY + SHIFT_Y);
            Gl.glVertex2d(232.4 / PX + SHIFT_X, 350 / PY + SHIFT_Y);
            Gl.glVertex2d(197.3 / PX + SHIFT_X, 390.2 / PY + SHIFT_Y);
            Gl.glVertex2d(192 / PX + SHIFT_X, 402.2 / PY + SHIFT_Y);
            Gl.glVertex2d(194.9 / PX + SHIFT_X, 430.2 / PY + SHIFT_Y);
            Gl.glVertex2d(192.3 / PX + SHIFT_X, 438.1 / PY + SHIFT_Y);
            Gl.glVertex2d(184.6 / PX + SHIFT_X, 430.6 / PY + SHIFT_Y);
            Gl.glEnd();

            //x,y 6
            //Gl.glBegin(Gl.GL_LINE_STRIP);

            //Gl.glVertex2d(208.7 / PX + SHIFT_X, 429.8 / PY + SHIFT_Y);
            //Gl.glVertex2d(220 / PX + SHIFT_X, 414.8 / PY + SHIFT_Y);
            //Gl.glVertex2d(225.6 / PX + SHIFT_X, 424 / PY + SHIFT_Y);
            //Gl.glVertex2d(234.6 / PX + SHIFT_X, 406.6 / PY + SHIFT_Y);
            //Gl.glVertex2d(251.3 / PX + SHIFT_X, 388 / PY + SHIFT_Y);
            //Gl.glVertex2d(258.7 / PX + SHIFT_X, 379.4 / PY + SHIFT_Y);
            //Gl.glVertex2d(255.4 / PX + SHIFT_X, 369 / PY + SHIFT_Y);
            //Gl.glVertex2d(245.8 / PX + SHIFT_X, 359.7 / PY + SHIFT_Y);
            //Gl.glVertex2d(236.5 / PX + SHIFT_X, 358.7 / PY + SHIFT_Y);
            //Gl.glVertex2d(245.8 / PX + SHIFT_X, 359.7 / PY + SHIFT_Y);
            //Gl.glVertex2d(255.4 / PX + SHIFT_X, 369 / PY + SHIFT_Y);
            //Gl.glVertex2d(258.7 / PX + SHIFT_X, 379.4 / PY + SHIFT_Y);
            //Gl.glVertex2d(267.8 / PX + SHIFT_X, 385.7 / PY + SHIFT_Y);
            //Gl.glVertex2d(276.4 / PX + SHIFT_X, 380.4 / PY + SHIFT_Y);
            //Gl.glVertex2d(280.7 / PX + SHIFT_X, 370.8 / PY + SHIFT_Y);
            //Gl.glVertex2d(280.3 / PX + SHIFT_X, 357.2 / PY + SHIFT_Y);
            //Gl.glEnd();
        }
    }
}
