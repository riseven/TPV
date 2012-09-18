using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPV
{
	/// <summary>
	/// Summary description for tpvForm.
	/// </summary>
	public class TpvForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Panel panelVenta;
        private System.Windows.Forms.Button botonVista1;
        private System.Windows.Forms.Button botonVista2;
        private System.Windows.Forms.Button botonAbrir;
        private System.Windows.Forms.Button botonPrecio;
        private System.Windows.Forms.Button botonVista3;
        private System.Windows.Forms.Button botonSacarMesa;
        private System.Windows.Forms.Panel panelOpsSinMesa;
		private System.Windows.Forms.Panel panelFamilias;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panelArticulos;
		private System.Windows.Forms.Button[] botonFamilia;
		private System.Windows.Forms.Button[] botonArticulo;
		private System.Windows.Forms.DataGrid dataGrid;
		private int[] codBotonArticulo ;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.Panel panelOpsConMesa;
		private System.Windows.Forms.Button botonTicket;
		private System.Windows.Forms.Button botonCobrar;
		private int mesaSeleccionada ;
		private int modoDeOperacion ;
        private Plaza printingPlaza = new Plaza();

		private const int ModoNormal = 0 ;
		private const int ModoSacarMesa = 1 ;
		private const int ModoTraspasar = 2 ;
		private const int ModoJuntar = 3 ;
		private const int ModoSeparar = 4 ;
		private System.Windows.Forms.Button botonJuntar;
		private System.Windows.Forms.Button botonTraspasar;
		private System.Windows.Forms.Panel panelSacarMesa;
		private System.Windows.Forms.Button botonFinSacarMesa;
		private System.Windows.Forms.Panel panelGeneral;
		private System.Windows.Forms.Panel panelGuardarMesa;
		private System.Windows.Forms.Button botonGuardarMesa;
		private System.Windows.Forms.Panel panelVaciarMesa;
		private System.Windows.Forms.Button botonVaciarMesa;
		private System.Windows.Forms.Panel panelLineas;
		private System.Windows.Forms.Panel panelVaciarPagados;
		private System.Windows.Forms.Button botonCancelarTraspasar;
		private System.Windows.Forms.Panel panelTraspasar;
		private System.Windows.Forms.Panel panelJuntar;
		private System.Windows.Forms.Button botonCancelarJuntar;
		private System.Windows.Forms.Button botonSeparar;
		private System.Windows.Forms.Panel panelSeparar;
		private System.Windows.Forms.Button botonCancelarSeparar;
        private System.Drawing.Printing.PrintDocument printTicket;
		private System.Windows.Forms.Button botonVaciarPagados;
		

		public TpvForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			// Recargamos 
			
			GestorFamilias.Load();
			GestorArticulos.Load();
			GestorPlazas.Load(); // Requiere que los articulos se hayan cargado


            panelVenta.Visible = true ;
            panelOpsSinMesa.Visible = true ;
			panelOpsConMesa.Visible = false ;
			panelSacarMesa.Visible = false ;
			panelGeneral.Visible = true ;
			panelTraspasar.Visible = false ;
			panelJuntar.Visible = false ;

			modoDeOperacion = ModoNormal ;

			// Creamos los botones del panel de familias
			int numBotonesFamiliaFila = panelFamilias.ClientSize.Width/64 ;
			int numBotonesFamiliaColumna = panelFamilias.ClientSize.Height/64 ;
			int numBotonesFamilia = numBotonesFamiliaFila * numBotonesFamiliaColumna ;
			botonFamilia = new System.Windows.Forms.Button[numBotonesFamilia];
			for ( int i = 0 ; i < numBotonesFamilia ; i++ )
			{
				botonFamilia[i] = new System.Windows.Forms.Button() ;
				botonFamilia[i].Size = new System.Drawing.Size(64,64);
				botonFamilia[i].Left = (i%numBotonesFamiliaFila)*64 ;
				botonFamilia[i].Top = (i/numBotonesFamiliaFila)*64 ;
				botonFamilia[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter ;
				botonFamilia[i].Visible = false ;
				panelFamilias.Controls.Add(botonFamilia[i]);
			}

			int numBotonesArticulosFila = panelArticulos.ClientSize.Width/64 ;
			int numBotonesArticulosColumna = panelArticulos.ClientSize.Height/64 ;
			int numBotonesArticulos = numBotonesArticulosFila * numBotonesArticulosColumna ;
			botonArticulo = new System.Windows.Forms.Button[numBotonesArticulos];
			codBotonArticulo = new int[numBotonesArticulos] ;
			for ( int i = 0 ; i < numBotonesArticulos ; i++ )
			{
				botonArticulo[i] = new System.Windows.Forms.Button() ;
				botonArticulo[i].Size = new System.Drawing.Size(64,64);
				botonArticulo[i].Left = (i%numBotonesArticulosFila)*64 ;
				botonArticulo[i].Top = (i/numBotonesArticulosFila)*64 ;
				botonArticulo[i].TextAlign = System.Drawing.ContentAlignment.BottomCenter ;
				botonArticulo[i].Visible = false ;
				botonArticulo[i].Click += new System.EventHandler(this.botonArticulo_Click);
				panelArticulos.Controls.Add(botonArticulo[i]);
			}

			// Rellenamos los botones de las familia
			for ( int i = 0 ; i < GestorFamilias.Familias.Count ; i++ )
			{
				botonFamilia[i].Image = Image.FromFile(((Familia)GestorFamilias.Familias[i]).Image);
				botonFamilia[i].Text = ((Familia)GestorFamilias.Familias[i]).Name ;
				botonFamilia[i].Visible = true ;
			}

			// Rellenamos los botones de los articulos
			for ( int i = 0 ; i < GestorArticulos.Articulos.Count ; i++ )
			{
				botonArticulo[i].Image = Image.FromFile(((Articulo)GestorArticulos.Articulos[i]).Image);
				botonArticulo[i].Text = ((Articulo)GestorArticulos.Articulos[i]).Name ;
				botonArticulo[i].Visible = true ;
				codBotonArticulo[i] = ((Articulo)GestorArticulos.Articulos[i]).Cod ;
			}


				


			// Ponemos los botones de las plazas
			for ( int i = 0 ; i < GestorPlazas.getNumPlazas(); i++ )
			{
				panelVenta.Controls.Add(GestorPlazas.getBotonTPV(i));
				GestorPlazas.getBotonTPV(i).Click += new System.EventHandler(botonesMesa_Click);
			}


			
			mesaSeleccionada = -1 ;

			

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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TpvForm));
            this.botonSalir = new System.Windows.Forms.Button();
            this.panelFamilias = new System.Windows.Forms.Panel();
            this.panelLineas = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.panelArticulos = new System.Windows.Forms.Panel();
            this.panelVenta = new System.Windows.Forms.Panel();
            this.botonVista1 = new System.Windows.Forms.Button();
            this.botonVista2 = new System.Windows.Forms.Button();
            this.botonAbrir = new System.Windows.Forms.Button();
            this.botonPrecio = new System.Windows.Forms.Button();
            this.botonVista3 = new System.Windows.Forms.Button();
            this.botonSacarMesa = new System.Windows.Forms.Button();
            this.panelOpsSinMesa = new System.Windows.Forms.Panel();
            this.botonSeparar = new System.Windows.Forms.Button();
            this.panelOpsConMesa = new System.Windows.Forms.Panel();
            this.panelVaciarPagados = new System.Windows.Forms.Panel();
            this.botonVaciarPagados = new System.Windows.Forms.Button();
            this.panelVaciarMesa = new System.Windows.Forms.Panel();
            this.botonVaciarMesa = new System.Windows.Forms.Button();
            this.panelGuardarMesa = new System.Windows.Forms.Panel();
            this.botonGuardarMesa = new System.Windows.Forms.Button();
            this.botonTraspasar = new System.Windows.Forms.Button();
            this.botonJuntar = new System.Windows.Forms.Button();
            this.botonTicket = new System.Windows.Forms.Button();
            this.botonCobrar = new System.Windows.Forms.Button();
            this.panelSacarMesa = new System.Windows.Forms.Panel();
            this.botonFinSacarMesa = new System.Windows.Forms.Button();
            this.panelGeneral = new System.Windows.Forms.Panel();
            this.panelTraspasar = new System.Windows.Forms.Panel();
            this.botonCancelarTraspasar = new System.Windows.Forms.Button();
            this.panelJuntar = new System.Windows.Forms.Panel();
            this.botonCancelarJuntar = new System.Windows.Forms.Button();
            this.panelSeparar = new System.Windows.Forms.Panel();
            this.botonCancelarSeparar = new System.Windows.Forms.Button();
            this.printTicket = new System.Drawing.Printing.PrintDocument();
            this.panelLineas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panelOpsSinMesa.SuspendLayout();
            this.panelOpsConMesa.SuspendLayout();
            this.panelVaciarPagados.SuspendLayout();
            this.panelVaciarMesa.SuspendLayout();
            this.panelGuardarMesa.SuspendLayout();
            this.panelSacarMesa.SuspendLayout();
            this.panelGeneral.SuspendLayout();
            this.panelTraspasar.SuspendLayout();
            this.panelJuntar.SuspendLayout();
            this.panelSeparar.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonSalir
            // 
            this.botonSalir.BackColor = System.Drawing.SystemColors.Control;
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(64, 64);
            this.botonSalir.TabIndex = 2;
            this.botonSalir.Text = "SALIR";
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // panelFamilias
            // 
            this.panelFamilias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFamilias.Location = new System.Drawing.Point(8, 324);
            this.panelFamilias.Name = "panelFamilias";
            this.panelFamilias.Size = new System.Drawing.Size(196, 388);
            this.panelFamilias.TabIndex = 4;
            // 
            // panelLineas
            // 
            this.panelLineas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelLineas.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                      this.dataGrid});
            this.panelLineas.Location = new System.Drawing.Point(728, 324);
            this.panelLineas.Name = "panelLineas";
            this.panelLineas.Size = new System.Drawing.Size(280, 316);
            this.panelLineas.TabIndex = 5;
            // 
            // dataGrid
            // 
            this.dataGrid.AlternatingBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGrid.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGrid.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dataGrid.CaptionVisible = false;
            this.dataGrid.CausesValidation = false;
            this.dataGrid.ColumnHeadersVisible = false;
            this.dataGrid.DataMember = "";
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.dataGrid.GridLineColor = System.Drawing.Color.Cyan;
            this.dataGrid.HeaderBackColor = System.Drawing.Color.LightCoral;
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ParentRowsBackColor = System.Drawing.Color.IndianRed;
            this.dataGrid.PreferredColumnWidth = 150;
            this.dataGrid.PreferredRowHeight = 32;
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionBackColor = System.Drawing.Color.Blue;
            this.dataGrid.Size = new System.Drawing.Size(276, 312);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
                                                                                                 this.dataGridTableStyle1});
            this.dataGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseDown);
            this.dataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dataGrid_MouseUp);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridTableStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridTableStyle1.ColumnHeadersVisible = false;
            this.dataGridTableStyle1.DataGrid = this.dataGrid;
            this.dataGridTableStyle1.GridLineColor = System.Drawing.Color.Cyan;
            this.dataGridTableStyle1.HeaderBackColor = System.Drawing.Color.LightCoral;
            this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridTableStyle1.MappingName = "Pedidos de la mesa";
            this.dataGridTableStyle1.RowHeadersVisible = false;
            this.dataGridTableStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            // 
            // panelArticulos
            // 
            this.panelArticulos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelArticulos.Location = new System.Drawing.Point(208, 320);
            this.panelArticulos.Name = "panelArticulos";
            this.panelArticulos.Size = new System.Drawing.Size(516, 324);
            this.panelArticulos.TabIndex = 6;
            // 
            // panelVenta
            // 
            this.panelVenta.AllowDrop = true;
            this.panelVenta.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("panelVenta.BackgroundImage")));
            this.panelVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelVenta.Location = new System.Drawing.Point(8, 8);
            this.panelVenta.Name = "panelVenta";
            this.panelVenta.Size = new System.Drawing.Size(1000, 312);
            this.panelVenta.TabIndex = 7;
            this.panelVenta.Click += new System.EventHandler(this.panelVenta_Click);
            // 
            // botonVista1
            // 
            this.botonVista1.BackColor = System.Drawing.SystemColors.Control;
            this.botonVista1.Location = new System.Drawing.Point(184, 0);
            this.botonVista1.Name = "botonVista1";
            this.botonVista1.Size = new System.Drawing.Size(64, 64);
            this.botonVista1.TabIndex = 8;
            this.botonVista1.Text = "VISTA 1";
            // 
            // botonVista2
            // 
            this.botonVista2.BackColor = System.Drawing.SystemColors.Control;
            this.botonVista2.Location = new System.Drawing.Point(256, 0);
            this.botonVista2.Name = "botonVista2";
            this.botonVista2.Size = new System.Drawing.Size(64, 64);
            this.botonVista2.TabIndex = 9;
            this.botonVista2.Text = "VISTA 2";
            // 
            // botonAbrir
            // 
            this.botonAbrir.Location = new System.Drawing.Point(288, 0);
            this.botonAbrir.Name = "botonAbrir";
            this.botonAbrir.Size = new System.Drawing.Size(64, 64);
            this.botonAbrir.TabIndex = 10;
            this.botonAbrir.Text = "ABRIR CAJON";
            // 
            // botonPrecio
            // 
            this.botonPrecio.Location = new System.Drawing.Point(216, 0);
            this.botonPrecio.Name = "botonPrecio";
            this.botonPrecio.Size = new System.Drawing.Size(64, 64);
            this.botonPrecio.TabIndex = 11;
            this.botonPrecio.Text = "IMPRIMIR PRECIO";
            // 
            // botonVista3
            // 
            this.botonVista3.BackColor = System.Drawing.SystemColors.Control;
            this.botonVista3.Location = new System.Drawing.Point(328, 0);
            this.botonVista3.Name = "botonVista3";
            this.botonVista3.Size = new System.Drawing.Size(64, 64);
            this.botonVista3.TabIndex = 14;
            this.botonVista3.Text = "VISTA 3";
            // 
            // botonSacarMesa
            // 
            this.botonSacarMesa.Name = "botonSacarMesa";
            this.botonSacarMesa.Size = new System.Drawing.Size(64, 64);
            this.botonSacarMesa.TabIndex = 15;
            this.botonSacarMesa.Text = "SACAR MESA";
            this.botonSacarMesa.Click += new System.EventHandler(this.botonSacarMesa_Click);
            // 
            // panelOpsSinMesa
            // 
            this.panelOpsSinMesa.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                          this.botonSeparar,
                                                                                          this.botonPrecio,
                                                                                          this.botonAbrir,
                                                                                          this.botonSacarMesa});
            this.panelOpsSinMesa.Location = new System.Drawing.Point(648, 648);
            this.panelOpsSinMesa.Name = "panelOpsSinMesa";
            this.panelOpsSinMesa.Size = new System.Drawing.Size(352, 64);
            this.panelOpsSinMesa.TabIndex = 17;
            // 
            // botonSeparar
            // 
            this.botonSeparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonSeparar.Location = new System.Drawing.Point(144, 0);
            this.botonSeparar.Name = "botonSeparar";
            this.botonSeparar.Size = new System.Drawing.Size(64, 64);
            this.botonSeparar.TabIndex = 16;
            this.botonSeparar.Text = "SEPARAR MESA";
            this.botonSeparar.Click += new System.EventHandler(this.botonSeparar_Click);
            // 
            // panelOpsConMesa
            // 
            this.panelOpsConMesa.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                          this.panelVaciarPagados,
                                                                                          this.panelVaciarMesa,
                                                                                          this.panelGuardarMesa,
                                                                                          this.botonTraspasar,
                                                                                          this.botonJuntar,
                                                                                          this.botonTicket,
                                                                                          this.botonCobrar});
            this.panelOpsConMesa.Location = new System.Drawing.Point(648, 648);
            this.panelOpsConMesa.Name = "panelOpsConMesa";
            this.panelOpsConMesa.Size = new System.Drawing.Size(352, 64);
            this.panelOpsConMesa.TabIndex = 18;
            this.panelOpsConMesa.Visible = false;
            // 
            // panelVaciarPagados
            // 
            this.panelVaciarPagados.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                             this.botonVaciarPagados});
            this.panelVaciarPagados.Name = "panelVaciarPagados";
            this.panelVaciarPagados.Size = new System.Drawing.Size(64, 64);
            this.panelVaciarPagados.TabIndex = 23;
            // 
            // botonVaciarPagados
            // 
            this.botonVaciarPagados.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonVaciarPagados.Name = "botonVaciarPagados";
            this.botonVaciarPagados.Size = new System.Drawing.Size(64, 64);
            this.botonVaciarPagados.TabIndex = 17;
            this.botonVaciarPagados.Text = "VACIAR PAGADOS";
            this.botonVaciarPagados.Click += new System.EventHandler(this.botonVaciarPagados_Click);
            // 
            // panelVaciarMesa
            // 
            this.panelVaciarMesa.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                          this.botonVaciarMesa});
            this.panelVaciarMesa.Name = "panelVaciarMesa";
            this.panelVaciarMesa.Size = new System.Drawing.Size(64, 64);
            this.panelVaciarMesa.TabIndex = 22;
            // 
            // botonVaciarMesa
            // 
            this.botonVaciarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonVaciarMesa.Name = "botonVaciarMesa";
            this.botonVaciarMesa.Size = new System.Drawing.Size(64, 64);
            this.botonVaciarMesa.TabIndex = 17;
            this.botonVaciarMesa.Text = "VACIAR MESA";
            this.botonVaciarMesa.Click += new System.EventHandler(this.botonVaciarMesa_Click);
            // 
            // panelGuardarMesa
            // 
            this.panelGuardarMesa.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                           this.botonGuardarMesa});
            this.panelGuardarMesa.Name = "panelGuardarMesa";
            this.panelGuardarMesa.Size = new System.Drawing.Size(64, 64);
            this.panelGuardarMesa.TabIndex = 21;
            // 
            // botonGuardarMesa
            // 
            this.botonGuardarMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonGuardarMesa.Name = "botonGuardarMesa";
            this.botonGuardarMesa.Size = new System.Drawing.Size(64, 64);
            this.botonGuardarMesa.TabIndex = 16;
            this.botonGuardarMesa.Text = "GUARDAR MESA";
            this.botonGuardarMesa.Click += new System.EventHandler(this.botonGuardarMesa_Click);
            // 
            // botonTraspasar
            // 
            this.botonTraspasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonTraspasar.Location = new System.Drawing.Point(72, 0);
            this.botonTraspasar.Name = "botonTraspasar";
            this.botonTraspasar.Size = new System.Drawing.Size(64, 64);
            this.botonTraspasar.TabIndex = 17;
            this.botonTraspasar.Text = "TRASPASAR";
            this.botonTraspasar.Click += new System.EventHandler(this.botonTraspasar_Click);
            // 
            // botonJuntar
            // 
            this.botonJuntar.Location = new System.Drawing.Point(144, 0);
            this.botonJuntar.Name = "botonJuntar";
            this.botonJuntar.Size = new System.Drawing.Size(64, 64);
            this.botonJuntar.TabIndex = 16;
            this.botonJuntar.Text = "JUNTAR";
            this.botonJuntar.Click += new System.EventHandler(this.botonJuntar_Click);
            // 
            // botonTicket
            // 
            this.botonTicket.Location = new System.Drawing.Point(216, 0);
            this.botonTicket.Name = "botonTicket";
            this.botonTicket.Size = new System.Drawing.Size(64, 64);
            this.botonTicket.TabIndex = 11;
            this.botonTicket.Text = "TICKET";
            this.botonTicket.Click += new System.EventHandler(this.botonTicket_Click);
            // 
            // botonCobrar
            // 
            this.botonCobrar.Location = new System.Drawing.Point(288, 0);
            this.botonCobrar.Name = "botonCobrar";
            this.botonCobrar.Size = new System.Drawing.Size(64, 64);
            this.botonCobrar.TabIndex = 10;
            this.botonCobrar.Text = "COBRAR";
            this.botonCobrar.Click += new System.EventHandler(this.botonCobrar_Click);
            // 
            // panelSacarMesa
            // 
            this.panelSacarMesa.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                         this.botonFinSacarMesa});
            this.panelSacarMesa.Location = new System.Drawing.Point(648, 648);
            this.panelSacarMesa.Name = "panelSacarMesa";
            this.panelSacarMesa.Size = new System.Drawing.Size(352, 64);
            this.panelSacarMesa.TabIndex = 19;
            // 
            // botonFinSacarMesa
            // 
            this.botonFinSacarMesa.Name = "botonFinSacarMesa";
            this.botonFinSacarMesa.Size = new System.Drawing.Size(64, 64);
            this.botonFinSacarMesa.TabIndex = 15;
            this.botonFinSacarMesa.Text = "VOLVER";
            this.botonFinSacarMesa.Click += new System.EventHandler(this.botonFinSacarMesa_Click);
            // 
            // panelGeneral
            // 
            this.panelGeneral.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                       this.botonSalir,
                                                                                       this.botonVista2,
                                                                                       this.botonVista1,
                                                                                       this.botonVista3});
            this.panelGeneral.Location = new System.Drawing.Point(208, 648);
            this.panelGeneral.Name = "panelGeneral";
            this.panelGeneral.Size = new System.Drawing.Size(392, 64);
            this.panelGeneral.TabIndex = 20;
            // 
            // panelTraspasar
            // 
            this.panelTraspasar.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                         this.botonCancelarTraspasar});
            this.panelTraspasar.Location = new System.Drawing.Point(648, 648);
            this.panelTraspasar.Name = "panelTraspasar";
            this.panelTraspasar.Size = new System.Drawing.Size(352, 64);
            this.panelTraspasar.TabIndex = 21;
            this.panelTraspasar.Visible = false;
            // 
            // botonCancelarTraspasar
            // 
            this.botonCancelarTraspasar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonCancelarTraspasar.Location = new System.Drawing.Point(72, 0);
            this.botonCancelarTraspasar.Name = "botonCancelarTraspasar";
            this.botonCancelarTraspasar.Size = new System.Drawing.Size(64, 64);
            this.botonCancelarTraspasar.TabIndex = 17;
            this.botonCancelarTraspasar.Text = "CANCELAR";
            this.botonCancelarTraspasar.Click += new System.EventHandler(this.botonCancelarTraspasar_Click);
            // 
            // panelJuntar
            // 
            this.panelJuntar.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                      this.botonCancelarJuntar});
            this.panelJuntar.Location = new System.Drawing.Point(648, 648);
            this.panelJuntar.Name = "panelJuntar";
            this.panelJuntar.Size = new System.Drawing.Size(352, 64);
            this.panelJuntar.TabIndex = 22;
            this.panelJuntar.Visible = false;
            // 
            // botonCancelarJuntar
            // 
            this.botonCancelarJuntar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonCancelarJuntar.Location = new System.Drawing.Point(144, 0);
            this.botonCancelarJuntar.Name = "botonCancelarJuntar";
            this.botonCancelarJuntar.Size = new System.Drawing.Size(64, 64);
            this.botonCancelarJuntar.TabIndex = 16;
            this.botonCancelarJuntar.Text = "CANCELAR";
            this.botonCancelarJuntar.Click += new System.EventHandler(this.botonCancelarJuntar_Click);
            // 
            // panelSeparar
            // 
            this.panelSeparar.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                       this.botonCancelarSeparar});
            this.panelSeparar.Location = new System.Drawing.Point(648, 648);
            this.panelSeparar.Name = "panelSeparar";
            this.panelSeparar.Size = new System.Drawing.Size(352, 64);
            this.panelSeparar.TabIndex = 23;
            this.panelSeparar.Visible = false;
            // 
            // botonCancelarSeparar
            // 
            this.botonCancelarSeparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonCancelarSeparar.Location = new System.Drawing.Point(144, 0);
            this.botonCancelarSeparar.Name = "botonCancelarSeparar";
            this.botonCancelarSeparar.Size = new System.Drawing.Size(64, 64);
            this.botonCancelarSeparar.TabIndex = 16;
            this.botonCancelarSeparar.Text = "CANCELAR";
            this.botonCancelarSeparar.Click += new System.EventHandler(this.botonCancelarSeparar_Click);
            // 
            // printTicket
            // 
            this.printTicket.DocumentName = "Ticket";
            this.printTicket.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printTicket_PrintPage);
            // 
            // TpvForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 741);
            this.ControlBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.panelSeparar,
                                                                          this.panelGeneral,
                                                                          this.panelVenta,
                                                                          this.panelArticulos,
                                                                          this.panelLineas,
                                                                          this.panelFamilias,
                                                                          this.panelJuntar,
                                                                          this.panelOpsConMesa,
                                                                          this.panelSacarMesa,
                                                                          this.panelOpsSinMesa,
                                                                          this.panelTraspasar});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TpvForm";
            this.Text = "Punto de venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.tpvForm_Load);
            this.panelLineas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panelOpsSinMesa.ResumeLayout(false);
            this.panelOpsConMesa.ResumeLayout(false);
            this.panelVaciarPagados.ResumeLayout(false);
            this.panelVaciarMesa.ResumeLayout(false);
            this.panelGuardarMesa.ResumeLayout(false);
            this.panelSacarMesa.ResumeLayout(false);
            this.panelGeneral.ResumeLayout(false);
            this.panelTraspasar.ResumeLayout(false);
            this.panelJuntar.ResumeLayout(false);
            this.panelSeparar.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        private void botonSalir_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void tpvForm_Load(object sender, System.EventArgs e)
        {
        
        }


		private void botonArticulo_Click(object sender, System.EventArgs e)
		{
			int index ;

			index = System.Array.IndexOf(botonArticulo, sender);

			GestorPlazas.getPlaza(mesaSeleccionada).AddArticulo( codBotonArticulo[index] ) ;

			//dataGrid.LinkColor

			GestorPlazas.ActualizarBotones();
			GestorPlazas.Save();

			ActualizarPanelConMesa();

		}

		public void SeleccionarMesa(int codigo)
		{
			mesaSeleccionada = codigo ;

            // Mostramos la mesa seleccionada
            

			// Cambiamos el dataLineas
			dataGrid.SetDataBinding( GestorPlazas.getDataLineas(mesaSeleccionada) , "" );
			dataGrid.TableStyles[0].GridColumnStyles["Nombre"].Width = 160 ;
			dataGrid.TableStyles[0].GridColumnStyles["Estado"].Width = 25 ;
			dataGrid.TableStyles[0].GridColumnStyles["Precio"].Width = 70 ;

			// Cambiamos botones
			panelOpsConMesa.Visible = true ;
			panelOpsSinMesa.Visible = false ;

			ActualizarPanelConMesa();
		}


		private void botonesMesa_Click(object sender, System.EventArgs e)
		{
			if ( modoDeOperacion == ModoNormal )
			{
				Plaza p = GestorPlazas.getPlaza((System.Windows.Forms.Button) sender);
				if ( !p.isJuntada )
				{
                    for ( int i = 0 ; i < GestorPlazas.NewCod-1 ; i++ )
                    {
                        GestorPlazas.getBotonTPV(i).Text = "" ;
                    }
                    ((Button) sender).Text = "X" ;
					GestorPlazas.getPlaza((System.Windows.Forms.Button) sender).ResetSeleccion();
					SeleccionarMesa(p.Cod);
				}
			}
			else if ( modoDeOperacion == ModoSacarMesa )
			{
				Plaza p = GestorPlazas.getPlaza((System.Windows.Forms.Button) sender);
				GestorPlazas.ActivarPlaza(p.Cod);
				GestorPlazas.Save();
			}
			else if ( modoDeOperacion == ModoTraspasar )
			{
				// Vamos a traspasar cosas
				int cuenta = 0 ;
				bool traspasadoTodo = false ;
				for ( int i = 0 ; i < GestorPlazas.getPlaza(mesaSeleccionada).NumLineas ; i++ )
				{
					Linea l = ((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[i]) ;
					if ( l.Seleccionado )
					{
						cuenta++ ;
						GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender ).AddLinea(l) ;
						GestorPlazas.getPlaza(mesaSeleccionada).EliminarLinea(i);
						i--;
					}
				}
				if ( cuenta == 0 )
				{
					// Traspasamos todo
					traspasadoTodo = true ;
					for ( int i = 0 ; i < GestorPlazas.getPlaza(mesaSeleccionada).NumLineas ; i++ )
					{
						Linea l = ((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[i]) ;
						GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).AddLinea(l) ;
						GestorPlazas.getPlaza(mesaSeleccionada).EliminarLinea(i);
						i--;
					}
				}
				GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).Activar();

				GestorPlazas.ActualizarBotones();
				GestorPlazas.Save();

				// Reponemos el modo de operacion
				modoDeOperacion = ModoNormal ;

				panelFamilias.Enabled = true ;
				panelArticulos.Enabled = true ;
				panelLineas.Enabled = true ;

				panelGeneral.Visible = true ;
				panelOpsConMesa.Visible = true ;
				panelTraspasar.Visible = false ;

				if ( traspasadoTodo )
				{
					// Elegimos la nueva mesa
					SeleccionarMesa( GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).Cod );
				}

				ActualizarPanelConMesa();
			}
			else if ( modoDeOperacion == ModoJuntar )
			{
				// Traspasamos todo
				for ( int i = 0 ; i < GestorPlazas.getPlaza(mesaSeleccionada).NumLineas ; i++ )
				{
					Linea l = ((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[i]) ;
					GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).AddLinea(l) ;
				}
				GestorPlazas.getPlaza(mesaSeleccionada).Clear();
				GestorPlazas.getPlaza(mesaSeleccionada).Juntar( GestorPlazas.getPlaza( (System.Windows.Forms.Button ) sender).Cod );

				GestorPlazas.ActualizarBotones();
				GestorPlazas.Save();

				// Reponemos el modo de operacion
				modoDeOperacion = ModoNormal ;

				panelFamilias.Enabled = true ;
				panelArticulos.Enabled = true ;
				panelLineas.Enabled = true ;

				panelGeneral.Visible = true ;
				panelOpsSinMesa.Visible = true ;
				panelJuntar.Visible = false ;

				// Elegimos la nueva mesa
				SeleccionarMesa( GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).Cod );

				ActualizarPanelConMesa();
			}
			else if ( modoDeOperacion == ModoSeparar )
			{
				GestorPlazas.getPlaza( (System.Windows.Forms.Button) sender).Activar() ;
				GestorPlazas.ActualizarBotones();
				GestorPlazas.Save();

				modoDeOperacion = ModoNormal ;

				panelFamilias.Enabled = true ;
				panelArticulos.Enabled = true ;
				panelLineas.Enabled = true ;

				panelGeneral.Visible = true ;
				panelOpsSinMesa.Visible = true ;
				panelSeparar.Visible = false ;

				ActualizarPanelConMesa();
			}
		}

		private void dataGrid_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			
			System.Windows.Forms.DataGrid temp = (System.Windows.Forms.DataGrid)sender ;

			int row = temp.HitTest(e.X, e.Y).Row ;

			if (row != -1)
			{
				((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[row]).Seleccionado = !(((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[row]).Seleccionado ); 
			}
			else
			{
				GestorPlazas.getPlaza(mesaSeleccionada).ResetSeleccion();
			}
		}


		private void dataGrid_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.DataGrid temp = (System.Windows.Forms.DataGrid)sender ;

			for ( int row = 0 ; row < GestorPlazas.getPlaza(mesaSeleccionada).NumLineas ; row++ )
			{
				if (((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[row]).Seleccionado)
				{
					temp.Select(row) ;
				}
				else
				{
					temp.UnSelect(row) ;
				}
			}
		}

		private void panelVenta_Click(object sender, System.EventArgs e)
		{


			dataGrid.SetDataBinding(null, "");
			mesaSeleccionada = -1 ;

			// Cambiamos botones
			panelOpsSinMesa.Visible = true ;
			panelOpsConMesa.Visible = false ;
			

			
		}

		private void botonGuardarMesa_Click(object sender, System.EventArgs e)
		{
			if ( GestorPlazas.GuardarPlaza(mesaSeleccionada) )
			{
				dataGrid.SetDataBinding(null, "");
				mesaSeleccionada = -1 ;
				panelOpsSinMesa.Visible = true ;
				panelOpsConMesa.Visible = false ;
				GestorPlazas.Save();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("No se puede guardar una mesa ocupada");
			}
				
		}

		private void botonSacarMesa_Click(object sender, System.EventArgs e)
		{
			GestorPlazas.StartModoSacarMesa();
			modoDeOperacion = ModoSacarMesa ;
			panelFamilias.Enabled = false ;
			panelArticulos.Enabled = false ;
			dataGrid.Enabled = false ;
			panelSacarMesa.Visible = true ;
			panelOpsSinMesa.Visible = false ;
			panelGeneral.Visible = false ;
		}

		private void botonFinSacarMesa_Click(object sender, System.EventArgs e)
		{
			GestorPlazas.StopModoSacarMesa();
			modoDeOperacion = ModoNormal ;
			panelFamilias.Enabled = true ;
			panelArticulos.Enabled = true ;
			dataGrid.Enabled = true ;
			panelOpsSinMesa.Visible = true ;
			panelSacarMesa.Visible = false ;
			panelGeneral.Visible = true ;
		}

		private void botonTicket_Click(object sender, System.EventArgs e)
		{
			int cuenta = 0 ;
			foreach (object o in GestorPlazas.getPlaza(mesaSeleccionada).Lineas)
			{
				if ( ((Linea) o).Seleccionado )
				{
					cuenta++ ;
					((Linea) o).Ticado = true ;
					// Imprimir...
                    printingPlaza.AddLinea( (Linea) o );
				}
			}
			if ( cuenta == 0 )
			{
				// No habia ninguno seleccionado, ticamos todo lo que no este tickado
				foreach (object o in GestorPlazas.getPlaza(mesaSeleccionada).Lineas)
				{
					if ( !((Linea) o).Ticado )
					{
						((Linea) o).Ticado = true ;
						// Imprimir...
                        printingPlaza.AddLinea( (Linea) o );
					}
				}
            }
            // Imprimimos
            printTicket.Print();

			GestorPlazas.getPlaza(mesaSeleccionada).ActualizarDataLineas();
			GestorPlazas.ActualizarBotones();
			GestorPlazas.Save();
			ActualizarPanelConMesa();
		}

		private void botonCobrar_Click(object sender, System.EventArgs e)
		{
			int cuenta = 0 ;
			foreach (object o in GestorPlazas.getPlaza(mesaSeleccionada).Lineas)
			{
				if ( ((Linea) o).Seleccionado )
				{
					cuenta++ ;
					((Linea) o).Pagado = true ;
					// Descontar de existencias
					// Imprimir...
				}
			}
			if ( cuenta == 0 )
			{
				// No habia ninguno seleccionado, ticamos todo lo que no este tickado
				foreach (object o in GestorPlazas.getPlaza(mesaSeleccionada).Lineas)
				{
					if ( !((Linea) o).Seleccionado )
					{
						((Linea) o).Pagado = true ;
						// Descontar de existencias
						// Imprimir...
					}
				}
			}
			GestorPlazas.getPlaza(mesaSeleccionada).ActualizarDataLineas();
			GestorPlazas.ActualizarBotones();
			GestorPlazas.Save();	
			ActualizarPanelConMesa();
		}

		private void botonVaciarMesa_Click(object sender, System.EventArgs e)
		{
			GestorPlazas.getPlaza(mesaSeleccionada).Clear();
			GestorPlazas.ActualizarBotones();
			GestorPlazas.Save();
			ActualizarPanelConMesa();
		}

		private void botonVaciarPagados_Click(object sender, System.EventArgs e)
		{
			for (int i = 0 ; i < GestorPlazas.getPlaza(mesaSeleccionada).NumLineas ; i++ )
			{
				if ( ((Linea)GestorPlazas.getPlaza(mesaSeleccionada).Lineas[i]).Pagado )
				{
					GestorPlazas.getPlaza(mesaSeleccionada).EliminarLinea(i);
					i--; // Al eliminar el elemento, el siguiente ocupa la posicion actual
					// y debemos volver a analizarla
				}
			}
			GestorPlazas.getPlaza(mesaSeleccionada).ActualizarDataLineas();
			GestorPlazas.ActualizarBotones();
			GestorPlazas.Save();
			ActualizarPanelConMesa();
		}
			

		private void ActualizarPanelConMesa()
		{
			if ( GestorPlazas.getPlaza(mesaSeleccionada).isTerminada() )
			{
				panelVaciarMesa.Visible = true ;
				panelGuardarMesa.Visible = false ;
				panelVaciarPagados.Visible = false ;
				botonTraspasar.Visible = true ;
			}
			else if ( !GestorPlazas.getPlaza(mesaSeleccionada).isOcupada() )
			{
				panelGuardarMesa.Visible = true ;
				panelVaciarMesa.Visible = false ;
				panelVaciarPagados.Visible = false ;
				botonTraspasar.Visible = false ;
			}
			else
			{
				panelVaciarPagados.Visible = true ;
				panelVaciarMesa.Visible = false ;
				panelGuardarMesa.Visible = false ;
				botonTraspasar.Visible = true ;
			}
		}

		private void botonTraspasar_Click(object sender, System.EventArgs e)
		{
			// Entramos en el modo de traspaso
			modoDeOperacion = ModoTraspasar ;

			panelFamilias.Enabled = false ;
			panelArticulos.Enabled = false ;
			panelLineas.Enabled = false ;
			
			panelTraspasar.Visible = true ;
			panelGeneral.Visible = false ;
			panelOpsConMesa.Visible = false ;
		}

		private void botonCancelarTraspasar_Click(object sender, System.EventArgs e)
		{
			// Salimos del modo traspaso
			modoDeOperacion = ModoNormal ;

			panelFamilias.Enabled = true ;
			panelArticulos.Enabled = true ;
			panelLineas.Enabled = true ;

			panelGeneral.Visible = true ;
			panelOpsConMesa.Visible = true ;
			panelTraspasar.Visible = false ;
			// Como no hemos hecho nada, no hay que cambiar nada en la visibilidad del panel
			// de opciones de mesa
            		
		}

		private void botonJuntar_Click(object sender, System.EventArgs e)
		{
			modoDeOperacion = ModoJuntar ;

			panelFamilias.Enabled = false ;
			panelArticulos.Enabled = false ;
			panelLineas.Enabled = false ;
			
			panelJuntar.Visible = true ;
			panelGeneral.Visible = false ;
			panelOpsConMesa.Visible = false ;
		}

		private void botonCancelarJuntar_Click(object sender, System.EventArgs e)
		{
			modoDeOperacion = ModoNormal ;
			panelFamilias.Enabled = true ;
			panelArticulos.Enabled = true ;
			panelLineas.Enabled = true ;

			panelGeneral.Visible = true ;
			panelOpsConMesa.Visible = true ;
			panelJuntar.Visible = false ;
		}

		private void botonSeparar_Click(object sender, System.EventArgs e)
		{
			modoDeOperacion = ModoSeparar ;
			
			panelFamilias.Enabled = false ;
			panelArticulos.Enabled = false ;
			panelLineas.Enabled = false ;
			
			panelSeparar.Visible = true ;
			panelGeneral.Visible = false ;
			panelOpsConMesa.Visible = false ;
		}

		private void botonCancelarSeparar_Click(object sender, System.EventArgs e)
		{
			modoDeOperacion = ModoNormal ;
			panelFamilias.Enabled = true ;
			panelArticulos.Enabled = true ;
			panelLineas.Enabled = true ;

			panelGeneral.Visible = true ;
			panelOpsConMesa.Visible = true ;
			panelSeparar.Visible = false ;
		}

        private void printTicket_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Creamos la fuente
            System.Drawing.Font fuente = new System.Drawing.Font("Arial", 12);

            // Generamos el ticket
            int linea = 0 ;

            // Cabecera
            e.Graphics.DrawString("Café Tr3ntatr3s", fuente, Brushes.Black, 0.0f, 16.0f*linea);
            linea++ ;
            e.Graphics.DrawString("-------------------------------------", fuente, Brushes.Black, 0.0f, 16.0f*linea);
            linea+=2 ;
            for ( int i = 0 ; i < printingPlaza.NumLineas ; i++ )
            {
                e.Graphics.DrawString( GestorArticulos.getArticulo( ((Linea)printingPlaza.Lineas[i]).CodArticulo ).Desc , fuente, Brushes.Black, 0.0f, 16.0f*linea);
                linea++;
            }

            

            printingPlaza.Clear();

        }

	}
}
