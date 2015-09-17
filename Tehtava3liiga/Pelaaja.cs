using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3liiga
{
    public class Pelaaja //: INotifyPropertyChanged
    {
        private string etunimi;
        private string sukunimi;
        //private string kokoNimi;
        private string seura;
        private int siirtohinta;

       /**
       **
       ** Jos haluais käyttää INotifyPropertyChanged niin tarvis tämän ilmeisesti
       **
       public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {

            }
            remove
            {

            }
        }
    **/

        public string KokoNimi
        {
            get
            {
                string a = this.etunimi + " " + this.sukunimi + ", " + this.seura;
                return a;
            }
        }

        public string Etunimi
        {
            get
            {
                return this.etunimi;
            }
            set
            {
                this.etunimi = value;
            }
        }

        public string Sukunimi
        {
            get
            {
                return this.sukunimi;
            }
            set
            {
                this.sukunimi = value;
            }
        }

        public int Siirtohinta
        {
            get
            {
                return this.siirtohinta;
            }
            set
            {
                this.siirtohinta = value;
            }
        }


        public string Seura
        {
            get
            {
                return this.seura;
            }
            set
            {
                this.seura = value;
            }
        }


        public Pelaaja(string enimi, string snimi, string seura, int hinta)
        {
            this.etunimi = enimi;
            this.sukunimi = snimi;
            this.seura = seura;
            this.siirtohinta = hinta;
        }

        // OLISI MYÖS MAHDOLLISTA YLIKIRJOITTAA TOSTRING, JOLLOIN EI TARVITSISI XAMLIIN DisplayMemberPath="KokoNimi"
    }
}
