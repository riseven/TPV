using System;

namespace TPV
{
	/// <summary>
	/// Summary description for GestorIvas.
	/// </summary>
    public class GestorIvas
    {
        private static int[] ivas = new int[5]{0,0,0,0,0}; // 5 Ivas
        private static System.Data.DataTable dataTable;

		public GestorIvas()
		{
			//
			// TODO: Add constructor logic here
			//
		}


        public static void SetIva(int cod, int porcentaje)
        {
            ivas[cod-1] = porcentaje ;
            dataTable.Rows.Find(cod)["Porcentaje"] = porcentaje ;
        }


        public static void Init()
        {
            dataTable = new System.Data.DataTable("Ivas");
            System.Data.DataColumn myDataColumn;

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Codigo";
            dataTable.Columns.Add(myDataColumn);

            myDataColumn = new System.Data.DataColumn(); 
            myDataColumn.DataType = System.Type.GetType("System.Int32");
            myDataColumn.ColumnName = "Porcentaje";
            dataTable.Columns.Add(myDataColumn);

            dataTable.PrimaryKey = new System.Data.DataColumn[]{dataTable.Columns["Codigo"]} ;

            System.Data.DataRow dataRow ;
            for ( int i = 0 ; i < 5 ; i++ )
            {
                dataRow = dataTable.NewRow();
                dataRow["Codigo"] = i+1 ;
                dataRow["Porcentaje"] = 0 ;
                dataTable.Rows.Add(dataRow);
            }
        }

        public static System.Data.DataTable DataTable
        {
            get
            {
                return dataTable ;
            }
        }

		public static void Save()
		{
			System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\ivas.dat", System.IO.FileMode.Create);
			Util.Save(file, ivas[0]);
			Util.Save(file, ivas[1]);
			Util.Save(file, ivas[2]);
			Util.Save(file, ivas[3]);
			Util.Save(file, ivas[4]);
			file.Close();
		} 

		public static void Load()
		{
			System.IO.FileStream file = new System.IO.FileStream("C:\\TPV\\ivas.dat", System.IO.FileMode.Open);
			ivas[0] = Util.LoadInt(file);
			ivas[1] = Util.LoadInt(file);
			ivas[2] = Util.LoadInt(file);
			ivas[3] = Util.LoadInt(file);
			ivas[4] = Util.LoadInt(file);

			dataTable.Rows.Find(1)["Porcentaje"] = ivas[0] ;
			dataTable.Rows.Find(2)["Porcentaje"] = ivas[1] ;
			dataTable.Rows.Find(3)["Porcentaje"] = ivas[2] ;
			dataTable.Rows.Find(4)["Porcentaje"] = ivas[3] ;
			dataTable.Rows.Find(5)["Porcentaje"] = ivas[4] ;
			file.Close();
		}
	}
}
