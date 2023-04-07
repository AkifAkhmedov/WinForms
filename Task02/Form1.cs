using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Task02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Button button = new Button();
            button1.Text = "Enter";
            label1.Text = "Login";
            label2.Text = "Password";
            label3.Hide();

            string path = Directory.GetCurrentDirectory() + "/file.txt";
            string[] text = File.ReadAllLines(path);

            listBox1.Items.AddRange(text);
            this.Text = "Akif";

        }
        private void ChangeLabel()
        {
            //string text = File.ReadAllText(path);
        }

        public void SaveUsers()
        {
            string path = Directory.GetCurrentDirectory() + "/file.txt";
            string data = "Login: " + textBox1.Text + " Passowrd: " + textBox2.Text + "\n";
            File.AppendAllText(path, data);
            label3.Visible = true;
            label3.Text = "Succes";
            listBox1.Items.Add(data);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text  != string.Empty && textBox2.Text != string.Empty)
            SaveUsers();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                  
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
