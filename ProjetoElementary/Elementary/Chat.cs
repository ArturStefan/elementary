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
    public partial class Chat : Form
    {
        // Instância de classe
        Grupo grupo = new Grupo();
        Usuario usuario = new Usuario();
        Medico medico = new Medico();
        BD bd = new BD();

        public Chat(BD pBD, Medico pMedico, Grupo pGrupo)
        {
            InitializeComponent();
            pictureBox3.Visible = false;

            // Manter os dados
            grupo = pGrupo;
            medico = pMedico;
            bd = pBD;

            // É o criador do grupo ?
            if (grupo.getParticipante().Contains(pMedico) == false)
            {
                grupo.setParticipante(pMedico);
            }

            exibirMensagens();
        }

        public Chat(BD pBD, Usuario pUsuario, Grupo pGrupo)
        {
            InitializeComponent();
            pictureBox3.Visible = false;

            // Manter os dados
            grupo = pGrupo;
            usuario = pUsuario;
            bd = pBD;

            grupo.setParticipante(pUsuario);

            exibirMensagens();
        }

        // Botão enviar
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                Mensagem mensagem = new Mensagem();

                if (usuario.getEmail() != null)
                {
                    mensagem.setConteudo(textBox1.Text);
                    mensagem.setUsuario(usuario);
                }
                else
                {
                    mensagem.setConteudo(textBox1.Text);
                    mensagem.setMedico(medico);
                }

                grupo.setMensagem(mensagem);
                exibirMensagens();
            }
        }

        // Enviar mensagem (ENTER)
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                {
                    Mensagem mensagem = new Mensagem();

                    if (usuario.getEmail() != null)
                    {
                        mensagem.setConteudo(textBox1.Text);
                        mensagem.setUsuario(usuario);
                    }
                    else
                    {
                        mensagem.setConteudo(textBox1.Text);
                        mensagem.setMedico(medico);
                    }

                    grupo.setMensagem(mensagem);
                    exibirMensagens();
                }
            }
        }

        // Método para exibir as mensagens
        private void exibirMensagens()
        {
            ArrayList listaDeMensagens = new ArrayList();
            listaDeMensagens = grupo.getMensagem();
            panel2.Controls.Clear();

            int y = 10;

            for (int i = 0; i <= grupo.numeroMensagem() - 1; i++)
            {
                RichTextBox conteudo = new RichTextBox();
                Mensagem tmpMensagem = new Mensagem();
                tmpMensagem = (Mensagem)listaDeMensagens[i];
                conteudo.Text = tmpMensagem.getConteudo();
                Usuario usuarioMensagem = (Usuario)tmpMensagem.getUsuario();

                // Design mensagens
                conteudo.Font = new Font("Baloo Bhaijaan", 12);
                conteudo.BorderStyle = System.Windows.Forms.BorderStyle.None;

                // Cores do chat
                // É médico ?
                if (usuarioMensagem.getIdentificador() == "medico")
                {
                    // É o médio logado ? 
                    if (usuarioMensagem.getEmail() == medico.getEmail())
                    {
                        conteudo.BackColor = Color.Silver;
                    }
                    else
                    {
                        conteudo.BackColor = Color.Turquoise;
                    }
                }
                else
                {
                    // É o usuário logado ?
                    if (usuarioMensagem.getEmail() == usuario.getEmail())
                    {
                        conteudo.BackColor = Color.Silver;
                    }
                    else
                    {
                        conteudo.BackColor = Color.Orange;
                    }
                }

                conteudo.SelectionAlignment = HorizontalAlignment.Center;
                conteudo.Width = 250;
                conteudo.Height = (int)(3 * conteudo.Font.Height) + conteudo.GetLineFromCharIndex(conteudo.Text.Length + 1) * conteudo.Font.Height + 1 + conteudo.Margin.Vertical;
                conteudo.SelectionStart = 0;
                conteudo.SelectionStart = conteudo.Text.Length;
                conteudo.ReadOnly = true;

                // É médico ?
                if (usuarioMensagem.getIdentificador() == "medico")
                {
                    // É o médio logado ? (layout DIREITA)
                    if (usuarioMensagem.getEmail() == medico.getEmail())
                    {
                        int x = panel2.Width - 400;

                        if (y == 10)
                        {
                            conteudo.Location = new Point(x, y += 20);
                        }
                        else
                        {
                            conteudo.Location = new Point(x, y += 100);
                        }
                    }
                    else
                    {
                        int x = (panel2.Width / 2) - 125;

                        if (y == 10)
                        {
                            conteudo.Location = new Point(x, y += 20);
                        }
                        else
                        {
                            conteudo.Location = new Point(x, y += 100);
                        }
                    }
                }
                else
                {
                    // É o usuário logado ? (layout DIREITA)
                    if (usuarioMensagem.getEmail() == usuario.getEmail())
                    {
                        int x = panel2.Width - 400;

                        if (y == 10)
                        {
                            conteudo.Location = new Point(x, y += 20);
                        }
                        else
                        {
                            conteudo.Location = new Point(x, y += 100);
                        }
                    }
                    else
                    {
                        int x = 150;

                        if (y == 10)
                        {
                            conteudo.Location = new Point(x, y += 20);
                        }
                        else
                        {
                            conteudo.Location = new Point(x, y += 100);
                        }
                    }
                }

                panel2.Controls.Add(conteudo);
                textBox1.Clear();
            }
        }

        // Botão voltar
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // É usuário ?
            if (usuario.getEmail() != null)
            {
                Feed feed = new Feed(bd, usuario, grupo);
                this.Dispose();
                feed.ShowDialog();
            }
            else
            {
                Feed feed = new Feed(bd, medico, grupo, true);
                this.Dispose();
                feed.ShowDialog();
            }
        }

        // Botão participantes
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            exibirParticipantes();
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Clear();
            pictureBox2.Visible = true;
            panel1.Width = 74;
            pictureBox3.Visible = false;
        }

        // Método para mostrar os participantes
        private void exibirParticipantes()
        {
            ArrayList participantes = new ArrayList();
            participantes = grupo.getParticipante();
            panel1.Width = 400;

            int x = 100;
            int y = 0;

            // Design dos participantes
            for (int i = 0; i <= grupo.numeroParticipante() - 1; i++)
            {
                Button participante = new Button();
                Usuario tmpUsuario = (Usuario)participantes[i];
                participante.Click += new EventHandler(participante_Click);

                participante.Text = tmpUsuario.getNome();
                participante.AutoSize = true;
                participante.FlatStyle = FlatStyle.Flat;
                participante.TextAlign = ContentAlignment.MiddleLeft;
                participante.FlatAppearance.BorderSize = 0;
                participante.Font = new Font("Baloo Bhaijaan", 12);
                participante.BackColor = Color.YellowGreen;

                if (y == 0)
                {
                    participante.Location = new Point(x, y += 5);
                }
                else
                {
                    participante.Location = new Point(x, y += 40);
                }

                panel1.Controls.Add(participante);

                void participante_Click(Object sender, EventArgs e)
                {
                    // ARRUMAR --> add amigo ao clicar
                }
            }
        }
    }
}


