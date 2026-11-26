namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe5
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 5: Kapselung im eigenen Fallbeispiel ===\n");

        Console.WriteLine("Das Geheimnis der Klasse Fahrzeug ist der Kilometerstand: er ist");
        Console.WriteLine("privat und wächst einzig über KilometerFahren, damit kein Fahrzeug");
        Console.WriteLine("je einen kleineren Stand melden kann als vorher.\n");

        Fahrzeug golf = new Fahrzeug("VW", "Golf", "ZH 123 456", 48200);

        Console.WriteLine($"{golf.Bezeichnung}");
        Console.WriteLine($"  Start:        {golf.KilometerStand} km " +
                          $"(Stand {golf.LetzteAenderung:HH:mm:ss.fff})");

        golf.KilometerFahren(120);
        Console.WriteLine($"  Nach 120 km:  {golf.KilometerStand} km " +
                          $"(Stand {golf.LetzteAenderung:HH:mm:ss.fff})");

        try
        {
            golf.KilometerFahren(-50);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"\n-50 km abgelehnt: {ex.Message.Split('(')[0].Trim()}");
        }

        // golf.KilometerStand = 100;  <- laesst der Compiler nicht zu, kein Setter.
        Console.WriteLine($"Kilometerstand bleibt bei {golf.KilometerStand} km.\n");
    }
}
