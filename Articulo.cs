using System;

namespace TPV
{
	/// <summary>
	/// 
	/// </summary>
	public class Articulo
	{
        public const int L_Name = 32 ;
        public const int L_Desc = 256 ;
        public const int L_Image = 256 ;


        private int cod ;
        private String name ;
        private String desc ;
        private int familia ;
        private String image ;
        private bool mostrar_ventas;
        
        private int iva ;//ref
        private float costo_s ;
        private float costo_c ;
        private float pvp_s ;
        private float pvp_c ;
        private int margen ; //0..100

        private int existencias ;
        private int stock_inicial ;
        private int stock_minimo ;
        private float valor_costo ;
        private float valor_venta ;

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

        public String Name
        {
            get
            {
                return name ;
            }
            set
            {
                name = value ;
            }
        }

        public String Desc
        {
            get
            {
                return desc ;
            }
            set
            {
                desc = value ;
            }
        }

        public int Familia
        {
            get
            {
                return familia ;
            }
            set
            {
                familia = value ;
            }
        }

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value ;
            }
        }

        public bool MostrarEnVentas
        {
            get
            {
                return mostrar_ventas ;
            }
            set
            {
                mostrar_ventas = value ;
            }
        }

        public int Iva
        {
            get
            {
                return iva ;
            }
            set
            {
                iva = value ;
            }
        }

        public float CostoSinIva
        {
            get
            {
                return costo_s ;
            }
            set
            {
                costo_s = value ;
            }
        }

        public float CostoConIva
        {
            get
            {
                return costo_c ;
            }
            set
            {
                costo_c = value ;
            }
        }

        public float PvpSinIva
        {
            get
            {
                return pvp_s ;
            }
            set
            {
                pvp_s = value ;
            }
        }

        public float PvpConIva
        {
            get
            {
                return pvp_c ;
            }
            set
            {
                pvp_c = value ;
            }
        }

        public int Margen
        {
            get
            {
                return margen ;
            }
            set
            {
                margen = value ;
            }
        }

        public int Existencias
        {
            get
            {
                return existencias ;
            }
            set
            {
                existencias = value ;
            }
        }

        public int StockInicial
        {
            get
            {
                return stock_inicial ;
            }
            set
            {
                stock_inicial = value ;
            }
        }

        public int StockMinimo
        {
            get
            {
                return stock_minimo ;
            }
            set
            {
                stock_minimo = value ;
            }
        }

        public float ValorCosto
        {
            get
            {
                return valor_costo ;
            }
            set
            {
                valor_costo = value ;
            }
        }

        public float ValorVenta
        {
            get
            {
                return valor_venta ;
            }
            set
            {
                valor_venta = value ;
            }
        }

		public Articulo()
		{
            cod = -1 ;
			name = "" ;
            desc = "" ;
            familia = -1 ;
            image = "" ;
            mostrar_ventas = false ;

            iva = 0 ; // Iva standar
            costo_s = 0.0f ;
            costo_c = 0.0f ;
            pvp_s = 0.0f ;
            pvp_c = 0.0f ;
            margen = 0 ;

            existencias = 0 ;
            stock_inicial = 0 ;
            stock_minimo = 0 ;
            valor_costo = 0.0f ;
            valor_venta = 0.0f ;
		}

        public void Load(System.IO.FileStream file)
        {
            cod = Util.LoadInt(file);
            name = Util.LoadString(file);
            desc = Util.LoadString(file);
            familia = Util.LoadInt(file);
            image = Util.LoadString(file);
            mostrar_ventas = Util.LoadBool(file);

            iva = Util.LoadInt(file);
            costo_s = Util.LoadFloat(file);
            costo_c = Util.LoadFloat(file);
            pvp_s = Util.LoadFloat(file);
            pvp_c = Util.LoadFloat(file);
            margen = Util.LoadInt(file);

            existencias = Util.LoadInt(file);
            stock_inicial = Util.LoadInt(file);
            stock_minimo = Util.LoadInt(file);
            valor_costo = Util.LoadFloat(file);
            valor_venta = Util.LoadFloat(file);
        }

        public void Save(System.IO.FileStream file)
        {
            Util.Save(file, cod);
            Util.Save(file, name, L_Name);
            Util.Save(file, desc, L_Desc);
            Util.Save(file, familia);
            Util.Save(file, image, L_Image);
            Util.Save(file, mostrar_ventas);

            Util.Save(file, iva);
            Util.Save(file, costo_s);
            Util.Save(file, costo_c);
            Util.Save(file, pvp_s);
            Util.Save(file, pvp_c);
            Util.Save(file, margen);

            Util.Save(file, existencias);
            Util.Save(file, stock_inicial);
            Util.Save(file, stock_minimo);
            Util.Save(file, valor_costo);
            Util.Save(file, valor_venta);
        }

	}
}
