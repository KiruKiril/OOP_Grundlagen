namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe1
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 1: Methoden im Fallbeispiel ===");

        Fahrschule schule = Beispieldaten.Fahrschule();

        // Methode mit Parameter und Rückgabewert
        Fahrschueler luca = schule.SucheSchueler("Luca Rossi");
        Fahrlehrer marco = schule.SucheLehrerFuerKategorie("B");
        Fahrzeug golf = schule.Stundenplan()[0].Fahrzeug;

        Console.WriteLine($"{luca.Name} möchte zur Führerprüfung.");
        Stand(luca);

        Fahrstunde(luca, marco, golf, 1, "Innerorts", false);
        Fahrstunde(luca, marco, golf, 2, "Kreisel und Vortritt", false);
        Fahrstunde(luca, marco, golf, 3, "Autobahn", true);

        Console.WriteLine($"\n{luca.Name} kann zur Prüfung antreten.");
        Console.WriteLine();
    }

    private static void Fahrstunde(Fahrschueler schueler, Fahrlehrer lehrer,
                                   Fahrzeug fahrzeug, int nummer, string thema,
                                   bool aufAutobahn)
    {
        Fahrstunde stunde = new Fahrstunde(schueler, lehrer, fahrzeug,
            DateTimeOffset.Now.AddDays(nummer), 90);
        stunde.Thema = thema;
        stunde.AufAutobahn = aufAutobahn;

        // Methode, die rechnet
        Console.WriteLine($"\nFahrstunde {nummer}: {thema}, " +
                          $"{stunde.DauerMinuten} Minuten für {stunde.Kosten():0.00} CHF");

        // Methode, die den Zustand verändert
        stunde.Durchfuehren(45);

        Stand(schueler);
    }

    private static void Stand(Fahrschueler schueler)
    {
        string autobahn = schueler.HatAutobahnGefahren ? "ja" : "nein";
        string reif = schueler.IstPruefungsreif ? "ja" : "nein";

        Console.WriteLine($"Stand: {schueler.AnzahlAbsolvierterStunden} Fahrstunden, " +
                          $"Autobahn: {autobahn}, prüfungsreif: {reif}");
    }
}
