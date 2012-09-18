using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TPV
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button botonSalirAplicacion;
        private System.Windows.Forms.Button botonFamilias;
        private System.Windows.Forms.Button botonArticulos;
        private System.Windows.Forms.Button botonIVA;
        private System.Windows.Forms.Button botonTPV;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button botonDiseño;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			/*
			GestorIvas.Save();
			GestorFamilias.Save();
			GestorArticulos.Save();
			GestorPlazas.Save();
            */
			
            GestorIvas.Init();
            GestorFamilias.Init();
            GestorArticulos.Init();
			GestorPlazas.Init();

			GestorIvas.Load();
			GestorFamilias.Load();
			GestorArticulos.Load();
			GestorPlazas.Load();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.botonSalirAplicacion = new System.Windows.Forms.Button();
            this.botonFamilias = new System.Windows.Forms.Button();
            this.botonArticulos = new System.Windows.Forms.Button();
            this.botonIVA = new System.Windows.Forms.Button();
            this.botonTPV = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.botonDiseño = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonSalirAplicacion
            // 
            this.botonSalirAplicacion.Location = new System.Drawing.Point(944, 648);
            this.botonSalirAplicacion.Name = "botonSalirAplicacion";
            this.botonSalirAplicacion.Size = new System.Drawing.Size(64, 64);
            this.botonSalirAplicacion.TabIndex = 0;
            this.botonSalirAplicacion.Text = "SALIR";
            this.botonSalirAplicacion.Click += new System.EventHandler(this.botonSalirAplicacion_Click);
            // 
            // botonFamilias
            // 
            this.botonFamilias.Location = new System.Drawing.Point(8, 8);
            this.botonFamilias.Name = "botonFamilias";
            this.botonFamilias.Size = new System.Drawing.Size(64, 64);
            this.botonFamilias.TabIndex = 1;
            this.botonFamilias.Text = "FAMILIAS";
            this.botonFamilias.Click += new System.EventHandler(this.button1_Click);
            // 
            // botonArticulos
            // 
            this.botonArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonArticulos.Location = new System.Drawing.Point(80, 8);
            this.botonArticulos.Name = "botonArticulos";
            this.botonArticulos.Size = new System.Drawing.Size(64, 64);
            this.botonArticulos.TabIndex = 2;
            this.botonArticulos.Text = "ARTICULOS";
            this.botonArticulos.Click += new System.EventHandler(this.botonArticulos_Click);
            // 
            // botonIVA
            // 
            this.botonIVA.Location = new System.Drawing.Point(8, 80);
            this.botonIVA.Name = "botonIVA";
            this.botonIVA.Size = new System.Drawing.Size(64, 64);
            this.botonIVA.TabIndex = 3;
            this.botonIVA.Text = "IVA";
            this.botonIVA.Click += new System.EventHandler(this.botonIVA_Click);
            // 
            // botonTPV
            // 
            this.botonTPV.Location = new System.Drawing.Point(8, 152);
            this.botonTPV.Name = "botonTPV";
            this.botonTPV.Size = new System.Drawing.Size(64, 64);
            this.botonTPV.TabIndex = 4;
            this.botonTPV.Text = "TPV";
            this.botonTPV.Click += new System.EventHandler(this.botonTPV_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "TPV";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(280, 112);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "textBox1";
            // 
            // botonDiseño
            // 
            this.botonDiseño.Location = new System.Drawing.Point(80, 152);
            this.botonDiseño.Name = "botonDiseño";
            this.botonDiseño.Size = new System.Drawing.Size(64, 64);
            this.botonDiseño.TabIndex = 7;
            this.botonDiseño.Text = "DISEÑO";
            this.botonDiseño.Click += new System.EventHandler(this.botonDiseño_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 719);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.botonDiseño,
                                                                          this.textBox1,
                                                                          this.button1,
                                                                          this.botonTPV,
                                                                          this.botonIVA,
                                                                          this.botonArticulos,
                                                                          this.botonFamilias,
                                                                          this.botonSalirAplicacion});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cafe Trentatres";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

        private void botonSalirAplicacion_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            FamiliasForm familiasForm = new FamiliasForm();
            familiasForm.ShowDialog();
        }

        private void botonArticulos_Click(object sender, System.EventArgs e)
        {
            ArticulosForm articulosForm = new ArticulosForm();
            articulosForm.ShowDialog();
        
        }

        private void botonIVA_Click(object sender, System.EventArgs e)
        {
            IvasForm ivasForm = new IvasForm() ;
            ivasForm.ShowDialog();
        }

        private void botonTPV_Click(object sender, System.EventArgs e)
        {
            TpvForm tpvForm = new TpvForm() ;
            tpvForm.ShowDialog();
        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            this.printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //e.Graphics.FillEllipse(Brushes.Red, 10, 10, 50, 50);
            e.Graphics.DrawString("Café Tr3ntatr3s", new System.Drawing.Font("Arial", 12), Brushes.Black, 0.0f, 0.0f);
            e.HasMorePages = false ;
        }

        private void botonDiseño_Click(object sender, System.EventArgs e)
        {
            DiseñoForm diseñoForm = new DiseñoForm();
            diseñoForm.ShowDialog();
        }
	}
}
