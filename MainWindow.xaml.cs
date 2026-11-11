using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ComplexCalculator.Models;
using ComplexCalculator.Services;

namespace ComplexCalculator
{
    public partial class MainWindow : Window
    {
        // Obiekt kalkulatora — zawiera logikę operacji na liczbach zespolonych
        private ComplexCalculator.Services.ComplexCalculator _calc;

        public MainWindow()
        {
            InitializeComponent();

            // Tworzymy kalkulator
            _calc = new ComplexCalculator.Services.ComplexCalculator();

            // Wypełniamy ComboBox listą dostępnych operacji
            OperationBox.ItemsSource = _calc.GetOperationNames();
        }

        // Obsługa kliknięcia przycisku "Oblicz"
        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Pobranie wartości z pól tekstowych
                double realA = double.Parse(RealA.Text);
                double imagA = double.Parse(ImagA.Text);
                double realB = double.Parse(RealB.Text);
                double imagB = double.Parse(ImagB.Text);

                // Utworzenie liczb zespolonych A i B
                var a = new ComplexNumber(realA, imagA);
                var b = new ComplexNumber(realB, imagB);

                // Pobranie wybranej operacji z ComboBoxa
                string op = OperationBox.SelectedItem.ToString();

                // Wykonanie operacji
                var result = _calc.Execute(op, a, b);

                // Wyświetlenie wyniku
                ResultText.Text = "Wynik: " + result.ToString();

                // Dodanie wpisu do historii obliczeń
                HistoryList.Items.Add($"{a}  {op}  {b}  =  {result}");

                // Narysowanie wektora wyniku na wykresie
                DrawVector(result);
            }
            catch
            {
                // Obsługa błędów (np. niepoprawne dane wejściowe)
                MessageBox.Show("Wprowadź poprawne liczby!", "Błąd",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Rysowanie początkowego układu współrzędnych po załadowaniu canvasa
        private void PlotCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            DrawVector(new ComplexNumber(0, 0));
        }

        // Funkcja rysująca wektor liczby zespolonej na płaszczyźnie
        private void DrawVector(ComplexNumber c)
        {
            // Czyścimy poprzedni rysunek
            PlotCanvas.Children.Clear();

            // Wyznaczamy środek canvasa
            double centerX = PlotCanvas.ActualWidth / 2;
            double centerY = PlotCanvas.ActualHeight / 2;

            // Skala powiększenia
            double scale = 20;

            // Przeliczenie współrzędnych liczby zespolonej na piksele
            double x = centerX + c.Real * scale;
            double y = centerY - c.Imag * scale;

            // Rysowanie osi X
            PlotCanvas.Children.Add(new Line
            {
                X1 = 0,
                Y1 = centerY,
                X2 = PlotCanvas.ActualWidth,
                Y2 = centerY,
                Stroke = Brushes.Gray
            });

            // Rysowanie osi Y
            PlotCanvas.Children.Add(new Line
            {
                X1 = centerX,
                Y1 = 0,
                X2 = centerX,
                Y2 = PlotCanvas.ActualHeight,
                Stroke = Brushes.Gray
            });

            // Rysowanie wektora liczby zespolonej
            PlotCanvas.Children.Add(new Line
            {
                X1 = centerX,
                Y1 = centerY,
                X2 = x,
                Y2 = y,
                Stroke = Brushes.Red,
                StrokeThickness = 3
            });
        }

        // Obsługa przycisku "Wyczyść historię"
        private void ClearHistory_Click(object sender, RoutedEventArgs e)
        {
            // Usunięcie wszystkich wpisów z ListBoxa
            HistoryList.Items.Clear();
        }
    }
}
