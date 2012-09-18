using System;

namespace TPV
{
	/// <summary>
	/// Summary description for Familia.
	/// </summary>
	public class Familia
	{
        public const int L_Name = 32 ;
        public const int L_Desc = 256 ;
        public const int L_Image = 256 ;



        private int cod ; // Codigo de enlazamiento
        private String name ;
        private String desc ;
        private String image ;

		public Familia()
		{
            cod = -1 ;
			name = "" ;
            desc = "" ;
            image = "" ;
		}

        public void Load(System.IO.FileStream file)
        {
            Cod = Util.LoadInt(file);
            Name = Util.LoadString(file);
            Desc = Util.LoadString(file);
            Image = Util.LoadString(file);
        }

        public void Save(System.IO.FileStream file)
        {
            Util.Save(file, Cod);
            Util.Save(file, Name, Familia.L_Name);
            Util.Save(file, Desc, Familia.L_Desc);
            Util.Save(file, Image, Familia.L_Image);
        }

        public int Cod
        {
            get
            {
                return cod;
            }
            set
            {
                cod = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public String Desc
        {
            get
            {
                return desc;
            }
            set
            {
                desc = value;
            }
        }

        public String Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }


	}
}
