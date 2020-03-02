﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    class Lexico
    {
        LinkedList<Token> lis_tokens;
        List<Errores> lis_erores;

        public Lexico()
        {
            lis_tokens = new LinkedList<Token>();
        }

        public void addToken(String lexema, String idToken, int linea, int columna)
        {
            Token nuevo = new Token(lexema, idToken, linea, columna);
            lis_tokens.AddLast(nuevo);
            //listaTokens.Add(nuevo);
        }

        public void addError(String lexema, String idToken, int linea, int columna)
        {
            Errores err = new Errores(lexema, idToken, linea, columna, "LEX");
            lis_erores.Add(err);
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

        public void Analizador_cadena(String entrada)
        {

            int estado = 0;
            int columna = 0;
            int fila = 1;
            String lexema = "";
            char c;
            entrada = entrada + " ";

            MessageBox.Show("#" + entrada+"#", " entrada");
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

                        //            /*para el delimitador %%*/
                        //            else if (c == '%')
                        //            {
                        //                estado = 16;
                        //                i--;
                        //                columna--;
                        //            }
                        /* comentario 1 linea*/
                        else if (c == '/')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }

                        //            /*comentario multilinea*/
                        //            else if (c == '<')
                        //            {
                        //                estado = 7;
                        //                i--;
                        //                columna--;
                        //            }
                        //            /*igualdad */
                        //            else if (c == '-')
                        //            {
                        //                estado = 11;
                        //                i--;
                        //                columna--;
                        //            }

                        //            //                        else if (c == ',')
                        //            //                        {
                        //            //                            estado = 6;
                        //            //                            i--;
                        //            //                            columna--;
                        //            //                        }
                        //            /*ignorar espacios*/
                        //            else if (c == ' ')
                        //            {
                        //                estado = 0;
                        //            }
                        //            /*ignorar*/
                        //            else if (c == '\n')
                        //            {
                        //                columna = 0;
                        //                fila++;
                        //                estado = 0;
                        //            }
                        else if (c == '{')
                        {
                            lexema += c;

                            addToken(lexema, "llaveIzq", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "llaveDer", fila, columna - lexema.Length);
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
                            addToken(lexema, "SeparRango", fila, columna - lexema.Length);
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
                            addToken(lexema, "DosPuntos", fila, columna - lexema.Length);
                            lexema = "";
                        }

                        /*expresiones regulares*/
                        else if (c == '.')
                        {
                            lexema += c;
                            addToken(lexema, "Conca_por", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '|')
                        {
                            lexema += c;
                            addToken(lexema, "Disyun_mas", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '?')
                        {
                            lexema += c;
                            addToken(lexema, "0oUnavez", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "0oMasvez", fila, columna - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "1oMasvez", fila, columna - lexema.Length);
                            lexema = "";
                        }


                        ///////////////////////////////////////////////////////////
                        /*fin operadors mat*/
                        else
                        {
                            //addError(c.ToString() , "Desconocido", fila, columna);
                            estado = -99;
                            i--;
                            columna--;
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
                            //boolean encontrado = false;
                            //encontrado = Macht_enReser(lexema);
                            //if (encontrado)
                            //{
                            //    addToken(lexema, "Reservada", fila, columna - lexema.Length);
                            //}
                            //else
                            //{
                                addToken(lexema, "Identificador", fila, columna - lexema.Length);

                            //}

                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;

                        }
                        break;
                    //        case 2:
                    //            if (Character.isDigit(c))
                    //            {
                    //                lexema += c;
                    //                estado = 2;
                    //            }
                    //            //                        /*nuevo*/
                    //            //                        else if (c == '.')
                    //            //                        {
                    //            //                            estado = 8;
                    //            //                            lexema += c;
                    //            //                        }
                    //            //                        /*nuevo fin*/
                    //            else
                    //            {
                    //                ////token = new Token(3, "Numero", lexema, fila, columna);
                    //                ////tokens.add(token);
                    //                //addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                    //                addToken(lexema, "Digito", fila, columna - lexema.length());
                    //                lexema = "";
                    //                i--;
                    //                columna--;
                    //                estado = 0;
                    //            }
                    //            break;                    
                    /*inicio de comentario 1 liena*/
                    case 4:
                        if (c == '/')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    //        case 5:
                    //            if (c == '/')
                    //            {
                    //                lexema += c;
                    //                estado = 6;
                    //            }
                    //            else
                    //            {
                    //                //psts que sea comentario tiene que ser 2
                    //                i--;
                    //                columna--;
                    //                estado = -99;
                    //            }
                    //            break;
                    //        case 6:
                    //            if (c != '\n')
                    //            {
                    //                lexema += c;
                    //                estado = 6;
                    //            }
                    //            else
                    //            {
                    //                lexema += c;
                    //                //////////////////////////                            addToken(lexema, "1LinComen", fila, columna - lexema.length());
                    //                estado = 0;
                    //                lexema = "";
                    //            }
                    //            break;
                    //        //////////////////////////////////////////    
                    //        /*fin  de comentario 1 liena*/
                    //        ////////////////////////////////////////
                    //        case 7:
                    //            if (c == '<')
                    //            {
                    //                lexema += c;
                    //                estado = 8;
                    //            }
                    //            break;
                    //        case 8:
                    //            if (c == '!')
                    //            {
                    //                lexema += c;
                    //                estado = 9;
                    //            }
                    //            break;
                    //        case 9:
                    //            if (c != '!')
                    //            {
                    //                lexema += c;
                    //                estado = 9;
                    //            }
                    //            else if (c == '!')
                    //            {
                    //                lexema += c;
                    //                estado = 10;
                    //            }
                    //            break;
                    //        case 10:
                    //            if (c != '>')
                    //            {
                    //                lexema += c;
                    //                estado = 9;
                    //            }
                    //            else if (c == '>')
                    //            {
                    //                lexema += c;
                    //                ////////////////////////                            addToken(lexema, "MultiComen", fila, columna - lexema.length());
                    //                estado = 0;
                    //                lexema = "";
                    //            }
                    //            break;
                    //        /*fin comentario multilinea*/
                    //        ////////////////////////////////////
                    //        /*igualdad*/
                    //        case 11:
                    //            if (c == '-')
                    //            {
                    //                lexema += c;
                    //                estado = 12;
                    //            }
                    //            break;
                    //        case 12:
                    //            if (c == '>')
                    //            {
                    //                lexema += c;
                    //                addToken(lexema, "Igualdad", fila, columna - lexema.length());
                    //                estado = 0;
                    //                lexema = "";
                    //                String a;
                    //            }
                    //            break;
                    //        ////////para la cadena , estado 13
                    //        case 13:
                    //            if (c == '"')
                    //            {
                    //                lexema += c;
                    //                estado = 14;
                    //            }
                    //            break;
                    //        case 14:
                    //            if (c != '"')
                    //            {
                    //                lexema += c;
                    //                estado = 14;
                    //            }
                    //            else
                    //            {
                    //                estado = 15;
                    //                i--;
                    //                columna--;
                    //            }
                    //            break;
                    //        case 15:
                    //            if (c == '"')
                    //            {
                    //                lexema += c;
                    //                addToken(lexema, "Cadena", fila, columna - lexema.length());
                    //                estado = 0;
                    //                lexema = "";
                    //            }

                    //            break;

                    //        /*fin cadena de caracteres*/

                    //        /*delimitador*/
                    //        /*inicio de comentario 1 liena*/
                    //        case 16:
                    //            if (c == '%')
                    //            {
                    //                lexema += c;
                    //                estado = 17;
                    //            }
                    //            break;
                    //        case 17:
                    //            if (c != '\n')
                    //            {
                    //                lexema += c;
                    //                addToken(lexema, "Delimitador", fila, columna - lexema.length());
                    //                estado = 0;
                    //                lexema = "";
                    //            }
                    //            else
                    //            {
                    //                ///errorr
                    //            }
                    //            break;


                    case -99:
                        lexema += c;
                        ////System.out.println("error lexico ("  + ")" );
                        ////JOptionPane.showMessageDialog(null, c );
                        ////JOptionPane.showMessageDialog(null, lexema + " Carácter Desconocido, fil:" + fila + ", col: " + (columna - lexema.length()));
                        ////System.out.println("error lexico (" + lexema + ")" );
                        ////                        Errores err = new Errores("error lexico (" + lexema + ")" );
                        ////                        Practica1_comp1.list_err.add(err);
                        //list_err.add("error lexico (" + lexema + ")");

                        addError(lexema, "Carácter Desconocido", fila, columna - lexema.Length);
                        estado = 0;
                        lexema = "";
                        break;
                }
            } ///fin for

        }
    }
}