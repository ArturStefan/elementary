using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class Mensagem
    {
        // Atributos
        private object usuario;
        private string conteudo;

        public Mensagem()
        {

        }

        public void setConteudo(string pConteudo)
        {
            conteudo = pConteudo;
        }

        public void setUsuario(Usuario pUsuario)
        {
            usuario = pUsuario;
        }

        public void setMedico(Medico pMedico)
        {
            usuario = pMedico;
        }

        public object getUsuario()
        {
            return usuario;
        }

        public string getConteudo()
        {
            return conteudo;
        }
    }
}
