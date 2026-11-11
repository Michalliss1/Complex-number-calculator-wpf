using ComplexCalculator.Models;

namespace ComplexCalculator.Operations
{
    // Klasa implementuje dodawanie liczb zespolonych.
    // Każda operacja ma własną klasę — to ułatwia rozbudowę projektu.
    public class AddOperation : IComplexOperation
    {
        public string Name => "Dodawanie"; // nazwa wyświetlana w UI

        // Dodawanie: (a + bi) + (c + di) = (a+c) + (b+d)i
        public ComplexNumber Execute(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real + b.Real, a.Imag + b.Imag);
    }
}
