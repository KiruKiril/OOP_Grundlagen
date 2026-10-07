using G2_Luca_Kiril.Tierpflege;

namespace G2_Luca_Kiril.Konto;

internal class Aufgabe3
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 3: Eine 1-m-Beziehung kapseln ===\n");

        Bankkonto konto = new Bankkonto("CH93 0076 2011 6238 5295 7", 500m);
        konto.Einzahlen(250m);
        konto.Abheben(120m);

        Console.WriteLine($"Konto {konto.Iban}");
        Console.WriteLine($"Saldo: {konto.Saldo:0.00} CHF");
        Console.WriteLine($"Transaktionen: {konto.AnzahlTransaktionen}\n");

        foreach (Transaktion transaktion in konto.Auszug())
        {
            Console.WriteLine($"  {transaktion.Beschreibung()}");
        }

        KopieZeigen(konto);
        Tierbeispiel();
    }

    // Der Auszug ist eine Kopie. Wer daran herumraeumt, trifft das Konto nicht.
    private static void KopieZeigen(Bankkonto konto)
    {
        Console.WriteLine("\nVersuch, den Auszug von aussen zu manipulieren:");

        List<Transaktion> kopie = konto.Auszug();
        kopie.Clear();

        Console.WriteLine($"  Kopie nach Clear: {kopie.Count} Einträge");
        Console.WriteLine($"  Konto unverändert: {konto.AnzahlTransaktionen} Transaktionen");
        Console.WriteLine("  Von aussen ist nicht erkennbar, ob intern eine Liste,");
        Console.WriteLine("  ein Array oder eine Queue steckt. Die Schnittstelle bleibt gleich.");
    }

    private static void Tierbeispiel()
    {
        Console.WriteLine("\nDasselbe Muster am eigenen Beispiel: Tier und Fütterungen\n");

        Tier simba = new Tier("Kibo", "Löwe");
        simba.Fuettern(4500, "Rindfleisch");
        simba.Fuettern(3800, "Pferdefleisch");
        simba.Fuettern(4200, "Rindfleisch");

        Console.WriteLine($"{simba.Name} ({simba.Art})");
        Console.WriteLine($"Fütterungen: {simba.AnzahlFuetterungen}");
        Console.WriteLine($"Gesamtmenge: {simba.GesamtmengeGramm()} g");
        Console.WriteLine($"Letzte Fütterung: {simba.LetzteFuetterung:HH:mm:ss}\n");

        foreach (Fuetterung fuetterung in simba.Fuetterungen())
        {
            Console.WriteLine($"  {fuetterung.Beschreibung()}");
        }

        Console.WriteLine();
    }
}
