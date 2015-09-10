using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3liiga
{
    class Pelaaja
    {
        private string etunimi;
        private string sukunimi;
        //private string kokoNimi;
        private string seura;
        private int siirtohinta;

        public string KokoNimi
        {
            get
            {
                string a = this.etunimi + " " + this.sukunimi + ", " + this.seura;
                return a;
            }
        }

        public Pelaaja(string enimi, string snimi, string seura, int hinta)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.seura = seura;
            this.siirtohinta = hinta;
        }

        // OLISI MYÖS MAHDOLLISTA YLIKIRJOITTAA TOSTRING, JOLLOIN EI TARVITSISI XAMLIIN DisplayMemberPath="KokoNimi"!!!!!!!!
    }
}
