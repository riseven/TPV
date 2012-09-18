using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace TPV
{
	/// <summary>
	/// Summary description for IvasForm.
	/// </summary>
	public class IvasForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbox_Iva1;
        private System.Windows.Forms.TextBox tbox_Iva2;
        private System.Windows.Forms.TextBox tbox_Iva3;
        private System.Windows.Forms.TextBox tbox_Iva4;
        private System.Windows.Forms.TextBox tbox_Iva5;
        private System.Windows.Forms.Button botonAceptar;
        private System.Windows.Forms.Button botonCancelar;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public IvasForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			GestorIvas.Load();
            tbox_Iva1.Text = Convert.ToString(GestorIvas.DataTable.Rows.Find(1)["Porcentaje"]) ;
            tbox_Iva2.Text = Convert.ToString(GestorIvas.DataTable.Rows.Find(2)["Porcentaje"]) ;
            tbox_Iva3.Text = Convert.ToString(GestorIvas.DataTable.Rows.Find(3)["Porcentaje"]) ;
            tbox_Iva4.Text = Convert.ToString(GestorIvas.DataTable.Rows.Find(4)["Porcentaje"]) ;
            tbox_Iva5.Text = Convert.ToString(GestorIvas.DataTable.Rows.Find(5)["Porcentaje"]) ;

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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbox_Iva1 = new System.Windows.Forms.TextBox();
			this.tbox_Iva2 = new System.Windows.Forms.TextBox();
			this.tbox_Iva3 = new System.Windows.Forms.TextBox();
			this.tbox_Iva4 = new System.Windows.Forms.TextBox();
			this.tbox_Iva5 = new System.Windows.Forms.TextBox();
			this.botonAceptar = new System.Windows.Forms.Button();
			this.botonCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IVA 1";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "IVA 2";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "IVA 3";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 96);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "IVA 4";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 120);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 16);
			this.label5.TabIndex = 4;
			this.label5.Text = "IVA 5";
			// 
			// tbox_Iva1
			// 
			this.tbox_Iva1.Location = new System.Drawing.Point(56, 24);
			this.tbox_Iva1.Name = "tbox_Iva1";
			this.tbox_Iva1.TabIndex = 5;
			this.tbox_Iva1.Text = "";
			// 
			// tbox_Iva2
			// 
			this.tbox_Iva2.Location = new System.Drawing.Point(56, 48);
			this.tbox_Iva2.Name = "tbox_Iva2";
			this.tbox_Iva2.TabIndex = 6;
			this.tbox_Iva2.Text = "";
			// 
			// tbox_Iva3
			// 
			this.tbox_Iva3.Location = new System.Drawing.Point(56, 72);
			this.tbox_Iva3.Name = "tbox_Iva3";
			this.tbox_Iva3.TabIndex = 7;
			this.tbox_Iva3.Text = "";
			// 
			// tbox_Iva4
			// 
			this.tbox_Iva4.Location = new System.Drawing.Point(56, 96);
			this.tbox_Iva4.Name = "tbox_Iva4";
			this.tbox_Iva4.TabIndex = 8;
			this.tbox_Iva4.Text = "";
			// 
			// tbox_Iva5
			// 
			this.tbox_Iva5.Location = new System.Drawing.Point(56, 120);
			this.tbox_Iva5.Name = "tbox_Iva5";
			this.tbox_Iva5.TabIndex = 9;
			this.tbox_Iva5.Text = "";
			// 
			// botonAceptar
			// 
			this.botonAceptar.Location = new System.Drawing.Point(104, 152);
			this.botonAceptar.Name = "botonAceptar";
			this.botonAceptar.Size = new System.Drawing.Size(64, 64);
			this.botonAceptar.TabIndex = 10;
			this.botonAceptar.Text = "OK";
			this.botonAceptar.Click += new System.EventHandler(this.botonAceptar_Click);
			// 
			// botonCancelar
			// 
			this.botonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.botonCancelar.Location = new System.Drawing.Point(8, 152);
			this.botonCancelar.Name = "botonCancelar";
			this.botonCancelar.Size = new System.Drawing.Size(64, 64);
			this.botonCancelar.TabIndex = 11;
			this.botonCancelar.Text = "CANCELAR";
			this.botonCancelar.Click += new System.EventHandler(this.botonCancelar_Click);
			// 
			// IvasForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(176, 221);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.botonCancelar,
																		  this.botonAceptar,
																		  this.tbox_Iva5,
																		  this.tbox_Iva4,
																		  this.tbox_Iva3,
																		  this.tbox_Iva2,
																		  this.tbox_Iva1,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IvasForm";
			this.Text = "Tipos de IVA";
			this.ResumeLayout(false);

		}
		#endregion

        private void botonAceptar_Click(object sender, System.EventArgs e)
        {
            GestorIvas.SetIva(1, Convert.ToInt32(tbox_Iva1.Text));
            GestorIvas.SetIva(2, Convert.ToInt32(tbox_Iva2.Text));
            GestorIvas.SetIva(3, Convert.ToInt32(tbox_Iva3.Text));
            GestorIvas.SetIva(4, Convert.ToInt32(tbox_Iva4.Text));
            GestorIvas.SetIva(5, Convert.ToInt32(tbox_Iva5.Text));

			GestorIvas.Save();
			
            this.Close();
        }

        private void botonCancelar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }


	}
}
