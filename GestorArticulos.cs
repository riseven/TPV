using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class GestorArticulos
	{
		private static System.Collections.ArrayList articulos = new System.Collections.ArrayList();
        private static System.Data.DataTable dataTable = new System.Data.DataTable("Articulos");
        private static int newCod = 1 ;

        public GestorArticulos()
        {
        }

        public static void Init()
        {
            System.Data.DataColumn myDataColumn;

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Codigo";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Nombre";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Familia";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "PVP";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Margen";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Existencias";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Valor";
            dataTable.Columns.Add(myDataColumn);
        }

        public static System.Data.DataTable GetDataTable()
        {
            return dataTable ;
        }

        public static void AddArticulo(Articulo a)
        {
			articulos.Add(a);
            
            System.Data.DataRow myDataRow ;
            myDataRow = dataTable.NewRow();
            myDataRow["Codigo"] = a.Cod ;
            myDataRow["Nombre"] = a.Name ;
            myDataRow["Familia"] = GestorFamilias.DataTable.Rows.Find(a.Familia)["Nombre"] ;
            myDataRow["PVP"] = a.PvpConIva ;
            myDataRow["Margen"] = a.Margen ;
            myDataRow["Existencias"] = a.Existencias ;
            myDataRow["Valor"] = a.ValorVenta ;
            dataTable.Rows.Add(myDataRow);
            
        }

        public static void Clear()
        {
            articulos.Clear() ;
            dataTable.Rows.Clear();
        }

        public static void Save()
        {
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\articulos.dat", System.IO.FileMode.OpenOrCreate);
            Util.Save(file, newCod);
            Util.Save(file, articulos.Count);
            for ( int i = 0 ; i < articulos.Count ; i++ )
            {
                ((Articulo)articulos[i]).Save(file);
            }
            file.Close();
        }



        public static void Load()
        {
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\articulos.dat", System.IO.FileMode.Open);
            newCod = Util.LoadInt(file);
            int l = Util.LoadInt(file);
            Clear();
            for ( int i = 0 ; i < l ; i++ )
            {
                Articulo a = new Articulo();
                a.Load(file);
                AddArticulo(a);
            }
            file.Close();
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

		public static System.Collections.ArrayList Articulos
		{
			get
			{
				return articulos ;
			}
			set
			{
				articulos = value ;
			}
		}

		public static Articulo getArticulo(int cod)
		{
			foreach (object o in articulos)
			{
				if ( ((Articulo)o).Cod == cod )
				{
					return ((Articulo)o) ;
				}
			}
			return new Articulo();
		}
	}
}
