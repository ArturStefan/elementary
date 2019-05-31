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
    public partial class Feed : Form
    {
        // Intância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        Grupo grupo = new Grupo();
        Medico amigoMedico = new Medico();
        Usuario amigoUsuario = new Usuario();
        BD bd = new BD();
        Post post = new Post();

        // Construtor para não perder os dados do médico
        public Feed(BD pBd, Medico pMedico)
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
            button9.Visible = true;
        }

        // Construtor para não perder os dados do grupo
        public Feed(BD pBD, Medico pMedico, Grupo pGrupo)
        {
            InitializeComponent();

            bd = pBD;
            medico = pMedico;
            grupo = pGrupo;

            // Design + deixar o grupo visível
            int x = (panel7.Width / 2) - 115; // Menos a metade do tamanho do controle (textbox)
            int y = 0;

            TextBox addNovoGrupo = new TextBox();
            addNovoGrupo.Text = grupo.getNome();
            addNovoGrupo.Font = new Font("Baloo Bhaijaan", 12);
            addNovoGrupo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            addNovoGrupo.TextAlign = HorizontalAlignment.Left;
            addNovoGrupo.Width = 230;
            addNovoGrupo.ReadOnly = true;
            addNovoGrupo.BackColor = Color.YellowGreen;
            addNovoGrupo.Location = new Point(x, y += 10);
            panel7.Controls.Add(addNovoGrupo);

            // Configurações das opções (engrenagem)
            ActiveControl = pictureBox1;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = true;
        }

        // Construtor para não perder os dados do usuário
        public Feed(BD pBD, Usuario pUsuario)
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

            // Desativar anonimato ?
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
            Posts novoPost = new Posts(bd, usuario);
            novoPost.ShowDialog();
        }

        // Método para exibir os posts feitos
        private void novoPost()
        {
            ArrayList listaDePosts = new ArrayList();

            int x = (panel6.Width / 2) - 240; // Menos a metade do tamanho do controle (textbox)
            int x2 = (panel6.Width / 2) - 240; // Menos a metade do tamanho do controle (richtextbox)
            int y = 0;
            int y2 = 0;

            for (int i = usuario.numeroPost() - 1; i >= 0; i--)
            {
                TextBox tituloDoPost = new TextBox();
                RichTextBox textoDoPost = new RichTextBox();

                listaDePosts = usuario.getPost();
                post = (Post)listaDePosts[i];

                // Design dos posts
                tituloDoPost.Font = new Font("Baloo Bhaijaan", 18);
                tituloDoPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
                tituloDoPost.TextAlign = HorizontalAlignment.Center;
                tituloDoPost.Width = 480;
                tituloDoPost.ReadOnly = true;

                textoDoPost.Font = new Font("Baloo Bhaijaan", 12);
                textoDoPost.BorderStyle = System.Windows.Forms.BorderStyle.None;
                textoDoPost.SelectionAlignment = HorizontalAlignment.Center;
                textoDoPost.Width = 480;
                textoDoPost.Height = (int)(3 * textoDoPost.Font.Height) + textoDoPost.GetLineFromCharIndex(textoDoPost.Text.Length + 1) * textoDoPost.Font.Height + 1 + textoDoPost.Margin.Vertical;
                textoDoPost.SelectionStart = 0;
                textoDoPost.SelectionStart = textoDoPost.Text.Length;
                textoDoPost.ReadOnly = true;

                tituloDoPost.Text = post.getTitulo();
                textoDoPost.Text = post.getTexto();
                
                if(y == 0)
                {
                    tituloDoPost.Location = new Point(x, y += 100);
                }
                else
                {
                    tituloDoPost.Location = new Point(x, y += 150);
                }
                
                y2 = tituloDoPost.Location.Y;
                textoDoPost.Location = new Point(x2, y2 += 50);
                y = textoDoPost.Location.Y;

                panel6.Controls.Add(tituloDoPost);
                panel6.Controls.Add(textoDoPost);
            }
        }

        // Botão para excluir a conta
        private void button4_Click(object sender, EventArgs e)
        {
            // Desativar conta ?
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
            string temp = textBox6.Text;

            if (bd.getUsuario(temp) != null)
            {
                amigoUsuario = (Usuario)bd.getUsuario(temp);
                FeedAmigos form6 = new FeedAmigos(bd, usuario, amigoUsuario);
                this.Hide();
                form6.ShowDialog();
                MessageBox.Show("Usuario encontrado");
            }

            if (bd.getMedico(temp) != null)
            {
                amigoMedico = (Medico)bd.getMedico(temp);
                usuario.addAmigo(amigoMedico.getEmail());
                MessageBox.Show("Medico encontrado");
            }
            if (bd.getUsuario(temp) == null && bd.getMedico(temp) == null)
            {
                MessageBox.Show("Usuario inexistente");
            }
        }

        // Botão "Novo Grupo"
        private void button9_Click(object sender, EventArgs e)
        {
            CriarGrupo novoGrupo = new CriarGrupo(bd, medico);
            this.Dispose();
            novoGrupo.ShowDialog();
        }
    }
} 
