namespace G1_Luca_Kiril.Aufgabe3_Fallbeispiel;

internal class Aufgabe3
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 3: Fahrschule mit Feldern ===\n");

        Fahrlehrer marco = new Fahrlehrer
        {
            Name = "Marco Bianchi",
            Geburtsdatum = new DateTimeOffset(1980, 3, 14, 0, 0, 0, TimeSpan.Zero),
            Telefon = "079 111 22 33",
            Kategorien = new List<string> { "B", "A" },
            Stundenansatz = 95.00m
        };

        Fahrlehrer sarah = new Fahrlehrer
        {
            Name = "Sarah Keller",
            Geburtsdatum = new DateTimeOffset(1991, 11, 2, 0, 0, 0, TimeSpan.Zero),
            Telefon = "079 444 55 66",
            Kategorien = new List<string> { "B", "C" },
            Stundenansatz = 105.00m
        };

        Fahrschueler luca = new Fahrschueler
        {
            Name = "Luca Rossi",
            Geburtsdatum = new DateTimeOffset(2007, 6, 21, 0, 0, 0, TimeSpan.Zero),
            Email = "luca.rossi@example.ch",
            HatLernfahrausweis = true,
            AnzahlAbsolvierterStunden = 12
        };

        Fahrschueler mia = new Fahrschueler
        {
            Name = "Mia Huber",
            Geburtsdatum = new DateTimeOffset(2006, 1, 9, 0, 0, 0, TimeSpan.Zero),
            Email = "mia.huber@example.ch",
            HatLernfahrausweis = false,
            AnzahlAbsolvierterStunden = 3
        };

        Fahrzeug golf = new Fahrzeug
        {
            Marke = "VW",
            Modell = "Golf",
            Kontrollschild = "ZH 123 456",
            Baujahr = 2021,
            KilometerStand = 48200,
            Getriebe = "Handschaltung"
        };

        Fahrzeug corsa = new Fahrzeug
        {
            Marke = "Opel",
            Modell = "Corsa",
            Kontrollschild = "ZH 654 321",
            Baujahr = 2023,
            KilometerStand = 15300,
            Getriebe = "Automat"
        };

        Fahrstunde stunde1 = new Fahrstunde
        {
            Beginn = new DateTimeOffset(2026, 9, 15, 14, 0, 0, TimeSpan.Zero),
            DauerMinuten = 90,
            Schueler = luca,
            Lehrer = marco,
            Fahrzeug = golf,
            Thema = "Autobahn auffahren und einspuren"
        };

        Fahrstunde stunde2 = new Fahrstunde
        {
            Beginn = new DateTimeOffset(2026, 9, 16, 9, 30, 0, TimeSpan.Zero),
            DauerMinuten = 45,
            Schueler = mia,
            Lehrer = sarah,
            Fahrzeug = corsa,
            Thema = "Rückwärts parkieren"
        };

        Fahrschule schule = new Fahrschule
        {
            Name = "Fahrschule Drive Easy",
            Adresse = "Bahnhofstrasse 10, 8001 Zürich",
            Lehrer = new List<Fahrlehrer> { marco, sarah },
            Schueler = new List<Fahrschueler> { luca, mia },
            Fahrzeuge = new List<Fahrzeug> { golf, corsa },
            Stundenplan = new List<Fahrstunde> { stunde1, stunde2 }
        };

        Ausgeben(schule);
    }

    private static void Ausgeben(Fahrschule schule)
    {
        Console.WriteLine($"{schule.Name}, {schule.Adresse}\n");

        Console.WriteLine("Fahrlehrer:");
        foreach (Fahrlehrer lehrer in schule.Lehrer)
        {
            Console.WriteLine($"  {lehrer.Name}, Kategorien {string.Join("/", lehrer.Kategorien)}, " +
                              $"{lehrer.Stundenansatz:0.00} CHF/h");
        }

        Console.WriteLine("\nFahrschüler:");
        foreach (Fahrschueler schueler in schule.Schueler)
        {
            string ausweis = schueler.HatLernfahrausweis ? "mit" : "ohne";

            Console.WriteLine($"  {schueler.Name}, {ausweis} Lernfahrausweis, " +
                              $"{schueler.AnzahlAbsolvierterStunden} Stunden");
        }

        Console.WriteLine("\nFahrzeuge:");
        foreach (Fahrzeug fahrzeug in schule.Fahrzeuge)
        {
            Console.WriteLine($"  {fahrzeug.Marke} {fahrzeug.Modell} ({fahrzeug.Kontrollschild}), " +
                              $"{fahrzeug.Getriebe}, {fahrzeug.KilometerStand} km");
        }

        Console.WriteLine("\nStundenplan:");
        foreach (Fahrstunde stunde in schule.Stundenplan)
        {
            Console.WriteLine($"  {stunde.Beginn:dd.MM.yyyy HH:mm}, {stunde.DauerMinuten} min, " +
                              $"{stunde.Schueler.Name} bei {stunde.Lehrer.Name} im {stunde.Fahrzeug.Modell}");
            Console.WriteLine($"    Thema: {stunde.Thema}");
        }

        Console.WriteLine();
    }
}
