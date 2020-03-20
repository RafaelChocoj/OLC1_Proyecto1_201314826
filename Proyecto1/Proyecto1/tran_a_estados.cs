using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class tran_a_estados
    {
        public String terminal;
        public String Ir_a_Estado;
        public String Tipo_ter;

        public tran_a_estados(String terminal, String Ir_a_Estado, String Tipo_ter)
        {

            this.terminal = terminal;
            this.Ir_a_Estado = Ir_a_Estado;

            this.Tipo_ter = Tipo_ter;
        }
    }
}
