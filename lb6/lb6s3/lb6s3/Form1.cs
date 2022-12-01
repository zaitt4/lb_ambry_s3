using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace lb6s3
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
        }
        // Ряд допоміжних змінних - поворот
        private int rot = 0;
        // прапор – завантажена чи текстура
        private bool textureIsLoad = false;
        // ім'я текстури
        public string texture_name = "";
        // Ідентифікатор текстури
        public int imageId = 0;
        // текстурний об'єкт
        public uint mGlTextureObject = 0;
        double x = 0, y = 0;


    private void Form1_Load(object sender, EventArgs e)
        {
        // ініціалізація бібліотеки glut
        Glut.glutInit();
        // ініціалізація режиму екрану
        Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE);
        // ініціалізація бібліотеки openIL
        Il.ilInit();

        Il.ilEnable(Il.IL_ORIGIN_SET);
        // встановлення кольору очищення екрану (RGBA)
        Gl.glClearColor(255, 255, 255, 1);
        // Установка порту висновку
        Gl.glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
        // активація проекційної матриці
        Gl.glMatrixMode(Gl.GL_PROJECTION);
        // Очищення матриці
        Gl.glLoadIdentity();
        // Встановлення перспективи
        Glu.gluPerspective(30, simpleOpenGlControl1.Width / simpleOpenGlControl1.Height, 1, 100);
        // Установка об'єктно - видовий матриці
        Gl.glMatrixMode(Gl.GL_MODELVIEW); Gl.glLoadIdentity();
        // Початкові налаштування OpenGL
        Gl.glEnable(Gl.GL_DEPTH_TEST);
        Gl.glEnable(Gl.GL_LIGHTING);
        Gl.glEnable(Gl.GL_LIGHT0);
        timer1.Start(); // Активація таймера
        
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {            
        // відкриваємо вікно вибору файлу
        DialogResult res = openFileDialog1.ShowDialog();
        // якщо файл вибраний - і повернуто результат OK
        if (res == DialogResult.OK)
            {
                // створюємо зображення з ідентифікатором imageId
                Il.ilGenImages(1, out imageId);
                // робимо зображення поточним
                Il.ilBindImage(imageId);
                // адреса зображення отримана за допомогою вікна вибору файлу
                string url = openFileDialog1.FileName;
                // пробуємо завантажити зображення
                if (Il.ilLoadImage(url))
                {
                    // якщо завантаження пройшло успішно
                    // Зберігаємо розміри зображення
                    int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                    int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                    // Визначаємо число біт на піксель
                    int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                    switch (bitspp)
                    // Залежно від отриманого результату
                    { // створюємо текстуру, використовуючи режим GL_RGB чи GL_RGBA
                        case 24:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                            break;
                        case 32:
                            mGlTextureObject = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                            break;
                    } // активуємо прапор, що сигналізує завантаження текстури
                    textureIsLoad = true;
                    // Очищаємо пам'ять
                    Il.ilDeleteImages(1, ref imageId);
                }
            }
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        { // Ідентифікатор текстурного об'єкта
            uint texObject; // генеруємо текстурний об'єкт
            Gl.glGenTextures(1, out texObject);
            // встановлюємо режим пакування пікселів
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            // створюємо прив'язку до щойно створеної текстури
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            // встановлюємо режим фільтрації та повторення текстури
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            // створюємо RGB чи RGBA текстуру
            switch (Format)
            {
                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;
            }
            // Повертаємо ідентифікатор текстурного об'єкта
            return texObject;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // виклик функції відтворення сцени
            Draw();
        }
        // функція малювання
        private void Draw()
        {
            if (textureIsLoad)
            {
                rot = 180; // збільшуємо кут повороту
                //if (rot > 360) // Коригуємо кут
                    //rot = 0;
                // очищення буфера кольору та буфера глибини
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT); Gl.glClearColor(255, 255, 255,
               1);
                Gl.glLoadIdentity(); // очищення поточною матриці
                Gl.glEnable(Gl.GL_TEXTURE_2D); // Включаємо режим текстурування
                                               // Включаємо режим текстурування, вказуючи ідентифікатор mGlTextureObject
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, mGlTextureObject);
                Gl.glPushMatrix(); // Зберігаємо стан матриці
                Gl.glTranslated(x + 1, y - 1.5, -5); // виконуємо переміщення для наочнішої вистави сцени
                Gl.glRotated(rot, 0, 1, 0); // реалізуємо поворот об'єкта
                Gl.glBegin(Gl.GL_QUADS); // Малюємо полігон
                                         // вказуємо по черзі вершини та текстурні координати
                Gl.glVertex3d(1, 1, 0);
                Gl.glTexCoord2f(0, 0);
                Gl.glVertex3d(1, 0, 0);
                Gl.glTexCoord2f(1, 0);
                Gl.glVertex3d(0, 0, 0);
                Gl.glTexCoord2f(1, 1);
                Gl.glVertex3d(0, 1, 0);
                Gl.glTexCoord2f(0, 1);
                // Завершуємо малювання
                Gl.glEnd();
                // Повертаємо матрицю
                Gl.glPopMatrix();
                // відключаємо режим текстурування
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                // оновлюємо елемент зі сценою
                simpleOpenGlControl1.Invalidate();
            }
        }

        private void simpleOpenGlControl1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.Location.X / 215.0 - 1.8;

            if (x < -1.5) { x = -1.5; }          
            if (x > 0.5) { x = 0.5; }
           

            y = (500 - e.Location.Y) / 120.0 - 1.8;

            if (y > 1.87) { y = 1.87; }
            if (y < 0.14) { y = 0.14; }
           
        }
    }

}

