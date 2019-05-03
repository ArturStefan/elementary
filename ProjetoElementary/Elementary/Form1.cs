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
        Medico medico = new Medico();
        Usuario usuario = new Usuario();
        BD bd = new BD();

        public Form1()
        {
            InitializeComponent();
          
        }

        //Método construtor que recebe o bd com o novo usuário cadastrado
        public Form1(BD pBD)
        {
            InitializeComponent();

            //Iguala os bds
            bd = (BD)pBD;
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Email")
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
            if(textBox2.Text == "Senha")
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

        // Botão cadastrar 
        private void button2_Click(object sender, EventArgs e)
        {
            //Chama a tela de cadastro e passa o bd atual para a tela de cadastro para não perder os dados
            Form2 cadastrar = new Form2(bd);
            this.Hide();
            cadastrar.ShowDialog();
        }

        // Botão entrar
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "Email" && textBox2.Text != "Senha")
            {
                if (bd.getUsuario(textBox1.Text) != null)
                {
                    usuario = (Usuario)bd.getUsuario(textBox1.Text);

                    if (usuario.getStatusConta() == true)
                    {
                        if (usuario.getSenha() == textBox2.Text && usuario.getEmail() == textBox1.Text)
                        {
                            //Chama o formulário do menu
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
                        if (medico.getSenha() == textBox2.Text && medico.getEmail() == textBox1.Text)
                        {
                            //Chama o formulário do menu
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
                //else
                //{
                //    MessageBox.Show("Usuário ou senha inválido");
                //}
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.desenvolvedores();
        }
    }
}
