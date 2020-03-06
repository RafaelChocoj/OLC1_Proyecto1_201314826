using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Sintactico
    {

        LinkedList<Token> listaTokens;
        int numPreanalisis;
        Token preanalisis;
        public void Parsear(LinkedList<Token> list)
        {
            //err_sin = new LinkedList<String>();
            ///*inicializando lista de variables*/
            //lis_var = new LinkedList<Variables>();

            ///*inicializando lista de expresiones regulares*/
            //lis_ex_reg = new LinkedList<VarExpReg>();

            ///*inicializando evaluar las expresiones regulares*/
            //lis_evaluar_expre = new LinkedList<>();

 
            listaTokens = list;
            listaTokens.AddLast(new Token("", "UltimoToken", 0, 0));
            //preanalisis = list.get(0);
            preanalisis = list.ElementAt(0);
            numPreanalisis = 0;
            S0();
        }

        void S0()
        {

            ////////////////match("llaveIzq"); //}

            /*pueden venir conjuntos*/
            if (preanalisis.idToken.Equals("Reservada"))
            {
                CONJ();
            }
            //else if (preanalisis.idToken.Equals("Identificador"))
            //{
            //    //ER();
            //}

            ///*psts evaluar las expresines regulares*/
            //if (preanalisis.idToken.equals("Delimitador"))
            //{
            //    match("Delimitador"); //%%
            //    match("Delimitador"); //%%
            //    EVA_ER();
            //}

            ///////////////////*pueden venir expresiones*/
            //////////////////match("llaveDer"); //{

        }

        String var_tempo;
        /*para conjuntos*/
        public void CONJ()
        {
            if (preanalisis.idToken.Equals("Reservada"))
            {
                if (preanalisis.lexema.Equals("CONJ"))
                {

                    match("Reservada"); // CONJ
                    match("DosPuntos"); // :

                    /*guardando variable*/
                    if (preanalisis.idToken.Equals("Identificador"))
                    {
                        //JOptionPane.showMessageDialog(null,"var: " + preanalisis.lexema);
                        var_tempo = preanalisis.lexema;
                    }
                    match("Identificador"); // name variable

                    match("Igualdad"); // ->

                    /*guardando valores*/
                    List<String> valores = new List<String>();
                    VAL_CON(valores);

                }
                else
                {
                    MessageBox.Show("Se esperaba Palabra Reservada CONJ");
                }

            }

            ////recusivo para conjuntos
            if (preanalisis.idToken.Equals("Reservada"))
            {
                CONJ();
            }
            else if (preanalisis.idToken.Equals("Identificador"))
            {
                //ER();
            }
        }

        ////
        /*para valores de los conjuntos*/
        public void VALOR_UNITARIO(List<String> valores)
        {
            if (preanalisis.idToken.Equals("Identificador"))
            {
                valores.Add(preanalisis.lexema);
                match("Identificador"); //a
            }
            else if (preanalisis.idToken.Equals("Digito"))
            {
                valores.Add(preanalisis.lexema);
                match("Digito"); //1
            }
            else if (preanalisis.idToken.Equals("CaracterEsp"))
            {
                valores.Add(preanalisis.lexema);
                match("CaracterEsp"); //%
            }
            else
            {
                //err_sin.add("Error Sintactico se esperaba un caracter o Dijito lexema: " + preanalisis.lexema);
                MessageBox.Show("Error Sintactico se esperaba un caracter, Dijito o Caracter Especial lexema: " + preanalisis.lexema);
                match("Identificador, Digito o CaracterEsp"); //1
            }
        }

        public void VAL_CON(List<String> valores)
        {

            VALOR_UNITARIO(valores);
            /*verificando si es coma o dos puntos*/
            /*sigue*/

            if (preanalisis.idToken.Equals("coma"))
            {
                match("coma"); //,
                VAL_CON(valores);
            }
            /*verificando si es rango*/
            else if (preanalisis.idToken.Equals("SeparRango"))
            {
                    match("SeparRango"); //,
                    VALOR_UNITARIO(valores);//VALOR FINAL
                    match("PuntoComa"); //;

                //MessageBox.Show("rengo valores: " + valores);
                
                List<String> tempo_val = new List<String>();

                char r1 = valores.ElementAt(0)[0];
                char r2 = valores.ElementAt(1)[0];
                //MessageBox.Show("r1: " + r1);
                //MessageBox.Show("r2: " + r2);
                //imprime_prub_list(valores);

                while (r1 <= r2)
                {
                    tempo_val.Add(r1.ToString());
                    r1++;
                }

                imprime_prub_list(tempo_val);

                ////Variables n_var = new Variables(var_tempo, valores, "R");
                //valores = tempo_val;
                //Variables n_var = new Variables(var_tempo, valores, "C");
                //lis_var.add(n_var);
                //var_tempo = "";
            }
            /*termina*/
            else if (preanalisis.idToken.Equals("PuntoComa"))
            {
                match("PuntoComa"); //;
                MessageBox.Show("listaod valores: " + valores);
                imprime_prub_list(valores);
                //Variables n_var = new Variables(var_tempo, valores, "C");
                //lis_var.add(n_var);
                //var_tempo = "";
            }
        }

        public void imprime_prub_list(List<String> valores)
        {
            String listad = "";
            foreach (String lis in valores)
            {
                listad = listad + lis + ", ";
            }
            MessageBox.Show(listad, "listad");
        }

        /*haciendo mach a las palabras, si son iguales*/
        public void match(String tipo)
        {
            //imprime el actual
            MessageBox.Show("*******Actual= " + tipo + "************ lexema= " + preanalisis.lexema);
            if (!tipo.Equals(preanalisis.idToken))
            {
                MessageBox.Show("Error Sintactico se esperaba un caracter TIPO " + tipo + ", lexema: " + preanalisis.lexema);
                //err_sin.add("Error Sintactico se esperaba un caracter TIPO " + tipo + ", lexema: " + preanalisis.lexema);
                ////            //lexema, idToken, linea, columna
                ////            addError(lexe_ac, des_er, preanalisis.getLinea(), preanalisis.getColumna());
                ////            can_erroes++;
            }
            else
            {
                //MessageBox.Show("paso sintactico");// , lexema: " + preanalisis.lexema);

            }
            if (!preanalisis.idToken.Equals("UltimoToken"))
            {
                numPreanalisis++;
                preanalisis = listaTokens.ElementAt(numPreanalisis);
            }
            else
            {
                MessageBox.Show("fin token");
            }

        }
        //////////////////////////////////////////////////////////////
    }
}
