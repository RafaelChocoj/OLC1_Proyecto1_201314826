using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class EvaluandoLexemas
    {

        List<TTransiciones_Cerraduras> tab_transiciones;
        List<Variables> lis_con;
        String name_expre;
        String cad;
        public EvaluandoLexemas(List<TTransiciones_Cerraduras> tab_transiciones, List<Variables> lis_con, String name_expre)
        {
            this.tab_transiciones = tab_transiciones;
            this.lis_con = lis_con;
            this.name_expre = name_expre;
        }


        public void EvaluandoLexema_x_Terminal(String entrada, int index_ac, String tipo, String ter, String ir_a)
        {
            String cad_actual = "";
            String Ir_a_estado_si_exito = "";
            int estado_interno = 0;
            ///
            int idEstado = 0;
            char c;
            Boolean Acepta_lexema = false;

            //int i_ante = 0;
            //int idEstado_ante = 0;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                //i_ante = i;
                //idEstado_ante = idEstado;

                MessageBox.Show(c.ToString(), i.ToString() + " EvaluandoLexema_final 11");
                //MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
                //for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
                //{
                Boolean pasa = false;

                //String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                //String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                //String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                //MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(idEstado).name_estado);
                //MessageBox.Show("ter: " + ter + ", ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                // MessageBox.Show(ir_a, "ir_a" + tab_transiciones.ElementAt(idEstado).name_estado);
                /**********************/
                if (tipo.Equals("CA"))
                    {
                        cad_actual = ter;
                        Ir_a_estado_si_exito = ir_a;
                        estado_interno = 2;

                        pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                        MessageBox.Show(pasa.ToString(), "pasa");
                        if (pasa)
                        {
                            //i = indice_continuar + 1;
                            i = indice_continuar;
                            //tab = 0;
                            idEstado = getIndexEstado(Ir_a_estado_si_exito);
                            MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);

                            String Aceptacion = tab_transiciones.ElementAt(idEstado).Estado;
                            if (Aceptacion.Equals("F"))
                            {
                                Acepta_lexema = true;
                            }
                            else
                            {
                                Acepta_lexema = false;
                            }
                        }
                        else
                        {
                            Acepta_lexema = false;
                            //i = i_ante;
                            //idEstado = idEstado_ante;
                            //MessageBox.Show(i.ToString(), "i_ante, no pasa");
                            //MessageBox.Show(idEstado.ToString(), "idEstado_ante, no pasa");
                        }
                    }
                    /**********************/

                //}
                //if (Acepta_lexema == false)
                //{

                //    MessageBox.Show("Error falta, se esperaba caracter");
                //}
                ////////if (tab_transiciones.ElementAt(idEstado).ir_a.Count == 0)
                ////////{
                ////////    Acepta_lexema = false;
                ////////}


            }

            //if (Acepta_lexema)
            //{
            //    MessageBox.Show("lexema aceptado");
            //}
            //else
            //{
            //    MessageBox.Show("Lexema invalido");
            //}
        }

        public void EvaluandoLexema_f2(String entrada)
        {
            
            int idEstado = 0;
            int i = 0;
            //c = entrada[i];

            MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
            for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
            {
                //Boolean pasa = false;
                MessageBox.Show(tab.ToString(), "tab");
                String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(idEstado).name_estado);
                MessageBox.Show("ter: " + ter + "    ----ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                //MessageBox.Show(ir_a, "ir_a" + tab_transiciones.ElementAt(idEstado).name_estado);
                /**********************/

                EvaluandoLexema_x_Terminal(entrada, i, tipo, ter, ir_a);
                //if (tipo.Equals("CA"))
                //{
                //    cad_actual = ter;
                //    Ir_a_estado_si_exito = ir_a;
                //    estado_interno = 2;

                //    pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                //    MessageBox.Show(pasa.ToString(), "pasa");
                //    if (pasa)
                //    {
                //        i = indice_continuar + 1;
                //        //i = indice_continuar;
                //        //tab = 0;
                //        idEstado = getIndexEstado(Ir_a_estado_si_exito);
                //        MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);

                //        String Aceptacion = tab_transiciones.ElementAt(idEstado).Estado;
                //        if (Aceptacion.Equals("F"))
                //        {
                //            Acepta_lexema = true;
                //        }
                //        else
                //        {
                //            Acepta_lexema = false;
                //        }
                //        MessageBox.Show(i.ToString(), "i");
                //        Verificando_Terminal(entrada, idEstado, i, c);  ////recursivo
                //    }
                //    else
                //    {
                //        Acepta_lexema = false;
                //        i = i_inicial;
                //        idEstado = idEstado_inicial;
                //        //MessageBox.Show(i.ToString(), "i_ante, no pasa");
                //        //MessageBox.Show(idEstado.ToString(), "idEstado_ante, no pasa");
                //        MessageBox.Show(i.ToString(), "i 222");
                //        Verificando_Terminal(entrada, idEstado, i, c);  ////recursivo
                //    }
                //}
                ///**********************/
            }
        }

        public void EvaluandoLexema_inicio(String entrada)
        {
            //String cad_actual = "";
            //String Ir_a_estado_si_exito = "";
            //int estado_interno = 0;
            ///
            int i = 0;
            int idEstado = 0;
            char c;
            //Boolean Acepta_lexema = false;

            c = entrada[i];
            Verificando_Terminal(entrada, idEstado, i, c);


        }

        /*************inicio*recorriendo*estados******************************************/
        List<Lexemas_Evaluados> l_evaluados;
        public void RecorroLisTransiciones(String entrada)
        {
            cad = entrada;
            l_evaluados = new List<Lexemas_Evaluados>();

            int estado_interno;
            int i_ac = 0;

            //Raiz A, 0, estado inicial;   
            //int ir_a_es = 0;
            int idEstado = 0;
            MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
            /*si ya no tiene mas estados pero todavia
             hay caracteres error lexema*/
            char c;
            int i = 0;
            MessageBox.Show("i = " + i.ToString(), "entrada.Length = " + entrada.Length.ToString());
            if (i < entrada.Length)
            {
                c = entrada[i];
                MessageBox.Show("c: " + c.ToString(), "i: " + i.ToString());
            }

            if (i == entrada.Length)
            {
                MessageBox.Show("1 la cadena termino");
            }

            Boolean encontro_transicion;
            encontro_transicion = false;
            for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
            {
                Boolean pasa = false;
                String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                MessageBox.Show("con| ter: " + ter + ", va a| ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                //ir_a_es = getIndexEstado(ir_a);
                if (tipo.Equals("CA"))
                {
                    //cad_actual = ter;
                    //Ir_a_estado_si_exito = ir_a;
                    estado_interno = 2;

                    //pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                    pasa = Eva_Lexema_Estado(entrada, ter, estado_interno, i);
                    MessageBox.Show(pasa.ToString(), "pasa");
                }

                if (pasa)
                {
                    //i = indice_continuar + 1;
                    ////i = indice_continuar;
                    i_ac = indice_continuar + 1;

                    ////idEstado = getIndexEstado(Ir_a_estado_si_exito);
                    ////MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);
                    //Boolean Acepta_lexema = false;
                    //String Aceptacion = tab_transiciones.ElementAt(idEstado).Estado;
                    //if (Aceptacion.Equals("F"))
                    //{
                    //    Acepta_lexema = true;
                    //}
                    //else
                    //{
                    //    Acepta_lexema = false;
                    //}

                    /*para listado de tokens*/
                    List<String> l_tokens_lex = new List<String>();
                    l_tokens_lex.Add(ter);
                    /*para listado de errores*/
                    List<String> l_errores_lex = new List<String>();
                    encontro_transicion = true;
                    l_evaluados.Add(new Lexemas_Evaluados(l_tokens_lex, l_errores_lex) );


                    ////MessageBox.Show(ter, "0 ter ter ter ter");

                    RecorroLisTransiciones(entrada, ir_a, i_ac, l_tokens_lex, l_errores_lex);
                } 
                ////////////RecorroLisTransiciones(entrada, ir_a, i_ac);
            }

            if (encontro_transicion == false && tab_transiciones.ElementAt(idEstado).ir_a.Count != 0)
            {
                char let = ' ';
                if (i < entrada.Length)
                {
                    let = entrada[i];
                }
                /*para listado de tokens*/
                List<String> l_tokens_lex = new List<String>();
                /*para listado de errores*/
                List<String> l_errores_lex = new List<String>();
                l_errores_lex.Add(let + ", No se Encontro Transicion 0");
                l_evaluados.Add(new Lexemas_Evaluados(l_tokens_lex, l_errores_lex));
                
            }
        }

        public void RecorroLisTransiciones(String entrada, String Estado, int i, List<String> l_tokens_lex, List<String> l_errores_lex)
        {
            int estado_interno;
            int i_ac = 0;

            int ir_a_es = getIndexEstado(Estado);
            //MessageBox.Show("1 Estado = " + Estado, "ir_a_es = " + ir_a_es.ToString());
            MessageBox.Show(tab_transiciones.ElementAt(ir_a_es).ir_a.Count.ToString(), " tab_transiciones.ElementAt(ir_a_es).ir_a.Count");
            /*si ya no tiene mas estados pero todavia
             hay caracteres error lexema*/

            Boolean Acepta_lexema = false;
            String Aceptacion = tab_transiciones.ElementAt(ir_a_es).Estado;
            if (Aceptacion.Equals("F"))
            {
                Acepta_lexema = true;
            }
            else
            {
                Acepta_lexema = false;
            }
            MessageBox.Show(Acepta_lexema.ToString(), "Acepta_lexema");

            char c;
            MessageBox.Show("i = " + i.ToString(), "entrada.Length = " + entrada.Length.ToString());
            if (i < entrada.Length)
            {
                c = entrada[i];
                MessageBox.Show("** c: " + c.ToString(), "*** i: " + i.ToString());
            }

            if (i == entrada.Length)
            {
                //////////////c = entrada[i];
                MessageBox.Show("== i: " + i.ToString());
            }

            if (i == entrada.Length)
            {
                MessageBox.Show("2 la cadena termino ++++++++++++++++++++++++++++");
                ////si cadena finaliza sin estado de aceptacion
                if (Acepta_lexema == false)
                {
                    l_errores_lex.Add("Cadena Finalizada sin Estado de Aceptación");
                }
            }

            /*si es estado final pero ya no sigue nada*/
            if (tab_transiciones.ElementAt(ir_a_es).ir_a.Count == 0 && i < entrada.Length )
            {
                l_errores_lex.Add(entrada[i] + ", Caracter invalido, caracteres de más");
            }

            //MessageBox.Show("** c: ", "*** i: " + i.ToString());
            if (i < entrada.Length) ////////////new
            { 

                Boolean encontro_transicion;
                encontro_transicion = false;
                for (int tab = 0; tab < tab_transiciones.ElementAt(ir_a_es).ir_a.Count; tab++)
                {
                    Boolean pasa = false;
                    String tipo = tab_transiciones.ElementAt(ir_a_es).ir_a.ElementAt(tab).Tipo_ter;
                    String ter = tab_transiciones.ElementAt(ir_a_es).ir_a.ElementAt(tab).terminal;
                    String ir_a = tab_transiciones.ElementAt(ir_a_es).ir_a.ElementAt(tab).Ir_a_Estado;

                    MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(ir_a_es).name_estado);
                    MessageBox.Show("*** con| ter: " + ter + ", *** va a| ir a: " + ir_a, tab_transiciones.ElementAt(ir_a_es).name_estado);
                    //ir_a_es = getIndexEstado(ir_a);
                    if (tipo.Equals("CA"))
                    {
                        //cad_actual = ter;
                        //Ir_a_estado_si_exito = ir_a;
                        estado_interno = 2;

                        ////pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                        //c = entrada[i];
                        //MessageBox.Show("----------------- c: " + c.ToString(), "--- i: " + i.ToString());
                        pasa = Eva_Lexema_Estado(entrada, ter, estado_interno, i);
                        //MessageBox.Show(pasa.ToString(), "pasa");
                    }

                    if (tipo.Equals("CO"))
                    {
                        estado_interno = 1;
                        pasa = Eva_Lexema_Estado(entrada, ter, estado_interno, i);
                        //MessageBox.Show(pasa.ToString(), "pasa");
                    }


                    MessageBox.Show(pasa.ToString(), "pasa"); ///
                    if (pasa)
                    {
                        //i = indice_continuar + 1;
                        ////i = indice_continuar;
                        i_ac = indice_continuar + 1;

                        ////idEstado = getIndexEstado(Ir_a_estado_si_exito);
                        ////MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);

                        //Boolean Acepta_lexema = false;
                        //String Aceptacion = tab_transiciones.ElementAt(ir_a_es).Estado;
                        //if (Aceptacion.Equals("F"))
                        //{
                        //    Acepta_lexema = true;
                        //}
                        //else
                        //{
                        //    Acepta_lexema = false;
                        //}

                        //List<String> l_tokens_lex = new List<String>();
                        encontro_transicion = true;
                        if (tipo.Equals("CO"))
                        {
                            l_tokens_lex.Add(ter + " - " + entrada[i]);
                        }
                        else
                        {
                            l_tokens_lex.Add(ter);
                        }
                        //MessageBox.Show(ter, "2 ter ter ter ter");
                        RecorroLisTransiciones(entrada, ir_a, i_ac, l_tokens_lex, l_errores_lex);
                    }
                    ////////////RecorroLisTransiciones(entrada, ir_a, i_ac);
                }

                if (encontro_transicion == false && tab_transiciones.ElementAt(ir_a_es).ir_a.Count != 0)
                {
                    MessageBox.Show("encontro_transicion = " + encontro_transicion.ToString(), "tab_transiciones.ElementAt(ir_a_es).ir_a.Count = " + tab_transiciones.ElementAt(ir_a_es).ir_a.Count);

                    char let = ' ';
                    if (i < entrada.Length)
                    {
                        let = entrada[i];
                    }
                    l_errores_lex.Add(let + ", No se Encontro Transicion 1");
                }
            }

        }

        public void Paso_Lexema()
        {
            for (int i = 0; i < l_evaluados.Count; i++)
            {
                MessageBox.Show(i.ToString(), "i");
                List<String> l_tokens = l_evaluados.ElementAt(i).l_tokens_lex;
                List<String> l_errores = l_evaluados.ElementAt(i).l_errores_lex;

                for (int j = 0; j < l_tokens.Count ; j++)
                {
                    MessageBox.Show(l_tokens.ElementAt(j), "l_tokens.ElementAt(j) = " + j);
                }

                for (int j = 0; j < l_errores.Count; j++)
                {
                    MessageBox.Show(l_errores.ElementAt(j), "l_errores.ElementAt(j) = " + j);
                }

            }
        }

        //public void Retorna_lex_validos()
        //{
        //    for (int i = 0; i < l_evaluados.Count; i++)
        //    {
        //        List<String> l_tokens = l_evaluados.ElementAt(i).l_tokens_lex;
        //        List<String> l_errores = l_evaluados.ElementAt(i).l_errores_lex;

        //        for (int j = 0; j < l_tokens.Count; j++)
        //        {
        //            //MessageBox.Show(l_tokens.ElementAt(j), "l_tokens.ElementAt(j) = " + j);
        //        }

        //        for (int j = 0; j < l_errores.Count; j++)
        //        {
        //            //MessageBox.Show(l_errores.ElementAt(j), "l_errores.ElementAt(j) = " + j);
        //        }

        //    }
        //}
        String resul_lexema;
        public void Tokes_n_Errors_xml()
        {
            resul_lexema = "";

            String lex_tok = "";
            String lex_err = "";
            int hay_valido = 0;
            int err = 0;
            for (int i = 0; i < l_evaluados.Count; i++)
            {
                //MessageBox.Show(i.ToString(), "i");
                List<String> l_tokens = l_evaluados.ElementAt(i).l_tokens_lex;
                List<String> l_errores = l_evaluados.ElementAt(i).l_errores_lex;

                StringBuilder tokens_xml = new StringBuilder();
                StringBuilder err_xml = new StringBuilder();

                if (l_tokens.Count > 0)
                {
                    tokens_xml.Append("<ListaTokens> \n");
                    for (int j = 0; j < l_tokens.Count; j++)
                    {
                        //MessageBox.Show(l_tokens.ElementAt(j), "l_tokens.ElementAt(j) = " + j);
                        tokens_xml.Append("<Token>\n");
                        //tokens_xml.Append("<Nombre>nombre_token1</Nombre>\n");
                        tokens_xml.Append("<Valor>" + l_tokens.ElementAt(j) + "</Valor>\n");
                        //tokens_xml.Append("<Fila>fila_token1</Fila>\n");
                        //tokens_xml.Append("<Columna>columna_token1</Columna>\n");
                        tokens_xml.Append("</Token>\n");

                    }
                    tokens_xml.Append("</ListaTokens>");
                    File.WriteAllText("tokens_" + name_expre + "_" + i + ".xml", tokens_xml.ToString());
                    System.Diagnostics.Process.Start("tokens_" + name_expre + "_" + i + ".xml");
                }
                if (l_errores.Count > 0)
                {
                    err++;
                    err_xml.Append("<ListaErrores>\n");
                    for (int j = 0; j < l_errores.Count; j++)
                    {
                        //MessageBox.Show(l_errores.ElementAt(j), "l_errores.ElementAt(j) = " + j);
                        err_xml.Append("<Error>\n");
                        err_xml.Append("<Valor>" + l_errores.ElementAt(j) + "</Valor>\n");
                        //err_xml.Append("<Fila>fila_error1</Fila>\n");
                        //err_xml.Append("<Columna>columna_error1</Columna>\n");
                        err_xml.Append("</Error>\n");
                    }
                    err_xml.Append("</ListaErrores>");

                    File.WriteAllText("errores_" + name_expre + "_" + i + ".xml", err_xml.ToString());
                    System.Diagnostics.Process.Start("errores_" + name_expre + "_" + i + ".xml");
                }

                /*verificando si no tiene errores, y haya pasado la validacion*/
                if (l_errores.Count == 0)
                {
                    hay_valido++;
                    lex_tok = lex_tok + "Expresión " + cad + " para la EXP " + name_expre + " ** Es Valida \n";
                }

                /*verificando si tiene errores encontrados*/
                if (l_errores.Count > 0)
                {
                    lex_err = lex_err + "Expresión " + cad + " para la EXP " + name_expre + " -- No es Valida \n";
                }

            }

            if (hay_valido > 0)
            {
                resul_lexema = lex_tok;
            }
            if (err > 0 && hay_valido == 0)
            {
                resul_lexema = lex_err;
            }
            //resul_lexema
        }

        public String return_texto_val()
        {
            return resul_lexema;
        }
        /*************fin*******************************************/

        //////////////////
        //public void RecorroLisTransiciones(String entrada)
        //{
        //    //Raiz A, 0, estado inicial;   
        //    //int ir_a_es = 0;
        //    int idEstado = 0;
        //    MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
        //    for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
        //    {
        //        String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
        //        String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

        //        MessageBox.Show("con| ter: " + ter + ", va a| ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
        //        //ir_a_es = getIndexEstado(ir_a);

        //        RecorroLisTransiciones(entrada, ir_a);
        //    }
        //}

        //public void RecorroLisTransiciones(String entrada, String Estado)
        //{
        //    int ir_a_es = getIndexEstado(Estado);
        //    MessageBox.Show(tab_transiciones.ElementAt(ir_a_es).ir_a.Count.ToString(), " tab_transiciones.ElementAt(ir_a_es).ir_a.Count");
        //    for (int tab = 0; tab < tab_transiciones.ElementAt(ir_a_es).ir_a.Count; tab++)
        //    {
        //        String ter = tab_transiciones.ElementAt(ir_a_es).ir_a.ElementAt(tab).terminal;
        //        String ir_a = tab_transiciones.ElementAt(ir_a_es).ir_a.ElementAt(tab).Ir_a_Estado;

        //        MessageBox.Show("*** con| ter: " + ter + ", *** va a| ir a: " + ir_a, tab_transiciones.ElementAt(ir_a_es).name_estado);
        //        //ir_a_es = getIndexEstado(ir_a);

        //        RecorroLisTransiciones(entrada, ir_a);
        //    }
        //}
        //////////////////

        public void Verificando_Terminal(String entrada, int idEstado, int i, char c)
        {
            String cad_actual = "";
            String Ir_a_estado_si_exito = "";
            int estado_interno = 0;
            Boolean Acepta_lexema = false;
            int i_inicial;
            int idEstado_inicial;


            i_inicial = i;
            idEstado_inicial = idEstado;
            c = entrada[i];
            MessageBox.Show(c.ToString(), i.ToString() + " EvaluandoLexema_final 11");
            MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
            for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
            {
                Boolean pasa = false;

                String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                //MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(idEstado).name_estado);
                MessageBox.Show("ter: " + ter + ", ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                // MessageBox.Show(ir_a, "ir_a" + tab_transiciones.ElementAt(idEstado).name_estado);
                /**********************/
                if (tipo.Equals("CA"))
                {
                    cad_actual = ter;
                    Ir_a_estado_si_exito = ir_a;
                    estado_interno = 2;

                    pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                    MessageBox.Show(pasa.ToString(), "pasa");
                    if (pasa)
                    {
                        i = indice_continuar + 1;
                        //i = indice_continuar;
                        //tab = 0;
                        idEstado = getIndexEstado(Ir_a_estado_si_exito);
                        MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);
                      
                        String Aceptacion = tab_transiciones.ElementAt(idEstado).Estado;
                        if (Aceptacion.Equals("F"))
                        {
                            Acepta_lexema = true;
                        }
                        else
                        {
                            Acepta_lexema = false;
                        }
                        MessageBox.Show(i.ToString(),"i");
                        Verificando_Terminal(entrada, idEstado, i, c);  ////recursivo
                    }
                    else
                    {
                        Acepta_lexema = false;
                        i = i_inicial;
                        idEstado = idEstado_inicial;
                        //MessageBox.Show(i.ToString(), "i_ante, no pasa");
                        //MessageBox.Show(idEstado.ToString(), "idEstado_ante, no pasa");
                        MessageBox.Show(i.ToString(), "i 222");
                        Verificando_Terminal(entrada, idEstado, i, c);  ////recursivo
                    }
                }
                /**********************/
            }

            if (Acepta_lexema == false)
            {

                MessageBox.Show("Error falta, se esperaba caracter","err lex lexema");
            }


        }

        public void EvaluandoLexema_final(String entrada)
        {
            String cad_actual = "";
            String Ir_a_estado_si_exito = "";
            int estado_interno = 0;
            ///
            int idEstado = 0;
            char c;
            Boolean Acepta_lexema = false;

            int i_ante = 0;
            int idEstado_ante = 0;
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                ////i_ante = i;
                ////idEstado_ante = idEstado;

                MessageBox.Show(c.ToString(), i.ToString() + " EvaluandoLexema_final 11");
                MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
                for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
                {
                    Boolean pasa = false;

                    String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                    String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                    String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                    //MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(idEstado).name_estado);
                    MessageBox.Show("ter: "+ ter + ", ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                   // MessageBox.Show(ir_a, "ir_a" + tab_transiciones.ElementAt(idEstado).name_estado);
                    /**********************/
                    if (tipo.Equals("CA"))
                    {
                        cad_actual = ter;
                        Ir_a_estado_si_exito = ir_a;
                        estado_interno = 2;

                        pasa = Eva_Lexema_Estado(entrada, cad_actual, estado_interno, i);
                        MessageBox.Show(pasa.ToString(), "pasa");
                        if (pasa)
                        {
                            //i = indice_continuar + 1;
                            i = indice_continuar;
                            tab = 0;
                            idEstado = getIndexEstado(Ir_a_estado_si_exito);
                            MessageBox.Show("CA pasa: " + pasa + " Ir_a_estado_si_exito: " + Ir_a_estado_si_exito);

                            String Aceptacion = tab_transiciones.ElementAt(idEstado).Estado;
                            if (Aceptacion.Equals("F"))
                            {
                                Acepta_lexema = true;
                            }
                            else
                            {
                                Acepta_lexema = false;
                            }
                        }
                        else
                        {
                            Acepta_lexema = false;
                            //i = i_ante;
                            //idEstado = idEstado_ante;
                            //MessageBox.Show(i.ToString(), "i_ante, no pasa");
                            //MessageBox.Show(idEstado.ToString(), "idEstado_ante, no pasa");
                        }
                    }
                    /**********************/

                }
                if (Acepta_lexema == false)
                {

                    MessageBox.Show("Error falta, se esperaba caracter");
                }
                //////if (tab_transiciones.ElementAt(idEstado).ir_a.Count == 0)
                //////{
                //////    Acepta_lexema = false;
                //////}


            }

            if (Acepta_lexema)
            {
                MessageBox.Show("lexema aceptado");
            } else
            {
                MessageBox.Show("Lexema invalido");
            }
        }

        public int getIndexEstado(String estado)
        {
            for (int i = 0; i < tab_transiciones.Count; i++)
            {
                if (tab_transiciones.ElementAt(i).name_estado.Equals(estado))
                {
                    return i;
                }
            }
            return -99;
        }

        /*si existe conjunto */
        public Variables existeCon(String name_con)
        {

            for (int i = 0; i < lis_con.Count ; i++)
            {
                if (name_con.Equals(lis_con.ElementAt(i).name_var))
                {
                    return lis_con.ElementAt(i);
                }
            }
            return null;
        }
        ///*si existe valor en listado*/
        //public boolean existe_valor_enConjunto(String val, List<String> valores)
        //{
        //    for (int i = 0; i < valores.size(); i++)
        //    {
        //        if (val.equals(valores.get(i)))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}


        int indice_continuar;
        public Boolean Eva_Lexema_Estado(String entrada, String cad_actual, int estado_interno, int ind)
        {
            int i_cad_actual = 0;
            String lexema = "";
            char c;

            for (int i = ind; i < entrada.Length; i++)
            {
                c = entrada[i];

                MessageBox.Show(c.ToString(), i.ToString() + "Eva_Lexema_Estado **");

                switch (estado_interno)
                {
                    /*para armar conjuntos*/
                    case 1:

                        /*buscando si existe conjunto*/
                        Variables conjunto = existeCon(cad_actual);
                        if (conjunto == null)
                        {
                            MessageBox.Show("no existe conjunto Conjunto " + cad_actual);
                            return false;
                        }
                        /*verificando tipo de conjunto*/
                        if (conjunto.tipo.Equals("C"))
                        {
                            /*verificando si es caracter especial*/
                            String character;
                            if (c == '\n')
                            {
                                character = "\\n";
                            }
                            else if (c == '\'')
                            {
                                character = "\\'";
                            }
                            else if (c == '\t')
                            {
                                character = "\\t";
                            }
                            /*no se valida con comillas dobles*/
                            //else if (c == '\"')
                            //{
                            //    character = "\\"";
                            //}
                            else
                            {
                                /**********si no es caracter especial**********/
                                character = c.ToString();
                                /*********fin*si no es caracter especial**********/
                            }
                            MessageBox.Show(character, "character");

                            ////Boolean existe = existe_valor_enConjunto(String.valueOf(c), conjunto.valores);
                            //Boolean existe = conjunto.valores.Contains(c.ToString());
                            Boolean existe = conjunto.valores.Contains(character);
                            if (existe)
                                {

                                    estado_interno = 0;
                                    cad_actual = "";
                                    lexema = "";
                                    indice_continuar = i;
                                    return true;
                                }
                                else
                                {
                                    ////////////JOptionPane.showMessageDialog(null, "No existe valor "+ c + " en Conjunto " + cad_actual);
                                    return false;
                                }
                                
                            

                        }


                        break;
                    /*para armar la cadena*/
                    case 2:
                        lexema += c;
                        i_cad_actual++;
                        if (i_cad_actual > cad_actual.Length)
                        {
                            //estado_interno = -99;
                            return false;
                        }

                        String conca_cad = cad_actual.Substring(0, i_cad_actual);
                        MessageBox.Show("+++cad_actual: "+ cad_actual + "|| creando cad: " + conca_cad + " - lex: "+ lexema);

                        if (conca_cad.Equals(lexema))
                        {
                            if (i_cad_actual == cad_actual.Length)
                            {

                                //acepta estado
                                estado_interno = 0;
                                cad_actual = "";
                                lexema = "";
                                indice_continuar = i;
                                MessageBox.Show("Cadena aceptada", "i = " + i.ToString()); 
                                return true;
                            }
                        }
                        else
                        {
                            ///MessageBox.Show("se enconetro error, no pasa lexema");
                            return false;
                        }

                        break;
                }
            }
            return false;
        }

        ///

    }
}
