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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel2.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel2.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;
        }
    }
}
