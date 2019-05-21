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
    public partial class Form5 : Form
    {
        // Instância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();
        Criptografia MD5 = new Criptografia();

        // Atributos
        string vNovaSenhaMD5;
        DateTime vData;

        public Form5(BD pBD)
        {
            InitializeComponent();

            ActiveControl = label1;
            bd = (BD)pBD;

            button1.Visible = false;
            textBox3.Visible = false;
            panel3.Visible = false;
            pictureBox3.Visible = false;
            textBox2.Visible = false;
            panel4.Visible = false;
            pictureBox1.Visible = false;
        }

        // Botão pesquisar
        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "Email" && maskedTextBox1.Text != "  /  /")
            { 
                // Verifica se o usuário existe
                if (bd.getUsuario(textBox1.Text) != null)
                {
                    usuario = (Usuario)bd.getUsuario(textBox1.Text);

                    // Converte a string para fazer a comparação com o "BD"
                    vData = Convert.ToDateTime(maskedTextBox1.Text);

                    // Verifica se a data é igual a do "BD" para liberar a troca de senha
                    if (vData.Equals(usuario.getDataNascimento()))
                    {
                        // Ativa o campo para entrar com a nova senha
                        textBox3.Visible = true;
                        panel3.Visible = true;
                        pictureBox3.Visible = true;
                        textBox2.Visible = true;
                        panel4.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Focus();

                        // Executa a troca dos botões
                        button1.Visible = true;
                        button2.Visible = false;

                        // Desabilita a edição dos campos após a pesquisa
                        textBox1.Enabled = false;
                        maskedTextBox1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Dados inválidos");
                    }
                }
                else if (bd.getMedico(textBox1.Text) != null)
                {
                    medico = (Medico)bd.getMedico(textBox1.Text);

                    // Converte a string para fazer a comparação com o "BD"
                    vData = Convert.ToDateTime(maskedTextBox1.Text);

                    // Verifica se a data é igual a do "BD" para liberar a troca de senha
                    if (vData.Equals(medico.getDataNascimento()))
                    {
                        // Ativa o campo para entrar com a nova senha
                        textBox3.Visible = true;
                        panel3.Visible = true;
                        pictureBox3.Visible = true;
                        textBox2.Visible = true;
                        panel4.Visible = true;
                        pictureBox1.Visible = true;
                        pictureBox3.Focus();

                        // Executa a troca dos botões
                        button1.Visible = true;
                        button2.Visible = false;

                        // Desabilita a edição dos campos após a pesquisa
                        textBox1.Enabled = false;
                        maskedTextBox1.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Dados inválidos");
                    }
                }
                else
                {
                    MessageBox.Show("Dados inválidos");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
        }

        // Botão alterar
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "Nova senha" && textBox2.Text.Equals(textBox3.Text))
            {
                // Faz a criptografia da nova senha
                vNovaSenhaMD5 = MD5.criptografar(textBox3.Text);

                // Envia a nova senha para o "BD"
                usuario.setSenha(vNovaSenhaMD5);
                medico.setSenha(vNovaSenhaMD5);

                MessageBox.Show("Senha alterada com sucesso");

                this.Dispose();
                Form1 login = new Form1(bd);
                login.ShowDialog();
            }
            else
            {
                MessageBox.Show("As senhas não são iguais");
            }
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Email")
            {
                textBox1.Clear();
            }

            textBox1.ForeColor = Color.White;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_white;
            panel2.BackColor = Color.White;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Email";
            }

            textBox1.ForeColor = Color.Black;
            pictureBox2.BackgroundImage = Properties.Resources.icon_email_black;
            panel2.BackColor = Color.Black;
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.White;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_white;
            panel1.BackColor = Color.White;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.ForeColor = Color.Black;
            pictureBox7.BackgroundImage = Properties.Resources.icon_birthday_black;
            panel1.BackColor = Color.Black;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Nova senha")
            {
                textBox3.Clear();
            }

            textBox3.PasswordChar = '*';
            textBox3.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel3.BackColor = Color.White;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.PasswordChar = '\u0000';
                textBox3.Text = "Nova senha";
            }

            textBox3.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel3.BackColor = Color.Black;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Confirmar senha")
            {
                textBox2.Clear();
            }

            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.White;
            pictureBox1.BackgroundImage = Properties.Resources.icon_pass_white;
            panel4.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\u0000';
                textBox2.Text = "Confirmar senha";
            }

            textBox2.ForeColor = Color.Black;
            pictureBox1.BackgroundImage = Properties.Resources.icon_pass_black;
            panel4.BackColor = Color.Black;

        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Form1 login = new Form1(bd);
            login.ShowDialog();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
