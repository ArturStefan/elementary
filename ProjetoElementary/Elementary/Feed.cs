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

        // Manter os dados do médico
        public Feed(BD pBd, Medico pMedico)
        {
            InitializeComponent();
            ActiveControl = pictureBox1;

            bd = (BD)pBd;
            medico = (Medico)pMedico;
            textBox1.Text = medico.getNome();

            // Configurações das opções (engrenagem)
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = true;

            exibirGrupos();
            novoPost();
        }

        // Manter os dados do grupo
        public Feed(BD pBD, Medico pMedico, Grupo pGrupo)
        {
            InitializeComponent();
            ActiveControl = pictureBox1;

            bd = pBD;
            medico = pMedico;
            grupo = pGrupo;

            // Adicionar o grupo nas informações do médico
            if (grupo.getNome() != null)
            {
                medico.addGrupo(grupo.getNome());
            }

            // Configurações das opções (engrenagem)
            button1.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = true;

            exibirGrupos();
            novoPost();
        }

        // É médico e está voltando do chat ?
        public Feed(BD pBD, Medico pMedico, Grupo pGrupo, Boolean pVoltandoDoChat)
        {
            InitializeComponent();
            ActiveControl = pictureBox1;

            bd = pBD;
            medico = pMedico;
            grupo = pGrupo;

            // Configurações das opções (engrenagem)
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = true;

            exibirGrupos();
            novoPost();
        }

        public Feed(BD pBD, Usuario pUsuario, Grupo pGrupo)
        {
            InitializeComponent();
            ActiveControl = pictureBox1;

            bd = pBD;
            usuario = pUsuario;
            grupo = pGrupo;

            textBox1.Text = "Anônimo";

            // Configurações das opções (engrenagem)
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button8.Visible = false;

            novoPost();
            exibirGrupos();
        }

        // Manter os dados do usuário
        public Feed(BD pBD, Usuario pUsuario)
        {
            InitializeComponent();
            ActiveControl = pictureBox1;

            bd = (BD)pBD;
            usuario = (Usuario)pUsuario;

            textBox1.Text = "Anônimo";

            // Configurações das opções (engrenagem)
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
            if (textBox6.Text == "Pesquisar")
            {
                textBox6.Clear();
            }
            
            textBox6.ForeColor = Color.White;
            panel4.BackColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier_white;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "Pesquisar";
            }

            panel4.BackColor = Color.Black;
            textBox6.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_magnifier;
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
            // É usuário ?
            if(usuario.getEmail() != null)
            {
                this.Dispose();
                Posts novoPost = new Posts(bd, usuario);
                novoPost.ShowDialog();
            }
            else
            {
                this.Dispose();
                Posts novoPost = new Posts(bd, medico);
                novoPost.ShowDialog();
            }
        }

        // Método de pesquisa de grupos
        private void pesquisarGrupos()
        {
            TextBox addNovoGrupo = new TextBox();
            grupo = (Grupo)bd.getGrupo(textBox6.Text);

            if(grupo == null)
            {
                MessageBox.Show("Este grupo não existe");
            }
            else
            {
                if (grupo.getNome() != null)
                {
                    if (usuario.getEmail() != null)
                    {
                        usuario.addGrupo(grupo.getNome());

                        Chat chat = new Chat(bd, usuario, grupo);
                        this.Dispose();
                        chat.ShowDialog();
                    }
                    else
                    {
                        medico.addGrupo(grupo.getNome());

                        Chat chat = new Chat(bd, medico, grupo);
                        this.Dispose();
                        chat.ShowDialog();
                    }
                }
            }
        }

        // Método para exibir os grupos criados
        private void exibirGrupos()
        {
            ArrayList listaDeGrupos = new ArrayList();

            int x = (panel7.Width / 2) - 115; // Menos a metade do tamanho do controle (textbox)
            int y = 0;

            // É usuário ?
            if(usuario.getEmail() != null)
            {
                for (int i = usuario.numeroGrupos() - 1; i >= 0; i--)
                {
                    listaDeGrupos = usuario.getGrupos();

                    // Design dos grupos
                    Button addNovoGrupo = new Button();
                    addNovoGrupo.Click += new EventHandler(addNovoGrupo_Click);
                    addNovoGrupo.Text = listaDeGrupos[i].ToString();
                    addNovoGrupo.AutoSize = true;
                    addNovoGrupo.FlatStyle = FlatStyle.Flat;
                    addNovoGrupo.TextAlign = ContentAlignment.MiddleLeft;
                    addNovoGrupo.FlatAppearance.BorderSize = 0;
                    addNovoGrupo.Font = new Font("Baloo Bhaijaan", 12);
                    addNovoGrupo.BackColor = Color.YellowGreen;

                    if (y == 0)
                    {
                        addNovoGrupo.Location = new Point(x, y += 2);
                    }
                    else
                    {
                        addNovoGrupo.Location = new Point(x, y += 40);
                    }

                    panel7.Controls.Add(addNovoGrupo);

                    void addNovoGrupo_Click(Object sender, EventArgs e)
                    {
                        Chat chat = new Chat(bd, usuario, (Grupo)bd.getGrupo(addNovoGrupo.Text));
                        this.Dispose();
                        chat.ShowDialog();
                    }
                }
            }
            else
            {
                for (int i = medico.numeroGrupos() - 1; i >= 0; i--)
                {
                    listaDeGrupos = medico.getGrupos();

                    // Design dos grupos
                    Button addNovoGrupo = new Button();
                    addNovoGrupo.Click += new EventHandler(addNovoGrupo_Click);
                    addNovoGrupo.Text = listaDeGrupos[i].ToString();
                    addNovoGrupo.AutoSize = true;
                    addNovoGrupo.FlatStyle = FlatStyle.Flat;
                    addNovoGrupo.TextAlign = ContentAlignment.MiddleLeft;
                    addNovoGrupo.FlatAppearance.BorderSize = 0;
                    addNovoGrupo.Font = new Font("Baloo Bhaijaan", 12);
                    addNovoGrupo.BackColor = Color.YellowGreen;

                    if (y == 0)
                    {
                        addNovoGrupo.Location = new Point(x, y += 2);
                    }
                    else
                    {
                        addNovoGrupo.Location = new Point(x, y += 40);
                    }

                    panel7.Controls.Add(addNovoGrupo);

                    void addNovoGrupo_Click(Object sender, EventArgs e)
                    {
                        Chat chat = new Chat(bd, medico, (Grupo)bd.getGrupo(addNovoGrupo.Text));
                        this.Dispose();
                        chat.ShowDialog();
                    }
                }
            }
        }

        // Método para exibir os posts feitos
        private void novoPost()
        {
            ArrayList listaDePosts = new ArrayList();

            int x = (panel6.Width / 2) - 240; // Menos a metade do tamanho do controle (textbox)
            int x2 = (panel6.Width / 2) - 240; // Menos a metade do tamanho do controle (richtextbox)
            int y = 0;
            int y2 = 0;

            // É usuário ?
            if (usuario.getEmail() != null)
            {
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

                    if (y == 0)
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
            else
            {
                for (int i = medico.numeroPost() - 1; i >= 0; i--)
                {
                    TextBox tituloDoPost = new TextBox();
                    RichTextBox textoDoPost = new RichTextBox();

                    listaDePosts = medico.getPost();
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

                    if (y == 0)
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

        // Botão "Novo Grupo"
        private void button9_Click(object sender, EventArgs e)
        {
            CriarGrupo novoGrupo = new CriarGrupo(bd, medico);
            this.Dispose();
            novoGrupo.ShowDialog();
        }

        // Pesquisar grupos
        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                pesquisarGrupos();
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
    }
} 
