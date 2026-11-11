using ComplexCalculator.Models;

namespace ComplexCalculator.Operations
{
    // Klasa implementuje odejmowanie liczb zespolonych.
    public class SubOperation : IComplexOperation
    {
        public string Name => "Odejmowanie";

        // Odejmowanie: (a + bi) - (c + di) = (a-c) + (b-d)i
        public ComplexNumber Execute(ComplexNumber a, ComplexNumber b)
            => new ComplexNumber(a.Real - b.Real, a.Imag - b.Imag);
    }
}
