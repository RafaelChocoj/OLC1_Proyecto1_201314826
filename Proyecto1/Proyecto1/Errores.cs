﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Errores
    {

        public String lexema;
        public String idToken;
        public int linea;
        public int columna;
        public String Tipo;

        public Errores(String lexema, String idToken, int linea, int columna, String Tipo)
        {
            this.lexema = lexema;
            this.idToken = idToken;
            this.linea = linea;
            this.columna = columna;
            this.Tipo = Tipo;
        }
    }
}