using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class xmlData
    {
        public String name_token;
        public String valor_token;
        public int fila;
        public int columna;

        public xmlData(String name_token, String valor_token, int fila, int columna)
        {
            this.name_token = name_token;
            this.valor_token = valor_token;
            this.fila = fila;
            this.columna = columna;
        }
    }
}
