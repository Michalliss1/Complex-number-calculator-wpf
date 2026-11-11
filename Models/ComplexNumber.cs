namespace ComplexCalculator.Models
{
    // Klasa reprezentuje liczbę zespoloną w postaci a + bi.
    // Jest to podstawowy model danych używany w całej aplikacji.
    public class ComplexNumber
    {
        // Część rzeczywista liczby zespolonej.
        public double Real { get; }

        // Część urojona liczby zespolonej.
        public double Imag { get; }

        // Konstruktor — tworzy nową liczbę zespoloną.
        public ComplexNumber(double real, double imag)
        {
            Real = real;   // przypisanie części rzeczywistej
            Imag = imag;   // przypisanie części urojonej
        }

        // Zwraca liczbę zespoloną w formacie tekstowym "a + bi".
        // Dzięki temu wynik można łatwo wyświetlić w UI.
        public override string ToString()
        {
            return $"{Real:F2} {(Imag >= 0 ? "+" : "-")} {Math.Abs(Imag):F2}i";
          
        }
    }
}
