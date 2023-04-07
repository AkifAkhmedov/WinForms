//Предположим, что существует прямоугольник, границы
//которого на 10 пикселей отстоят от границ клиентской
//области окна. Необходимо при нажатии левой кнопки
//мыши выводить в заголовок окна сообщение о том, где
//произошел щелчок мышью: внутри прямоугольника,
//снаружи или на границе прямоугольника. При нажатии
//правой кнопки мыши необходимо выводить в заголовок
//окна информацию о размере клиентской области окна
//(ширина и высота клиентской области окна).
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Приложение";
            this.MouseClick += Form1_MouseClick;
           
            
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.Location.X;
                int y = e.Location.Y;
                
                int height = this.Height;
                int width = this.Width;
                if (x == 0 || y == 0 || x == width || y == height)
                {
                    this.Text = "Неизвестная область ";
                }
                else if (x < (width - 100)  && y < (height - 100))
                {
                    this.Text = " внутри прямоугольника ";
                }
                else if (x > (width - 100) || y > (height - 100))
                {
                    this.Text = " снаружи прямоугольника";
                }
            }
            
        }
    }
}
