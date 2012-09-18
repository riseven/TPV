using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class GestorPlazas
	{
        private static int newCod = 1 ;
        private static System.Collections.ArrayList plazas = new System.Collections.ArrayList();
        private static System.Collections.ArrayList botonesDiseño = new System.Collections.ArrayList() ;
		private static System.Collections.ArrayList botonesTPV = new System.Collections.ArrayList();
        
		public GestorPlazas()
		{
            
		}

        public static void Init()
        {
        }

        public static void AddPlaza(Plaza p)
        {
            plazas.Add(p);

            // Creamos el boton de diseño
            System.Windows.Forms.Button b = new System.Windows.Forms.Button();
            b.Location = new System.Drawing.Point(p.X,p.Y);
            if ( p.isBarra )
            {
                b.Size = new System.Drawing.Size(32,32);
            }
            else
            {
                b.Size = new System.Drawing.Size(40,40);
            }
            b.Text = "" ;
            b.Name = "BotonDiseño" + plazas.IndexOf(p).ToString() ;
			b.BackColor = System.Drawing.Color.SlateBlue ;
            botonesDiseño.Add(b);

			b = new System.Windows.Forms.Button();
			b.Location = new System.Drawing.Point(p.X, p.Y);
			if ( p.isBarra )
			{
				b.Size = new System.Drawing.Size(32,32);
			}
			else
			{
				b.Size = new System.Drawing.Size(40,40);
			}
			b.Text = "" ;
			b.Name = "BotonTPV" + plazas.IndexOf(p).ToString() ;
			botonesTPV.Add(b);
			ActualizarBotones();
        }

        public static void Clear()
        {
            plazas.Clear(); 
            botonesDiseño.Clear();
			botonesTPV.Clear();
        }

        public static void Save()
        {
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\plazas.dat", System.IO.FileMode.OpenOrCreate);
            Util.Save(file, newCod);
            Util.Save(file, plazas.Count);
            for ( int i = 0 ; i < plazas.Count ; i++ )
            {
                ((Plaza) plazas[i]).Save(file);
            }
            file.Close();
        }



        public static void Load()
        {
            Clear();
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\plazas.dat", System.IO.FileMode.Open);
            newCod = Util.LoadInt(file);
            int l = Util.LoadInt(file);
            if ( l != 0 )
            {
				Plaza p ;
                for ( int i = 0 ; i < l ; i++ )
                {
                    p = new Plaza();
                    p.Load(file);
                    AddPlaza(p);
                }
            }
            file.Close();
        }

        public static int getNumPlazas()
        {
            return plazas.Count ;
        }

        public static System.Windows.Forms.Button getBotonDiseño(int index)
        {
            return (System.Windows.Forms.Button) botonesDiseño[index] ;
        }

		public static System.Windows.Forms.Button getBotonTPV(int index)
		{
			return (System.Windows.Forms.Button) botonesTPV[index] ;
		}

        public static void setPlazaPos(System.Windows.Forms.Button b, int _x, int _y)
        {
            int i = botonesDiseño.IndexOf(b);
            ((Plaza)plazas[i]).X = _x ;
            ((Plaza)plazas[i]).Y = _y ;
        }

        public static void RemovePlaza(System.Windows.Forms.Button b)
        {
            int i = botonesDiseño.IndexOf(b);
            plazas.RemoveAt(i);
            botonesDiseño.RemoveAt(i);
        }

        public static int NewCod
        {
            get
            {
                return newCod ;
            }
            set
            {
                newCod = value ;
            }
        }

		public static System.Collections.ArrayList Plazas
		{
			get
			{
				return plazas ;
			}
		}

		public static Plaza getPlaza(System.Windows.Forms.Button b)
		{
			int i ;
			i = GestorPlazas.botonesDiseño.IndexOf(b);
			if ( i == -1 )
			{
				i = GestorPlazas.botonesTPV.IndexOf(b);
			}
			return ((Plaza)plazas[i]) ;
		}

		public static System.Data.DataTable getDataLineas(int codigo)
		{
			return getPlaza(codigo).DataLineas ;
		}

		public static Plaza getPlaza(int codigo)
		{
			foreach (object o in plazas)
			{
				if (((Plaza) o).Cod == codigo )
				{
					return ((Plaza)o);
				}
			}
			return new Plaza();
		}

		public static bool GuardarPlaza(int codigo)
		{
			// Guardamos la plaza
			foreach (object o in plazas)
			{
				Plaza p = ((Plaza)o) ;
				if ( p.Cod == codigo )
				{
					if ( p.Guardar() )
					{
						// Ahora que ya hemos conseguido guardar la plaza, cambiamos los botones
						int index = plazas.IndexOf(p) ;
						((System.Windows.Forms.Button)botonesTPV[index]).Visible = false ;
                        return true ;
					}
					else
					{
						return false ;
					}
				}
			}
			return false ;
		}

		public static void ActivarPlaza(int codigo)
		{
			foreach (object o in plazas)
			{
				Plaza p = ((Plaza)o);
				if ( p.Cod == codigo )
				{
					int i = plazas.IndexOf(p);
					((Plaza)o).Activar();
					((System.Windows.Forms.Button)botonesTPV[i]).Enabled = false ;
					((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.DimGray ;
					return ;
				}
			}
		}
					


		public static void StartModoSacarMesa()
		{
			for ( int i = 0 ; i < plazas.Count ; i++ )
			{
				Plaza p = ((Plaza) plazas[i]) ;
				if ( p.isGuardada )
				{
					((System.Windows.Forms.Button)botonesTPV[i]).Visible = true ;
					((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.SlateBlue ;
				}
				else
				{
					((System.Windows.Forms.Button)botonesTPV[i]).Enabled = false ;
					((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.DimGray ;
				}
			}
		}

		public static void StopModoSacarMesa()
		{
			for ( int i = 0 ; i < plazas.Count ; i++ )
			{
				((System.Windows.Forms.Button)botonesTPV[i]).Enabled = true ;
			}
			ActualizarBotones();
		}

		public static void ActualizarBotones()
		{
			for ( int i = 0 ; i < plazas.Count ; i++ )
			{
				Plaza p = ((Plaza) plazas[i]) ;
				if ( p.isGuardada )
				{
					((System.Windows.Forms.Button)botonesTPV[i]).Visible = false ;
				}
				else if ( p.isJuntada )
				{
					((System.Windows.Forms.Button)botonesTPV[i]).Visible = true ;
					((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.Gray ;
				}
				else if ( p.isActiva )
				{
					((System.Windows.Forms.Button)botonesTPV[i]).Visible = true ;
					if ( p.isTerminada() )
					{
						((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.OrangeRed ;
					}
					else if ( p.isTicada() )
					{
						((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.Yellow ;
					}
					else if ( p.isOcupada() )
					{
						((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.SlateBlue ;
					}
					else
					{
						((System.Windows.Forms.Button)botonesTPV[i]).BackColor = System.Drawing.Color.Lime ;
					}
				}
			}
		}

	}
}
