using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPV
{
	/// <summary>
	/// Summary description for DiseņoForm.
	/// </summary>
	public class DiseņoForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Panel panelDiseņo;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonNuevaMesa;
        private System.Windows.Forms.Button botonNuevoPuntoBarra;
        private System.Windows.Forms.Button botonQuitar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public DiseņoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            GestorPlazas.Load();
            for ( int i = 0 ; i < GestorPlazas.getNumPlazas(); i++ )
            {
                panelDiseņo.Controls.Add(GestorPlazas.getBotonDiseņo(i));
                GestorPlazas.getBotonDiseņo(i).MouseDown += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseDown);
                GestorPlazas.getBotonDiseņo(i).MouseMove += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseMove);
                GestorPlazas.getBotonDiseņo(i).Click += new System.EventHandler(botonesDiseņo_Click);
            }

            quitandoMesa = false ;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(DiseņoForm));
            this.panelDiseņo = new System.Windows.Forms.Panel();
            this.botonSalir = new System.Windows.Forms.Button();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonNuevaMesa = new System.Windows.Forms.Button();
            this.botonNuevoPuntoBarra = new System.Windows.Forms.Button();
            this.botonQuitar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelDiseņo
            // 
            this.panelDiseņo.AllowDrop = true;
            this.panelDiseņo.BackgroundImage = ((System.Drawing.Bitmap)(resources.GetObject("panelDiseņo.BackgroundImage")));
            this.panelDiseņo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelDiseņo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelDiseņo.Location = new System.Drawing.Point(8, 8);
            this.panelDiseņo.Name = "panelDiseņo";
            this.panelDiseņo.Size = new System.Drawing.Size(1000, 312);
            this.panelDiseņo.TabIndex = 19;
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(944, 328);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(64, 64);
            this.botonSalir.TabIndex = 20;
            this.botonSalir.Text = "SALIR";
            this.botonSalir.Click += new System.EventHandler(this.botonSalir_Click);
            // 
            // botonCancelar
            // 
            this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.botonCancelar.Location = new System.Drawing.Point(872, 328);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(64, 64);
            this.botonCancelar.TabIndex = 21;
            this.botonCancelar.Text = "CANCELAR";
            this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
            // 
            // botonNuevaMesa
            // 
            this.botonNuevaMesa.Location = new System.Drawing.Point(8, 328);
            this.botonNuevaMesa.Name = "botonNuevaMesa";
            this.botonNuevaMesa.Size = new System.Drawing.Size(64, 64);
            this.botonNuevaMesa.TabIndex = 22;
            this.botonNuevaMesa.Text = "NUEVA MESA";
            this.botonNuevaMesa.Click += new System.EventHandler(this.botonNuevaMesa_Click);
            // 
            // botonNuevoPuntoBarra
            // 
            this.botonNuevoPuntoBarra.Location = new System.Drawing.Point(80, 328);
            this.botonNuevoPuntoBarra.Name = "botonNuevoPuntoBarra";
            this.botonNuevoPuntoBarra.Size = new System.Drawing.Size(64, 64);
            this.botonNuevoPuntoBarra.TabIndex = 23;
            this.botonNuevoPuntoBarra.Text = "NUEVO PUNTO DE BARRA";
            this.botonNuevoPuntoBarra.Click += new System.EventHandler(this.botonNuevoPuntoBarra_Click);
            // 
            // botonQuitar
            // 
            this.botonQuitar.Location = new System.Drawing.Point(152, 328);
            this.botonQuitar.Name = "botonQuitar";
            this.botonQuitar.Size = new System.Drawing.Size(64, 64);
            this.botonQuitar.TabIndex = 24;
            this.botonQuitar.Text = "QUITAR";
            this.botonQuitar.Click += new System.EventHandler(this.botonQuitar_Click);
            // 
            // DiseņoForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 397);
            this.ControlBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.botonQuitar,
                                                                          this.botonNuevoPuntoBarra,
                                                                          this.botonNuevaMesa,
                                                                          this.botonCancelar,
                                                                          this.botonSalir,
                                                                          this.panelDiseņo});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiseņoForm";
            this.Text = "DiseņoForm";
            this.ResumeLayout(false);

        }
		#endregion


        private int clickX, clickY ;
        private void botonesDiseņo_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int nx, ny ;
            if ( e.Button.CompareTo( System.Windows.Forms.MouseButtons.Left )==0 )
            {
                nx = e.X - clickX + ((System.Windows.Forms.Button)sender).Left ;
                if ( nx < 0 ) nx = 0 ;
                if ( nx + ((System.Windows.Forms.Button)sender).Width > panelDiseņo.ClientSize.Width ) nx = panelDiseņo.ClientSize.Width - ((System.Windows.Forms.Button)sender).Width ;
                ((System.Windows.Forms.Button)sender).Left = nx ;

                ny = e.Y - clickY + ((System.Windows.Forms.Button)sender).Top ;
                if ( ny < 0 ) ny = 0 ;
                if ( ny + ((System.Windows.Forms.Button)sender).Height > panelDiseņo.ClientSize.Height ) ny = panelDiseņo.ClientSize.Height - ((System.Windows.Forms.Button)sender).Height ;
                ((System.Windows.Forms.Button)sender).Top = ny ;

                ((System.Windows.Forms.Button)sender).Refresh();
                GestorPlazas.setPlazaPos((System.Windows.Forms.Button)sender, nx, ny);
            }
        }

        private void botonesDiseņo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            clickX = e.X ;        
            clickY = e.Y ;
        }

        private void botonesDiseņo_Click(object sender, System.EventArgs e)
        {
			if ( quitandoMesa )
			{
				this.panelDiseņo.Controls.Remove((System.Windows.Forms.Control) sender);
				GestorPlazas.RemovePlaza((System.Windows.Forms.Button) sender);
			}
        }

        private void botonSalir_Click(object sender, System.EventArgs e)
        {
            GestorPlazas.Save();
            this.Close();
        }

        private void botonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void botonNuevaMesa_Click(object sender, System.EventArgs e)
        {
            Plaza p = new Plaza();
            p.Cod = GestorPlazas.NewCod++ ;
            p.isMesa = true ;
            p.X = 0 ; 
            p.Y = 0 ;
            GestorPlazas.AddPlaza(p);
            int i = GestorPlazas.getNumPlazas()-1;
            this.panelDiseņo.Controls.Add(GestorPlazas.getBotonDiseņo(i));
            GestorPlazas.getBotonDiseņo(i).MouseDown += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseDown);
            GestorPlazas.getBotonDiseņo(i).MouseMove += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseMove);
			GestorPlazas.getBotonDiseņo(i).Click += new System.EventHandler(botonesDiseņo_Click);
        }

        private void botonNuevoPuntoBarra_Click(object sender, System.EventArgs e)
        {
            Plaza p = new Plaza();
            p.Cod = GestorPlazas.NewCod++ ;
            p.isBarra = true ;
            p.X = 0 ; 
            p.Y = 0 ;
            GestorPlazas.AddPlaza(p);
            int i = GestorPlazas.getNumPlazas()-1;
            this.panelDiseņo.Controls.Add(GestorPlazas.getBotonDiseņo(i));
            GestorPlazas.getBotonDiseņo(i).MouseDown += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseDown);
            GestorPlazas.getBotonDiseņo(i).MouseMove += new System.Windows.Forms.MouseEventHandler(botonesDiseņo_MouseMove);        
			GestorPlazas.getBotonDiseņo(i).Click += new System.EventHandler(botonesDiseņo_Click);
        }

        

        private bool quitandoMesa;
        private void botonQuitar_Click(object sender, System.EventArgs e)
        {
            if ( quitandoMesa )
            {
                quitandoMesa = false ;
                this.botonCancelar.Visible = true ;
                this.botonSalir.Visible = true ;
                this.botonNuevaMesa.Visible = true ;
                this.botonNuevoPuntoBarra.Visible = true ;
                this.botonQuitar.Text = "QUITAR MESA" ;
                this.botonQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f);
            }
            else
            {
                quitandoMesa = true ;
                this.botonCancelar.Visible = false ;
                this.botonSalir.Visible = false ;
                this.botonNuevaMesa.Visible = false ;
                this.botonNuevoPuntoBarra.Visible = false ;
                this.botonQuitar.Text = "CANCELAR QUITAR MESA";
                this.botonQuitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.0f) ;
            }
        }
	}
}
