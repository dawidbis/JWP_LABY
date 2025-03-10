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

namespace JWP_LAB_KOL_A
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

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double waga, wzrost, BMI;
                waga = Convert.ToDouble(txtWaga.Text);
                wzrost = Convert.ToDouble(txtWzrost.Text);

                if (waga > 0 && wzrost > 0)
                {
                    BMI = waga / Math.Pow(wzrost/100, 2.0);

                    if (BMI < 18.5) MessageBox.Show($"Masz niedowagę! BMI = {BMI:F2}");
                    else if (BMI >= 18.5 && BMI < 30.0) MessageBox.Show($"Waga w normie :) BMI = {BMI:F2}");
                    else MessageBox.Show($"Masz nadwagę! BMI = {BMI:F2}");
                }
                else MessageBox.Show("Wzrost lub waga nie mogą być ujemne!");
            }
            catch {
                MessageBox.Show("Nieprawidłowy format danych!");
            }
        }
    }
}