using G2_Luca_Kiril.Fallbeispiel_Fahrschule;

namespace G2_Luca_Kiril.Konto;

internal class Aufgabe3
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 3: Eine 1-m-Beziehung kapseln ===\n");

        Bankkonto konto = new Bankkonto("CH93 XXXX XXXX XXXX 2957");
        Console.WriteLine($"Konto eröffnet: {konto.Iban}, Saldo {Geld.AlsText(konto.Saldo)}\n");

        konto.Einzahlen(50000, DateTimeOffset.Now.AddDays(-12));
        konto.Abheben(13500, DateTimeOffset.Now.AddDays(-5));
        konto.Abheben(13500);

        foreach (Transaktion buchung in konto.Auszug())
        {
            Console.WriteLine($"  {buchung.Zeile()}");
        }

        Console.WriteLine($"\nSaldo: {Geld.AlsText(konto.Saldo)} aus " +
                          $"{konto.AnzahlTransaktionen} Buchungen");

        AuszugIstKopie(konto);
        DasselbeMusterInDerFahrschule();
    }

    private static void AuszugIstKopie(Bankkonto konto)
    {
        List<Transaktion> abgeholt = konto.Auszug();
        abgeholt.Clear();

        Console.WriteLine("\nAuszug abgeholt und darin alle Zeilen gelöscht:");
        Console.WriteLine($"  im abgeholten Auszug: {abgeholt.Count} Buchungen");
        Console.WriteLine($"  im Konto selbst:      {konto.AnzahlTransaktionen} Buchungen");
    }

    // Gleiches Muster, anderes Thema
    private static void DasselbeMusterInDerFahrschule()
    {
        Fahrschule schule = Beispieldaten.Fahrschule();
        Fahrschueler luca = schule.SucheSchueler("Luca Rossi");

        List<Fahrstunde> alle = luca.Fahrstunden();

        Console.WriteLine($"\n{luca.Name} hat {alle.Count} Fahrstunden, " +
                          $"die drei letzten:");

        for (int i = alle.Count - 3; i < alle.Count; i++)
        {
            Console.WriteLine($"  {alle[i].Beginn:dd.MM.yyyy}  {alle[i].Thema}");
        }

        List<Fahrstunde> nachweis = luca.Fahrstunden();
        nachweis.Clear();

        Console.WriteLine($"\nNachweis abgeholt und geleert:");
        Console.WriteLine($"  im abgeholten Nachweis: {nachweis.Count} Fahrstunden");
        Console.WriteLine($"  bei Luca selbst:        {luca.AnzahlAbsolvierterStunden} Fahrstunden");
        Console.WriteLine();
    }
}
