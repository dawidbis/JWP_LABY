using System.Drawing;
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
using Rectangle = System.Windows.Shapes.Rectangle;

namespace JWP_LAB_1C
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
            try{
                double a, b, c, delta, x1, x2;
                a = Convert.ToDouble(txtWspółczynnikA.Text);
                b = Convert.ToDouble(txtWspółczynnikB.Text);
                c = Convert.ToDouble(txtWspółczynnikC.Text);

                if (a != 0)
                {
                    delta = Math.Pow(b, 2.0) - 4.0 * a * c;

                    if(delta > 0) {
                        x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
                        x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);
                        lblWynikRównania.Content = $"Delta > 0;   x1 = {x1:F2}, x2 = {x2:F2}";
                    }
                    else if(delta == 0){
                        x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
                        lblWynikRównania.Content = $"Delta = 0;   x = {x1:F2}";
                    }
                    else {
                        lblWynikRównania.Content = $"Delta < 0;   brak rozwiązań";
                    }
                }
                else MessageBox.Show("Współczynnik a nie może być równy 0!");
            }
            catch{
                MessageBox.Show("Nieprawidłowy format danych!");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RysujPiramide(cvsPiramida, 5, 50, 20, Brushes.Goldenrod);
        }

        private void RysujPiramide(Canvas canvas, int liczbaStopni, double szerokoscStopnia, double wysokoscStopnia, Brush kolor)
        {
            canvas.Children.Clear();
            double startX = (canvas.ActualWidth - szerokoscStopnia * liczbaStopni) / 2;
            double startY = canvas.ActualHeight - wysokoscStopnia;

            for (int i = liczbaStopni; i > 0; i--)
            {
                Rectangle stopien = new Rectangle
                {
                    Width = szerokoscStopnia * i,
                    Height = wysokoscStopnia,
                    Fill = kolor,
                    Stroke = Brushes.LightGoldenrodYellow,
                    StrokeThickness = 2
                };

                Canvas.SetLeft(stopien, startX + ((liczbaStopni - i) * (szerokoscStopnia / 2)));
                Canvas.SetTop(stopien, startY - ((liczbaStopni - i) * wysokoscStopnia));

                canvas.Children.Add(stopien);
            }
        }

        private void btnRysujSzachownicę_Click(object sender, RoutedEventArgs e)
        {
            gridSzachownica.Children.Clear();

            Brush kolor;

            for (int i = 0; i < 8; i++)
            {
                gridSzachownica.RowDefinitions.Add(new RowDefinition());
                gridSzachownica.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < 8;i++)
            {
                for(int j = 0; j < 8;j++)
                {
                   kolor = ((i + j) % 2 == 0) ? Brushes.White : Brushes.Black;

                   Rectangle pole = new Rectangle
                   {
                       Width = 20.0,
                       Height = 20.0,
                       Fill = kolor,
                       Stroke = Brushes.Black,
                       StrokeThickness = 1
                   };

                   Grid.SetRow(pole, i);
                   Grid.SetColumn(pole, j);

                   gridSzachownica.Children.Add(pole);
                }
            }
        }
    }
}