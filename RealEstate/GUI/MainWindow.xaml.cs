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

namespace RealEstateGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var ads = Ad.LoadFromCsv(@"../../../SRC/realestates.csv");

            foreach (var nevek in ads)
            {
                lbx_nevek.Items.Add(nevek.Seller.Name);
            }

            
        }
    }
}