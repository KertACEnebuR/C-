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
using GooglePlayAppsCLI;

namespace GooglePlayAppsGUI
{
    public partial class MainWindow : Window
    {
        List<GooglePlayAppsCLI.App> apps = new List<GooglePlayAppsCLI.App>();
        public MainWindow()
        {
            InitializeComponent();

            var apps = GooglePlayAppsCLI.App.LoadFromCSV(@"..\..\..\..\GooglePlayAppsCLI\src\apps.csv");

            var kategoriak = apps.Select(a => a.Category.CategoryName).Distinct().ToList();

            foreach (var i in kategoriak)
            {
                kategoriakLB.Items.Add(i);
            }

            kategoriakLB.Focus();
            kategoriakLB.SelectedIndex = 0;
        }

        private void kategoriakLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var alkalmazas = apps.Where(a => a.Category.CategoryName == kategoriakLB.SelectedItem).ToList();
            foreach (var i in alkalmazas)
            {
                alkalmazasokCB.Items.Add(i.AppName);
            }
        }
    }
}
