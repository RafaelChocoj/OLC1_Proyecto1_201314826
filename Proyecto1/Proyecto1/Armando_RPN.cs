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
        List<NodeAFN> listado_Nodos;

        List<ER_unitario> pref_expresiones;
        //Stack<String> pila;
        Stack<NodeAFN> pila;

        public Armando_RPN(List<ER_unitario> pref_expresiones)
        {
            listado_Nodos = new List<NodeAFN>();

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
                        //eleDer = pila.Pop();
                        eleIzq = pila.Pop();
                        if (!pila.Any())
                        {
                            MessageBox.Show("Faltan Elementos para armar arbol");
                            i = pref_expresiones.Count;
                        }

                        eleDer = pila.Pop();
                        //eleIzq = pila.Pop();
                        NodeAFN resultado = operar(eleIzq, pref_expresiones.ElementAt(i).er, eleDer, i);
                        //odeAFN resultado = operar(eleIzq, pref_expresiones.get(i).er, eleDer, i);
                        pila.Push(resultado);
                    }
                    else if (tipo == 1)
                    {

                        //                    //eleDer = pila.pop();
                        //                    eleIzq = pila.pop();
                        if (!pila.Any())
                        {
                            MessageBox.Show("Faltan Elementos para armar arbol");
                            i = pref_expresiones.Count;
                        }
                        //eleIzq = pila.pop();
                        eleDer = pila.Pop();
                        //NodeArbol resultado = operar_1(pref_expresiones.get(i).er, eleDer, i);
                        NodeAFN resultado = operar(eleDer, pref_expresiones.ElementAt(i).er, null, i);
                        pila.Push(resultado);
                    }

                }
                else
                {
                    //pila.push(pref_expresiones.get(i));
                    //this.root = new NodeAVL(nombre, contenido, user, fecha_creacion);

                    //NodeArbol n_nodo = new NodeArbol(pref_expresiones.get(i).er, i, "F", 0, 0, 0);

                    //NodeArbol n_nodo = new NodeArbol(pref_expresiones.get(i).er, i, "A", 0, "-", "-");

                    //NodeAFN n_nodo = new NodeAFN(pref_expresiones.ElementAt(i).er, i,  pref_expresiones.ElementAt(i).tipo, Tipo.TipoN.NORMAL);
                    NodeAFN n_nodo = new NodeAFN("N", i, pref_expresiones.ElementAt(i).tipo, Tipo.TipoN.NORMAL);
                    n_nodo.Tran_left = pref_expresiones.ElementAt(i).er;
                    n_nodo.ultimo_ref = n_nodo;
                    pila.Push(n_nodo);

                    listado_Nodos.Add(n_nodo); ///agregar ref de nodos

                    //////JOptionPane.showMessageDialog(null,"("+i+") "+pref_expresiones.get(i));
                }
            }

            //nodo final
            return pila.Pop();

        }

        public NodeAFN operar(NodeAFN eleIzq, String oper, NodeAFN eleDer, int i)
        {


            NodeAFN OR = null;
            NodeAFN Cerradura = null;

            NodeAFN AND = null;
            NodeAFN MAS = null;

            if (oper.Equals("|"))
            {
                //NodeAFN N1 = new NodeAFN("N1", i, "E", Tipo.TipoN.EPSILON);
                //NodeAFN N4 = new NodeAFN("N4", i, "E", Tipo.TipoN.EPSILON);
                //NodeAFN N5 = new NodeAFN("N5", i, "E", Tipo.TipoN.EPSILON);
                //NodeAFN N6 = new NodeAFN("N6", i, "E", Tipo.TipoN.EPSILON);

                NodeAFN N1 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                NodeAFN N4 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                NodeAFN N5 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                NodeAFN N6 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);


                /*armando OR*/
                //MessageBox.Show(eleIzq.Tran_left, "eleIzq.Tran_left");
                N1.left = eleIzq;
                N1.Tran_left = "e";

                //MessageBox.Show(eleDer.Tran_left, "eleDer.Tran_left");
                N1.right = eleDer;
                N1.Tran_right = "e";

                ////eleIzq.left = N4;
                ////eleDer.left = N5;
                //MessageBox.Show("---------");
                //MessageBox.Show(eleIzq.ultimo_ref.Tran_left, "eleIzq.ultimo_ref.Tran_left");
                //MessageBox.Show(eleIzq.ultimo_ref.tipo_n.ToString(), "eleIzq.ultimo_ref.tipo_n");
                if (eleIzq.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    eleIzq.ultimo_ref.left = N4;
                    N4.left = N6;
                    N4.Tran_left = "e";
                }
                else if (eleIzq.ultimo_ref.tipo_n == Tipo.TipoN.EPSILON)
                {
                    eleIzq.ultimo_ref.left = N6;
                    eleIzq.ultimo_ref.Tran_left = "e";
                }

                //MessageBox.Show(eleDer.ultimo_ref.Tran_left, "uu eleDer.ultimo_ref.Tran_left");
                //MessageBox.Show(eleDer.ultimo_ref.tipo_n.ToString(), "uu eleDer.ultimo_ref.tipo_n");

                if (eleDer.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    eleDer.ultimo_ref.left = N5;
                    N5.left = N6;
                    N5.Tran_left = "e";
                }
                else if (eleDer.ultimo_ref.tipo_n == Tipo.TipoN.EPSILON)
                {
                    eleDer.ultimo_ref.left = N6;
                    eleDer.ultimo_ref.Tran_left = "e";
                }


                N1.ultimo_ref = N6;
                OR = N1;

                return OR;
            }
            if (oper.Equals("*"))
            {
                NodeAFN N1 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                NodeAFN N2 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                NodeAFN N3 = new NodeAFN("N", 99, "E", Tipo.TipoN.EPSILON);

                //eleIzq
                N1.left = eleIzq;
                N1.Tran_left = "e";
                N1.right = N3;
                N1.Tran_right = "e";

                if (eleIzq.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    //eleIzq.left = N2;
                    eleIzq.ultimo_ref.left = N2;
                    N2.left = N3;
                    N2.Tran_left = "e";

                    N2.right = eleIzq;
                    N2.Tran_right = "e";

                }
                else if (eleIzq.ultimo_ref.tipo_n == Tipo.TipoN.EPSILON)
                {
                    eleIzq.ultimo_ref.left = N3;
                    //N2.left = N3;
                    eleIzq.ultimo_ref.Tran_left = "e";

                    eleIzq.ultimo_ref.right = eleIzq;
                    eleIzq.ultimo_ref.Tran_right = "e";
                }

                N1.ultimo_ref = N3;
                Cerradura = N1;

                return Cerradura;
            }
            //MessageBox.Show(OR.leema, "Or-inicio");
            //MessageBox.Show(OR.ultimo_ref.lexema, "Or-ultimo_ref.lexema");

            if (oper.Equals("."))
            {
                NodeAFN N3 = new NodeAFN("N", i, "E", Tipo.TipoN.EPSILON);
                //eleIzq.left = eleDer;
                //eleDer.left = N3;

                NodeAFN tempo_der;

                if (eleIzq.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    eleIzq.ultimo_ref.left = eleDer;
                    tempo_der = eleDer;
                }
                else
                {
                    //////////////////////MessageBox.Show(eleIzq.ultimo_ref.Tran_left, "eleIzq.ultimo_ref.Tran_left  sin asignacion");
                    //////////////////////MessageBox.Show(eleDer.Tran_left, "eleDer.Tran_left  ");


                    //eleIzq.ultimo_ref = eleDer;
                    eleIzq.ultimo_ref.id = eleDer.id;
                    eleIzq.ultimo_ref.lexema = eleDer.lexema;
                    eleIzq.ultimo_ref.left = eleDer.left;
                    eleIzq.ultimo_ref.right = eleDer.right;
                    eleIzq.ultimo_ref.Tran_left = eleDer.Tran_left;
                    eleIzq.ultimo_ref.Tran_right = eleDer.Tran_right;
                    eleIzq.ultimo_ref.ultimo_ref = eleDer.ultimo_ref;
                    //eleIzq.ultimo_ref.visitado = false;
                    eleIzq.ultimo_ref.visitado = eleDer.visitado;
                    eleIzq.ultimo_ref.tipo = eleDer.tipo;
                    eleIzq.ultimo_ref.tipo_n = eleDer.tipo_n;

                    //tempo_der = eleIzq;
                    tempo_der = eleIzq.ultimo_ref;



                    //////////////////MessageBox.Show(eleIzq.ultimo_ref.Tran_left, "eleIzq.ultimo_ref.Tran_left  yayayay");
                    //////////////////MessageBox.Show(eleDer.Tran_left, "eleDer.Tran_left  yayayay 2 ");


                }

                ////////////////////////MessageBox.Show(tempo_der.ultimo_ref.tipo_n.ToString(), "***No2 tran -" + tempo_der.ultimo_ref.Tran_left);
                //////////////////////MessageBox.Show(tempo_der.ultimo_ref.tipo_n.ToString(), "***tempo_der.ultimo_ref.tipo_n tran -" + tempo_der.ultimo_ref.Tran_left);
                //////////////////////MessageBox.Show(eleDer.ultimo_ref.tipo_n.ToString(), "**eleDer.ultimo_ref.tipo_n tran -" + eleDer.ultimo_ref.Tran_left);

                if (tempo_der.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    //eleDer.ultimo_ref.left = N3;

                    tempo_der.ultimo_ref.left = N3; ////este funciono antes
                    tempo_der.left = N3;
                    //eleIzq.ultimo_ref.left = N3;
                }
                else
                {
                    //N3 = tempo_der.ultimo_ref;
                    N3 = eleDer.ultimo_ref;
                }

                


                //MessageBox.Show(eleDer.ultimo_ref.tipo_n.ToString(), "No2 tran -" + eleDer.ultimo_ref.Tran_left);
                //if (eleDer.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                //{
                //    eleDer.ultimo_ref.left = N3;
                //    //eleIzq.ultimo_ref.left = N3;
                //}
                //else
                //{
                //    N3 = eleDer.ultimo_ref;
                //}

                AND = eleIzq;
                AND.ultimo_ref = N3;
                return AND;
            }

            if (oper.Equals("+"))
            {


                //NodeAFN a1 = new NodeAFN("N", i, "E", Tipo.TipoN.NORMAL);
                ////NodeAFN a2 = new NodeAFN("N", i, "E", Tipo.TipoN.NORMAL);
                //a1.Tran_left = "a1";
                //a1.ultimo_ref = a1;

                //a2.Tran_left = "a2";
                //a2.ultimo_ref = a2;
                //NodeAFN a1 = eleIzq;
                //NodeAFN a2 = eleIzq;
                
                NodeAFN a2 = copiandoEstructura(eleIzq);
                

                //MessageBox.Show(a2.lexema, "primero a2.lexema ");
                //MessageBox.Show(a2.ultimo_ref.lexema, "ultimo a2.ultimo_ref.lexema ");

                MessageBox.Show(eleIzq.tipo_n.ToString(), "primero eleIzq.tipo_n ");
                MessageBox.Show(eleIzq.ultimo_ref.tipo_n.ToString(), "ultimo eleIzq.ultimo_ref.tipo_n ");

                MessageBox.Show(a2.tipo_n.ToString(), "primero a2.tipo_n ");
                MessageBox.Show(a2.ultimo_ref.tipo_n.ToString(), "ultimo a2.ultimo_ref.tipo_n ");

                //copiandoEstructura(eleIzq);

                //a1.Tran_left = "ah a1";
                //a2.Tran_left = "in a2";

                //NodeAFN conca = operar(eleIzq, ".", a2, i);
                ////NodeAFN kleen = operar(eleIzq, "*", null, i);

                IniciarVisitado(a2);
                IniciarVisitado(eleIzq);
                NodeAFN conca = operar(a2, ".", eleIzq, i);
                //MAS = eleIzq;
                MAS = conca;

                //Thompson tree = new Thompson(MAS, "mas");
                //tree.SetIndex();
                //tree.IniciarVisitado();
                //tree.graficando_Thomson();

                //SetIndex_soloprueba(MAS);
                return MAS;
            }
                return null; 

        }

        public NodeAFN copiandoEstructura(NodeAFN orinal)
        {
            IniciarVisitado(orinal);
            //MessageBox.Show(orinal.lexema, "copiandoNodos(orinal)");
            copiandoNodos(orinal);

            IniciarVisitado(orinal);
            //MessageBox.Show(orinal.lexema, "copiandoEnlaces(orinal)");
            copiandoEnlaces(orinal);
            return orinal.tempo_copy;

        }
        public void copiandoNodos(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                //MessageBox.Show("root_ac.lexema = " + root_ac.lexema);
                //MessageBox.Show("root_ac.Tran_left = " + root_ac.Tran_left);
                //MessageBox.Show("root_ac.Tran_right = " + root_ac.Tran_right);
                ///*copiando valores*/
                NodeAFN new_tem = new NodeAFN("N", 0, "E", Tipo.TipoN.EPSILON);
                new_tem.id = root_ac.id;
                ////////////MessageBox.Show(root_ac.lexema, "creando nodo--lexema");
                //new_tem.lexema = root_ac.lexema;
                new_tem.lexema = "N";
                //new_tem.left = root_ac.left;
                //new_tem.right = root_ac.right;
                new_tem.Tran_left = root_ac.Tran_left + "_c"; ;
                new_tem.Tran_right = root_ac.Tran_right + "_c"; ;
                ////////new_tem.ultimo_ref = root_ac.ultimo_ref;
                //new_tem.visitado = false;
                new_tem.tipo = root_ac.tipo;
                new_tem.tipo_n = root_ac.tipo_n;

                ///guardo la refencia el nodo nuevo
                root_ac.tempo_copy = new_tem;

                root_ac.visitado = true;

                if (root_ac.left != null && root_ac.left.visitado == false)
                {
                    this.copiandoNodos(root_ac.left);
                }
                if (root_ac.right != null && root_ac.right.visitado == false)
                {
                    this.copiandoNodos(root_ac.right);
                }
            }
        }

        //////////////////
        int index = 0;
        public void SetIndex_soloprueba(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                if (root_ac.lexema.Equals("N"))
                {
                    index++;
                    MessageBox.Show(index.ToString(), "set_lex");

                    root_ac.lexema = index.ToString();
                }


                if (root_ac.left != null && root_ac.left.lexema.Equals("N"))
                {
                    this.SetIndex_soloprueba(root_ac.left);
                }
                if (root_ac.right != null && root_ac.right.lexema.Equals("N"))
                {
                    this.SetIndex_soloprueba(root_ac.right);
                }
            }
        }
        //////////////////////
        public void copiandoEnlaces(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                ///*copiando enlaces*/
               
                NodeAFN new_tem;
                new_tem = root_ac.tempo_copy;
                //////////////////MessageBox.Show(root_ac.lexema, "enlzanado nodito nodo ++ lexema root_ac.lexema");
                
                //MessageBox.Show(new_tem.lexema, "enlzanado nodito nodo ++ lexema new_tem.lexema");
                //new_tem.left = root_ac.left.tempo_copy;
                //new_tem.right = root_ac.right.tempo_copy;
                //new_tem.ultimo_ref = root_ac.ultimo_ref.tempo_copy;

                if (root_ac.left != null)
                {
                    new_tem.left = root_ac.left.tempo_copy;
                }
                if (root_ac.right != null)
                {
                    new_tem.right = root_ac.right.tempo_copy;
                }
                if (root_ac.ultimo_ref != null)
                {
                    new_tem.ultimo_ref = root_ac.ultimo_ref.tempo_copy;
                }

                root_ac.visitado = true;    

                if (root_ac.left != null && root_ac.left.visitado == false)
                {
                    //new_tem.left = root_ac.left.tempo_copy;
                    this.copiandoEnlaces(root_ac.left);
                }
                if (root_ac.right != null && root_ac.right.visitado == false)
                {
                    //new_tem.right = root_ac.right.tempo_copy;
                    this.copiandoEnlaces(root_ac.right);
                }
            }
        }

        public void IniciarVisitado(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                if (root_ac.visitado == true)
                {
                    root_ac.visitado = false;
                }
                if (root_ac.left != null && root_ac.left.visitado == true)
                {
                    this.IniciarVisitado(root_ac.left);
                }
                if (root_ac.right != null && root_ac.right.visitado == true)
                {
                    this.IniciarVisitado(root_ac.right);
                }
            }
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
