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
using System.Windows.Shapes;

namespace ViinikellariT4
{
    /// <summary>
    /// Interaction logic for Viinikellari2.xaml
    /// </summary>
    public partial class Viinikellari2 : Window
    {
        public Viinikellari2()
        {
            InitializeComponent();
            MessageBox.Show(GetCountries().ToString());
        }

        public List<string> GetCountries()
        {
            List<string> a = new List<string>();

            System.Xml.Serialization.XmlSerializer reader =
            new System.Xml.Serialization.XmlSerializer(typeof(Arvio));
            System.IO.StreamReader file = new System.IO.StreamReader(
                @"D:\H3340\Viinit1.xml");
            Arvio arvio = (Arvio)reader.Deserialize(file);

            a.Add(arvio.Maa);

            file.Close();

            return a;
        }
    }
}
