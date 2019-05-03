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
    public partial class Form4 : Form
    {
        // Instância de classe
        Post post = new Post();
        Usuario usuario = new Usuario();
        BD bd = new BD();

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(BD pBd, Usuario pUsuario)
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
            Form3 menu = new Form3(bd, usuario);
            menu.ShowDialog();
        }
    }
}
