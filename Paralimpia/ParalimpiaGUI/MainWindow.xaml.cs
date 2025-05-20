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

namespace ParalimpiaGUI
{

    public partial class MainWindow : Window
    {
        List<Paralimpia> sporolok = new List<Paralimpia>();
        public MainWindow()
        {
            InitializeComponent();
            sporolok = Paralimpia.FromFile(@"..\..\..\src\ermek.txt");

        }

        private void sporolokDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //int kijelolt = sporolok.Where(k => k.Ev == int.Parse(sporolokDG.SelectedItem));

        }

        private void szuresOrszagvagyVaros_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keresettOrszagvagyVaros = szuresOrszagvagyVaros.Text;

            var szures = sporolok.Where(s => s.Orszag.Contains(keresettOrszagvagyVaros.ToLower()) || s.Varos.Contains(keresettOrszagvagyVaros.ToLower())).ToList();

            sporolokDG.ItemsSource = szures;
        }
    }
}