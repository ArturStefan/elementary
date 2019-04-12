using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel2.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel2.BackColor = Color.Black;

            if(textBox1.Text == "")
            {
                textBox1.Text = "Email";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;

            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\u0000';
                textBox2.Text = "Senha";
            }
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Botão cadastrar 
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 cadastrar = new Form2();
            cadastrar.Visible = true;
        }

        // Botão entrar
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 menu = new Form3();
            menu.Visible = true;
        }
    }
}
