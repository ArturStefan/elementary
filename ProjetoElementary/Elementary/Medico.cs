using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    class Medico : Usuario
    {
        // Atributos
        private string vCRM;

        // Métodos
        public Medico(string pNome, string pEmail, string pSenha, string pConfirmarSenha, DateTime pDataNascimento, bool pStatusConta, string pCRM)
        {
            setNome(pNome);
            setEmail(pEmail);
            setSenha(pSenha);
            setConfirmarSenha(pConfirmarSenha);
            setDataNascimento(pDataNascimento);
            setStatusConta(pStatusConta);
            setCRM(pCRM);
        }

        public void setCRM(string pCRM)
        {
            vCRM = pCRM;
        }

        public string getCRM()
        {
            return vCRM;
        }

    }
}
