using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class Linea
	{
		private int codArticulo ;
		private bool ticado ;
		private bool pagado ;
		private bool invitado ;

		// Datos temporales
		private bool selected;



		public int CodArticulo
		{
			get
			{
				return codArticulo ;
			}
			set
			{
				codArticulo = value ;
			}
		}
		
		public bool Ticado
		{
			get
			{
				return ticado ;
			}
			set
			{
				ticado = value ;
			}
		}

		public bool Pagado
		{
			get
			{
				return pagado ;
			}
			set
			{
				pagado = value ;
			}
		}

		public bool Invitado
		{
			get
			{
				return invitado ;
			}
		}

		public bool Seleccionado
		{
			get
			{
				return selected ;
			}
			set
			{
				selected = value ;
			}
		}
			


		public Linea()
		{
			// 
			// TODO: Add constructor logic here
			//
		}


		public void Save(System.IO.FileStream file)
		{
			Util.Save(file, codArticulo);
			Util.Save(file, ticado) ;
			Util.Save(file, pagado);
			Util.Save(file, invitado);
		}

		public void Load(System.IO.FileStream file)
		{
			codArticulo = Util.LoadInt(file);
			ticado = Util.LoadBool(file);
			pagado = Util.LoadBool(file);
			invitado = Util.LoadBool(file);
		}

		public string getEstadoString()
		{
			if ( pagado )
			{
				return "P" ;
			}
			else if ( invitado )
			{
				return "I" ;
			}
			else if ( ticado )
			{
				return "-" ;
			}
			else
			{
				return " ";
			}
		}
	}
}
