using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Lexemas_Evaluados
    {
        //////////////public List<String> l_tokens_lex;
        public List<xmlData> l_tokens_lex;
        //public String Aceptado;
        //////////////////public List<String> l_errores_lex;
        public List<xmlData> l_errores_lex;
        public Lexemas_Evaluados(List<xmlData> l_tokens_lex, List<xmlData> l_errores_lex)
        {
            this.l_tokens_lex = l_tokens_lex;
            this.l_errores_lex = l_errores_lex;
        }
    }
}
