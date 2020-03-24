using System;
using System.Collections.Generic;
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

        public EvaluandoLexemas(List<TTransiciones_Cerraduras> tab_transiciones, List<Variables> lis_con)
        {
            this.tab_transiciones = tab_transiciones;
            this.lis_con = lis_con;
        }


        public void EvaluandoLexema_f2 (String entrada)
        {

            int idEstado = 0;

            MessageBox.Show(tab_transiciones.ElementAt(idEstado).ir_a.Count.ToString(), " tab_transiciones.ElementAt(idEstado).ir_a.Count");
            for (int tab = 0; tab < tab_transiciones.ElementAt(idEstado).ir_a.Count; tab++)
            {
                //Boolean pasa = false;

                String tipo = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Tipo_ter;
                String ter = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).terminal;
                String ir_a = tab_transiciones.ElementAt(idEstado).ir_a.ElementAt(tab).Ir_a_Estado;

                //MessageBox.Show(tipo, "tipo " + tab_transiciones.ElementAt(idEstado).name_estado);
                MessageBox.Show("ter: " + ter + ", ir a: " + ir_a, tab_transiciones.ElementAt(idEstado).name_estado);
                // MessageBox.Show(ir_a, "ir_a" + tab_transiciones.ElementAt(idEstado).name_estado);
                
                /**********************/
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

        public void EvaluandoLexema_final(String entrada, List<Variables> lis_con)
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
                i_ante = i;
                idEstado_ante = idEstado;

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
            return true;
        }

        ///

    }
}
