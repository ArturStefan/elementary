using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary
{
    class Post
    {
        // Atributos
        private string vTitulo;
        private string vTexto;

        // Métodos
        public void setTitulo(string pTitulo)
        {
            vTitulo = pTitulo;
        }

        public void setTexto(string pTexto)
        {
            vTexto = pTexto;
        }

        public string getTitulo()
        {
            return vTitulo;
        }

        public string getTexto()
        {
            return vTexto;
        }
    }
}
