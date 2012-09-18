using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class Plaza
	{
		private const int EstadoActiva = 0 ;
		private const int EstadoGuardada = 1 ;
		private const int EstadoJuntada = 2 ;

        private int cod ;
        private int x, y ;
        private bool tipoMesa ;
		private int estado ;
		private int juntadaCon ;
		private System.Collections.ArrayList lineas = new System.Collections.ArrayList();

		private System.Data.DataTable dataLineas = new System.Data.DataTable("Pedidos de la mesa");
		

        

		public Plaza()
		{
            x = y = 0 ;
            tipoMesa = false ;
			estado = EstadoActiva ;
			juntadaCon = -1 ;

			//Generamos la tabla
			dataLineas.Columns.Clear();

			System.Data.DataColumn miColumna ;

			miColumna = new System.Data.DataColumn();
			miColumna.DataType = System.Type.GetType("System.String");
			miColumna.ColumnName = "Nombre" ;
			dataLineas.Columns.Add(miColumna);

			miColumna = new System.Data.DataColumn();
			miColumna.DataType = System.Type.GetType("System.String");
			miColumna.ColumnName = "Estado" ;
			dataLineas.Columns.Add(miColumna);

			miColumna = new System.Data.DataColumn();
			miColumna.DataType = System.Type.GetType("System.Double");
			miColumna.ColumnName = "Precio" ;
			dataLineas.Columns.Add(miColumna);



			
		}

        public int Cod
        {
            get
            {
                return cod ;
            }
            set
            {
                cod = value ;
            }
        }

        public int X
        {
            get
            {
                return x ;
            }
            set
            {
                x = value ;
            }
        }

        public int Y
        {
            get
            {
                return y ;
            }
            set
            {
                y = value ;
            }
        }

        public bool isMesa
        {
            get
            {
                return tipoMesa ;
            }
            set
            {
                tipoMesa = value ;
            }
        }

        public bool isBarra
        {
            get
            {
                return !tipoMesa ;
            }
            set
            {
                tipoMesa = !value ;
            }
        }

		public int NumLineas
		{
			get
			{
				return lineas.Count ;
			}
		}

		public System.Collections.ArrayList Lineas
		{
			get
			{
				return lineas ;
			}
		}

		public System.Data.DataTable DataLineas
		{
			get
			{
				return dataLineas ;
			}
		}

		public bool isActiva
		{
			get
			{
				return estado == EstadoActiva ;
			}
		}

		public bool isGuardada
		{
			get
			{
				return estado == EstadoGuardada ;
			}
		}

		public bool isJuntada
		{
			get
			{
				return estado == EstadoJuntada ;
			}
		}

		public int JuntadaCon
		{
			get
			{
				return juntadaCon ;
			}
		}

		public void Activar()
		{
			estado = EstadoActiva ;
			juntadaCon = -1 ;
		}

		public bool Guardar()
		{
			if ( lineas.Count > 0 )
			{
				return false ;
			}
			else
			{
				estado = EstadoGuardada ;
				return true ;
			}

			// No hay que hacer nada mas porque los botones los gestiona GestorPlazas
		}
        
		public void Save(System.IO.FileStream file)
        {
			Util.Save(file, cod);
            Util.Save(file, x);
            Util.Save(file, y);
            Util.Save(file, tipoMesa);
			Util.Save(file, estado);
			Util.Save(file, juntadaCon);
			Util.Save(file, lineas.Count);
			for ( int i = 0 ; i < lineas.Count ; i++ )
			{
				((Linea)lineas[i]).Save(file);
			}
        }

        public void Load(System.IO.FileStream file)
        {
			cod = Util.LoadInt(file);
            x = Util.LoadInt(file);
            y = Util.LoadInt(file);
            tipoMesa = Util.LoadBool(file);
			estado = Util.LoadInt(file);
			juntadaCon = Util.LoadInt(file);
			int numLineas = Util.LoadInt(file);
			lineas.Clear();
			for ( int i = 0 ; i < numLineas ; i++ )
			{
				Linea l = new Linea();
				l.Load(file);
				lineas.Add(l);

				System.Data.DataRow miDataRow = dataLineas.NewRow();
				Articulo a = GestorArticulos.getArticulo(l.CodArticulo);
				miDataRow["Nombre"] = a.Desc ;
				miDataRow["Precio"] = a.PvpConIva ;
				miDataRow["Estado"] = l.getEstadoString();
				dataLineas.Rows.Add(miDataRow);
			}
        }

		public void AddArticulo(int codigo)
		{
			Linea l = new Linea();
			l.CodArticulo = codigo ;
			lineas.Add(l);

			// Generamos la row
			System.Data.DataRow miDataRow = dataLineas.NewRow() ;
			Articulo a = GestorArticulos.getArticulo(codigo);
			miDataRow["Nombre"] = a.Desc ;
			miDataRow["Precio"] = a.PvpConIva ;
			miDataRow["Estado"] = l.getEstadoString();
			dataLineas.Rows.Add(miDataRow);

		}

		public void AddLinea(Linea l)
		{
			lineas.Add(l);

			// Generamos la row
			System.Data.DataRow miDataRow = dataLineas.NewRow() ;
			Articulo a = GestorArticulos.getArticulo(l.CodArticulo);
			miDataRow["Nombre"] = a.Desc ;
			miDataRow["Precio"] = a.PvpConIva ;
			miDataRow["Estado"] = l.getEstadoString();
			dataLineas.Rows.Add(miDataRow);
		}

		public void ResetSeleccion()
		{
			foreach (Object o in lineas)
			{
				((Linea)o).Seleccionado = false ;
			}
		}

		public bool isOcupada()
		{
			return lineas.Count != 0 ;
		}

		public bool isTicada()
		{
			if ( lineas.Count == 0 )
			{
				return false ;
			}
			foreach (object o in lineas)
			{
				if ( !((Linea) o).Ticado )
				{
					return false ;
				}
			}
			return true ;
		}

		public bool isTerminada()
		{
			if ( lineas.Count == 0 )
			{
				return false ;
			}
			foreach (object o in lineas)
			{
				if ( !(((Linea) o).Pagado || ((Linea) o).Invitado))
				{
					return false ;
				}
			}
			return true ;
		}

		public void ActualizarDataLineas()
		{
			for ( int i = 0 ; i < lineas.Count ; i++ )
			{
				dataLineas.Rows[i]["Estado"] = ((Linea)lineas[i]).getEstadoString();
			}
		}

		public void Clear()
		{
			lineas.Clear();
			dataLineas.Clear();
		}

		public void EliminarLinea(int index)
		{
			lineas.RemoveAt(index);
			dataLineas.Rows.RemoveAt(index);
		}

		public void Juntar(int codMesa)
		{
			estado = EstadoJuntada ;
			juntadaCon = codMesa ;
		}
	}
}
