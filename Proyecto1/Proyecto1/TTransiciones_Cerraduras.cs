using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class TTransiciones_Cerraduras
    {
        public String name_estado;
        public List<String> cerradura;
        public String Estado;
        public String tipo_estado;

        public List<tran_a_estados> ir_a;

        public TTransiciones_Cerraduras(String name_estado, List<String> cerradura, String Estado, String tipo_estado, List<tran_a_estados> ir_a)
        {

            this.name_estado = name_estado;
            this.cerradura = cerradura;
            this.tipo_estado = tipo_estado;
            this.Estado = Estado;

            this.ir_a = ir_a;
        }
    }
}
