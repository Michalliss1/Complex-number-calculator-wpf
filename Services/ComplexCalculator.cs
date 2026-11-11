using ComplexCalculator.Models;
using ComplexCalculator.Operations;

namespace ComplexCalculator.Services
{
    // Główna klasa kalkulatora.
    // Przechowuje wszystkie dostępne operacje w słowniku.
    public class ComplexCalculator
    {
        // Słownik: klucz = nazwa operacji, wartość = obiekt operacji.
        private readonly Dictionary<string, IComplexOperation> _operations = new();

        // Konstruktor — rejestruje wszystkie operacje.
        // Dzięki temu UI może je wyświetlić na liście.
        public ComplexCalculator()
        {
            Register(new AddOperation());
            Register(new SubOperation());
            Register(new MulOperation());
            Register(new DivOperation());
        }

        // Rejestracja operacji — pozwala łatwo dodać nowe działania.
        public void Register(IComplexOperation op)
            => _operations[op.Name] = op;

        // Zwraca listę nazw operacji — do wyświetlenia w ComboBox.
        public IEnumerable<string> GetOperationNames()
            => _operations.Keys;

        // Wykonuje wybraną operację na dwóch liczbach zespolonych.
        public ComplexNumber Execute(string name, ComplexNumber a, ComplexNumber b)
            => _operations[name].Execute(a, b);
    }
}
