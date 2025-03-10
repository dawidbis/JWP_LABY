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

namespace JWP_LAB_1B
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

        private void czyśćPłótno()
        {
            cvsKrzyż.Children.Clear();
        }

        private void rysujKrzyż(int centerX, int centerY, int długośćRamienia, int thickness)
        {
            rysujLinię(centerX - długośćRamienia, centerY,
                centerX + długośćRamienia, centerY, Brushes.Red, thickness);
            rysujLinię(centerX, centerY - długośćRamienia, centerX, centerY + długośćRamienia,
                Brushes.Red, thickness);
        }

        private void rysujLinię(int startX, int startY, int endX, int endY, Brush kolor, int thickness)
        {
            Line myLine = new Line();
            myLine.Stroke = kolor;
            myLine.X1 = startX;
            myLine.X2 = endX;
            myLine.Y1 = startY;
            myLine.Y2 = endY;
            myLine.StrokeThickness = thickness;

            cvsKrzyż.Children.Add(myLine);
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

            cvsKrzyż.Children.Add(ellipse);
        }

        private void btnRysujKrzyż_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
            rysujLinię(0, 150, 300, 150, Brushes.Red, 4);
            rysujLinię(150, 150, 150, 300, Brushes.Green, 6);
        }

        private void btnCzyść_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
        }

        private void btnRysujKrzyż2_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
            rysujKrzyż(150, 150, 100, 10);
        }

        private void btnRysujKrzyż3_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
            rysujElipsę(50, 100, 200, 100, Brushes.Bisque, 4);
        }

        private void btnRysujKrzyż4_Click(object sender, RoutedEventArgs e)
        {
            czyśćPłótno();
        }
    }
}