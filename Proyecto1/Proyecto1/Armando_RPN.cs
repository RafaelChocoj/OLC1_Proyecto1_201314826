using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Armando_RPN
    {

        List<ER_unitario> pref_expresiones;
        //Stack<String> pila;
        Stack<NodeAFN> pila;

        public Armando_RPN(List<ER_unitario> pref_expresiones)
        {
            this.pref_expresiones = pref_expresiones;
            this.pila = new Stack<NodeAFN>();
        }


        public NodeAFN leyendo_expresiones()
        {
            //String eleDer, eleIzq;
            NodeAFN eleDer, eleIzq;

            /*recorriendo listado de expresiores regulares*/
            //for (String expre : pref_expresiones) {

            //for (int i = 0; i < pref_expresiones.size(); ++i){
            for (int i = pref_expresiones.Count - 1; i >= 0; i--)
            {

                ////////////            JOptionPane.showMessageDialog(null,pref_expresiones.get(i).er);

                /*verificando si es operador*/

                //if (IsOperador(expre)) {

                //if (IsOperador(pref_expresiones.get(i))) {
                if (pref_expresiones.ElementAt(i).tipo.Equals("O"))
                {

                    int tipo = TipoOperador(pref_expresiones.ElementAt(i).er);

                    if (tipo == 2)
                    {

                        eleIzq = pila.Pop();
                        if (!pila.Any())
                        {
                            MessageBox.Show("Faltan Elementos para armar arbol");
                            i = pref_expresiones.Count;
                        }
                
                        //eleDer = pila.Pop();
                        //NodeArbol resultado = operar(eleIzq, pref_expresiones.get(i).er, eleDer, i);
                        //pila.push(resultado);
                    }
                    //        else if (tipo == 1)
                    //        {

                    //            //                    //eleDer = pila.pop();
                    //            //                    eleIzq = pila.pop();
                    //            if (pila.isEmpty())
                    //            {
                    //                JOptionPane.showMessageDialog(null, "Faltan Elementos para armar arbol", "NANI", JOptionPane.ERROR_MESSAGE);
                    //                i = pref_expresiones.size();
                    //            }
                    //            //eleIzq = pila.pop();
                    //            eleDer = pila.pop();
                    //            NodeArbol resultado = operar_1(pref_expresiones.get(i).er, eleDer, i);
                    //            pila.push(resultado);
                    //        }

                }
                else
                {
                    ////pila.push(pref_expresiones.get(i));
                    ////this.root = new NodeAVL(nombre, contenido, user, fecha_creacion);

                    ////NodeArbol n_nodo = new NodeArbol(pref_expresiones.get(i).er, i, "F", 0, 0, 0);

                    ////NodeArbol n_nodo = new NodeArbol(pref_expresiones.get(i).er, i, "A", 0, "-", "-");
                    //NodeArbol n_nodo = new NodeArbol(pref_expresiones.get(i).er, i, "A", 0, "-", "-", pref_expresiones.get(i).tipo);
                    //pila.push(n_nodo);
                    ////////JOptionPane.showMessageDialog(null,"("+i+") "+pref_expresiones.get(i));
                }
            }

            //nodo final
            return pila.Pop();

        }

        private int TipoOperador(String oper)
        {
            if (oper.Equals(".") || oper.Equals("|"))
            {
                return 2;
            }
            else { return 1; }
        }

        //////////////////
    }
}
