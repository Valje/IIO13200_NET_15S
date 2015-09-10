using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava3liiga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private listaValmiistaPelaajista listaValmiistaPelaajista = new listaValmiistaPelaajista();

        public MainWindow()
        {
            InitializeComponent();
            TaytaSeuralaatikko();
            lbPelaajalista.ItemsSource = listaValmiistaPelaajista.Lista;
        }

        // Täyttää Seura-comboboxin seurojen nimillä, jotka haetaan enumista
        public void TaytaSeuralaatikko()
        {
            string[] seuralista = Enum.GetNames(typeof(joukkueet));
            foreach (string a in seuralista)
            {
                cmbSeura.Items.Add(a);
            }
        }

        // Seurojen nimet
        public enum joukkueet
        {
            TPS,
            Lukko,
            Ässät,
            HIFK,
            Blues,
            HPK,
            Tappara,
            Ilves,
            Sport,
            Pelicans,
            KooKoo,
            SaiPa,
            Kärpät,
            JYP,
            KalPa
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnLuoPelaaja_Click(object sender, RoutedEventArgs e)
        {
            string enimi = tbEtunimi.Text;
            string snimi = tbSukunimi.Text;

            int hinta;
            Int32.TryParse(tbSiirtohinta.Text, out hinta);

            string seura = cmbSeura.Items.GetItemAt(cmbSeura.SelectedIndex).ToString();

            Pelaaja pelaaja = new Pelaaja(enimi, snimi, seura, hinta);

            listaValmiistaPelaajista.LisaaPelaajaValmiiseenListaan(pelaaja);  

            //lbPelaajalista.Items.Add(pelaaja.KokoNimi);

        }


    }
}
