namespace Proyecto1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_analizar = new System.Windows.Forms.Button();
            this.tb_texto = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erroresPDFerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button1 = new System.Windows.Forms.Button();
            this.b_graficar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dtable = new System.Windows.Forms.DataGridView();
            this.probartab = new System.Windows.Forms.Button();
            this.cb_expresiones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.beva_lex = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tconjun = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tconjun)).BeginInit();
            this.SuspendLayout();
            // 
            // b_analizar
            // 
            this.b_analizar.Location = new System.Drawing.Point(33, 374);
            this.b_analizar.Name = "b_analizar";
            this.b_analizar.Size = new System.Drawing.Size(82, 32);
            this.b_analizar.TabIndex = 0;
            this.b_analizar.Text = "Analizar";
            this.b_analizar.UseVisualStyleBackColor = true;
            this.b_analizar.Click += new System.EventHandler(this.b_analizar_Click);
            // 
            // tb_texto
            // 
            this.tb_texto.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tb_texto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_texto.ForeColor = System.Drawing.Color.Lime;
            this.tb_texto.Location = new System.Drawing.Point(262, 382);
            this.tb_texto.Name = "tb_texto";
            this.tb_texto.Size = new System.Drawing.Size(491, 149);
            this.tb_texto.TabIndex = 1;
            this.tb_texto.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1325, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(188, 26);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erroresPDFerToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(80, 24);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // erroresPDFerToolStripMenuItem
            // 
            this.erroresPDFerToolStripMenuItem.Name = "erroresPDFerToolStripMenuItem";
            this.erroresPDFerToolStripMenuItem.Size = new System.Drawing.Size(190, 26);
            this.erroresPDFerToolStripMenuItem.Text = "Errores PDF (.er)";
            this.erroresPDFerToolStripMenuItem.Click += new System.EventHandler(this.erroresPDFerToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(33, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(720, 340);
            this.tabControl1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1238, 475);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_graficar
            // 
            this.b_graficar.Location = new System.Drawing.Point(121, 374);
            this.b_graficar.Name = "b_graficar";
            this.b_graficar.Size = new System.Drawing.Size(121, 32);
            this.b_graficar.TabIndex = 5;
            this.b_graficar.Text = "Cargar ER";
            this.b_graficar.UseVisualStyleBackColor = true;
            this.b_graficar.Click += new System.EventHandler(this.b_graficar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1206, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "probar enlace";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1219, 475);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "pruba igual listado";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1219, 475);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "comp list nod";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dtable
            // 
            this.dtable.AllowUserToAddRows = false;
            this.dtable.AllowUserToDeleteRows = false;
            this.dtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtable.Location = new System.Drawing.Point(759, 66);
            this.dtable.Name = "dtable";
            this.dtable.ReadOnly = true;
            this.dtable.RowTemplate.Height = 24;
            this.dtable.Size = new System.Drawing.Size(539, 302);
            this.dtable.TabIndex = 9;
            // 
            // probartab
            // 
            this.probartab.Location = new System.Drawing.Point(1238, 475);
            this.probartab.Name = "probartab";
            this.probartab.Size = new System.Drawing.Size(75, 23);
            this.probartab.TabIndex = 10;
            this.probartab.Text = "probar table";
            this.probartab.UseVisualStyleBackColor = true;
            this.probartab.Visible = false;
            this.probartab.Click += new System.EventHandler(this.probartab_Click);
            // 
            // cb_expresiones
            // 
            this.cb_expresiones.FormattingEnabled = true;
            this.cb_expresiones.Location = new System.Drawing.Point(930, 28);
            this.cb_expresiones.Name = "cb_expresiones";
            this.cb_expresiones.Size = new System.Drawing.Size(368, 24);
            this.cb_expresiones.TabIndex = 11;
            this.cb_expresiones.SelectedIndexChanged += new System.EventHandler(this.cb_expresiones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(759, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Expresiones Regulares:";
            // 
            // beva_lex
            // 
            this.beva_lex.Location = new System.Drawing.Point(33, 412);
            this.beva_lex.Name = "beva_lex";
            this.beva_lex.Size = new System.Drawing.Size(209, 32);
            this.beva_lex.TabIndex = 13;
            this.beva_lex.Text = "Evaluar Lexemas";
            this.beva_lex.UseVisualStyleBackColor = true;
            this.beva_lex.Click += new System.EventHandler(this.beva_lex_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(759, 382);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Conjuntos";
            // 
            // tconjun
            // 
            this.tconjun.AllowUserToAddRows = false;
            this.tconjun.AllowUserToDeleteRows = false;
            this.tconjun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tconjun.Location = new System.Drawing.Point(836, 382);
            this.tconjun.Name = "tconjun";
            this.tconjun.ReadOnly = true;
            this.tconjun.RowTemplate.Height = 24;
            this.tconjun.Size = new System.Drawing.Size(364, 149);
            this.tconjun.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 543);
            this.Controls.Add(this.tconjun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.beva_lex);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_expresiones);
            this.Controls.Add(this.probartab);
            this.Controls.Add(this.dtable);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.b_graficar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tb_texto);
            this.Controls.Add(this.b_analizar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tconjun)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_analizar;
        private System.Windows.Forms.RichTextBox tb_texto;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erroresPDFerToolStripMenuItem;
        private System.Windows.Forms.Button b_graficar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dtable;
        private System.Windows.Forms.Button probartab;
        private System.Windows.Forms.ComboBox cb_expresiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button beva_lex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tconjun;
    }
}

