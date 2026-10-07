namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Aufgabe4
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 4: Fahrschule mit Eigenschaften ===\n");

        Fahrschule schule = Beispieldaten();

        Console.WriteLine($"{schule.Name}, {schule.Adresse}");
        Console.WriteLine($"{schule.AnzahlSchueler} Schüler, " +
                          $"Umsatz {schule.Gesamtumsatz:0.00} CHF\n");

        Console.WriteLine("Fahrschüler:");
        foreach (Fahrschueler schueler in schule.Schueler)
        {
            string reif = schueler.IstPruefungsreif ? "prüfungsreif" : "noch nicht prüfungsreif";

            Console.WriteLine($"  {schueler.Name}, {schueler.Alter} Jahre, " +
                              $"{schueler.AnzahlAbsolvierterStunden} Stunden, {reif}");
            Console.WriteLine($"    registriert am {schueler.RegistriertAm:dd.MM.yyyy HH:mm:ss}");
        }

        Console.WriteLine("\nFahrzeuge:");
        foreach (Fahrzeug fahrzeug in schule.Fahrzeuge)
        {
            string service = fahrzeug.BrauchtService ? "Service fällig" : "Service ok";

            Console.WriteLine($"  {fahrzeug.Bezeichnung}, {fahrzeug.KilometerStand} km, " +
                              $"{fahrzeug.AlterInJahren} Jahre, {service}");
        }

        Console.WriteLine("\nStundenplan:");
        foreach (Fahrstunde stunde in schule.Stundenplan)
        {
            Console.WriteLine($"  {stunde.Beginn:dd.MM.yyyy HH:mm} bis {stunde.Ende:HH:mm}, " +
                              $"{stunde.Schueler.Name} bei {stunde.Lehrer.Name}, " +
                              $"{stunde.Kosten:0.00} CHF");
        }

        ValidierungVorfuehren(schule);
    }

    private static void ValidierungVorfuehren(Fahrschule schule)
    {
        Console.WriteLine("\nWas die Setter ablehnen:");

        Fahrzeug golf = schule.Fahrzeuge[0];

        try
        {
            golf.KilometerStand = 100;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  {Meldung(ex)}");
        }

        try
        {
            schule.Schueler[0].Email = "keine-gueltige-adresse";
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  {Meldung(ex)}");
        }

        try
        {
            Fahrstunde zuKurz = new Fahrstunde();
            zuKurz.DauerMinuten = 20;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  {Meldung(ex)}");
        }

        Console.WriteLine($"\nKilometerstand ist unverändert: {golf.KilometerStand} km\n");
    }

    // ArgumentException haengt " (Parameter 'value')" an die Meldung an.
    private static string Meldung(ArgumentException ex)
    {
        return ex.Message.Split('(')[0].Trim();
    }

    public static Fahrschule Beispieldaten()
    {
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
            Geburtsdatum = new DateTimeOffset(2006, 6, 21, 0, 0, 0, TimeSpan.Zero),
            Email = "luca.rossi@example.ch",
            HatLernfahrausweis = true,
            AnzahlAbsolvierterStunden = 12
        };

        Fahrschueler mia = new Fahrschueler
        {
            Name = "Mia Huber",
            Geburtsdatum = new DateTimeOffset(2009, 1, 9, 0, 0, 0, TimeSpan.Zero),
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
            Baujahr = 2015,
            KilometerStand = 115300,
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

        return new Fahrschule
        {
            Name = "Fahrschule Drive Easy",
            Adresse = "Bahnhofstrasse 10, 8001 Zürich",
            Lehrer = new List<Fahrlehrer> { marco, sarah },
            Schueler = new List<Fahrschueler> { luca, mia },
            Fahrzeuge = new List<Fahrzeug> { golf, corsa },
            Stundenplan = new List<Fahrstunde> { stunde1, stunde2 }
        };
    }
}
