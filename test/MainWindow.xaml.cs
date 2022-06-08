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
using System.Xml.Linq;

namespace test
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string city;

            city = txtcity.Text;

            string url = string.Format("http://api.weatherapi.com/v1/current.xml?key=4f1fb1a37abf44f4be1123613220706&q={0}&aqi=no", city);


            XDocument doc = XDocument.Load(url);



            string c_temperature = (string)doc.Descendants("temp_c").FirstOrDefault();
            string f_temperature = (string)doc.Descendants("temp_f").FirstOrDefault();
            string mph_wind = (string)doc.Descendants("wind_mph").FirstOrDefault();
            string kph_wind = (string)doc.Descendants("wind_kph").FirstOrDefault();
            string humidity = (string)doc.Descendants("humidity").FirstOrDefault();

            txtwindm.Text = mph_wind;
            txtwindk.Text = kph_wind;
            txthumidity.Text = humidity;

            txtctemp.Text = c_temperature;
            txtftemp.Text = f_temperature;
        }
    }
}
