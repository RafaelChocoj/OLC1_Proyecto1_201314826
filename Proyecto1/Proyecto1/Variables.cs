﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Variables
    {

        String name_var;
        List<String> valores;
        String tipo; // C = conjunto, R = rango


        public Variables(String name_var, List<String> valores, String tipo)
        {
            this.name_var = name_var;
            this.valores = valores;
            this.tipo = tipo;
        }

    }
}
