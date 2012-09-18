using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPV
{
	/// <summary>
	/// Summary description for ArticulosForm.
	/// </summary>
	public class ArticulosForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonGrabar;
        private System.Windows.Forms.Button botonNuevo;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button botonImage;
        private System.Windows.Forms.TextBox tbox_Image;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_Desc;
        private System.Windows.Forms.TextBox tbox_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbox_Cod;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox combo_Familia;
        private System.Windows.Forms.CheckBox check_MostrarVentas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox combo_Iva;
        private System.Windows.Forms.OpenFileDialog imageFileDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbox_CostoS;
        private System.Windows.Forms.TextBox tbox_CostoC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbox_PvpC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbox_PvpS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbox_Margen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox tbox_StockInicial;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbox_Existencias;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbox_StockMinimo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbox_ValorVenta;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbox_ValorCosto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGrid dataGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ArticulosForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            combo_Familia.DataSource = GestorFamilias.DataTable;
            combo_Familia.ValueMember = "Codigo" ;
            combo_Familia.DisplayMember = "Nombre" ;

            combo_Iva.DataSource = GestorIvas.DataTable ;
            combo_Iva.ValueMember = "Codigo" ;
            combo_Iva.DisplayMember = "Porcentaje" ;

            GestorFamilias.Load();

            botonNuevo.Enabled = true ;
            botonGrabar.Enabled = false ;
            botonSalir.Enabled = true ;
            panelEdicion.Enabled = false ;

            dataGrid.SetDataBinding(GestorArticulos.GetDataTable(), null);
            GestorArticulos.Load();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonGrabar = new System.Windows.Forms.Button();
            this.botonNuevo = new System.Windows.Forms.Button();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.tbox_ValorVenta = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbox_ValorCosto = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbox_StockMinimo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbox_StockInicial = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbox_Existencias = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tbox_Margen = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbox_PvpC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbox_PvpS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbox_CostoC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbox_CostoS = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_Iva = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.check_MostrarVentas = new System.Windows.Forms.CheckBox();
            this.combo_Familia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.botonImage = new System.Windows.Forms.Button();
            this.tbox_Image = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_Desc = new System.Windows.Forms.TextBox();
            this.tbox_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbox_Cod = new System.Windows.Forms.TextBox();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.panelEdicion.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(944, 648);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(64, 64);
            this.botonSalir.TabIndex = 2;
            this.botonSalir.Text = "SALIR";
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // botonGrabar
            // 
            this.botonGrabar.Enabled = false;
            this.botonGrabar.Location = new System.Drawing.Point(80, 8);
            this.botonGrabar.Name = "botonGrabar";
            this.botonGrabar.Size = new System.Drawing.Size(64, 64);
            this.botonGrabar.TabIndex = 7;
            this.botonGrabar.Text = "GRABAR";
            this.botonGrabar.Click += new System.EventHandler(this.botonGrabar_Click);
            // 
            // botonNuevo
            // 
            this.botonNuevo.Location = new System.Drawing.Point(8, 8);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(64, 64);
            this.botonNuevo.TabIndex = 6;
            this.botonNuevo.Text = "NUEVO";
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // panelEdicion
            // 
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdicion.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                       this.tbox_ValorVenta,
                                                                                       this.label15,
                                                                                       this.tbox_ValorCosto,
                                                                                       this.label16,
                                                                                       this.tbox_StockMinimo,
                                                                                       this.label14,
                                                                                       this.tbox_StockInicial,
                                                                                       this.label12,
                                                                                       this.tbox_Existencias,
                                                                                       this.label13,
                                                                                       this.panel3,
                                                                                       this.tbox_Margen,
                                                                                       this.label11,
                                                                                       this.tbox_PvpC,
                                                                                       this.label9,
                                                                                       this.tbox_PvpS,
                                                                                       this.label10,
                                                                                       this.tbox_CostoC,
                                                                                       this.label8,
                                                                                       this.tbox_CostoS,
                                                                                       this.label7,
                                                                                       this.label6,
                                                                                       this.combo_Iva,
                                                                                       this.panel1,
                                                                                       this.check_MostrarVentas,
                                                                                       this.combo_Familia,
                                                                                       this.label5,
                                                                                       this.pictureBox,
                                                                                       this.botonImage,
                                                                                       this.tbox_Image,
                                                                                       this.label4,
                                                                                       this.tbox_Desc,
                                                                                       this.tbox_Name,
                                                                                       this.label3,
                                                                                       this.label2,
                                                                                       this.label1,
                                                                                       this.tbox_Cod});
            this.panelEdicion.Location = new System.Drawing.Point(8, 80);
            this.panelEdicion.Name = "panelEdicion";
            this.panelEdicion.Size = new System.Drawing.Size(1000, 336);
            this.panelEdicion.TabIndex = 8;
            // 
            // tbox_ValorVenta
            // 
            this.tbox_ValorVenta.Location = new System.Drawing.Point(480, 296);
            this.tbox_ValorVenta.Name = "tbox_ValorVenta";
            this.tbox_ValorVenta.ReadOnly = true;
            this.tbox_ValorVenta.Size = new System.Drawing.Size(80, 20);
            this.tbox_ValorVenta.TabIndex = 48;
            this.tbox_ValorVenta.Text = "";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(400, 296);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 23);
            this.label15.TabIndex = 47;
            this.label15.Text = "Valor Venta";
            // 
            // tbox_ValorCosto
            // 
            this.tbox_ValorCosto.Location = new System.Drawing.Point(304, 296);
            this.tbox_ValorCosto.Name = "tbox_ValorCosto";
            this.tbox_ValorCosto.ReadOnly = true;
            this.tbox_ValorCosto.Size = new System.Drawing.Size(80, 20);
            this.tbox_ValorCosto.TabIndex = 46;
            this.tbox_ValorCosto.Text = "";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(232, 296);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(80, 23);
            this.label16.TabIndex = 45;
            this.label16.Text = "Valor Costo";
            // 
            // tbox_StockMinimo
            // 
            this.tbox_StockMinimo.Location = new System.Drawing.Point(480, 272);
            this.tbox_StockMinimo.Name = "tbox_StockMinimo";
            this.tbox_StockMinimo.Size = new System.Drawing.Size(80, 20);
            this.tbox_StockMinimo.TabIndex = 44;
            this.tbox_StockMinimo.Text = "";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(400, 272);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 23);
            this.label14.TabIndex = 43;
            this.label14.Text = "Stock Minimo";
            // 
            // tbox_StockInicial
            // 
            this.tbox_StockInicial.Location = new System.Drawing.Point(304, 272);
            this.tbox_StockInicial.Name = "tbox_StockInicial";
            this.tbox_StockInicial.Size = new System.Drawing.Size(80, 20);
            this.tbox_StockInicial.TabIndex = 42;
            this.tbox_StockInicial.Text = "";
            this.tbox_StockInicial.Validated += new System.EventHandler(this.tbox_StockInicial_Validated);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(232, 272);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 41;
            this.label12.Text = "Stock Inicial";
            // 
            // tbox_Existencias
            // 
            this.tbox_Existencias.Location = new System.Drawing.Point(96, 272);
            this.tbox_Existencias.Name = "tbox_Existencias";
            this.tbox_Existencias.ReadOnly = true;
            this.tbox_Existencias.Size = new System.Drawing.Size(80, 20);
            this.tbox_Existencias.TabIndex = 40;
            this.tbox_Existencias.Text = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 272);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 23);
            this.label13.TabIndex = 39;
            this.label13.Text = "Existencias";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.panel4});
            this.panel3.Location = new System.Drawing.Point(6, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 8);
            this.panel3.TabIndex = 38;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(-2, -2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(984, 8);
            this.panel4.TabIndex = 26;
            // 
            // tbox_Margen
            // 
            this.tbox_Margen.Location = new System.Drawing.Point(632, 200);
            this.tbox_Margen.Name = "tbox_Margen";
            this.tbox_Margen.Size = new System.Drawing.Size(80, 20);
            this.tbox_Margen.TabIndex = 37;
            this.tbox_Margen.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(576, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 23);
            this.label11.TabIndex = 36;
            this.label11.Text = "Margen";
            // 
            // tbox_PvpC
            // 
            this.tbox_PvpC.Location = new System.Drawing.Point(480, 224);
            this.tbox_PvpC.Name = "tbox_PvpC";
            this.tbox_PvpC.Size = new System.Drawing.Size(80, 20);
            this.tbox_PvpC.TabIndex = 35;
            this.tbox_PvpC.Text = "";
            this.tbox_PvpC.Validated += new System.EventHandler(this.tbox_PvpC_Validated);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(400, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 23);
            this.label9.TabIndex = 34;
            this.label9.Text = "PVP (con iva)";
            // 
            // tbox_PvpS
            // 
            this.tbox_PvpS.Location = new System.Drawing.Point(304, 224);
            this.tbox_PvpS.Name = "tbox_PvpS";
            this.tbox_PvpS.ReadOnly = true;
            this.tbox_PvpS.Size = new System.Drawing.Size(80, 20);
            this.tbox_PvpS.TabIndex = 33;
            this.tbox_PvpS.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(232, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 23);
            this.label10.TabIndex = 32;
            this.label10.Text = "PVP (sin iva)";
            // 
            // tbox_CostoC
            // 
            this.tbox_CostoC.Location = new System.Drawing.Point(480, 200);
            this.tbox_CostoC.Name = "tbox_CostoC";
            this.tbox_CostoC.ReadOnly = true;
            this.tbox_CostoC.Size = new System.Drawing.Size(80, 20);
            this.tbox_CostoC.TabIndex = 31;
            this.tbox_CostoC.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(400, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 30;
            this.label8.Text = "Costo (con iva)";
            // 
            // tbox_CostoS
            // 
            this.tbox_CostoS.Location = new System.Drawing.Point(304, 200);
            this.tbox_CostoS.Name = "tbox_CostoS";
            this.tbox_CostoS.Size = new System.Drawing.Size(80, 20);
            this.tbox_CostoS.TabIndex = 29;
            this.tbox_CostoS.Text = "";
            this.tbox_CostoS.Validated += new System.EventHandler(this.tbox_CostoS_Validated);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(232, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 28;
            this.label7.Text = "Costo (sin iva)";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "IVA";
            // 
            // combo_Iva
            // 
            this.combo_Iva.Location = new System.Drawing.Point(96, 200);
            this.combo_Iva.Name = "combo_Iva";
            this.combo_Iva.Size = new System.Drawing.Size(121, 21);
            this.combo_Iva.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                 this.panel2});
            this.panel1.Location = new System.Drawing.Point(8, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 8);
            this.panel1.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(-2, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 8);
            this.panel2.TabIndex = 26;
            // 
            // check_MostrarVentas
            // 
            this.check_MostrarVentas.Location = new System.Drawing.Point(704, 40);
            this.check_MostrarVentas.Name = "check_MostrarVentas";
            this.check_MostrarVentas.Size = new System.Drawing.Size(120, 24);
            this.check_MostrarVentas.TabIndex = 24;
            this.check_MostrarVentas.Text = "Mostrar en ventas";
            // 
            // combo_Familia
            // 
            this.combo_Familia.Location = new System.Drawing.Point(568, 40);
            this.combo_Familia.Name = "combo_Familia";
            this.combo_Familia.Size = new System.Drawing.Size(121, 21);
            this.combo_Familia.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(488, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Familia";
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(528, 104);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 21;
            this.pictureBox.TabStop = false;
            // 
            // botonImage
            // 
            this.botonImage.Location = new System.Drawing.Point(488, 104);
            this.botonImage.Name = "botonImage";
            this.botonImage.Size = new System.Drawing.Size(24, 24);
            this.botonImage.TabIndex = 20;
            this.botonImage.Text = "...";
            this.botonImage.Click += new System.EventHandler(this.botonImage_Click);
            // 
            // tbox_Image
            // 
            this.tbox_Image.Location = new System.Drawing.Point(96, 104);
            this.tbox_Image.Name = "tbox_Image";
            this.tbox_Image.ReadOnly = true;
            this.tbox_Image.Size = new System.Drawing.Size(384, 20);
            this.tbox_Image.TabIndex = 19;
            this.tbox_Image.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 18;
            this.label4.Text = "Imagen";
            // 
            // tbox_Desc
            // 
            this.tbox_Desc.Location = new System.Drawing.Point(96, 72);
            this.tbox_Desc.Name = "tbox_Desc";
            this.tbox_Desc.Size = new System.Drawing.Size(896, 20);
            this.tbox_Desc.TabIndex = 17;
            this.tbox_Desc.Text = "";
            // 
            // tbox_Name
            // 
            this.tbox_Name.Location = new System.Drawing.Point(96, 40);
            this.tbox_Name.Name = "tbox_Name";
            this.tbox_Name.Size = new System.Drawing.Size(384, 20);
            this.tbox_Name.TabIndex = 16;
            this.tbox_Name.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre corto";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Cod";
            // 
            // tbox_Cod
            // 
            this.tbox_Cod.Location = new System.Drawing.Point(96, 8);
            this.tbox_Cod.Name = "tbox_Cod";
            this.tbox_Cod.ReadOnly = true;
            this.tbox_Cod.Size = new System.Drawing.Size(48, 20);
            this.tbox_Cod.TabIndex = 12;
            this.tbox_Cod.Text = "";
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Title = "Selecciona la imagen para el artículo";
            // 
            // dataGrid
            // 
            this.dataGrid.CaptionVisible = false;
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(8, 424);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(1000, 216);
            this.dataGrid.TabIndex = 9;
            // 
            // ArticulosForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.dataGrid,
                                                                          this.panelEdicion,
                                                                          this.botonGrabar,
                                                                          this.botonNuevo,
                                                                          this.botonSalir});
            this.Name = "ArticulosForm";
            this.Text = "ArticulosForm";
            this.panelEdicion.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        private void botonSalir_Click(object sender, System.EventArgs e)
        {
            GestorArticulos.Save();
            this.Close();
        }

        private void botonImage_Click(object sender, System.EventArgs e)
        {
            if ( imageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                tbox_Image.Text = imageFileDialog.FileName ;
                pictureBox.Image = Image.FromFile(imageFileDialog.FileName);
            }
        }



        private void botonNuevo_Click(object sender, System.EventArgs e)
        {
            botonNuevo.Enabled = false ;
            botonGrabar.Enabled = true ;
            botonSalir.Enabled = false ;
            panelEdicion.Enabled = true ;

            tbox_Cod.Text = System.Convert.ToString(GestorArticulos.NewCod++) ;
            tbox_Name.Text = "";
            tbox_Desc.Text = "";
            tbox_Image.Text = "";
            check_MostrarVentas.Checked = true ;
            tbox_CostoS.Text = "" ;
            tbox_CostoC.Text = "" ;
            tbox_PvpS.Text = "" ;
            tbox_PvpC.Text = "" ;
            tbox_Margen.Text = "" ;
            tbox_Existencias.Text = "";
            tbox_StockInicial.Text = "";
            tbox_StockMinimo.Text = "";
            tbox_ValorCosto.Text = "";
            tbox_ValorVenta.Text = "" ;
        }

        private void botonGrabar_Click(object sender, System.EventArgs e)
        {
            botonNuevo.Enabled = true ;
            botonGrabar.Enabled = false ;
            botonSalir.Enabled = true ;
            panelEdicion.Enabled = false ;

            Articulo a = new Articulo();
            a.Cod = System.Convert.ToInt32(tbox_Cod.Text);
            a.Name = tbox_Name.Text ;
            a.Desc = tbox_Desc.Text ;
            a.Familia = (int)combo_Familia.SelectedValue ;
            a.Image = tbox_Image.Text ;
            a.MostrarEnVentas = check_MostrarVentas.Checked ;

            a.Iva = (int)combo_Iva.SelectedValue;
            a.CostoSinIva = (float)System.Convert.ToDouble(tbox_CostoS.Text);
            a.CostoConIva = (float)System.Convert.ToDouble(tbox_CostoC.Text);
            a.PvpSinIva = (float)System.Convert.ToDouble(tbox_PvpS.Text);
            a.PvpConIva = (float)System.Convert.ToDouble(tbox_PvpC.Text);
            a.Margen = System.Convert.ToInt32(tbox_Margen.Text);

            a.Existencias = System.Convert.ToInt32(tbox_Existencias.Text);
            a.StockInicial = System.Convert.ToInt32(tbox_StockInicial.Text);
            a.StockMinimo = System.Convert.ToInt32(tbox_StockMinimo.Text);
            a.ValorCosto = (float)System.Convert.ToDouble(tbox_ValorCosto.Text);
            a.ValorVenta = (float)System.Convert.ToDouble(tbox_ValorVenta.Text);

            GestorArticulos.AddArticulo(a);
        }

        private void tbox_CostoS_Validated(object sender, System.EventArgs e)
        {
            try
            {
                float _iva = ((float)System.Convert.ToDouble( combo_Iva.Text )) /100.0f;
                float _siniva = (float)System.Convert.ToDouble(tbox_CostoS.Text);
                float _coniva = _siniva + _siniva * _iva ;
                tbox_CostoC.Text = System.Convert.ToString(_coniva);

                // Si ya hay valor para pvp con iva, calculamos el nuevo margen
                if ( tbox_PvpC.Text != "" )
                {
                    float _pvp = (float)System.Convert.ToDouble(tbox_PvpC.Text);
                    int _margen = ((int)(_pvp * 100.0f / _coniva))-100;
                    tbox_Margen.Text = System.Convert.ToString(_margen);
                }
            }
            catch(System.FormatException ex)
            {
                tbox_CostoS.Text = "" ;
                tbox_CostoC.Text = "" ;
                tbox_Margen.Text = "" ;
            }
        }

        private void tbox_PvpC_Validated(object sender, System.EventArgs e)
        {
            try
            {
                float _iva = ((float)System.Convert.ToDouble( combo_Iva.Text )) /100.0f;
                float _coniva = (float)System.Convert.ToDouble(tbox_PvpC.Text);
                float _siniva = _coniva * (1.0f / (1.0f + _iva)) ;
                tbox_PvpS.Text = System.Convert.ToString(_siniva);

                // Si ya hay valor para costo con iva, calculamos el nuevo margen
                if ( tbox_CostoC.Text != "" )
                {
                    float _costo = (float)System.Convert.ToDouble(tbox_CostoC.Text);
                    int _margen = ((int)(_coniva * 100.0f / _costo))-100;
                    tbox_Margen.Text = System.Convert.ToString(_margen);
                }
            }
            catch(System.FormatException ex)
            {
                tbox_PvpC.Text = "" ;
                tbox_PvpS.Text = "" ;
                tbox_Margen.Text = "" ;
            }
        
        }

        private void tbox_StockInicial_Validated(object sender, System.EventArgs e)
        {
            try
            {
                int n = System.Convert.ToInt32(tbox_StockInicial.Text);
                tbox_Existencias.Text = System.Convert.ToString(n);
                if ( tbox_CostoC.Text != "" )
                {
                    double _costo = (float)System.Convert.ToDouble(tbox_CostoC.Text);
                    double _valorc = n * _costo ;
                    tbox_ValorCosto.Text = System.Convert.ToString(_valorc);
                }
                if ( tbox_PvpC.Text != "" )
                {
                    double _pvp = (float)System.Convert.ToDouble(tbox_PvpC.Text);
                    double _valorv = n * _pvp ;
                    tbox_ValorVenta.Text = System.Convert.ToString(_valorv);
                }
            }
            catch(System.FormatException ex)
            {
                tbox_StockInicial.Text = "" ;
                tbox_Existencias.Text = "" ;
                tbox_ValorCosto.Text = "" ;
                tbox_ValorVenta.Text = "" ;
            }
        }
	}
}
