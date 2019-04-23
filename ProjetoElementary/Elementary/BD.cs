using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    public class BD
    {
        //Instanciamento dos dicionários
        Dictionary<string,object> listaDeUsuarios = new Dictionary<string, object>();
        Dictionary<string,object> listaDeMedicos = new Dictionary<string,object>();
                
    public BD()
        {
            
        }

       //"Banco de dados" medico
        public BD(Medico pMedico)
        {
            Dictionary<object, string> listaDeMedicos = new Dictionary<object, string>();
            listaDeMedicos.Add(pMedico, pMedico.getEmail());
        }    
        // "Banco de dados" usuario
        public BD(Usuario pUsuario)
        {
            Dictionary<object, string> listaDeUsuarios = new Dictionary<object, string>();
            listaDeUsuarios.Add(pUsuario, pUsuario.getEmail());
        }
        //Grava um medico
        public void gravaMedico(Medico pMedico)
        {            
            listaDeMedicos.Add(pMedico.getEmail(),pMedico);
        }
        //Grava um usuario
        public void gravaUsuario(Usuario pUsuario)
        {
            listaDeUsuarios.Add(pUsuario.getEmail(),pUsuario);
        }
        //Retorna um usuario
        public object pegaUsuario(string pUsuario)
        {
            if (listaDeUsuarios.ContainsKey(pUsuario))
            {
                return listaDeUsuarios[pUsuario];
            }
            return null;
        }
        //Retorna o um medico
        public object pegaMedico(string pUsuario)
        {
            if (listaDeMedicos.ContainsKey(pUsuario))
            {
                return listaDeMedicos[pUsuario];
            }
            return null;
        }
    }    
}
