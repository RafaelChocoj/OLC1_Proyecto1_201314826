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
        public Form1()
        {
            InitializeComponent();
        }

        private void b_analizar_Click(object sender, EventArgs e)
        {

            String texto = tb_texto.Text;  

            Lexico analisis_lex = new Lexico();
            analisis_lex.Analizador_cadena(texto);

            analisis_lex.ImprimeTokens();
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
                MessageBox.Show(nombreC, "2 nombreC");
                MessageBox.Show(ruta1, "2 ruta1");

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
        public void InsertaPesta(String contenido, String name)
        {
            int indi_pag;
            //jspan = new JScrollPane();

            //JTextArea editor = new JTextArea();
            RichTextBox editor = new RichTextBox();
            //editor.setColumns(20);
            //editor.setRows(5);
            //editor.setText(contenido);
            editor.Text = contenido;
            //jspan.setViewportView(editor);



            //jTabbedPane1.addTab("Archivo " + (jTabbedPane1.getTabCount() + 1) + " (" + name + ")", jspan);

            TabPage newtab = new TabPage(name); // Creamos una nueva pestaña
            //tabControl1.Controls.Add(editor);
            //indi_pag = jTabbedPane1.getTabCount() - 1;
            //Panel pal = new Panel();
            editor.Width = tabControl1.Width -5;
            editor.Height = tabControl1.Height-10;
            //pal.Controls.Add(editor);
            

            newtab.Controls.Add(editor);
            tabControl1.TabPages.Add(newtab); //cargamos la pestaña en el control

            //JOptionPane.showMessageDialog(null, indi_pag);
            //jTabbedPane1.setSelectedIndex(indi_pag);
            tabControl1.SelectedTab = newtab;
            //rutas_ar.add(new rutas(indi_pag, archivo, name));

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Boolean ya = false;
            //archivo = dialog.getSelectedFile();
            //if (archivo.canRead())
            //{
            //    /*verificando si ya tiene abierto el arhicvo*/
            //    for (int i = 0; i < rutas_ar.size(); i++)
            //    {

            //        //JOptionPane.showMessageDialog(null,  "ruta **: " + rutas_ar.get(i).getArhivo() );
            //        if (archivo.equals(rutas_ar.get(i).getArhivo()))
            //        {
            //            JOptionPane.showMessageDialog(null, "El documento " + archivo.getName() + " ya esta abierto");
            //            ya = true;
            //        }
            //    }
            //    /*fin*/

                if (ya == false)
                {

                //    if (archivo.getName().endsWith("dat") || archivo.getName().endsWith("rep"))
                //    {
                //        //JOptionPane.showMessageDialog(null,  archivo.getName() );
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "[Proyecto1]ER|*.er";
                string texto = "";
                string fila = "";
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string ruta1 = openFile.FileName;
                    //StreamReader streamReader = new StreamReader(ruta1, System.Text.Encoding.UTF8);
                    //string nombreC = Path.GetFileNameWithoutExtension(openFile.FileName);
                    string nombreC = Path.GetFileName(openFile.FileName);
                    //MessageBox.Show(nombreC, "1 nombreC");
                    //MessageBox.Show(ruta1, "1 ruta1");
                    String contenido = AbrirArhivo(openFile);

                    //InsertaPesta(contenido, archivo.getName());
                    InsertaPesta(contenido, nombreC);
                }
                    //String contenido = AbrirArhivo(archivo);
                    //String contenido = AbrirArhivo();
                    //        //jeditor.setText(contenido);
                    //        InsertaPesta(contenido, archivo.getName());

                    //        //errores.add(new Error(token.getLexema(), "Error Sintáctico", "Se esperaba el simbolo '[' y se encontró "
                    //        //            + token.getLexema(), token.getFila(), token.getColumna()));
                    //    }
                    //}
                }
            //else
            //{
            //    MessageBox.Show("No puede abrir archivo", " Abrir");
            //}

        }
    
    }
}
