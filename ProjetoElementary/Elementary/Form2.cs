using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementary
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            textBox5.Visible = false;
            panel5.Visible = false;
            pictureBox6.Visible = false;
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_white;
            panel4.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_black;
            panel4.BackColor = Color.Black;

            if(textBox1.Text == "")
            {
                textBox1.Text = "Nome completo";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.ForeColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel3.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel3.BackColor = Color.Black;

            if(textBox2.Text == "")
            {
                textBox2.Text = "Email";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox3.PasswordChar = '*';
            textBox3.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel2.BackColor = Color.White;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel2.BackColor = Color.Black;

            if(textBox3.Text == "")
            {
                textBox3.PasswordChar = '\u0000';
                textBox3.Text = "Senha";
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox4.PasswordChar = '*';
            textBox4.ForeColor = Color.White;
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.ForeColor = Color.Black;
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;

            if (textBox4.Text == "")
            {
                textBox4.PasswordChar = '\u0000';
                textBox4.Text = "Confirmar senha";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Clear();
            textBox5.ForeColor = Color.White;
            panel5.BackColor = Color.White;
            pictureBox6.BackgroundImage = Properties.Resources.icon_CRM_white;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.ForeColor = Color.Black;
            panel5.BackColor = Color.Black;
            pictureBox6.BackgroundImage = Properties.Resources.icon_CRM_black;

            if(textBox5.Text == "")
            {
                textBox5.Text = "CRM";
            }
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.White;
            panel6.BackColor = Color.White;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_white;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.Black;
            panel6.BackColor = Color.Black;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_black;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked.Equals(true))
            {
                textBox5.Visible = true;
                textBox5.Text = "CRM";
                panel5.Visible = true;
                pictureBox6.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
                panel5.Visible = false;
                pictureBox6.Visible = false;
            }
        }

        // Botão sair 'X'
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // Botao cadastrar
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Medico medico = new Medico(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToDateTime(maskedTextBox1.Text), true, textBox5.Text);
                BD bd = new BD(medico);
            }
            else
            {
                Usuario usuario = new Usuario(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToDateTime(maskedTextBox1.Text), true);
                BD bd = new BD(usuario);
            }
        }   
    }
}
