using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class VarExpReg
    {

        public String name_exreg;
        public List<ER_unitario> prefijo;

        public VarExpReg(String name_exreg, List<ER_unitario> prefijo)
        {
            this.name_exreg = name_exreg;
            this.prefijo = prefijo;
        }
    }
}
