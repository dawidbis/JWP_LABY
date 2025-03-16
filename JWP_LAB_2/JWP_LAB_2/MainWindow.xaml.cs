using System.Text;
using System.Transactions;
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

        // MOJE FUNKCJE

        private double iloczyn(double n, double m) { return n * m; }
        private double kwadrat(double n) { return iloczyn(n, n); }
        private double sumaKwadratów(double a, double b) { return kwadrat(a) + kwadrat(b); }
        private double poleKoła(double r) { return Math.PI * kwadrat(r); }
        private double objętośćWalca(double h, double r) { return poleKoła(r) * h; }
        private double objętośćWalca(double h) { return objętośćWalca(h, h); }

        private double potęga(double podstawa, int wykładnik)
        {
            if (wykładnik < 0)
                throw new ArgumentException("Wykładnik nie może być ujemny.");

            if (wykładnik == 0)
                return 1;

            return podstawa * potęga(podstawa, wykładnik - 1);
        }
        private void rysujLinię(int startX, int endX, int startY, int endY, Brush kolor, int thickness, Canvas canvas)
        {
            Line myLine = new Line();
            myLine.Stroke = kolor;
            myLine.X1 = startX;
            myLine.X2 = endX;
            myLine.Y1 = startY;
            myLine.Y2 = endY;
            myLine.StrokeThickness = thickness;

            canvas.Children.Add(myLine);
        }

        private void rysujGwiazdę(int x, int y, int length, Brush kolor, int thickness, Canvas canvas, int minLength)
        {
            if (length < minLength) return; 

            rysujLinię(x - length / 2, x + length / 2, y, y, kolor, thickness, canvas);
            rysujLinię(x - length / 4, x + length / 4, y - length / 2, y + length / 2, kolor, thickness, canvas);
            rysujLinię(x + length / 4, x - length / 4, y - length / 2, y + length / 2, kolor, thickness, canvas);

            int newLength = length / 3; 

            rysujGwiazdę(x - length / 2, y, newLength, kolor, thickness, canvas, minLength);
            rysujGwiazdę(x + length / 2, y, newLength, kolor, thickness, canvas, minLength);
            rysujGwiazdę(x - length / 4, y - length / 2, newLength, kolor, thickness, canvas, minLength);
            rysujGwiazdę(x + length / 4, y - length / 2, newLength, kolor, thickness, canvas, minLength);
            rysujGwiazdę(x - length / 4, y + length / 2, newLength, kolor, thickness, canvas, minLength);
            rysujGwiazdę(x + length / 4, y + length / 2, newLength, kolor, thickness, canvas, minLength);
        }

        // PRZYCISKI

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lsbTest1.Items.Add($"Iloczyn 4 i 6: {iloczyn(4.0, 6.0):F2}");
            lsbTest1.Items.Add($"Kwadrat liczby 8: {kwadrat(8.0):F2}");
            lsbTest1.Items.Add($"Pole koła o promieniu 1: {poleKoła(1.0):F2}");
            lsbTest1.Items.Add($"Objętość walca o wysokości 10 i promieniu 5: {objętośćWalca(10.0, 5.0):F2}");
            lsbTest1.Items.Add($"Objętość walca o wysokości 4 i promieniu 4: {objętośćWalca(4.0):F2}");
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double podstawa = double.Parse(txtPodstawa.Text);
                int wykładnik = int.Parse(txtWykładnik.Text);

                double wynik = potęga(podstawa, wykładnik);
                MessageBox.Show($"Wynik: {wynik}", "Rezultat", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (FormatException)
            {
                MessageBox.Show("Wprowadź poprawne liczby w polach!", "Błąd formatu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił nieoczekiwany błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnTest3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double szerokość, wysokość;
                (double pole, double obwód, double przekątna) wynik;
                szerokość = Convert.ToDouble(txtSzerokość.Text);
                wysokość = Convert.ToDouble(txtWysokość.Text);

                if(szerokość > 0 && wysokość > 0)
                {
                    wynik.pole = iloczyn(szerokość, wysokość);
                    wynik.obwód = iloczyn(szerokość, 2.0) + iloczyn(wysokość, 2.0);
                    wynik.przekątna = Math.Sqrt(sumaKwadratów(szerokość, wysokość));

                    MessageBox.Show($"Pole: {wynik.pole}, obwód: {wynik.obwód}, przekątna: {wynik.przekątna}", "Rezultat", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else MessageBox.Show("Wprowadź dodatnie liczby w polach!", "Błąd zakresu", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Wprowadź dane w odpowiednim formacie!", "Błąd formatu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void btnTest4_Click(object sender, RoutedEventArgs e)
        {
            int[,] wymiary = { { 0, 300, 0, 0 }, { 60, 60, 0, 200 }, { 240, 240, 0, 200 }, { 60, 240, 60, 60 } };
            Brush[] kolory = { Brushes.Black, Brushes.Green, Brushes.Green, Brushes.Red };

            for(int i=0; i < 4; i++)
            {
                rysujLinię(wymiary[i, 0], wymiary[i, 1], wymiary[i, 2], wymiary[i, 3], kolory[i], 10, cvsTrzepak);
            }
        }

        private void btnGwiazda_Click(object sender, RoutedEventArgs e)
        {
            cvsGwiazda.Children.Clear();
            rysujGwiazdę(100, 100, 120, Brushes.DarkOrange, 2, cvsGwiazda, 5);
        }
    }
}