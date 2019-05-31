using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class Grupo
    {
        // Atributos
        private string vNome;
        private ArrayList vParticipantes = new ArrayList();
        private ArrayList vMensagens = new ArrayList();

        // Métodos
        public string getNome()
        {
            return vNome;
        }

        public void setNome(string pNome)
        {
            vNome = pNome;
        }

        public void setMensagem(string pMensagem)
        {
            vMensagens.Add(pMensagem);
        }

        public void setParticipante(object pUsuario) {
            vParticipantes.Add(pUsuario);
        }
    }
}
