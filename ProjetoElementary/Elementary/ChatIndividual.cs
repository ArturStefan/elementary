using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class ChatIndividual
    {
        // Atributos
        private object usuario;
        private ArrayList mensagens = new ArrayList();
        
        public ChatIndividual()
        {

        }

        public void setMensagem(Mensagem pMensagem)
        {
            mensagens.Add(pMensagem);
        }

        public ArrayList getMensagem()
        {
            return mensagens;
        }

        public void setUsuario(object pUsuario)
        {
            usuario = pUsuario;
        }

        public object getUsuario()
        {
            return usuario;
        }
    }
}
