using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Elementary
{
    public partial class Form3 : Form
    {
        // Intância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();
        Post post = new Post();

        // Construtor para não perder os dados do médico
        public Form3(BD pBd, Medico pMedico)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;

            bd = (BD)pBd;
            medico = (Medico)pMedico;

            textBox1.Text = medico.getNome();

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
        }

        // Construtor para não perder os dados do usuário
        public Form3(BD pBD, Usuario pUsuario)
        {
            InitializeComponent();

            ActiveControl = pictureBox1;

            bd = (BD)pBD;
            usuario = (Usuario)pUsuario;

            textBox1.Text = "Anônimo";

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button4.Visible = false;
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

            if(ativarDesativarAnonimato == DialogResult.Yes)
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
            Form4 novoPost = new Form4(bd, usuario);
            novoPost.ShowDialog();
        }

        // Método para exibir os posts feitos
        private void novoPost()
        {
            ArrayList listaDePosts = new ArrayList();

            int x = (panel6.Width / 2) - 50; // Menos a metade do tamanho do controle (textbox)
            int y = 0;
            int y2 = 0;

            for (int i = usuario.numeroPost() - 1; i >= 0; i--)
            {
                TextBox tituloDoPost = new TextBox();
                TextBox textoDopost = new TextBox();
                
                listaDePosts = usuario.getPost();
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

            if(desativarConta == DialogResult.Yes)
            {
                usuario.setStatusConta(false);
                medico.setStatusConta(false);

                this.Dispose();
                Form1 login = new Form1(bd);
                login.ShowDialog();
            }
        }

        // Botão sair
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(bd);
            this.Hide();
            form1.ShowDialog();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
