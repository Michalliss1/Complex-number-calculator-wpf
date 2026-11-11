using ComplexCalculator.Models;

namespace ComplexCalculator.Operations
{
    // Klasa implementuje mnożenie liczb zespolonych.
    public class MulOperation : IComplexOperation
    {
        public string Name => "Mnożenie";

        // Mnożenie: (a + bi)(c + di) = (ac - bd) + (ad + bc)i
        public ComplexNumber Execute(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(
                a.Real * b.Real - a.Imag * b.Imag,
                a.Real * b.Imag + a.Imag * b.Real
            );
    }
}
