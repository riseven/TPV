using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPV
{
	/// <summary>
	/// Summary description for FamiliasForm.
	/// </summary>
	public class FamiliasForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.TextBox tbox_Cod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button botonNuevo;
        private System.Windows.Forms.Panel panelEdicion;
        private System.Windows.Forms.Button botonSalir;
        private System.Windows.Forms.Button botonGrabar;
        private System.Windows.Forms.TextBox tbox_Name;
        private System.Windows.Forms.TextBox tbox_Desc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbox_Image;
        private System.Windows.Forms.Button botonImage;
        private System.Windows.Forms.OpenFileDialog imageFileDialog;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.DataGrid dataGrid;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FamiliasForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            
            dataGrid.SetDataBinding(GestorFamilias.DataTable, null);
            GestorFamilias.Load();
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
            this.tbox_Cod = new System.Windows.Forms.TextBox();
            this.panelEdicion = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.botonImage = new System.Windows.Forms.Button();
            this.tbox_Image = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbox_Desc = new System.Windows.Forms.TextBox();
            this.tbox_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.botonNuevo = new System.Windows.Forms.Button();
            this.botonGrabar = new System.Windows.Forms.Button();
            this.imageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.panelEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // botonSalir
            // 
            this.botonSalir.Location = new System.Drawing.Point(944, 648);
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(64, 64);
            this.botonSalir.TabIndex = 1;
            this.botonSalir.Text = "SALIR";
            this.botonSalir.Click += new System.EventHandler(this.botonSalirAplicacion_Click);
            // 
            // tbox_Cod
            // 
            this.tbox_Cod.Location = new System.Drawing.Point(96, 8);
            this.tbox_Cod.Name = "tbox_Cod";
            this.tbox_Cod.ReadOnly = true;
            this.tbox_Cod.Size = new System.Drawing.Size(48, 20);
            this.tbox_Cod.TabIndex = 2;
            this.tbox_Cod.Text = "";
            // 
            // panelEdicion
            // 
            this.panelEdicion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelEdicion.Controls.AddRange(new System.Windows.Forms.Control[] {
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
            this.panelEdicion.Enabled = false;
            this.panelEdicion.Location = new System.Drawing.Point(8, 80);
            this.panelEdicion.Name = "panelEdicion";
            this.panelEdicion.Size = new System.Drawing.Size(1000, 176);
            this.panelEdicion.TabIndex = 3;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(528, 104);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(64, 64);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 11;
            this.pictureBox.TabStop = false;
            // 
            // botonImage
            // 
            this.botonImage.Location = new System.Drawing.Point(488, 104);
            this.botonImage.Name = "botonImage";
            this.botonImage.Size = new System.Drawing.Size(24, 24);
            this.botonImage.TabIndex = 10;
            this.botonImage.Text = "...";
            this.botonImage.Click += new System.EventHandler(this.botonImage_Click);
            // 
            // tbox_Image
            // 
            this.tbox_Image.Location = new System.Drawing.Point(96, 104);
            this.tbox_Image.Name = "tbox_Image";
            this.tbox_Image.ReadOnly = true;
            this.tbox_Image.Size = new System.Drawing.Size(384, 20);
            this.tbox_Image.TabIndex = 9;
            this.tbox_Image.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Imagen";
            // 
            // tbox_Desc
            // 
            this.tbox_Desc.Location = new System.Drawing.Point(96, 72);
            this.tbox_Desc.Name = "tbox_Desc";
            this.tbox_Desc.Size = new System.Drawing.Size(896, 20);
            this.tbox_Desc.TabIndex = 7;
            this.tbox_Desc.Text = "";
            // 
            // tbox_Name
            // 
            this.tbox_Name.Location = new System.Drawing.Point(96, 40);
            this.tbox_Name.Name = "tbox_Name";
            this.tbox_Name.Size = new System.Drawing.Size(384, 20);
            this.tbox_Name.TabIndex = 6;
            this.tbox_Name.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre corto";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cod";
            // 
            // botonNuevo
            // 
            this.botonNuevo.Location = new System.Drawing.Point(8, 8);
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(64, 64);
            this.botonNuevo.TabIndex = 4;
            this.botonNuevo.Text = "NUEVO";
            this.botonNuevo.Click += new System.EventHandler(this.botonNuevo_Click);
            // 
            // botonGrabar
            // 
            this.botonGrabar.Enabled = false;
            this.botonGrabar.Location = new System.Drawing.Point(80, 8);
            this.botonGrabar.Name = "botonGrabar";
            this.botonGrabar.Size = new System.Drawing.Size(64, 64);
            this.botonGrabar.TabIndex = 5;
            this.botonGrabar.Text = "GRABAR";
            this.botonGrabar.Click += new System.EventHandler(this.botonGrabar_Click);
            // 
            // imageFileDialog
            // 
            this.imageFileDialog.Title = "Selecciona la imagen para la familia";
            // 
            // dataGrid
            // 
            this.dataGrid.CaptionVisible = false;
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(8, 264);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(1000, 376);
            this.dataGrid.TabIndex = 6;
            // 
            // FamiliasForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1016, 743);
            this.ControlBox = false;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.dataGrid,
                                                                          this.botonGrabar,
                                                                          this.botonNuevo,
                                                                          this.panelEdicion,
                                                                          this.botonSalir});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FamiliasForm";
            this.Text = "Control de Familias de Articulos";
            this.panelEdicion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        private void botonSalirAplicacion_Click(object sender, System.EventArgs e)
        {
            GestorFamilias.Save();
            this.Close();
        }

        private void botonNuevo_Click(object sender, System.EventArgs e)
        {
            panelEdicion.Enabled = true ;
            botonNuevo.Enabled = false ;
            botonGrabar.Enabled = true ;
            botonSalir.Enabled = false ;
            

            tbox_Cod.Text = Convert.ToString(GestorFamilias.NewCod);
            tbox_Name.Text = "";
            tbox_Desc.Text = "";
            tbox_Image.Text = "";
            pictureBox.Image = null ;
        }

        private void botonGrabar_Click(object sender, System.EventArgs e)
        {
            panelEdicion.Enabled = false ;
            botonNuevo.Enabled = true ;
            botonGrabar.Enabled = false ;
            botonSalir.Enabled = true ;



            Familia f = new Familia();
            f.Cod = Convert.ToInt32(tbox_Cod.Text) ;
            f.Name = tbox_Name.Text ;
            f.Desc = tbox_Desc.Text ;
            f.Image = tbox_Image.Text ;
            GestorFamilias.AddFamilia(f);

            GestorFamilias.NewCod++ ;
            

        }



        private void botonImage_Click(object sender, System.EventArgs e)
        {
            if ( imageFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                tbox_Image.Text = imageFileDialog.FileName ;
                pictureBox.Image = Image.FromFile(imageFileDialog.FileName);
            }
        }

	}
}
