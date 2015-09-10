using System.Collections.ObjectModel;

namespace Tehtava3liiga
{
    internal class listaValmiistaPelaajista 
    {
        private ObservableCollection<Pelaaja> lista = new ObservableCollection<Pelaaja>();

        public ObservableCollection<Pelaaja> Lista
        {
            get
            {
                return this.lista;
            }
        }

        public void LisaaPelaajaValmiiseenListaan(Pelaaja pelaaja)
        {
            this.lista.Add(pelaaja);
        }
    }
}