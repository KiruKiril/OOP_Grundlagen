namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe2
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 2: Konstruktoren mit Überladung ===\n");

        // Kurzer Konstruktor: nur Name und Geburtsdatum
        Fahrschueler mia = new Fahrschueler("Mia Huber",
            new DateTimeOffset(2009, 1, 9, 0, 0, 0, TimeSpan.Zero));

        // Langer Konstruktor: setzt zusätzlich E-Mail und Lernfahrausweis
        Fahrschueler luca = new Fahrschueler("Luca Rossi",
            new DateTimeOffset(2006, 6, 21, 0, 0, 0, TimeSpan.Zero),
            "luca.rossi@example.ch", true);

        Console.WriteLine("Zwei Schüler, zwei verschiedene Konstruktoren:");
        Ausgeben(mia);
        Ausgeben(luca);

        // Dasselbe beim Fahrzeug
        Fahrzeug neuwagen = new Fahrzeug("Skoda", "Fabia");
        Fahrzeug bestand = new Fahrzeug("VW", "Golf", "ZH 123 456", 2021, 48200,
            "Handschaltung");

        Console.WriteLine("Zwei Fahrzeuge, zwei verschiedene Konstruktoren:");
        Console.WriteLine($"  {neuwagen.Bezeichnung}, {neuwagen.KilometerStand} km");
        Console.WriteLine($"  {bestand.Bezeichnung}, {bestand.KilometerStand} km");

        // Und bei der Fahrschule selbst
        Fahrschule ohneAdresse = new Fahrschule("Fahrschule Drive Easy");
        Fahrschule mitAdresse = new Fahrschule("Fahrschule Drive Easy",
            "Bahnhofstrasse 10, 8001 Zürich");

        Console.WriteLine("\nZwei Fahrschulen, zwei verschiedene Konstruktoren:");
        Console.WriteLine($"  {ohneAdresse.Name}, Adresse: " +
                          $"{(ohneAdresse.Adresse == null ? "nicht gesetzt" : ohneAdresse.Adresse)}");
        Console.WriteLine($"  {mitAdresse.Name}, Adresse: {mitAdresse.Adresse}");

        Console.WriteLine("\nDer lange Konstruktor ruft mit this(...) den kurzen auf.");
        Console.WriteLine("So steht die gemeinsame Zuweisung nur an einer Stelle.");
        Console.WriteLine("Sobald eine Klasse einen eigenen Konstruktor hat, gibt es");
        Console.WriteLine("kein new Fahrschueler() ohne Parameter mehr.");
        Console.WriteLine();
    }

    private static void Ausgeben(Fahrschueler schueler)
    {
        string mail = schueler.Email == null ? "nicht gesetzt" : schueler.Email;
        string ausweis = schueler.HatLernfahrausweis ? "ja" : "nein";

        Console.WriteLine($"  {schueler.Name}, {schueler.Alter} Jahre, " +
                          $"E-Mail: {mail}, Lernfahrausweis: {ausweis}");
    }
}
