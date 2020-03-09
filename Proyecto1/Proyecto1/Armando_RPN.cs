using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Armando_RPN
    {

        List<ER_unitario> pref_expresiones;
        Stack<String> pila;
        //Stack<NodeArbol> pila;

        public Armando_RPN(List<ER_unitario> pref_expresiones)
        {
            this.pref_expresiones = pref_expresiones;
            //this.pila = new Stack<NodeArbol>();
            this.pila = new Stack<String>();

        }

    }
}
