using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class Medico : Usuario
    {
        // Atributos
        private string vCRM;

        // Métodos
        public Medico()
        {

        }

        public Medico(string pNome, string pEmail, string pSenha, DateTime pDataNascimento, bool pStatusConta, string pCRM)
        {
            setNome(pNome);
            setEmail(pEmail);
            setSenha(pSenha);
            setDataNascimento(pDataNascimento);
            setStatusConta(pStatusConta);
            setCRM(pCRM);
            setIndentificador("medico");
        }

        public void setCRM(string pCRM)
        {
            vCRM = pCRM;
        }

        public string getCRM()
        {
            return vCRM;
        }

        public void cadastrarMedico(string pNome, string pEmail, string pSenha, string pCRM, DateTime pDataNascimento, bool pStatusConta)
        {
            setNome(pNome);
            setEmail(pEmail);
            setSenha(pSenha);
            setDataNascimento(pDataNascimento);
            setStatusConta(pStatusConta);
            setCRM(pCRM);
        }
    }

}

