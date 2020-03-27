using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Exp_a_Evaluar
    {
        public String identificador;
        public String cadena_eva;

        public int fila;
        public int columna;
        public Exp_a_Evaluar(String identificador, String cadena_eva, int fila, int columna)
        {
            this.identificador = identificador;
            this.cadena_eva = cadena_eva;

            this.fila = fila;
            this.columna = columna;
        }
    }
}
