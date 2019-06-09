using System;
using System.Collections;
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
        private ArrayList Grupos = new ArrayList();

        // Métodos
        public Medico()
        {

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
            setIndentificador("medico");
        }

        //public void addGrupo(string pNomegrupo)
        //{
        //    Grupos.Add(pNomegrupo);
        //}

        //public ArrayList getGrupos()
        //{
        //    return Grupos;
        //}

        //public int numeroGrupos()
        //{
        //    if (Grupos.Count != 0)
        //    {
        //        return Grupos.Count;
        //    }

        //    return -1;
        //}
    }
}

