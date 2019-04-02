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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_white;
            panel4.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.icon_username_black;
            panel4.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Clear();
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel3.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel3.BackColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Clear();
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel2.BackColor = Color.White;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel2.BackColor = Color.Black;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.Clear();
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            pictureBox4.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
