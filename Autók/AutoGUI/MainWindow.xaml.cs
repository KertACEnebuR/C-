using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AutoKonzol;

namespace AutoGUI
{
    public partial class MainWindow : Window
    {
        List<Auto> autok = new List<Auto>();
        string radioButton = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
            autok = Auto.LoadFromCSV(@"..\..\..\..\AutoKonzol\src\carsData.csv");

            var f11 = autok.Select(a => a.Gyarto.GyartoNev).Distinct().ToList();

            foreach (var f in f11)
            {
                autoGyartokLB.Items.Add(f);
            }

            autoGyartokLB.SelectedIndex = 0;
        }

        private void autoGyartokLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var f12 = autok.Where(a => a.Gyarto.GyartoNev.Contains(Convert.ToString(autoGyartokLB.SelectedItem))).ToList();

            var distinctKarosszeriak = f12.Select(f => f.Karosszeria.KarosszeriaNev).Distinct();
            var distinctValtok = f12.Select(f => f.Valto.ValtoNev).Distinct();

            karosszeriaCB.Items.Clear();
            valtoCB.Items.Clear();

            foreach (var k in distinctKarosszeriak)
            {
                karosszeriaCB.Items.Add(k);
            }

            foreach (var v in distinctValtok)
            {
                valtoCB.Items.Add(v);
            }
        }

        private void keresesBTN_Click(object sender, RoutedEventArgs e)
        {
            var minEv = int.Parse(evekSzamaMIN.Text);
            var maxEv = int.Parse(evekSzamaMAX.Text);

            var keresettAuto = autok.Where(a => a.Gyarto.GyartoNev.Contains(Convert.ToString(autoGyartokLB.SelectedItem)) &&
                                                a.Karosszeria.KarosszeriaNev.Contains(Convert.ToString(karosszeriaCB.SelectedItem)) &&
                                                a.Valto.ValtoNev.Contains(Convert.ToString(valtoCB.SelectedItem)) &&
                                                a.Ajtok == int.Parse(radioButton) &&
                                                a.Evjarat <= 2023 - minEv && a.Evjarat >= 2023 - maxEv)
                                    .Select(a => $"{a.Azonosito}. - {a.Evjarat} - {a.KilometerAllas} km - {a.Ar} CAD").ToList();


            keresettAutokLB.ItemsSource = keresettAuto;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio == null)
            {
                return;
            }
            radioButton = radio.Content.ToString();
        }
    }
}