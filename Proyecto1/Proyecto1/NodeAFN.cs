using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto1
{
    class NodeAFN
    {

        public String lexema;
        public int id;

        /*si solo es uno se usara solo el left*/
        public NodeAFN left;
        public NodeAFN right;
        public String Tran_left;
        public String Tran_right;

        public Tipo.TipoN Tran_left_Tipo;
        public Tipo.TipoN Tran_right_Tipo;

        public Tipo.TipoN tipo_n;

        public NodeAFN ultimo_ref;

        public String tipo;

        public int height;

        public Boolean visitado;
        public String nod_visitado;

        public NodeAFN tempo_copy;

        //public NodeAFN(String lexema, int id, String Anulable, int identificador, String primeros, String ultimos, String tipo)
        public NodeAFN(String lexema, int id, String tipo, Tipo.TipoN tipo_n)
        {
            this.id = id;
            this.lexema = lexema;
            this.left = null;
            this.right = null;

            this.Tran_left = null;
            this.Tran_right = null;

            this.ultimo_ref = null;

            this.visitado = false;
            this.nod_visitado = "N";

            this.tempo_copy = null;

            //this.Anulable = Anulable;
            //this.identificador = identificador;
            //this.primeros = primeros;
            //this.ultimos = ultimos;

            this.tipo = tipo;
            this.tipo_n = tipo_n;

            this.Tran_left_Tipo = Tipo.TipoN.NULL;
            this.Tran_right_Tipo = Tipo.TipoN.NULL;

            this.height = 1;
        }

    }
}
