using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    class NodeAFN
    {

        String lexema;
        int id;
        NodeAFN left;
        NodeAFN right;
        String Tran_left;
        String Tran_right;
        Tipo tipo;

        //String Anulable;
        //int identificador;
        //String primeros;
        //String ultimos;

        //String tipo;

        int height;


        //public NodeAFN(String lexema, int id, String Anulable, int identificador, String primeros, String ultimos, String tipo)
        public NodeAFN(String lexema, int id, Tipo tipo)
        {
            this.id = id;
            this.lexema = lexema;
            this.left = null;
            this.right = null;

            this.Tran_left = null;
            this.Tran_right = null;

            //this.Anulable = Anulable;
            //this.identificador = identificador;
            //this.primeros = primeros;
            //this.ultimos = ultimos;

            this.tipo = tipo;

            this.height = 1;
        }

    }
}
