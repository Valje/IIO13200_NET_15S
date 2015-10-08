using System;
using System.Collections.Generic;
using System.Data;
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

namespace T8Palaute
{
    /// <summary>
    /// Interaction logic for Inspection.xaml
    /// </summary>
    public partial class Inspection : Window
    {

        DataSet ds;
        DataTable dt;
        DataView dv;

        public Inspection()
        {
            InitializeComponent();
            UpdateDGItemsSource();
        }

        public void UpdateDGItemsSource()
        {
            // luetaan koko XML DataSettiin
            // DataSet in-memory database
            try
            {
                string file = T8Palaute.Properties.Settings.Default.yhteys;
                ds = new DataSet();
                dt = new DataTable();
                dv = new DataView();
                ds.ReadXml(file);
                dt = ds.Tables[0];
                dv = dt.DefaultView;

                //MessageBox.Show(ds.GetXml());

                dgFeedbacks.ItemsSource = dv;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnInspectionBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
