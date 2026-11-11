using ComplexCalculator.Models;

namespace ComplexCalculator.Operations
{
    // Klasa implementuje dzielenie liczb zespolonych.
    public class DivOperation : IComplexOperation
    {
        public string Name => "Dzielenie";

        // Dzielenie: (a + bi) / (c + di)
        // Wymaga obliczenia mianownika: c² + d²
        public ComplexNumber Execute(ComplexNumber a, ComplexNumber b)
        {
            double denom = b.Real * b.Real + b.Imag * b.Imag;

            // Sprawdzenie dzielenia przez zero — wymagane matematycznie.
            if (denom == 0)
                throw new DivideByZeroException("Dzielenie przez zero w liczbach zespolonych.");

            return new ComplexNumber(
                (a.Real * b.Real + a.Imag * b.Imag) / denom,
                (a.Imag * b.Real - a.Real * b.Imag) / denom
            );
        }
    }
}
