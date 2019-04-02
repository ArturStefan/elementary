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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Silver;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
            button1.BackColor = Color.Silver;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.White;
            panel4.BackColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier_white;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button5.Visible = false;
            button3.Visible = true;
            button6.Visible = false;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
            textBox6.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier;
        }
    }
}
