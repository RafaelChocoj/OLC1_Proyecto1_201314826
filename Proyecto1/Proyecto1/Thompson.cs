using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Thompson
    {

        NodeAFN root;
        int index;
        List<NodeAFN> lis_Nodos_thomson;

        List<Transiciones> Listado_Tran; ///guarda el lista de trandiciones

        List<TTransiciones_Cerraduras> tab_transiciones; ///guarda la tabla de transiciones

        String name_expre;

        NodeAFN nod_inicial;  ///nodo incial de thomsopn
        NodeAFN nod_final;     ///nodo final thomson
        public Thompson(NodeAFN root, String name_expre, List<Transiciones> Listado_Tran)
        {
            this.root = root;
            index = 0;
            lis_Nodos_thomson = new List<NodeAFN>();

            tab_transiciones = new List<TTransiciones_Cerraduras>();


            this.Listado_Tran = Listado_Tran;
            this.name_expre = name_expre;

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
            VerArbol(automatas);

            //////VerArbol(graf);

            //graf.Append("node [shape = doublecircle]; ");
            //graf.Append(finales);
            graf.Append("\n");
            graf.Append("node [shape = circle];\n");
            graf.Append(automatas);

            graf.Append("\n}");


            MessageBox.Show(graf.ToString());
            File.WriteAllText("thom.txt", graf.ToString());
            ////////////////////System.Diagnostics.Process.Start("thom.txt");
            //return this.graf_arbolavl(graf.toString(), "graf_automata_" + name_expre);

            //System.Diagnostics.Process.Start("dot -Tpng " + name_g + ".txt -o " + name_g + ".jpg");

            MessageBox.Show(root.lexema, "ultimo root.lexema ");
            MessageBox.Show(root.ultimo_ref.lexema, "ultimo root.ultimo_ref.lexema ");
            nod_inicial = root;
            nod_final = root.ultimo_ref;
            return CreateImage("thom");
            //return true;
        }

        /*graficando automata*/
        public Boolean graficando_Automata()
        {
            StringBuilder graf = new StringBuilder(); //grafica total

            StringBuilder automatas = new StringBuilder(); // para las transiciones
            StringBuilder finales = new StringBuilder(); // para los estados finales

            StringBuilder inicial = new StringBuilder(); // para los estados inicial

            graf.Append("digraph finite_state_machine {\n");
            graf.Append("rankdir=LR;\n");
            graf.Append("size=\"8,5\"");
            graf.Append("\n");

            for (int i = 0; i < tab_transiciones.Count; i++)
            {

                if (tab_transiciones.ElementAt(i).Estado.Equals("F"))
                {
                    finales.Append(" " + tab_transiciones.ElementAt(i).name_estado);
                }
                if (tab_transiciones.ElementAt(i).Estado.Equals("I"))
                {
                    inicial.Append(" " + tab_transiciones.ElementAt(i).name_estado);
                }

                for (int j = 0; j < tab_transiciones.ElementAt(i).ir_a.Count; j++)
                {

                    automatas.Append(tab_transiciones.ElementAt(i).name_estado + " -> " + tab_transiciones.ElementAt(i).ir_a.ElementAt(j).Ir_a_Estado);
                    automatas.Append("[ label = \"" + tab_transiciones.ElementAt(i).ir_a.ElementAt(j).terminal + "\" ];");
                    automatas.Append("\n");

                }
            }

            graf.Append("node [shape = doublecircle]; ");
            graf.Append(finales);
            graf.Append("\n");

            graf.Append("node [shape = Mcircle]; ");
            graf.Append(inicial);
            graf.Append("\n");

            graf.Append("node [shape = circle];\n");
            graf.Append(automatas);

            graf.Append("\n}");

            File.WriteAllText("graf_automata_" + name_expre + ".txt" , graf.ToString());
            //return this.graf_arbolavl(graf.toString(), "graf_automata_" + name_expre);
            return CreateImage("graf_automata_" + name_expre);
        }


        /////////////////////
        public Boolean CreateImage(String name)
        {
            try
            {
                var comando = "dot -Tpng " + name + ".txt -o " + name + ".jpg";
                var PStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
                var proc = new System.Diagnostics.Process();
                PStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo = PStartInfo;
                proc.Start();
                proc.WaitForExit();
                //Thread.Sleep(500);
                System.Diagnostics.Process.Start(name + ".jpg");
                return true;
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message, "w.Message");
                MessageBox.Show(w.StackTrace, "w.StackTrace");
                MessageBox.Show(w.Source, "w.Source");
                return false;
            }
        }

        public void IniciarVisitado()
        {
            this.IniciarVisitado(this.root);
        }

        public void listar()
        {
            //this.IniciarVisitado(this.root);
            NodeAFN root_noda;
            root_noda = this.root;
            while (root_noda != null)
            {
                MessageBox.Show(root_noda.lexema + " -> " + root_noda.Tran_left);
                root_noda = root_noda.left;
            }
        }


        public void listar_nodes_thom()
        {
            for (int i = 0; i < lis_Nodos_thomson.Count; ++i)
            {
                //MessageBox.Show(lis_Nodos_thomson.ElementAt(i).lexema, i.ToString());

                switch (lis_Nodos_thomson.ElementAt(i).lexema)
                {
                    case "7":
                        lis_Nodos_thomson.ElementAt(i).lexema = "10";
                        break;
                    case "8":
                        lis_Nodos_thomson.ElementAt(i).lexema = "11";
                        break;
                    case "9":
                        lis_Nodos_thomson.ElementAt(i).lexema = "12";
                        break;
                    case "10":
                        lis_Nodos_thomson.ElementAt(i).lexema = "13";
                        break;
                    case "11":
                        lis_Nodos_thomson.ElementAt(i).lexema = "14";
                        break;
                    case "12":
                        lis_Nodos_thomson.ElementAt(i).lexema = "15";
                        break;
                    case "13":
                        lis_Nodos_thomson.ElementAt(i).lexema = "16";
                        break;

                    case "14":
                        lis_Nodos_thomson.ElementAt(i).lexema = "7";
                        break;
                    case "15":
                        lis_Nodos_thomson.ElementAt(i).lexema = "8";
                        break;
                    case "16":
                        lis_Nodos_thomson.ElementAt(i).lexema = "9";
                        break;
                }
            }
        }
        ////////////////////////////////////////////
        public NodeAFN return_nodoMueve(String idNode)
        {
            for (int i = 0; i < lis_Nodos_thomson.Count; ++i)
            {
                if (lis_Nodos_thomson.ElementAt(i).lexema.Equals(idNode))
                {
                    //////////////MessageBox.Show(lis_Nodos_thomson.ElementAt(i).lexema,"retornando nodo");
                    return lis_Nodos_thomson.ElementAt(i);
                }

            }
            return null;
        }

        public void reset_Visitador_cerradura()
        {
            for (int i = 0; i < lis_Nodos_thomson.Count; ++i)
            {
                lis_Nodos_thomson.ElementAt(i).visitado = false;
            }
        }
        public void MetedoCerradura_back()
        {

            IEnumerable<Transiciones> Listado_Tran_sort = Listado_Tran.OrderBy(trn => trn.transicion);
            Listado_Tran = Listado_Tran_sort.ToList();

            ///cerradura inicial
            List<String> lis_cerraduras = new List<String>(); ///A
            Cerradura_X(nod_inicial, lis_cerraduras);



            String cerx = "";
            //for (int i = 0; i < lis_cerraduras.Count; ++i)
            //{
            //    cerx = cerx + lis_cerraduras[i] + ", ";
            //}
            //MessageBox.Show(cerx, "cerx");
            //////////////////////////////////////////////////////
            cerx = "";
            for (int i = 0; i < Listado_Tran.Count; ++i)
            {
                cerx = cerx + Listado_Tran[i].transicion + ", ";
            }
            MessageBox.Show(cerx, "transiciones");

            IEnumerable<String> lis_cerraduras_sort = lis_cerraduras.OrderBy(idnod => idnod);
            lis_cerraduras = lis_cerraduras_sort.ToList();

            char name_cerradura = 'A';
            ////////////TTransiciones_Cerraduras transi = new TTransiciones_Cerraduras(name_cerradura.ToString(), lis_cerraduras, "I", "N" /*, ir_a_estados*/);
            ////////////tab_transiciones.Add(transi);

            cerx = "";
            for (int i = 0; i < lis_cerraduras.Count; ++i)
            {
                //NodeAFN nod_stado = return_nodoMueve(lis_cerraduras.ElementAt(i));
                //List<String> mueve_ira = new List<String>();
                //MueveX_a(nod_stado, mueve_ira);
                cerx = cerx + lis_cerraduras[i] + ", ";
            }
            MessageBox.Show(cerx, "cerraduras");

            /*mueve a/ ir a
             verifica en la cerradura si hay en el listado de transiciones*/
            for (int i = 0; i < Listado_Tran.Count; ++i)
            {
                //Listado_Tran.ElementAt(i).transicion;
                //Listado_Tran.ElementAt(i).tipo;
                MessageBox.Show(Listado_Tran.ElementAt(i).transicion, Listado_Tran.ElementAt(i).tipo);
                List<String> mueve_ira = new List<String>();
                MueveX_a(lis_cerraduras, Listado_Tran.ElementAt(i), mueve_ira);

                ///
                cerx = "";
                for (int i2 = 0; i2 < mueve_ira.Count; ++i2)
                {
                    cerx = cerx + mueve_ira[i2] + ", ";
                }
                MessageBox.Show(cerx, "mueve_ira.Count: " + mueve_ira.Count);
                ///

            }
        }

        public DataTable view_Listado_Tran()
        {
            DataRow row;
            //DataColumn colum;
            DataTable tabtan = new DataTable();
            tabtan.Columns.Add("T", typeof(string));
            tabtan.Columns.Add("Estado", typeof(string));

            for (int i = 0; i < Listado_Tran.Count; ++i)
            {
                tabtan.Columns.Add(Listado_Tran.ElementAt(i).transicion + "  [" + Listado_Tran.ElementAt(i).tipo + "]", typeof(string));
            }

            for (int tb = 0; tb < tab_transiciones.Count; ++tb)
            {
                row = tabtan.NewRow();
                row["T"] = tab_transiciones.ElementAt(tb).Estado;
                row["Estado"] = tab_transiciones.ElementAt(tb).name_estado;

                List<tran_a_estados> terminales = tab_transiciones.ElementAt(tb).ir_a;
                for (int i = 0; i < terminales.Count; ++i)
                {
                    //row[terminales.ElementAt(i).terminal] = terminales.ElementAt(i).Ir_a_Estado;
                    row[terminales.ElementAt(i).terminal + "  [" + terminales.ElementAt(i).Tipo_ter + "]"] = terminales.ElementAt(i).Ir_a_Estado;

                }

                tabtan.Rows.Add(row);
            }
            ////object ob_row = new object[3];
            ////ob_row.add
            ////tabtan.Rows.Add(new object[] { "A", "b" });
            //row = tabtan.NewRow();
            //row["Tipo"] = "A";
            //row["Estado"] = "no se vos";
            //tabtan.Rows.Add(row);

            return tabtan;
        }

        public void MetedoCerradura()
        {

            IEnumerable<Transiciones> Listado_Tran_sort = Listado_Tran.OrderBy(trn => trn.transicion);
            Listado_Tran = Listado_Tran_sort.ToList();

            ///cerradura inicial
            List<String> lis_cerraduras_inicial = new List<String>(); ///A
            Cerradura_X(nod_inicial, lis_cerraduras_inicial);



            String cerx = "";
            cerx = "";
            for (int i = 0; i < Listado_Tran.Count; ++i)
            {
                cerx = cerx + Listado_Tran[i].transicion + ", ";
            }
            MessageBox.Show(cerx, "transiciones");

            IEnumerable<String> lis_cerraduras_sort = lis_cerraduras_inicial.OrderBy(idnod => idnod);
            lis_cerraduras_inicial = lis_cerraduras_sort.ToList();

            List<tran_a_estados> ir_a_estados = new List<tran_a_estados>();
            char name_cerradura = 'A';

            String tip_nodin = EsFinal(lis_cerraduras_inicial);
            if (tip_nodin.Equals("N"))
            {
                tip_nodin = "I";
            }
            TTransiciones_Cerraduras transi = new TTransiciones_Cerraduras(name_cerradura.ToString(), lis_cerraduras_inicial, tip_nodin, "N", ir_a_estados);
            //TTransiciones_Cerraduras transi = new TTransiciones_Cerraduras(name_cerradura.ToString(), lis_cerraduras_inicial, "I", "N", ir_a_estados);
            tab_transiciones.Add(transi);

            /////////////////////////////////
            for (int tb = 0; tb < tab_transiciones.Count; ++tb)
            {
                if (tab_transiciones.ElementAt(tb).tipo_estado.Equals("N"))
                {
                    ////////////////////reset_Visitador_cerradura();
                    List<String> lis_cerraduras = tab_transiciones.ElementAt(tb).cerradura;
                    /***********************************************************/
                    cerx = "";
                    for (int i = 0; i < lis_cerraduras.Count; ++i)
                    {
                        //NodeAFN nod_stado = return_nodoMueve(lis_cerraduras.ElementAt(i));
                        //List<String> mueve_ira = new List<String>();
                        //MueveX_a(nod_stado, mueve_ira);
                        cerx = cerx + lis_cerraduras[i] + ", ";
                    }
                    MessageBox.Show(cerx, "Leyendo cerr NAME: " + tab_transiciones.ElementAt(tb).name_estado);

                    /*mueve a/ ir a
                     verifica en la cerradura si hay en el listado de transiciones*/
                    for (int i = 0; i < Listado_Tran.Count; ++i)
                    {
                        //Listado_Tran.ElementAt(i).transicion;
                        //Listado_Tran.ElementAt(i).tipo;

                        //reset_Visitador_cerradura(); ///reiniciar visitados
                        MessageBox.Show(Listado_Tran.ElementAt(i).transicion, "00 terminar = " + Listado_Tran.ElementAt(i).tipo);
                        List<String> mueve_ira = new List<String>();
                        MueveX_a(lis_cerraduras, Listado_Tran.ElementAt(i), mueve_ira);

                        /*mueve_ira con el mueve resultando
                         * se busca las cerraduras para cada nodo
                         * encontrado en el lexema */

                        List<String> lis_cerraduras_ac = new List<String>(); ///B, C, D
                        for (int m = 0; m < mueve_ira.Count; m++)
                        {
                            reset_Visitador_cerradura(); ///reiniciar visitados
                            MessageBox.Show(mueve_ira.ElementAt(m), "haciendo Cerradura de ---- mueve_ira-");
                            NodeAFN nod_cerra = return_nodoMueve(mueve_ira.ElementAt(m));

                            Cerradura_X(nod_cerra, lis_cerraduras_ac);
                        }
                        /****fin creando cerraduras****/

                        /********mueve_ira*********/
                        /////////////////   aqui deberia de guardar moeve a mi
                        ////tabla de estados
                        //IEnumerable<String> mueve_sort = mueve_ira.OrderBy(idnod => idnod);
                        //mueve_ira = mueve_sort.ToList();
                        IEnumerable<String> lis_cerraduras_ac_sort = lis_cerraduras_ac.OrderBy(idnod => idnod);
                        lis_cerraduras_ac = lis_cerraduras_ac_sort.ToList();

                        ///
                        cerx = "";
                        for (int i2 = 0; i2 < lis_cerraduras_ac.Count; ++i2)
                        {
                            cerx = cerx + lis_cerraduras_ac[i2] + ", ";
                        }
                        //////MessageBox.Show(cerx, "lis_cerraduras_ac.Count: " + lis_cerraduras_ac.Count);
                        ///
                        /*verificando si tiene contenido y que no este repedido*/
                        if (lis_cerraduras_ac.Count > 0)
                        {
                            MessageBox.Show(cerx, "lis_cerraduras_ac.Count: " + lis_cerraduras_ac.Count);
                            MessageBox.Show(ExisteCerradura(lis_cerraduras_ac).ToString(), "ExisteCerradura(lis_cerraduras_ac)");
                            if (ExisteCerradura(lis_cerraduras_ac) == false)
                            {
                                char new_name_cerradura = tab_transiciones.Last().name_estado[0];
                                new_name_cerradura++;
                                MessageBox.Show(new_name_cerradura.ToString(), "new estado");
                                ////lis_cerraduras_ac son las tranciciones

                                //TTransiciones_Cerraduras new_transi = new TTransiciones_Cerraduras(new_name_cerradura.ToString(), mueve_ira, "N", "N" /*, ir_a_estados*/);
                                //tab_transiciones.Add(new_transi);
                                List<tran_a_estados> ir_a_estados_tem = new List<tran_a_estados>();

                                String tip_nod = EsFinal(lis_cerraduras_ac);
                                TTransiciones_Cerraduras new_transi = new TTransiciones_Cerraduras(new_name_cerradura.ToString(), lis_cerraduras_ac, tip_nod, "N", ir_a_estados_tem);
                                tab_transiciones.Add(new_transi);

                                //////MessageBox.Show("1 agregando terminar " + Listado_Tran.ElementAt(i).transicion, Listado_Tran.ElementAt(i).tipo);
                                tab_transiciones.ElementAt(tb).ir_a.Add(new tran_a_estados(Listado_Tran.ElementAt(i).transicion, new_name_cerradura.ToString(), Listado_Tran.ElementAt(i).tipo));

                            } else  //// si si existe, solo lo ingreso a ir a estado
                            {
                                ////MessageBox.Show("2 agregando terminar " + Listado_Tran.ElementAt(i).transicion,  Listado_Tran.ElementAt(i).tipo);
                                String name_cerr = Obtengo_Ir_A_Estado(lis_cerraduras_ac);
                                tab_transiciones.ElementAt(tb).ir_a.Add(new tran_a_estados(Listado_Tran.ElementAt(i).transicion, name_cerr, Listado_Tran.ElementAt(i).tipo));
                            }
                        }

                    }
                    tab_transiciones.ElementAt(tb).tipo_estado = "S";
                    /***********************************************************/
                }

            }

            /*mostrando datos en el datagrid view*/

        }

        /*obtiene si el estado es final*/
        public String EsFinal(List<String> lis_cerraduras_ac)
        {
            String idfinal = nod_final.lexema;
            for (int i = 0; i < lis_cerraduras_ac.Count; i++)
            {
                if (lis_cerraduras_ac.ElementAt(i).Equals(idfinal) )
                {
                    return "F";
                }
            }
            return "N";
        }

        public bool ExisteCerradura(List<String> mueve_ira)
        {
            for (int i = 0; i < tab_transiciones.Count; ++i)
            {
                List<String> cerr_existente = tab_transiciones.ElementAt(i).cerradura;
                var exist = cerr_existente.Count() == mueve_ira.Count() && !cerr_existente.Except(mueve_ira).Any();
                if (exist)
                {
                    return true;
                }
            }
            return false;
        }

        public String Obtengo_Ir_A_Estado(List<String> mueve_ira)
        {
            for (int i = 0; i < tab_transiciones.Count; ++i)
            {
                List<String> cerr_existente = tab_transiciones.ElementAt(i).cerradura;
                var exist = cerr_existente.Count() == mueve_ira.Count() && !cerr_existente.Except(mueve_ira).Any();
                if (exist)
                {
                    return tab_transiciones.ElementAt(i).name_estado;
                }
            }
            return null;
        }
        public void MueveX_a(List<String> lis_cerraduras, Transiciones transicion, List<String> mueve_ira)
        {
            for (int i = 0; i < lis_cerraduras.Count; ++i)
            {
                NodeAFN nod_stado = return_nodoMueve(lis_cerraduras.ElementAt(i));

                //if (transicion.transicion.Equals(nod_stado.Tran_left))
                if (transicion.transicion.Equals(nod_stado.Tran_left) &&
                    nod_stado.Tran_left_Tipo == Tipo.TipoN.NORMAL && transicion.tipo.Equals(nod_stado.tipo) )
                {
                    if (nod_stado.left != null)
                    {
                        //MessageBox.Show(nod_stado.left.lexema, transicion.transicion + " izq");
                        mueve_ira.Add(nod_stado.left.lexema);
                    }
                }
                ////if (transicion.transicion.Equals(nod_stado.Tran_right))
                //if (transicion.transicion.Equals(nod_stado.Tran_right) && 
                //    nod_stado.Tran_left_Tipo == Tipo.TipoN.NORMAL)
                //{
                //    if (nod_stado.right != null)
                //    {
                //        //MessageBox.Show(nod_stado.right.lexema, transicion.transicion + " der");
                //        mueve_ira.Add(nod_stado.right.lexema);
                //    }

                //}
            }
        }

        //public void MueveX_a(NodeAFN nod_stado, List<String> mueve_ira)
        //{
        //    for (int i = 0; i < Listado_Tran.Count; ++i)
        //    {
        //        //Listado_Tran.ElementAt(i).transicion;
        //        //Listado_Tran.ElementAt(i).tipo;
        //        if (Listado_Tran.ElementAt(i).transicion.Equals(nod_stado.Tran_left) )
        //        {
        //           if (nod_stado.left != null) {
        //                mueve_ira.Add(nod_stado.left.lexema);
        //            }
        //        }
        //        if (Listado_Tran.ElementAt(i).transicion.Equals(nod_stado.Tran_right))
        //        {
        //            if (nod_stado.right != null)
        //            {
        //                mueve_ira.Add(nod_stado.right.lexema);
        //            }

        //        }
        //    }
        //}
        /*creando las cerraduras*/
        public void Cerradura_X(NodeAFN root_ac, List<String> lis_cerraduras)
        {
            //if (root_ac != null)
            if (root_ac != null)
            {
                MessageBox.Show("Cerradura* " + root_ac.lexema, root_ac.tipo_n.ToString());
                ////////////////lis_cerraduras.Add(root_ac.lexema);
                
                if (lis_cerraduras.Contains(root_ac.lexema) == false)
                {
                    lis_cerraduras.Add(root_ac.lexema);
                }
                if (root_ac.left != null)
                {
                    //if (root_ac.Tran_left_Tipo == Tipo.TipoN.EPSILON)
                    //{
                    //    //cerra_x.Add(root_ac.left.lexema);
                    //    MessageBox.Show("left ->* " + root_ac.left.lexema, root_ac.Tran_left_Tipo.ToString());
                    //}

                }
                if (root_ac.right != null)
                {
                    //if (root_ac.Tran_right_Tipo == Tipo.TipoN.EPSILON)
                    //{
                    //    //cerra_x.Add(root_ac.right.lexema);
                    //    MessageBox.Show("right ->* " + root_ac.right.lexema, root_ac.Tran_right_Tipo.ToString());
                    //}
                }
                
                root_ac.visitado = true;

                if (root_ac.left != null && root_ac.left.visitado == false && root_ac.Tran_left_Tipo == Tipo.TipoN.EPSILON)
                {
                    this.Cerradura_X(root_ac.left, lis_cerraduras);
                }

                if (root_ac.right != null && root_ac.right.visitado == false && root_ac.Tran_right_Tipo == Tipo.TipoN.EPSILON)
                {
                    this.Cerradura_X(root_ac.right, lis_cerraduras);
                }
            }
        }
        ///////////////////////////////////////
        public void IniciarVisitado(NodeAFN root_ac)
        {
            if (root_ac != null)
            {
                ////////////MessageBox.Show("root_ac.lexema: " + root_ac.lexema, "root_ac.visitado: " + root_ac.visitado);
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
                    //////////////////MessageBox.Show("index: "+root_ac.lexema, index.ToString());

                    root_ac.lexema = index.ToString();
                    lis_Nodos_thomson.Add(root_ac);
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
            //this.VerArbol(this.root, graf);
            this.VerArbol(root, graf);
        }

        public void VerArbol(NodeAFN root_ac, StringBuilder graf)
        {
            if (root_ac != null)
            {
                //////////////////MessageBox.Show(root_ac.lexema, "lexema**************");
                NodeAFN tempo = root_ac;
                if (tempo.left != null)
                {
                    //MessageBox.Show(root_ac.lexema, root_ac.Tran_left + " left");
                    graf.Append(root_ac.lexema + " -> " + tempo.left.lexema);
                    if (root_ac.Tran_left_Tipo == Tipo.TipoN.NORMAL)
                    {
                        graf.Append("[ label = \"" + root_ac.Tran_left + "\" ];");
                    }
                    else if (root_ac.Tran_left_Tipo == Tipo.TipoN.EPSILON)
                    {
                        graf.Append("[ label = \"" + "ε" + "\" ];");
                    }

                    graf.Append("\n");
                }
                if (tempo.right != null)
                {
                    //MessageBox.Show(root_ac.lexema, root_ac.Tran_right + " right");
                    graf.Append(root_ac.lexema + " -> " + tempo.right.lexema);
                    if (root_ac.Tran_right_Tipo == Tipo.TipoN.NORMAL)
                    {
                        graf.Append("[ label = \"" + root_ac.Tran_right + "\" ];");
                    } else if (root_ac.Tran_right_Tipo == Tipo.TipoN.EPSILON)
                    {
                        graf.Append("[ label = \"" + "ε" + "\" ];");
                    }
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
