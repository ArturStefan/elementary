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
        Medico medico = new Medico();

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

        public Posts(BD pBd, Medico pMedico)
        {
            InitializeComponent();
            ActiveControl = button1;

            medico = pMedico;
            bd = pBd;
        }

        // Botão publicar
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "Título" || richTextBox1.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
            else
            {
                if(usuario.getEmail() != null)
                {
                    post.setTitulo(textBox1.Text);
                    post.setTexto(richTextBox1.Text);
                    usuario.addPost(post);

                    this.Dispose();
                    Feed menu = new Feed(bd, usuario);
                    menu.ShowDialog();
                }
                else
                {
                    post.setTitulo(textBox1.Text);
                    post.setTexto(richTextBox1.Text);
                    medico.addPost(post);

                    this.Dispose();
                    Feed feed = new Feed(bd, medico);
                    feed.ShowDialog();
                }
            }
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            if (usuario.getEmail() != null)
            {
                this.Dispose();
                Feed menu = new Feed(bd, usuario);
                menu.ShowDialog();
            }
            else
            {
                this.Dispose();
                Feed feed = new Feed(bd, medico);
                feed.ShowDialog();
            }
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

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
