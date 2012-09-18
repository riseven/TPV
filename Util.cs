using System;

namespace TPV
{
	/// <summary>
	/// Summary description for Util.
	/// </summary>
	public class Util
	{
		public Util()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        public static Byte[] StringToBytes(String s, int maxLength)
        {
            Char[] cbuffer ;
            if ( s.Length > maxLength )
                cbuffer = s.ToCharArray(0, maxLength);
            else
                cbuffer = s.ToCharArray();

            Byte[] bbuffer = new Byte[cbuffer.Length * 2];
            for ( int i = 0 ; i < cbuffer.Length ; i++ )
            {
                Byte []temp = System.BitConverter.GetBytes(cbuffer[i]);
                bbuffer[i*2] = temp[0] ;
                bbuffer[i*2+1] = temp[1] ;
            }
            return bbuffer ;
        }

        public static String BytesToString(Byte[] bbuffer)
        {
            Char[] cbuffer = new Char[bbuffer.Length/2];
            for ( int i = 0 ; i < bbuffer.Length ; i+=2 )
            {
                cbuffer[i/2] = System.BitConverter.ToChar(bbuffer, i);
            }
            return new String(cbuffer);
        }

        public static void Save(System.IO.FileStream file, String s, int maxLength)
        {
            Byte[] bbuffer = StringToBytes(s, maxLength);
            Save(file, bbuffer.Length);
            file.Write(bbuffer, 0, bbuffer.Length);
        }

        public static void Save(System.IO.FileStream file, int i)
        {
            Byte[] bbuffer = System.BitConverter.GetBytes(i);
            file.Write(bbuffer, 0, bbuffer.Length);
        }

        public static void Save(System.IO.FileStream file, float f)
        {
            double d = (double)f;
            Byte[] bbuffer = System.BitConverter.GetBytes(d);
            file.Write(bbuffer, 0, bbuffer.Length);
        }

        public static void Save(System.IO.FileStream file, bool b)
        {
            Byte[] bbuffer = new Byte[1] ;
            bbuffer[0] = (Byte)(b?1:0) ;
            file.Write(bbuffer, 0, bbuffer.Length);
        }

        public static String LoadString(System.IO.FileStream file)
        {
            Int32 l = LoadInt(file);
            byte[] bbuffer = new Byte[l];
            file.Read(bbuffer, 0, l);
            return BytesToString(bbuffer);
        }

        public static int LoadInt(System.IO.FileStream file)
        {
            byte[] bbuffer = new Byte[4];
            file.Read(bbuffer, 0, 4);
            return System.BitConverter.ToInt32(bbuffer, 0);
        }

        public static float LoadFloat(System.IO.FileStream file)
        {
            byte[] bbuffer = new Byte[8] ;
            file.Read(bbuffer, 0, 8);
            return (float)System.BitConverter.ToDouble(bbuffer, 0);
        }

        public static bool LoadBool(System.IO.FileStream file)
        {
            byte[] bbuffer = new Byte[1] ;
            file.Read(bbuffer, 0, 1);
            return (bbuffer[0]!=0)?true:false ;
        }
	}
}
