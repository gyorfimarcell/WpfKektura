using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfKektura
{
    public class Szakasz
    {
        string leiras;
        double tavolsag;
        int magassag;
        int ido;

        public Szakasz(string csvSor)
        {
            string[] mezok = csvSor.Split(';');
            this.leiras = mezok[0];
            this.tavolsag = Convert.ToDouble(mezok[1]);
            this.magassag = Convert.ToInt32(mezok[2]);
            this.ido = Convert.ToInt32(mezok[3]);
        }

        public Szakasz(string leiras, float tavolsag, int magassag, int ido)
        {
            this.leiras = leiras;
            this.tavolsag = tavolsag;
            this.magassag = magassag;
            this.ido = ido;
        }

        public string Leiras { get => leiras; }
        public double Tavolsag { get => tavolsag;  }
        public int Magassag { get => magassag; }
        public int Ido { get => ido; }

        public string Nehezseg()
        {
            if (tavolsag <= 5)
            {
                return "Könnyű";
            }
            else if (tavolsag < 10)
            {
                return "Közepes";
            }
            else
            {
                return "Nehéz";
            }
        }
    }
}
