using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        // Nappaa listasta valitun pelaajan tiedot kenttiin
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Jos valittu pelaaja on poistettu
            if (lbPelaajalista.SelectedItem == null)
            {
                lbPelaajalista.SelectedIndex = -1;
                return;
            }

            Pelaaja selectedPlayer = (Pelaaja)lbPelaajalista.SelectedItem;
            tbEtunimi.Text = selectedPlayer.Etunimi;
            tbSukunimi.Text = selectedPlayer.Sukunimi;
            tbSiirtohinta.Text = selectedPlayer.Siirtohinta.ToString();
            cmbSeura.SelectedItem = selectedPlayer.Seura;
        }

        // Luo uuden pelaajan syötettyjen arvojen mukaan
        private void btnLuoPelaaja_Click(object sender, RoutedEventArgs e)
        {
            string enimi = tbEtunimi.Text;
            string snimi = tbSukunimi.Text;
            string seura = cmbSeura.Items.GetItemAt(cmbSeura.SelectedIndex).ToString();

            int hinta;
            Int32.TryParse(tbSiirtohinta.Text, out hinta);

            // Tarkistetaan että syötteet on sopivia
            if (CheckNameInput(enimi) && CheckNameInput(snimi))
            {
                Pelaaja pelaaja = new Pelaaja(enimi, snimi, seura, hinta);
                listaValmiistaPelaajista.LisaaPelaajaValmiiseenListaan(pelaaja);
            }
            else
            {
                return;
            }

            

            //lbPelaajalista.Items.Add(pelaaja.KokoNimi);

        }

        // Nimen tarkistus
        private bool CheckNameInput (string input)
        {
            Regex regex = new Regex(@"^[A-Z][a-z]+$");
            Match match = regex.Match(input);

            if (!match.Success)
            {
                MessageBox.Show("Käytä nimessä vain kirjaimia A-Z. Aloita isolla kirjaimella." + input);
                return false;
            }

            return true;
        }

        private void btnTallennaPelaaja_Click(object sender, RoutedEventArgs e)
        {
            int index = lbPelaajalista.SelectedIndex; // Mahtaako toimia?

            

            //var muutettava = listaValmiistaPelaajista.Lista.Where(pelaaja => pelaaja.Etunimi == enimi).FirstOrDefault();

            if (index != -1)
            {
                var muutettava = listaValmiistaPelaajista.Lista[index];

                string enimi = tbEtunimi.Text;
                string snimi = tbSukunimi.Text;
                int hinta = Int32.Parse(tbSiirtohinta.Text);

                muutettava.Etunimi = enimi;
                muutettava.Sukunimi = snimi;
                muutettava.Siirtohinta = hinta;
                muutettava.Seura = cmbSeura.SelectedItem.ToString();

                // Päivittää listan
                lbPelaajalista.DisplayMemberPath = "";
                lbPelaajalista.DisplayMemberPath = "KokoNimi";

            }
            else
            {
                MessageBox.Show("Valitse jotain, hyvä mies!");
            }

        }

        private void btnPoistaPelaaja_Click(object sender, RoutedEventArgs e)
        {

            // Listasta voidaan poistaa listboxin itemin indexin mukaan, koska ne ovat yhtenevät
            int index = lbPelaajalista.SelectedIndex;

            listaValmiistaPelaajista.Lista.RemoveAt(index);

            // Päivittää listan
            lbPelaajalista.DisplayMemberPath = "";
            lbPelaajalista.DisplayMemberPath = "KokoNimi";

        }

        private void btnLopetus_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
