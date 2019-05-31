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
    public partial class Posts : Form
    {
        // Instância de classe
        Post post = new Post();
        Usuario usuario = new Usuario();
        BD bd = new BD();

        public Posts()
        {
            InitializeComponent();
            ActiveControl = button1;
        }

        public Posts(BD pBd, Usuario pUsuario)
        {
            InitializeComponent();
            ActiveControl = button1;

            usuario = pUsuario;
            bd = pBd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Título" || richTextBox1.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
            else
            {
                post.setTitulo(textBox1.Text);
                post.setTexto(richTextBox1.Text);
                usuario.addPost(post);

                this.Dispose();
                Feed menu = new Feed(bd, usuario);
                menu.ShowDialog();
            }
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            Feed feed = new Feed(bd, usuario);
            this.Dispose();
            feed.ShowDialog();
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Título")
            {
                textBox1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Título";
            }
        }
    }
}
