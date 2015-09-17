using System;
using System.Collections.Generic;
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



namespace TehtavaLotto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            BLLotto lotto = new BLLotto();

            // Tarkistetaan että pelityyppi on valittu ja asetetaan tyyppi
            if (cmbGames.SelectedIndex != -1)
            {
                lotto.type = cmbGames.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Valitse pelityyppi.");
                return;
            }


            // Tarkistetaan että rivien määrä on alle 10 ja jos on niin otetaan määrä talteen

            int maara;
            Int32.TryParse(tbNumberOfDrawns.Text, out maara);

            if (!(maara < 11 && maara != 0))
            {
                MessageBox.Show("Valitse määräksi 1-10.");
            }
            else
            {

                //Tyhjätään vanhat rivit
                txtblNumbers.Text = String.Empty;

                // Arvotaan haluttu määrä rivejä
                do
                {
                    List<int> arvotutNumerot = lotto.ArvoRivi(); // Arvotaan rivi
                    arvotutNumerot.Sort(); // Arvottu rivi järjestykseen

                    // Lyödään rivi laatikkoon
                    foreach (int rivi in arvotutNumerot)
                    {
                        txtblNumbers.Text += rivi.ToString();
                        txtblNumbers.Text += " ";

                    }

                    // Jos Eurojackpot
                    if (lotto.type == 2)
                    {
                        lotto.type = 3; // vaihdetaan arvottavaksi lisänumerot

                        arvotutNumerot = lotto.ArvoRivi(); // Arvotaan rivi
                        arvotutNumerot.Sort(); // Arvottu rivi järjestykseen

                        txtblNumbers.Text += "-- ";

                        // Lyödään rivi laatikkoon
                        foreach (int rivi in arvotutNumerot)
                        {
                            txtblNumbers.Text += rivi.ToString();
                            txtblNumbers.Text += " ";

                        }

                        lotto.type = 2; // vaihdetaan takaisin päänumeroihin
                    }

                    txtblNumbers.Text += "\n";

                    maara--;
                } while (maara > 0);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //Tyhjätään vanhat rivit
            txtblNumbers.Text = String.Empty;
        }
    }
}
