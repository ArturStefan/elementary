using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class Usuario
    {
        // Atributos
        private string vNome;
        private string vEmail;
        private string vSenha;
        private DateTime vDataNascimento;
        private bool vStatusConta;
        private ArrayList Posts = new ArrayList();
        private ArrayList Amigos = new ArrayList();
        private string vIdentificador;
        private ArrayList Grupos = new ArrayList();

        // Métodos
        public Usuario()
        {

        }

        public void setNome(string pNome)
        {
            vNome = pNome;
        }

        public void setEmail(string pEmail)
        {
            vEmail = pEmail;
        }

        public void setSenha(string pSenha)
        {
            vSenha = pSenha;
        }

        public void setDataNascimento(DateTime pDataNascimento)
        {
            vDataNascimento = pDataNascimento;
        }

        public void setStatusConta(bool pStatusConta)
        {
            vStatusConta = pStatusConta;
        }

        public void setIndentificador(string pIdentificador)
        {
            vIdentificador = pIdentificador;
        }

        public string getNome()
        {
            return vNome;
        }

        public string getEmail()
        {
            return vEmail;
        }

        public string getSenha()
        {
            return vSenha;
        }

        public DateTime getDataNascimento()
        {
            return vDataNascimento;
        }

        public bool getStatusConta()
        {
            return vStatusConta;
        }
        public string getIdentificador()
        {
            return vIdentificador;
        }

        public void cadastrarUsuario(string pNome, string pEmail, string pSenha, DateTime pDataNascimento, bool pStatusConta)
        {
            setNome(pNome);
            setEmail(pEmail);
            setSenha(pSenha);
            setDataNascimento(pDataNascimento);
            setStatusConta(pStatusConta);
            setIndentificador("usuario");
        }

        public void addPost(object pPost)
        {
            Posts.Add((Post)pPost);
        }

        public int numeroPost()
        {
            if (Posts.Count != 0)
            {
                return Posts.Count;
            }

            return -1;
        }

        public void addGrupo(string pNomegrupo)
        {
            Grupos.Add(pNomegrupo);
        }

        public ArrayList getGrupos()
        {
            return Grupos;
        }

        public int numeroGrupos()
        {
            if (Grupos.Count != 0)
            {
                return Grupos.Count;
            }

            return -1;
        }

        public ArrayList getPost()
        {
            return Posts;
        }

        public void addAmigo(string pEmailAmigo)
        {
            Amigos.Add(pEmailAmigo);
        }

        public void removeAmigo(string pEmailAmigo)
        {
            Amigos.Remove(pEmailAmigo);
        }
    }
}
