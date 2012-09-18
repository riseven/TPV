using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class GestorFamilias
	{
        //private static Familia[] familias = null ;
		private static System.Collections.ArrayList familias = new System.Collections.ArrayList() ;
        private static System.Data.DataTable dataTable = new System.Data.DataTable("Familias");
        private static int newCod = 1 ;

		public GestorFamilias()
		{
			// 
			// TODO: Add constructor logic here
			//
		}

        public static void AddFamilia(Familia f)
        {
			familias.Add(f);

            System.Data.DataRow myDataRow ;
            myDataRow = dataTable.NewRow();
            myDataRow["Codigo"] = f.Cod ;
            myDataRow["Nombre"] = f.Name ;
            myDataRow["Descripcion"] = f.Desc ;
            myDataRow["Imagen"] = f.Image ;
            dataTable.Rows.Add(myDataRow);
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
            myDataColumn.ColumnName = "Descripcion";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.String");
            myDataColumn.ColumnName = "Imagen";
            dataTable.Columns.Add(myDataColumn);
            
            dataTable.PrimaryKey = new System.Data.DataColumn[]{dataTable.Columns["Codigo"]} ;

        }


        public static System.Data.DataTable DataTable
        {
            get
            {
                return dataTable ;
            }
            set
            {
                dataTable = value ;
            }
        }

        public static void Save()
        {
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\familias.dat", System.IO.FileMode.OpenOrCreate);
            Util.Save(file, newCod);
            {
                Util.Save(file, familias.Count);
                for ( int i = 0 ; i < familias.Count ; i++ )
                {
					((Familia) familias[i]).Save(file);
                }
            }
            file.Close();
        }



        public static void Load()
        {
            System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\familias.dat", System.IO.FileMode.Open);
            newCod = Util.LoadInt(file);
            int l = Util.LoadInt(file);
            Clear();
            if ( l != 0 )
            {
                for ( int i = 0 ; i < l ; i++ )
                {
                    Familia f = new Familia();
                    f.Load(file);
                    AddFamilia(f);
                }
            }
            file.Close();
        }

        public static void Clear()
        {
            familias.Clear() ;
            dataTable.Rows.Clear();
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

		public static System.Collections.ArrayList Familias
		{
			get
			{
				return familias ;
			}
			set
			{
				familias = value ;
			}
		}
	}
}
