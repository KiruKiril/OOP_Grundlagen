namespace G2_Luca_Kiril.StatischeMethoden;

internal class Aufgabe6
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 6: Statische Methoden ===\n");

        // Aufruf direkt über die Klasse, ohne Objekt
        int summe = Zinsrechner.Addiere(3, 4);
        decimal zins = Zinsrechner.Jahreszins(5000m, 1.5m);
        decimal endkapital = Zinsrechner.Endkapital(5000m, 1.5m, 10);

        Console.WriteLine($"Zinsrechner.Addiere(3, 4)                  = {summe}");
        Console.WriteLine($"Zinsrechner.Jahreszins(5000, 1.5)          = {zins:0.00} CHF");
        Console.WriteLine($"Zinsrechner.Endkapital(5000, 1.5, 10)      = {endkapital:0.00} CHF");

        Console.WriteLine("\nKein new nötig, weil die Methoden zur Klasse gehören");
        Console.WriteLine("und nicht zu einem einzelnen Objekt. Sie rechnen nur mit");
        Console.WriteLine("ihren Parametern und greifen auf keine Instanzdaten zu.");
        Console.WriteLine("Endkapital ruft intern Jahreszins auf, ebenfalls ohne Objekt.");
        Console.WriteLine();
    }
}
