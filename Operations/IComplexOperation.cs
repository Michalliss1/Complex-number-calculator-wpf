namespace ComplexCalculator.Operations
{
    // Interfejs definiuje wspólny "szablon" dla wszystkich operacji.
    // Dzięki temu każda operacja ma taką samą strukturę.
    // To pozwala łatwo dodawać nowe operacje bez zmiany istniejącego kodu.
    public interface IComplexOperation
    {
        // Nazwa operacji — np. "Dodawanie".
        string Name { get; }

        // Metoda wykonująca działanie na dwóch liczbach zespolonych.
        // Każda operacja implementuje tę metodę inaczej.
        ComplexCalculator.Models.ComplexNumber Execute(
            ComplexCalculator.Models.ComplexNumber a,
            ComplexCalculator.Models.ComplexNumber b);
    }
}
