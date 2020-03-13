﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Thompson
    {

        NodeAFN root;
        int index;
        public Thompson(NodeAFN root, String name_expre)
        {
            this.root = root;
            index = 0;
            //this.name_expre = name_expre;

            //tabla_siguientes = new LinkedList<>();

            //resul_expresiones = new LinkedList<>();
        }


        public Boolean graficando_Thomson()
        {
            StringBuilder graf = new StringBuilder(); //grafica total

            StringBuilder automatas = new StringBuilder(); // para las transiciones
            StringBuilder finales = new StringBuilder(); // para los estados finales

            graf.Append("digraph finite_state_machine {\n");
            graf.Append("rankdir=LR;\n");
            graf.Append("size=\"8,5\"");
            graf.Append("\n");

            //for (int i = 0; i < tab_transiciones.size(); i++)
            //{

            //    if (tab_transiciones.get(i).terminal.equals("F"))
            //    {
            //        finales.Append(" " + tab_transiciones.get(i).name_estado);
            //    }

            //    for (int j = 0; j < tab_transiciones.get(i).ir_a.size(); j++)
            //    {

            //        automatas.Append(tab_transiciones.get(i).name_estado + " -> " + tab_transiciones.get(i).ir_a.get(j).Ir_a_Estado);
            //        automatas.Append("[ label = \"" + tab_transiciones.get(i).ir_a.get(j).terminal + "\" ];");
            //        automatas.Append("\n");

            //    }
            //}
            VerArbol(graf);
            //graf.Append("node [shape = doublecircle]; ");
            //graf.Append(finales);
            graf.Append("\n");
            graf.Append("node [shape = circle];\n");
            ////graf.Append(automatas);

            graf.Append("\n}");


            MessageBox.Show(graf.ToString());
            File.WriteAllText("thom.txt", graf.ToString());
            System.Diagnostics.Process.Start("thom.txt");
            //return this.graf_arbolavl(graf.toString(), "graf_automata_" + name_expre);

            MessageBox.Show(root.lexema, "ultimo root.lexema ");
            MessageBox.Show(root.ultimo_ref.lexema, "ultimo root.ultimo_ref.lexema ");
            return true;
        }

        public void IniciarVisitado()
        {
            this.IniciarVisitado(this.root);
        }
        public void IniciarVisitado(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                if (root_ac.visitado == true)
                {
                    root_ac.visitado = false;
                }
                this.SetIndex(root_ac.left);
                this.SetIndex(root_ac.right);
            }
        }

        public void SetIndex()
        {
            this.SetIndex(this.root);
        }
        public void SetIndex(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                if (root_ac.lexema.Equals("N"))
                {
                    index++;
                    // MessageBox.Show(root_ac.lexema, index.ToString());

                    root_ac.lexema = index.ToString();
                }
                
                
                if (root_ac.left != null && root_ac.left.lexema.Equals("N"))
                {
                    this.SetIndex(root_ac.left);
                }
                if (root_ac.right != null && root_ac.right.lexema.Equals("N"))
                {
                    this.SetIndex(root_ac.right);
                }
            }
        }

        public void VerArbol(StringBuilder graf)
        {
            this.VerArbol(this.root, graf);
        }

        public void VerArbol(NodeAFN root_ac, StringBuilder graf)
        {
            if (root_ac != null)
            {
                
                NodeAFN tempo = root_ac;
                if (tempo.left != null)
                {
                    //MessageBox.Show(root_ac.lexema, root_ac.Tran_left + " left");
                    graf.Append(root_ac.lexema + " -> " + tempo.left.lexema);
                    graf.Append("[ label = \"" + root_ac.Tran_left + "\" ];");
                    graf.Append("\n");
                }
                if (tempo.right != null)
                {
                    //MessageBox.Show(root_ac.lexema, root_ac.Tran_right + " right");
                    graf.Append(root_ac.lexema + " -> " + tempo.right.lexema);
                    graf.Append("[ label = \"" + root_ac.Tran_right + "\" ];");
                    graf.Append("\n");
                }

                //if (tempo.right != null)
                //{
                //    //MessageBox.Show(root_ac.lexema, root_ac.Tran_right + " right");
                //    graf.Append(root_ac.lexema + " -> " + tempo.right.lexema);
                //    graf.Append("[ label = \"" + root_ac.Tran_right + "\" ];");
                //    graf.Append("\n");
                //}
                //if (tempo.left != null)
                //{
                //    //MessageBox.Show(root_ac.lexema, root_ac.Tran_left + " left");
                //    graf.Append(root_ac.lexema + " -> " + tempo.left.lexema);
                //    graf.Append("[ label = \"" + root_ac.Tran_left + "\" ];");
                //    graf.Append("\n");
                //}
                root_ac.visitado = true;

                if (root_ac.left != null && root_ac.left.visitado == false)
                {
                    this.VerArbol(root_ac.left, graf);
                }
   
                if (root_ac.right != null &&  root_ac.right.visitado == false)
                {
                    this.VerArbol(root_ac.right, graf);
                }
            }
        }

        ///////////////////
    }
}
