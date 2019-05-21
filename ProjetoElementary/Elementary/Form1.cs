using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elementary
{
    public partial class Form1 : Form
    {
        // Instância de classe
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();
        Criptografia MD5 = new Criptografia();

        // Atributos
        string vSenhaMD5;

        public Form1()
        {
            InitializeComponent();
          
        }

        // Método construtor que recebe o "BD" com o novo usuário cadastrado
        public Form1(BD pBD)
        {
            InitializeComponent();

            // Iguala os "BDs"
            bd = (BD)pBD;
        }

        // Botão cadastrar 
        private void button2_Click(object sender, EventArgs e)
        {
            // Chama a tela de cadastro e passa o "BD" atual para a tela de cadastro para não perder os dados
            Form2 cadastrar = new Form2(bd);
            this.Hide();
            cadastrar.ShowDialog();
        }

        // Botão entrar
        private void button1_Click(object sender, EventArgs e)
        {
            // Verifica se os campos não estão vazios
            if (textBox1.Text != "Email" && textBox2.Text != "Senha")
            {
                // Verifica se existe o usuário informado
                if (bd.getUsuario(textBox1.Text) != null)
                {
                    usuario = (Usuario)bd.getUsuario(textBox1.Text);

                    // Verifica se a conta NÃO foi excluída
                    if (usuario.getStatusConta() == true)
                    {
                        // Criptografa a senha para comparar com a que está no "BD"
                        vSenhaMD5 = MD5.criptografar(textBox2.Text);

                        if (usuario.getSenha() == vSenhaMD5 && usuario.getEmail() == textBox1.Text)
                        {
                            // Chama o formulário do menu
                            Form3 menu = new Form3(bd, usuario);
                            this.Hide();
                            menu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha inválido");
                        }
                    }
                    else
                    {
                        // Diálogo para reativar a conta
                        DialogResult ativarConta = MessageBox.Show("Sua conta foi desativada desejá ativa-lá novamente?", "AVISO", MessageBoxButtons.YesNo);

                        if(ativarConta == DialogResult.Yes)
                        {
                            usuario.setStatusConta(true);

                            Form3 menu = new Form3(bd, usuario);
                            this.Hide();
                            menu.ShowDialog();
                        }
                    }
                }
                else if (bd.getMedico(textBox1.Text) != null)
                {
                    medico = (Medico)bd.getMedico(textBox1.Text);

                    if (medico.getStatusConta() == true)
                    {
                        // Criptografa a senha para comparar com a que está no "BD"
                        vSenhaMD5 = MD5.criptografar(textBox2.Text);

                        if (medico.getSenha() == vSenhaMD5 && medico.getEmail() == textBox1.Text)
                        {
                            // Chama o formulário do menu
                            Form3 menu = new Form3(bd, medico);
                            this.Hide();
                            menu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Usuário ou senha inválido");
                        }
                    }
                    else
                    {
                        // Diálogo de confirmação para reativar a conta
                        DialogResult ativarConta = MessageBox.Show("Sua conta foi desativada desejá ativa-lá novamente?", "AVISO", MessageBoxButtons.YesNo);

                        if (ativarConta == DialogResult.Yes)
                        {
                            medico.setStatusConta(true);

                            Form3 menu = new Form3(bd, medico);
                            this.Hide();
                            menu.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválido");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
        }

        // Restaurar senha de usuário
        private void button3_Click(object sender, EventArgs e)
        {
            Form5 restaurarSenha = new Form5(bd);
            this.Hide();
            restaurarSenha.ShowDialog();
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Clear();
            }

            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.White;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_white;
            panel1.BackColor = Color.White;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.PasswordChar = '\u0000';
                textBox2.Text = "Senha";
            }

            textBox2.ForeColor = Color.Black;
            pictureBox3.BackgroundImage = Properties.Resources.icon_pass_black;
            panel1.BackColor = Color.Black;
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Exibe informações de desenvolvimento
        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
