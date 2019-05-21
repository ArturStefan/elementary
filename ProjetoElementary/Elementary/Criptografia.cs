using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Elementary
{
    class Criptografia
    {
        // Faz a criptografia de uma string em MD5
        public string criptografar(string pSenha) {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pSenha);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder senhaCriptografada = new System.Text.StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                senhaCriptografada.Append(hash[i].ToString("X2"));
            }

            return senhaCriptografada.ToString();
        }
    }
}
