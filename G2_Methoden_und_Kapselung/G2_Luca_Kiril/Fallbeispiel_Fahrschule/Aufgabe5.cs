namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe5
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 5: Kapselung im eigenen Fallbeispiel ===\n");

        Console.WriteLine("Gekapselte Klasse: Fahrzeug");
        Console.WriteLine("Das Geheimnis ist der Kilometerstand. Er liegt in einem privaten");
        Console.WriteLine("Feld und hat nach aussen nur einen Getter. Verändern lässt er sich");
        Console.WriteLine("einzig über KilometerFahren, und dort gilt die Regel, dass nur");
        Console.WriteLine("positive Strecken zählen. Deshalb kann ein Fahrzeug nie einen");
        Console.WriteLine("kleineren Kilometerstand melden als vorher, was bei einem");
        Console.WriteLine("öffentlichen Feld jederzeit möglich wäre.\n");

        Fahrzeug golf = new Fahrzeug("VW", "Golf", "ZH 123 456", 2021, 48200,
            "Handschaltung");

        Console.WriteLine($"Start: {golf.KilometerStand} km, " +
                          $"letzte Änderung {golf.LetzteAenderung:HH:mm:ss}");

        golf.KilometerFahren(120);
        Console.WriteLine($"Nach 120 km: {golf.KilometerStand} km, " +
                          $"letzte Änderung {golf.LetzteAenderung:HH:mm:ss}");

        Console.WriteLine("\nUngültige Zugriffe:");

        try
        {
            golf.KilometerFahren(-50);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  abgelehnt: {ex.Message.Split('(')[0].Trim()}");
        }

        try
        {
            golf.KilometerFahren(0);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  abgelehnt: {ex.Message.Split('(')[0].Trim()}");
        }

        Console.WriteLine($"\nKilometerstand unverändert: {golf.KilometerStand} km");
        Console.WriteLine("Ein direktes golf.KilometerStand = 100 lässt der Compiler");
        Console.WriteLine("nicht zu, weil die Eigenschaft keinen Setter hat.");
        Console.WriteLine("\nDie Folgeaktion im Zeitstempel ist der Trigger: wer fährt,");
        Console.WriteLine("aktualisiert automatisch das Datum der letzten Änderung,");
        Console.WriteLine("ohne selbst daran denken zu müssen.");
        Console.WriteLine();
    }
}
