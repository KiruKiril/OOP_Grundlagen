using System.Globalization;
using G1_Luca_Kiril.Aufgabe4_Eigenschaften;

namespace G1_Luca_Kiril.Aufgabe5_Erfassung;

internal class Aufgabe5
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 5: Erfassung über die Konsole ===\n");

        Fahrschueler schueler = new Fahrschueler();

        Console.Write("Name: ");
        schueler.Name = Console.ReadLine();

        while (true)
        {
            Console.Write("E-Mail: ");

            try
            {
                schueler.Email = Console.ReadLine();
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"  {ex.Message.Split('(')[0].Trim()}");
            }
        }

        while (true)
        {
            Console.Write("Geburtsdatum (TT.MM.JJJJ): ");
            string eingabe = Console.ReadLine();

            if (DateTimeOffset.TryParseExact(eingabe, "dd.MM.yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal,
                    out DateTimeOffset geburtsdatum))
            {
                schueler.Geburtsdatum = geburtsdatum;
                break;
            }

            Console.WriteLine("  Bitte im Format 21.06.2007 eingeben.");
        }

        while (true)
        {
            Console.Write("Bisher absolvierte Fahrstunden: ");
            string eingabe = Console.ReadLine();

            try
            {
                schueler.AnzahlAbsolvierterStunden = int.Parse(eingabe);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("  Bitte eine ganze Zahl eingeben.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"  {ex.Message.Split('(')[0].Trim()}");
            }
        }

        Console.Write("Lernfahrausweis vorhanden? (j/n): ");
        string antwort = Console.ReadLine();
        schueler.HatLernfahrausweis = antwort != null &&
                                      antwort.Trim().StartsWith("j", StringComparison.OrdinalIgnoreCase);

        Ausgeben(schueler);
    }

    private static void Ausgeben(Fahrschueler schueler)
    {
        Console.WriteLine("\nErfasster Fahrschüler:");
        Console.WriteLine($"  Name:            {schueler.Name}");
        Console.WriteLine($"  E-Mail:          {schueler.Email}");
        Console.WriteLine($"  Geburtsdatum:    {schueler.Geburtsdatum:dd.MM.yyyy}");
        Console.WriteLine($"  Alter:           {schueler.Alter} Jahre");
        Console.WriteLine($"  Fahrstunden:     {schueler.AnzahlAbsolvierterStunden}");
        Console.WriteLine($"  Lernfahrausweis: {(schueler.HatLernfahrausweis ? "ja" : "nein")}");
        Console.WriteLine($"  Prüfungsreif:    {(schueler.IstPruefungsreif ? "ja" : "nein")}");
        Console.WriteLine($"  Registriert am:  {schueler.RegistriertAm:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine();
    }
}
