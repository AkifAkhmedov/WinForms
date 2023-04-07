using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.PreviewKeyDown += Form1_PreviewKeyDown;
            label2.Text = "Турбо: нету";
            label1.AutoSize = false;
           

        }

        private async void TurboSpdAsync()
        {
            await Task.Run(async () =>
            {
                turboSpeed = 15;
                TimerSpdAsync();
                await Task.Delay(5000);
                turboSpeed = 1;
            });
        }
        private async void TimerSpdAsync()
        {
            await Task.Run(async () =>
            {
                int q = 5;
                while(q >= 0 ) {
                    Invoke(new Action(() => {
                        label2.Text = "Турбо: " + q.ToString();
                    }));
                    q--;
                    await Task.Delay(1000);
                }
                Invoke(new Action(() => {
                    label2.Text = "Турбо: нету";
                }));
            });
        }

        int y = 0;
        int x = 0;
        int turboSpeed = 1;

   
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {

                TurboSpdAsync();
            }


            if (e.KeyCode == Keys.Up)
            {
                y -= turboSpeed;
                label1.Location = new System.Drawing.Point(x, y);
            }
             if (e.KeyCode == Keys.Down)
            {
                y += turboSpeed;
                label1.Location = new System.Drawing.Point(x, y);
            }
             if (e.KeyCode == Keys.Left)
            {
                x -= turboSpeed;
                label1.Location = new System.Drawing.Point(x, y);
            }
             if (e.KeyCode == Keys.Right)
            {
                x += turboSpeed;
                label1.Location = new System.Drawing.Point(x, y);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("T");
        }

       
    }
}