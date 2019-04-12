using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    class BD
    {
        public BD()
        {
            
        }

        // "Banco de dados" medico
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
    }
}
