using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Lexico
    {
        public LinkedList<Token> lis_tokens;
        List<Errores> lis_erores;

        List<String> reservadas;

        //List<String> con_caracteres; // para conjunto de caracteres
        String[] con_caracteres;
        public Lexico()
        {
            lis_tokens = new LinkedList<Token>();
            lis_erores = new List<Errores>();

            reservadas = new List<String>();
            reservadas.Add("CONJ");

            /* para conjunto de caracteres*/
            //con_caracteres = new List<String>();
            String[] con_c = { "!", "\"", "#", "$",
            "%","&","'","(",")","*","+",",", "-", ".","/", ":", ";", "<","=",
            ">", "?","@", "[", "\\", "]", "^", "_", "`", "{", "|", "}"};
            con_caracteres = con_c;
    }

        public void addToken(String lexema, String idToken, int linea, int columna)
        {
            Token nuevo = new Token(lexema, idToken, linea, columna);
            lis_tokens.AddLast(nuevo);
            //listaTokens.Add(nuevo);
        }

        public void addError(String lexema, String idToken, int linea, int columna)
        {
            Errores err = new Errores(lexema, idToken, linea, columna+1, "LEX");
            lis_erores.Add(err);
        }

        public List<Errores> getErroresLex()
        {
            return lis_erores;
        }
        public void ImprimeTokens()
        {
            //for (Token tok : lis_tokens)
            for (int i = 0; i < lis_tokens.Count; i++)
            {
                //Token tok = lis_tokens.ElementAt(i);
                Console.Out.WriteLine(lis_tokens.ElementAt(i).lexema + " - tipo: " + lis_tokens.ElementAt(i).idToken);

            }
        }

        public void ImprimeErrores()
        {
            for (int i = 0; i < lis_erores.Count; i++)
            {
                Console.Out.WriteLine("******" +lis_erores.ElementAt(i).lexema + " - err: " + lis_erores.ElementAt(i).idToken);

            }
        }

        public Boolean Macht_enReser(String sente)
        {
            Boolean enco = false;
            for (int i = 0; i < reservadas.Count; ++i)
            {
                if (sente.Equals(reservadas.ElementAt(i)))
                {
                    enco = true;
                    //estado_token = i;
                    return enco;
                }
                else { enco = false; }

            }
            return enco;
        }

        public Boolean Macht_Caracteres(String sente)
        {
            Boolean enco = false;
            for (int i = 0; i < con_caracteres.Length; ++i)
            {
                if (sente.Equals(con_caracteres[i]))
                {
                    enco = true;
                    return enco;
                }
                else { enco = false; }

            }
            return enco;
        }

    

        public void Analizador_cadena(String entrada)
        {
            //String ü = "1";
            //MessageBox.Show(ü, "ü");
            int estado_conjunto = 0;
            /*
             * 0 = no
             * 1 = conj
             * 2 = :
             * 3 = igualdad
             * 4 = rango del conjunto
             */
            int estado = 0;
            int columna = 0;
            int fila = 1;
            String lexema = "";
            char c;
            entrada = entrada + " ";

            //////////////////MessageBox.Show("#" + entrada+"#", " entrada");
            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;

                switch (estado)
                {
                    case 0:
                        //columna++;

                        /*para identificadores*/
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            lexema += c;

                        }
                        /*para numero*/
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }

                        /*para cadena de caracteres*/
                        else if (c == '"')
                        {
                            estado = 13;
                            i--;
                            columna--;
                        }

                        ///*para el delimitador %%*/
                        //else if (c == '%')
                        //{
                        //    estado = 16;
                        //    i--;
                        //    columna--;
                        //}
                        /* comentario 1 linea*/
                        else if (c == '/')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }

                        /*comentario multilinea*/
                        else if (c == '<')
                        {
                            estado = 7;
                            i--;
                            columna--;
                        }
                        /*igualdad */
                        else if (c == '-')
                        {
                            estado = 11;
                            i--;
                            columna--;
                        }

                        /*para [:todo:]*/
                        else if (c == '[')
                        {
                            estado = 21;
                            i--;
                            columna--;
                        }
                        /***inicio de caracteres especiales***/
                        else if (c == '\\')
                        {
                            estado = 17;
                            i--;
                            columna--;
                        }

                        //                        else if (c == ',')
                        //                        {
                        //                            estado = 6;
                        //                            i--;
                        //                            columna--;
                        //                        }
                        /*ignorar espacios*/
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        /*ignorar*/
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        else if (c == '{')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "llaveIzq", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "llaveDer", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }

                        /*coms*/
                        else if (c == ',')
                        {
                            lexema += c;
                            addToken(lexema, "coma", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "PuntoComa", fila, columna - lexema.Length);
                            lexema = "";

                            if (estado_conjunto == 4)
                            { estado_conjunto = 0; }
                        }
                        //                        else if (c == '<')
                        //                        {
                        //                            //Estado <>
                        //                            estado = 11;
                        //                            lexema += c;
                        //                            //addToken(lexema, "Menor (Abierto)", fila, columna - lexema.Length, i - lexema.Length);
                        //                            //lexema = "";
                        //                        }

                        else if (c == '~')
                        {
                            lexema += c;
                            //if (estado_conjunto == 4)
                            //{
                            //    addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            //}
                            //else
                            //{
                                addToken(lexema, "SeparRango", fila, columna - lexema.Length);
                            //}
                            lexema = "";
                        }
                        //
                        //                        /*fin nuevos*/
                        //
                        //                        /*nuevo proyecto 2*/
                        //                        else if (c == '\'')
                        //                        {
                        //                            lexema += c;
                        //                            addToken(lexema, "Comilla Simple", fila, columna, i);
                        //                            lexema = "";
                        //                        }
                        else if (c == ':')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "DosPuntos", fila, columna - lexema.Length);
                            }
                            lexema = "";

                            if (estado_conjunto == 1)
                            {estado_conjunto++;   }
                        }

                        /*expresiones regulares*/
                        else if (c == '.')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "Conca_por", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }
                        else if (c == '|')
                        {
                            lexema += c;
                            String tipo = "";
                            if (estado_conjunto == 4)
                            { tipo = "CaracterEsp"; }
                            else
                            {
                                tipo = "Disyun_mas";
                            }
                                addToken(lexema, tipo, fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '?')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "0oUnavez", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);}
                            else{
                                addToken(lexema, "0oMasvez", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }
                        else if (c == '+')
                        {
                            lexema += c;
                            if (estado_conjunto == 4)
                            {
                                addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            }
                            else
                            {
                                addToken(lexema, "1oMasvez", fila, columna - lexema.Length);
                            }
                            lexema = "";
                        }

                        ///////////////////////////////////////////////////////////
                        /*fin operadors mat*/
                        //antes
                        //else
                        //{
                        //    //addError(c.ToString() , "Desconocido", fila, columna);
                        //    estado = -99;
                        //    i--;
                        //    columna--;
                        //}
                        ////ahora
                        else
                        {
                            //////addError(c.ToString() , "Desconocido", fila, columna);
                            ////estado = -99;
                            ////i--;
                            ////columna--;

                            if (estado_conjunto == 4)
                            {
                                lexema += c;
                                //MessageBox.Show(lexema, "lexema");
                                Boolean encontrado = false;
                                encontrado = Macht_Caracteres(lexema);
                                
                                if (encontrado)
                                {
                                    addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                                    lexema = "";
                                }
                                else
                                {
                                    //MessageBox.Show(encontrado.ToString(), "encontrado");
                                    estado = -99;
                                    i--;
                                    columna--;
                                    lexema = "";
                                }


                            } else
                            {
                            estado = -99;
                            i--;
                            columna--;
                        }

                }
                        break;
                    case 1:
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;

                        }
                        else
                        {
                            Boolean encontrado = false;
                            encontrado = Macht_enReser(lexema);
                            if (encontrado)
                            {
                                addToken(lexema, "Reservada", fila, columna - lexema.Length);
                                estado_conjunto = 1;
                            }
                            else
                            {
                                addToken(lexema, "Identificador", fila, columna - lexema.Length);
                                if (estado_conjunto == 2)
                                { estado_conjunto++; }
                            }

                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;

                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        //                        /*nuevo*/
                        //                        else if (c == '.')
                        //                        {
                        //                            estado = 8;
                        //                            lexema += c;
                        //                        }
                        //                        /*nuevo fin*/
                        else
                        {
                            ////token = new Token(3, "Numero", lexema, fila, columna);
                            ////tokens.add(token);
                            //addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            addToken(lexema, "Digito", fila, columna - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    /*inicio de comentario 1 liena*/
                    //--
                    case 4:
                        if (c == '/')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (c == '/')
                        {
                            lexema += c;
                            estado = 6;
                        }
                        else
                        {
                            ////para que sea comentario tiene que ser 2
                            //i--;
                            //columna--;
                            //estado = -99;
                            if (estado_conjunto == 4)
                            {
                                /*pero si acepta -*/
                                lexema = "";
                                i = i - 2;
                                columna = columna - 2;
                                estado = 25;
                                lexema = "";
                            }
                            else
                            {
                                lexema = "";
                                i = i - 2;
                                columna = columna - 2;
                                estado = -99;
                            }
                        }
                        break;
                    case 6:
                        if (c != '\n')
                        {
                            lexema += c;
                            estado = 6;
                        }
                        else
                        {
                            lexema += c;
                            //////////////////////////                    addToken(lexema, "1LinComen", fila, columna - lexema.length());
                            estado = 0;
                            lexema = "";

                            columna = 0;
                            fila++;
                        }
                        break;
                    ////////////////////////////////////////    
                    /*fin  de comentario 1 liena*/

                    ////////////////////////////////////////
                    case 7:
                        if (c == '<')
                        {
                            lexema += c;
                            estado = 8;
                        }
                        break;
                    case 8:
                        if (c == '!')
                        {
                            lexema += c;
                            estado = 9;
                        }
                        else
                        {
                            lexema = "";
                            i--;
                            columna--;
                            estado = -99;
                        }
                        break;
                    case 9:
                        if (c != '!')
                        {
                            lexema += c;
                            estado = 9;

                            /////new
                            if (c == '\n')
                            {
                                columna = 0;
                                fila++;
                            }
                        }
                        else if (c == '!')
                        {
                            lexema += c;
                            estado = 10;
                        }
                        break;
                    case 10:
                        if (c != '>')
                        {
                            lexema += c;
                            estado = 9;
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            ////////////////////////                            addToken(lexema, "MultiComen", fila, columna - lexema.length());
                            estado = 0;
                            //MessageBox.Show(lexema, "lexema");
                            lexema = "";
                        }
                        break;
                    /*fin comentario multilinea*/
                    //////////////////////////////////

                    /*igualdad*/
                    case 11:
                        if (c == '-')
                        {
                            lexema += c;
                            estado = 12;
                        }
                        break;
                    case 12:
                        if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Igualdad", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";

                            if (estado_conjunto == 3)
                            { estado_conjunto++; }

                        }
                        else
                        {

                            //i--;
                            //columna--;
                            //estado = -99;
                            ////lexema += c;
                            ////addError(lexema, "Se experaba caracter >", fila, columna - lexema.Length);
                            ////estado = 0;
                            ////lexema = "";

                           

                            if (estado_conjunto == 4)
                            {
                                /*pero si acepta -*/
                                lexema = "";
                                i = i - 2;
                                columna = columna - 2;
                                estado = 20;
                                lexema = "";
                            }
                            else
                            {
                                lexema = "";
                                i = i - 2;
                                columna = columna - 2;
                                estado = -99;
                            }

                        }
                        break;
                    ////////para la cadena , estado 13
                    case 13:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 14;
                        }
                        break;
                    case 14:
                        ///*new */
                        //if (c == '\n')
                        //{
                        //    estado = -99;
                        //    i--;
                        //    columna--;
                        //    lexema = "";
                        //}
                        ///*origial*/
                        //else 
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 14;
                        }
                        else
                        {
                            estado = 15;
                            i--;
                            columna--;
                        }
                        //if (c != '"')
                        //{
                        //    lexema += c;
                        //    estado = 14;
                        //}
                        //else
                        //{
                        //    estado = 15;
                        //    i--;
                        //    columna--;
                        //}
                        break;
                    case 15:
                        if (c == '"')
                        {
                            lexema += c;
                            addToken(lexema, "Cadena", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    /*caracteres especiales*/
                    case 17:
                        if (c == '\\')
                        {
                            lexema += c;
                            estado = 18;
                        }
                        break;
                    case 18:
                        if (c == 'n')
                        {
                            lexema += c;
                            addToken(lexema, "SaltoLinea", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == '\'')
                        {
                            lexema += c;
                            addToken(lexema, "ComSimple", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == '"')
                        {
                            lexema += c;
                            addToken(lexema, "ComDoble", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == 't')
                        {
                            lexema += c;
                            addToken(lexema, "Tabulacion", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else
                        {
                            if (estado_conjunto == 4)
                            {
                                lexema += c;
                                lexema = "";
                                //MessageBox.Show(lexema, "lexema");
                                //MessageBox.Show(c.ToString(), "c");
                                ////i--;
                                ////columna--;
                                i = i - 2;
                                columna = columna - 2;
                                estado = 19;
                                lexema = "";
                            }
                            else
                            {
                                lexema = "";
                                i = i - 2;
                                columna = columna - 2;
                                estado = -99;
                            }
                            

                        }
                        break;

                    //para solo \
                    case 19:
                        if (c == '\\')
                        {
                            lexema += c;
                            //MessageBox.Show(lexema, "1111 lexema");
                            //MessageBox.Show(c.ToString(), "2222 c");
                            addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;


                    //para solo -
                    case 20:
                        if (c == '-')
                        {
                            lexema += c;
                            //MessageBox.Show(lexema, "1111 lexema");
                            //MessageBox.Show(c.ToString(), "2222 c");
                            addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;

                    /////////////////
                    /*fin cadena de caracteres*/


                    ////////inicio para [:todo:] ////////////////////////////////
                    case 21:
                        if (c == '[')
                        {
                            lexema += c;
                            estado = 22;
                        }
                        break;
                    case 22:
                        if (c == ':')
                        {
                            lexema += c;
                            estado = 23;
                        }
                        else
                        {
                            lexema = "";
                            i--;
                            columna--;
                            estado = -99;
                        }
                        break;
                    case 23:
                        if (c != ':')
                        {
                            lexema += c;
                            estado = 23;

                            /////new
                            if (c == '\n')
                            {
                                //lexema = "";
                                i--;
                                columna--;
                                estado = -99;
                            }
                        }
                        else if (c == ':')
                        {
                            lexema += c;
                            estado = 24;
                        }
                        break;
                    case 24:
                        if (c != ']')
                        {
                            lexema += c;
                            estado = 9;
                        }
                        else if (c == ']')
                        {
                            lexema += c;
                            addToken(lexema, "Todito", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;

                    //para solo /
                    case 25:
                        if (c == '/')
                        {
                            lexema += c;
                            //MessageBox.Show(lexema, "1111 lexema");
                            //MessageBox.Show(c.ToString(), "2222 c");
                            addToken(lexema, "CaracterEsp", fila, columna - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    /*fin comentario multilinea*/
                    //////////////////////////////////

                    ////        /*delimitador*/
                    ///*inicio de comentario 1 liena*/
                    //case 16:
                    //    if (c == '%')
                    //    {
                    //        lexema += c;
                    //        estado = 17;
                    //    }
                    //    break;
                    //case 17:
                    //    if (c == '%')
                    //    {
                    //        lexema += c;
                    //        addToken(lexema, "Delimitador", fila, columna - lexema.Length);
                    //        estado = 0;
                    //        lexema = "";
                    //    }
                    //    else
                    //    {
                    //        i--;
                    //        columna--;
                    //        estado = -99;
                    //        ///errorr
                    //    }
                    //    break;


                    case -99:
                        lexema += c;
                        ////System.out.println("error lexico ("  + ")" );
                        ////JOptionPane.showMessageDialog(null, c );
                        ////JOptionPane.showMessageDialog(null, lexema + " Carácter Desconocido, fil:" + fila + ", col: " + (columna - lexema.length()));
                        ////System.out.println("error lexico (" + lexema + ")" );
                        ////                        Errores err = new Errores("error lexico (" + lexema + ")" );
                        ////                        Practica1_comp1.list_err.add(err);
                        //list_err.add("error lexico (" + lexema + ")");

                        //MessageBox.Show(lexema, "lexema");
                        addError(lexema, "Carácter Desconocido", fila, columna - lexema.Length);
                        estado = 0;
                        lexema = "";
                        break;
                }
            } ///fin for

        }
    }
}
