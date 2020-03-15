﻿using System;
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
                    MessageBox.Show(eleIzq.ultimo_ref.Tran_left, "eleIzq.ultimo_ref.Tran_left  sin asignacion");
                    MessageBox.Show(eleDer.Tran_left, "eleDer.Tran_left  ");

                    //Thompson tree = new Thompson(eleIzq, "iz");
                    //tree.SetIndex();
                    //tree.listar();
                    
                    //tree.IniciarVisitado();
                    //tree.graficando_Thomson();

                    
                    //treeder.IniciarVisitado();
                    //treeder.graficando_Thomson();

                    //eleIzq.ultimo_ref = eleDer;
                    eleIzq.ultimo_ref.id = eleDer.id;
                    eleIzq.ultimo_ref.lexema = eleDer.lexema;
                    eleIzq.ultimo_ref.left = eleDer.left;
                    eleIzq.ultimo_ref.right = eleDer.right;
                    eleIzq.ultimo_ref.Tran_left = eleDer.Tran_left;
                    eleIzq.ultimo_ref.Tran_right = eleDer.Tran_right;
                    eleIzq.ultimo_ref.ultimo_ref = eleDer.ultimo_ref;
                    eleIzq.ultimo_ref.visitado = false;
                    eleIzq.ultimo_ref.tipo = eleDer.tipo;
                    eleIzq.ultimo_ref.tipo_n = eleDer.tipo_n;

                    tempo_der = eleIzq;
                    //tempo_der = eleIzq.ultimo_ref;



                    MessageBox.Show(eleIzq.ultimo_ref.Tran_left, "eleIzq.ultimo_ref.Tran_left  yayayay");
                    MessageBox.Show(eleDer.Tran_left, "eleDer.Tran_left  yayayay 2 ");

                    //MessageBox.Show(eleIzq.ultimo_ref.lexema, "eleIzq.ultimo_ref.lexema aaaaa ");
                    ////eleDer.lexema = "mod para der ver si cambia iz";
                    //MessageBox.Show(eleIzq.ultimo_ref.lexema, "eleIzq.ultimo_ref.lexema bbbb ");
                    //MessageBox.Show(eleIzq.ultimo_ref.tipo_n.ToString(), "11111");

                    //MessageBox.Show(eleIzq.ultimo_ref.tipo_n.ToString(), "2222");
                    ////eleIzq.ultimo_ref.left = eleDer;
                    ////eleDer = eleIzq.ultimo_ref;
                    //eleIzq.ultimo_ref.lexema = "mod en izquid";
                    //MessageBox.Show(eleIzq.ultimo_ref.lexema, "eleIzq.ultimo_ref.lexema lexlex 1");

                }

                //MessageBox.Show(tempo_der.ultimo_ref.tipo_n.ToString(), "***No2 tran -" + tempo_der.ultimo_ref.Tran_left);
                MessageBox.Show(tempo_der.ultimo_ref.tipo_n.ToString(), "***No2 tran -" + tempo_der.ultimo_ref.Tran_left);

                MessageBox.Show(eleDer.ultimo_ref.tipo_n.ToString(), "**No2 tran -" + eleDer.ultimo_ref.Tran_left);

                if (tempo_der.ultimo_ref.tipo_n == Tipo.TipoN.NORMAL)
                {
                    //eleDer.ultimo_ref.left = N3;

                    tempo_der.ultimo_ref.left = N3;
                    //eleIzq.ultimo_ref.left = N3;
                }
                else
                {
                    Thompson treeder = new Thompson(eleIzq, "eleDer");
                    treeder.SetIndex();
                    treeder.listar();

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
                //NodeAFN kleen = operar(eleIzq, "*", null, i);
                //NodeAFN conca = operar(eleIzq, ".", kleen, i

                //NodeAFN a1 = new NodeAFN("N", i, "E", Tipo.TipoN.NORMAL);
                //NodeAFN a2 = new NodeAFN("N", i, "E", Tipo.TipoN.NORMAL);
                //a1.Tran_left = "a1";
                //a1.ultimo_ref = a1;

                //a2.Tran_left = "a2";
                //a2.ultimo_ref = a2;
                NodeAFN a1 = eleIzq;
                NodeAFN a2 = eleIzq;

                a2.Tran_left = "ah a nose a2";
                a1.Tran_left = "ah a nose a1";   
                NodeAFN conca = operar(a1, ".", a2, i);
                //MessageBox.Show(eleIzq.ultimo_ref.tipo_n.ToString(), "eleIzq.ultimo_ref.tipo_n");
                //NodeAFN conca = operar(eleIzq, ".", eleIzq, i);
                MAS = conca;
                return MAS;
            }
                return null; 

        }

        public NodeAFN copiandoEstructura(NodeAFN orinal)
        {
            return null;
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