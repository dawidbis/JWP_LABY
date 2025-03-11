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

namespace JWP_LAB_KOL_B
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
        private void rysujElipsę(int topX, int topY, int width, int height, Brush kolor, int thickness)
        {
            Ellipse ellipse = new Ellipse();

            ellipse.Width = width;
            ellipse.Height = height;
            ellipse.StrokeThickness = thickness;
            ellipse.Stroke = Brushes.Black;
            ellipse.Fill = kolor;

            Canvas.SetLeft(ellipse, topX);
            Canvas.SetTop(ellipse, topY);

            cvsPłótno.Children.Add(ellipse);
        }

        private void rysujProstokąt(int topX, int topY, int width, int height, Brush kolor, int thickness)
        {
            Rectangle rectangle = new Rectangle();

            rectangle.Width = width;
            rectangle.Height = height;
            rectangle.Stroke = Brushes.Black;
            rectangle.StrokeThickness = thickness;
            rectangle.Fill = kolor;

            Canvas.SetLeft(rectangle, topX);
            Canvas.SetTop(rectangle, topY);

            cvsPłótno.Children.Add(rectangle);
        }

        private void czyśćPłótno()
        {
            cvsPłótno.Children.Clear();
        }

        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double topLeftX, topLeftY, width, height;
                topLeftX = Convert.ToDouble(txtTopLeftX.Text);
                topLeftY = Convert.ToDouble(txtTopLeftY.Text);
                width = Convert.ToDouble(txtSzerokość.Text);
                height = Convert.ToDouble(txtWysokość.Text);

                if (topLeftX > 0 && topLeftY > 0 && width > 0 && height > 0)
                {
                    if (rdbElipsa.IsChecked == true) rysujElipsę((int)topLeftX, (int)topLeftY, (int)width, (int)height, Brushes.Green, 2);
                    else if (rdbProstokąt.IsChecked == true) rysujProstokąt((int)topLeftX, (int)topLeftY, (int)width, (int)height, Brushes.Green, 2);
                }
                else MessageBox.Show("Dane nie mogą być ujemne!");
            }
            catch {
                MessageBox.Show("Nieprawidłowy format danych!");
            }
        }

        private void btnCzyść_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
        }
    }
}