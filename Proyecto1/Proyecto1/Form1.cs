using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Form1 : Form
    {
        List<rutas> rutas_ar;

        List<Errores> lis_erores;

        /*para variables de conjuntos*/
        List<Variables> lis_var;
        /*para variables de expresiones regulares*/
        List<VarExpReg> lis_ex_reg;
        /*para evaluar las expresiones regulares*/
        List<Exp_a_Evaluar> lis_evaluar_expre;

        public Form1()
        {
            InitializeComponent();
            rutas_ar = new List<rutas>();

            lis_erores = new List<Errores>();

            /*inicializando lista de variables de conjuntos*/
            lis_var = new List<Variables>();
            /*inicializando lista de expresiones regulares*/
            lis_ex_reg = new List<VarExpReg>();
            /*inicializando evaluar las expresiones regulares*/
            lis_evaluar_expre = new List<Exp_a_Evaluar>();


        }

        private void b_analizar_Click(object sender, EventArgs e)
        {

            TabPage tab_actual = tabControl1.SelectedTab;
            String texto = tab_actual.Controls[0].Text;
            //MessageBox.Show(texto, "texto");
            //String texto = tb_texto.Text;  

            Lexico analisis_lex = new Lexico();
            analisis_lex.Analizador_cadena(texto);

            analisis_lex.ImprimeTokens();

            analisis_lex.ImprimeErrores();
            lis_erores = analisis_lex.getErroresLex();

            Sintactico sin = new Sintactico();
            sin.Parsear(analisis_lex.lis_tokens);

            lis_ex_reg = sin.getLista_ExpRegulares();
            lis_var = sin.getLista_Conjuntos();
            lis_evaluar_expre = sin.getLista_Evaluar();

            MessageBox.Show("Terminó el Analisis", "Analisis");

        }

        //public String AbrirArhivo(File archivo)
        public String AbrirArhivo(OpenFileDialog openFile)
        {
            String document = "";

            string texto = "";
            string fila = "";

            string ruta1 = openFile.FileName;
            StreamReader streamReader = new StreamReader(ruta1, System.Text.Encoding.UTF8);
            //string nombreC = Path.GetFileNameWithoutExtension(openFile.FileName);
            string nombreC = Path.GetFileName(openFile.FileName);
            //MessageBox.Show(nombreC, "2 nombreC");
            //MessageBox.Show(ruta1, "2 ruta1");

            while ((fila = streamReader.ReadLine()) != null)
            {
                texto += fila + System.Environment.NewLine;
            }
            document = texto;
            streamReader.Close();


            //rutas.Clear();
            //Rutas path = new Rutas(ruta1, nombreC);
            //rutas.Add(path);

            ////MessageBox.Show(rutas.Count.ToString() , "rutas.Count");
            //Path_actual = ruta1;
            //nombre_acual = nombreC;
            //this.Text = nombre_acual;

            return document;
        }
        public String AbrirArhivo_back()
        {
            String document = "";

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "[Proyecto1]ER|*.er";
            string texto = "";
            string fila = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string ruta1 = openFile.FileName;
                StreamReader streamReader = new StreamReader(ruta1, System.Text.Encoding.UTF8);
                //string nombreC = Path.GetFileNameWithoutExtension(openFile.FileName);
                string nombreC = Path.GetFileName(openFile.FileName);
                MessageBox.Show(nombreC, "nombreC");
                MessageBox.Show(ruta1, "ruta1");

                while ((fila = streamReader.ReadLine()) != null)
                {
                    texto += fila + System.Environment.NewLine;
                }
                tb_texto.Text = texto;
                streamReader.Close();


                //rutas.Clear();
                //Rutas path = new Rutas(ruta1, nombreC);
                //rutas.Add(path);

                ////MessageBox.Show(rutas.Count.ToString() , "rutas.Count");
                //Path_actual = ruta1;
                //nombre_acual = nombreC;
                //this.Text = nombre_acual;

            }

            //try
            //{
            //    entrada = new FileInputStream(archivo);
            //    int ascci;
            //    while ((ascci = entrada.read()) != -1)
            //    {
            //        char letr = (char)ascci;
            //        document = document + letr;

            //    }

            //}
            //catch (Exception e)
            //{
            //    JOptionPane.showMessageDialog(null, e.getMessage());
            //}
            return document;
        }
        public void InsertaPesta(String contenido, String name, String ruta1)
        {
            int indi_pag;

            RichTextBox editor = new RichTextBox();
            //editor.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            //editor.SelectionColor = System.Drawing.Color.Red;
            editor.Text = contenido;



            TabPage newtab = new TabPage(name); // Creamos una nueva pestaña
            //tabControl1.Controls.Add(editor);
            //indi_pag = jTabbedPane1.getTabCount() - 1;
            //Panel pal = new Panel();
            editor.Width = tabControl1.Width - 5;
            editor.Height = tabControl1.Height - 10;

            //MessageBox.Show(editor.Font.Size.ToString());
            //pal.Controls.Add(editor);


            newtab.Controls.Add(editor);
            tabControl1.TabPages.Add(newtab); //cargamos la pestaña en el control




            tabControl1.SelectedTab = newtab;
            rutas_ar.Add(new rutas(ruta1, name, tabControl1.TabCount - 1));

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Boolean ya = false;
            //archivo = dialog.getSelectedFile();
            //if (archivo.canRead())
            //{
            /*verificando si ya tiene abierto el arhicvo*/
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "[Proyecto1]ER|*.er";
            string texto = "";
            string fila = "";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string ruta1 = openFile.FileName;
                string nombreC = Path.GetFileName(openFile.FileName);

                for (int i = 0; i < rutas_ar.Count; i++)
                {

                    //JOptionPane.showMessageDialog(null,  "ruta **: " + rutas_ar.get(i).getArhivo() );
                    if (ruta1.Equals(rutas_ar.ElementAt(i).ruta_in))
                    {
                        MessageBox.Show("El documento " + nombreC + " ya esta abierto", "Archivo");
                        ya = true;
                    }
                }
                /*fin*/

                if (ya == false)
                {
                    //    string ruta1 = openFile.FileName;
                    //    string nombreC = Path.GetFileName(openFile.FileName);
                    //MessageBox.Show(nombreC, "1 nombreC");
                    //MessageBox.Show(ruta1, "1 ruta1");
                    String contenido = AbrirArhivo(openFile);
                    InsertaPesta(contenido, nombreC, ruta1);
                }

            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            tb_texto.SelectionFont = new System.Drawing.Font("Microsoft Sans Serif", 25, FontStyle.Bold);
            tb_texto.SelectionColor = System.Drawing.Color.Red;

            ////TabPage current_tab = tabControl1.SelectedTab;
            //TabPage tab_actual = tabControl1.SelectedTab;

            //MessageBox.Show(tab_actual.Controls[0].Text, "tab_actual");

            ////String tex = tab_actual.Contains.ToString();
            ////String texto = tb_texto.Text;

            //////MessageBox.Show(tex, "tex");
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int indice_actual;
            //indice_actual = jTabbedPane1.getSelectedIndex();
            if (rutas_ar.Count <= 0)
            {
                MessageBox.Show("Hoy hay ningun archivo", "Guardar");
            }
            else
            {
                //JOptionPane.showMessageDialog(null, rutas_ar.get(indice_actual).getArhivo());
                int ind = tabControl1.SelectedIndex;
                //MessageBox.Show(rutas_ar.ElementAt(ind).ruta_in, "Guardar");

                String ruta;
                ruta = rutas_ar.ElementAt(ind).ruta_in;

                GuardarAhora(ruta);


            }


        }

        public void GuardarAhora(String archivo_g)
        {


            TabPage tab_actual = tabControl1.SelectedTab;
            String doc = tab_actual.Controls[0].Text;


            Boolean pasa = GuardarArchivo(archivo_g, doc);

            if (pasa == false)
            {
                MessageBox.Show("error al guardar achivo");
            }
            MessageBox.Show("archivo guardado");


        }

        public Boolean GuardarArchivo(String arhivo, String documento)
        {
            Boolean pasa = true;
            try
            {
                string text = documento;
                StreamWriter writer = new StreamWriter(arhivo);
                writer.Write(text);
                writer.Flush();
                writer.Close();

                string nombre = Path.GetFileNameWithoutExtension(arhivo);
            }
            catch (Exception ex)
            {
                pasa = false;
                Console.WriteLine(ex.Message);
            }
            return pasa;
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rutas_ar.Count <= 0)
            {
                MessageBox.Show("Hoy hay ningun archivo", "Guardar como...");
            }
            else
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "[Proyecto1]ER|*.er";
                saveFile.Title = "Guardar archivo";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = (FileStream)saveFile.OpenFile();
                    fs.Close();
                    string path = saveFile.FileName;
                    //guardar(path);
                    GuardarAhora(path);
                    //string nombre = Path.GetFileNameWithoutExtension(path);
                    //Rutas path_r = new Rutas(path, nombre);
                    //rutas.Add(path_r);

                }


            }


        }

        private void erroresPDFerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreandoPdf();
        }

        public void CreandoPdf()
        {
            //FileStream stream = new FileStream("EorresLex.pdf", FileMode.Create);

            using (FileStream stream = new FileStream("EorresLex.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                ////
                pdfDoc.Add(new Paragraph("Reporte de Errores \n\n"));

                PdfPTable tabla_er = new PdfPTable(4);
                tabla_er.WidthPercentage = 60;
                tabla_er.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
                tabla_er.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
                tabla_er.DefaultCell.BorderWidth = 1;

                tabla_er.AddCell(new Paragraph("Lexema"));
                tabla_er.AddCell(new Paragraph("Descripción"));
                tabla_er.AddCell(new Paragraph("linea"));
                tabla_er.AddCell(new Paragraph("Columna"));

                foreach (Errores err in lis_erores)
                {
                    tabla_er.AddCell(new Paragraph(err.lexema));
                    tabla_er.AddCell(new Paragraph(err.idToken));
                    tabla_er.AddCell(new Paragraph(err.linea.ToString()));
                    tabla_er.AddCell(new Paragraph(err.columna.ToString()));
                }

                pdfDoc.Add(tabla_er);

                pdfDoc.Close();
                stream.Close();
            }

            System.Diagnostics.Process.Start("EorresLex.pdf");
        }

        private void b_graficar_Click(object sender, EventArgs e)
        {
            //if (err_lex.size() == 0 && err_sin.size() == 0)
            if (lis_erores.Count == 0)
            {
                Crea_AFN_AFD_ER();
            }
            else
            {
                MessageBox.Show("Corriga errores para graficar", "err");
            }

        }

        public void Crea_AFN_AFD_ER()
        {
            ///*probando armando el arbol*/
            //LinkedList<ListadoArboles> lis_arnew = new LinkedList<>();
            //lis_arbol_expre = lis_arnew;
            for (int i = 0; i < lis_ex_reg.Count; ++i)
            {
                MessageBox.Show( lis_ex_reg.ElementAt(i).name_exreg /*+ " - "
                        +lis_ex_reg.get(i).prefijo*/);
                ///
                List<ER_unitario> pref_er = new List<ER_unitario>();
                pref_er = lis_ex_reg.ElementAt(i).prefijo;


                /////creando arbol
                Armando_RPN arbol = new Armando_RPN(pref_er);
                //NodeArbol root_exp;
                //root_exp = arbol.leyendo_expresiones();

                /////JOptionPane.showMessageDialog(null,"res arbol: " + root);


                //    ///////////////////inicioa graficas
                //    //Arbol tree = new Arbol(root_exp);
                //    Arbol tree = new Arbol(root_exp, lis_ex_reg.get(i).name_exreg);

                //    tree.preOrder();

                //    tree.posOrder();
                //    tree.Graficando_arbol();
                //    //JOptionPane.showMessageDialog(null,"recor _pos ");

                //    tree.posOrder_sig();
                //    tree.graficando_siguientes();

                //    ////transiciones
                //    //tree.TabTransiciones();
                //    tree.Create_TabTransiciones();
                //    tree.graficando_Automata();

                //    ListadoArboles ar = new ListadoArboles(lis_ex_reg.get(i).name_exreg, tree);
                //    lis_arbol_expre.add(ar);
                //    //            
                //    //////////           tree.EvaluandoLexema_final(lis_evaluar_expre.get(0).cadena_eva, lis_var);
                //    //            
                //    //            ////////////////fin graficas

            }
            //lis_ar();
            //JOptionPane.showMessageDialog(null, "Termino de graficar");

        }
        //////
    }
}
