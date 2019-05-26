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

        public CriarGrupo(BD pBD, Medico pMedico)
        {
            InitializeComponent();

            // Igualar "BDs" para não perder os dados
            bd = pBD;
            medico = pMedico;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            grupo.setNome(textBox1.Text);
            MessageBox.Show("Grupo criado com Sucesso");
            Feed feed = new Feed(bd, medico, grupo);
            this.Dispose();
            feed.ShowDialog();
        }
    }
}
