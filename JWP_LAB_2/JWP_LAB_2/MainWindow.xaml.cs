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

namespace JWP_LAB_2
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

        private double iloczyn(double n, double m) { return n * m; }
        private double kwadrat(double n) { return iloczyn(n, n); }
        private double poleKoła(double r) { return Math.PI * kwadrat(r); }
        private double objętośćWalca(double h, double r) { return poleKoła(r) * h; }
        private double objętośćWalca(double h) { return objętośćWalca(h, h); }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lsbTest1.Items.Add($"Iloczyn 4 i 6: {iloczyn(4.0, 6.0):F2}");
            lsbTest1.Items.Add($"Kwadrat liczby 8: {kwadrat(8.0):F2}");
            lsbTest1.Items.Add($"Pole koła o promieniu 1: {poleKoła(1.0):F2}");
            lsbTest1.Items.Add($"Objętość walca o wysokości 10 i promieniu 5: {objętośćWalca(10.0, 5.0):F2}");
            lsbTest1.Items.Add($"Objętość walca o wysokości 4 i promieniu 4: {objętośćWalca(4.0):F2}");
        }
    }
}