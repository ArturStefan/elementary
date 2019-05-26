using System;
using System.Collections;
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
    public partial class FeedAmigos : Form
    {
        // Intância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();

        //Amigos
        Medico amigoMedico = new Medico();
        Usuario amigoUsuario = new Usuario();

        //Lista de Usuários
        BD bd = new BD();

        //Lista de posts
        Post post = new Post();

        // Construtor para não perder os dados do médico
        public FeedAmigos(BD pBd, Medico pMedico, Medico fMedico)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;

            bd = (BD)pBd;
            medico = (Medico)pMedico;
            amigoMedico = (Medico)fMedico;


            textBox1.Text = medico.getNome();

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
        }

        // Construtor para não perder os dados do usuário
        public FeedAmigos(BD pBD, Usuario pUsuario, Usuario fUsuario)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;

            bd = (BD)pBD;
            usuario = (Usuario)pUsuario;
            amigoUsuario = (Usuario)fUsuario;

            textBox1.Text = "Anônimo";

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;

            novoPost();
        }
        public FeedAmigos(BD pBd, Medico pMedico, Usuario fUsuario)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;

            bd = (BD)pBd;
            medico = (Medico)pMedico;
            amigoUsuario = (Usuario)fUsuario;

            textBox1.Text = medico.getNome();

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button5.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
        }
        public FeedAmigos(BD pBD, Usuario pUsuario, Medico fMedico)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;
            amigoMedico = (Medico)fMedico;
            bd = (BD)pBD;
            usuario = (Usuario)pUsuario;

            textBox1.Text = "Anônimo";

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button5.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;

            novoPost();
        }

        // Botão ON
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Silver;

            textBox1.Text = "Anônimo";
        }

        // Botão OFF
        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
            button1.BackColor = Color.Silver;

            // Diálogo de confirmação para desativar o anonimato
            DialogResult ativarDesativarAnonimato = MessageBox.Show("Tem certeza que deseja desativar o anonimato?", "AVISO", MessageBoxButtons.YesNo);

            if (ativarDesativarAnonimato == DialogResult.Yes)
            {
                textBox1.Text = usuario.getNome();
            }
        }

        // Efeito do campo de pesquisa
        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox6.ForeColor = Color.White;
            panel4.BackColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier_white;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Black;
            textBox6.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier;

            if (textBox6.Text == "")
            {
                textBox6.Text = "Pesquisar";
            }
        }

        // Exibir/esconder opções (engrenagem)
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button8.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
        }

        // Botão para realizar um novo post
        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Posts novoPost = new Posts(bd, amigoUsuario);
            novoPost.ShowDialog();
        }

        // Método para exibir os posts feitos
        private void novoPost()
        {
            ArrayList listaDePosts = new ArrayList();

            int x = (panel6.Width / 2) - 50; // Menos a metade do tamanho do controle (textbox)
            int y = 0;
            int y2 = 0;

            for (int i = amigoUsuario.numeroPost() - 1; i >= 0; i--)
            {
                TextBox tituloDoPost = new TextBox();
                TextBox textoDopost = new TextBox();

                listaDePosts = amigoUsuario.getPost();
                post = (Post)listaDePosts[i];

                tituloDoPost.Text = post.getTitulo();
                textoDopost.Text = post.getTexto();

                tituloDoPost.Location = new Point(x, y += 100);
                y2 = tituloDoPost.Location.Y;
                textoDopost.Location = new Point(x, y2 += 30);

                panel6.Controls.Add(tituloDoPost);
                panel6.Controls.Add(textoDopost);
            }
        }    
            
        // Botão para excluir a conta
        private void button4_Click(object sender, EventArgs e)
        {
            // Diálogo de confirmação para desativar a conta
            DialogResult desativarConta = MessageBox.Show("Deseja realmente desativar sua conta?", "AVISO", MessageBoxButtons.YesNo);

            if (desativarConta == DialogResult.Yes)
            {
                usuario.setStatusConta(false);
                medico.setStatusConta(false);

                this.Dispose();
                Login login = new Login(bd);
                login.ShowDialog();
            }
        }

        // Botão sair
        private void button5_Click(object sender, EventArgs e)
        {
            Login form1 = new Login(bd);
            this.Hide();
            form1.ShowDialog();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button9_Click(object sender, EventArgs e)
        {
            usuario.addAmigo(amigoUsuario.getEmail());
            foreach (Post post in amigoUsuario.getPost())
            {
                usuario.addPost(post);
            }
            MessageBox.Show("Adicionado com sucesso!!!");
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Feed form3 = new Feed(bd, usuario);
            this.Hide();
            form3.ShowDialog();
        }
    }
 }

