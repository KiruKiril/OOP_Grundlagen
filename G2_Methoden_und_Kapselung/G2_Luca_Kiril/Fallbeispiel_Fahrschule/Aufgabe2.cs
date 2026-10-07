namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe2
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 2: Konstruktoren mit Überladung ===\n");

        Fahrschule schule = Beispieldaten.Fahrschule();
        Console.WriteLine($"{schule.Name} hat {schule.AnzahlSchueler} Schüler.\n");

        Fahrschueler nina = new Fahrschueler("Nina Frei",
            new DateTimeOffset(2007, 3, 15, 0, 0, 0, TimeSpan.Zero));

        schule.SchuelerAufnehmen(nina);

        Console.WriteLine("Anruf: Nina Frei meldet sich an.");
        Ausgeben(nina);

        Fahrschueler jonas = new Fahrschueler("Jonas Weber",
            new DateTimeOffset(2008, 5, 20, 0, 0, 0, TimeSpan.Zero),
            "jonas.weber@example.ch", true);

        schule.SchuelerAufnehmen(jonas);

        Console.WriteLine("\nAnmeldeformular von Jonas Weber ist vollständig.");
        Ausgeben(jonas);

        Console.WriteLine($"\nKartei: {schule.AnzahlSchueler} Schüler.");
        Console.WriteLine();
    }

    private static void Ausgeben(Fahrschueler schueler)
    {
        Console.WriteLine($"  {schueler.Name}, {schueler.Alter} Jahre");
        Console.WriteLine($"  Aufgenommen am {schueler.RegistriertAm:dd.MM.yyyy HH:mm}");

        List<string> fehlt = schueler.FehlendeAngaben();

        if (fehlt.Count == 0)
        {
            Console.WriteLine("  Angaben vollständig, Anmeldung kann abgeschlossen werden.");
            return;
        }

        Console.WriteLine($"  Es fehlt noch: {string.Join(", ", fehlt)}");
    }
}
