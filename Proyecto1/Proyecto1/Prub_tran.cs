using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class Prub_tran
    {
        //public String transicion;
        //public String tipo;
        //public Prub_tran(String transicion, String tipo)
        //{
        //    this.transicion = transicion;
        //    this.tipo = tipo;
        //}

        public String transicion { get; set; }
        public String tipo { get; set; }

        public List<String> ir_a { get; set; }

        public String saber { get; set; }
    }
}
