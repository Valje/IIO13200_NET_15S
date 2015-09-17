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

namespace ViinikellariT4
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

        private void btnXML1_Click(object sender, RoutedEventArgs e)
        {
            //avataan uusi ikkuna
            Viinikellari1 vk = new Viinikellari1();
            vk.Käyttäjä = "Niilo Käyttäjä";
            vk.ShowDialog();
        }

        private void btnXML3_Click(object sender, RoutedEventArgs e)
        {
            Viinikellari2 vk2 = new Viinikellari2();
            vk2.ShowDialog();
        }

        private void btnXML4_Click(object sender, RoutedEventArgs e)
        {
            Viinikellari_dataset vk4 = new Viinikellari_dataset();
            vk4.ShowDialog();
        }
    }
}
