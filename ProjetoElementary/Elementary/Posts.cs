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
        }

        public Posts(BD pBd, Usuario pUsuario)
        {
            InitializeComponent();

            usuario = pUsuario;
            bd = pBd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            post.setTitulo(textBox1.Text);
            post.setTexto(textBox2.Text);
            usuario.addPost(post);

            this.Dispose();
            Feed menu = new Feed(bd, usuario);
            menu.ShowDialog();
        }
    }
}
