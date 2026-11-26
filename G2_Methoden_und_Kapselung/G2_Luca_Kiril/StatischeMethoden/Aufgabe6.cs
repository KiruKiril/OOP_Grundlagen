namespace G2_Luca_Kiril.StatischeMethoden;

internal class Aufgabe6
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 6: Statische Methoden ===\n");

        int kapital = 500000;          // 5000.00 CHF
        decimal satzProzent = 1.5m;
        int jahre = 10;

        Console.WriteLine($"Sparkonto: {Geld.AlsText(kapital)} Startkapital, " +
                          $"{satzProzent} % Zins pro Jahr, Laufzeit {jahre} Jahre.\n");

        // Aufruf direkt über die Klasse, ohne new
        int ersterZins = Zinsrechner.Jahreszins(kapital, satzProzent);
        int endkapital = Zinsrechner.Endkapital(kapital, satzProzent, jahre);

        Console.WriteLine($"  {"Zins im ersten Jahr",-24}{Geld.AlsText(ersterZins),12}");
        Console.WriteLine($"  {$"Kapital nach {jahre} Jahren",-24}{Geld.AlsText(endkapital),12}");
        Console.WriteLine($"  {"Zins insgesamt",-24}{Geld.AlsText(endkapital - kapital),12}");

        Console.WriteLine("\nBeide Zahlen kommen aus Zinsrechner, aufgerufen ohne new.\n");
    }
}
