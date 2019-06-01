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
    public partial class CriarGrupo : Form
    {
        // Intância de classe
        Grupo grupo = new Grupo();
        BD bd = new BD();
        Medico medico = new Medico();
        Usuario usuario = new Usuario();

        public CriarGrupo(BD pBD, Medico pMedico)
        {
            InitializeComponent();
            ActiveControl = button1;

            // Igualar "BDs" para não perder os dados
            bd = pBD;
            medico = pMedico;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nome do grupo")
            {
                MessageBox.Show("Preencha todos os campos para prosseguir");
            }
            else
            {
                grupo.setNome(textBox1.Text);
                grupo.setParticipante(medico);
                MessageBox.Show("Grupo criado com Sucesso");
                bd.setGrupo(grupo);

                Feed feed = new Feed(bd, medico, grupo);
                this.Dispose();
                feed.ShowDialog();
            }
        }

        // Botão sair 'X'
        private void button4_Click(object sender, EventArgs e)
        {
            Feed feed = new Feed(bd, medico, grupo);
            this.Dispose();
            feed.ShowDialog();
        }

        // Efeitos da interface
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "Nome do grupo")
            {
                textBox1.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Nome do grupo";
            }
        }
    }
}
