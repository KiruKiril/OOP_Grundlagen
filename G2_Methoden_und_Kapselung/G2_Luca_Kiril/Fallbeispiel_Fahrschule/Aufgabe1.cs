namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Aufgabe1
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 1: Methoden im Fallbeispiel ===");

        Fahrschule schule = Beispieldaten.Fahrschule();

        // Methode mit Parameter und Rueckgabewert
        Fahrschueler luca = schule.SucheSchueler("Luca Rossi");
        Console.WriteLine($"SucheSchueler(\"Luca Rossi\") liefert: {luca.Name}");
        Console.WriteLine($"SucheSchueler(\"Niemand\") liefert:    " +
                          $"{(schule.SucheSchueler("Niemand") == null ? "null" : "Treffer")}");

        Fahrlehrer fuerC = schule.SucheLehrerFuerKategorie("C");
        Console.WriteLine($"Lehrer für Kategorie C: {fuerC.Name}");
        Console.WriteLine($"Marco kann Kategorie C: " +
                          $"{schule.SucheLehrerFuerKategorie("A").KannKategorie("C")}");

        // Methode, die rechnet
        Console.WriteLine($"\nHonorar für 90 Minuten bei {fuerC.Name}: " +
                          $"{fuerC.BerechneHonorar(90):0.00} CHF");
        Console.WriteLine($"Gesamtumsatz der Fahrschule: {schule.Gesamtumsatz():0.00} CHF");

        // Methode, die den Zustand mehrerer Objekte veraendert
        Fahrstunde stunde = schule.Stundenplan()[0];
        Console.WriteLine($"\n{stunde.Beschreibung()}");
        Console.WriteLine($"vorher:  {stunde.Fahrzeug.KilometerStand} km, " +
                          $"{Stunden(stunde.Schueler.AnzahlAbsolvierterStunden)}");

        stunde.Durchfuehren(45);

        Console.WriteLine($"nachher: {stunde.Fahrzeug.KilometerStand} km, " +
                          $"{Stunden(stunde.Schueler.AnzahlAbsolvierterStunden)}");

        Console.WriteLine($"\nNoch fehlende Stunden bis zur Prüfung: " +
                          $"{luca.FehlendeStundenBisPruefung(10)}");
        Console.WriteLine($"Braucht der {stunde.Fahrzeug.Bezeichnung} Service? " +
                          $"{stunde.Fahrzeug.BrauchtService()}");
        Console.WriteLine();
    }

    private static string Stunden(int anzahl)
    {
        return anzahl == 1 ? "1 Stunde" : $"{anzahl} Stunden";
    }
}
