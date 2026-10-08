namespace G2_Luca_Kiril.Konto;

internal class Aufgabe4
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 4: Klasse Konto kapseln und testen ===\n");

        Bankkonto konto = new Bankkonto("CH93 XXXX XXXX XXXX 2957");
        konto.Einzahlen(100000);

        Console.WriteLine($"Startsaldo: {Geld.AlsText(konto.Saldo)}\n");

        Einzahlen(konto, 50000);
        Abheben(konto, 20000);
        Einzahlen(konto, 0);
        Einzahlen(konto, -10000);
        Abheben(konto, -5000);
        Abheben(konto, 9999900);

        Console.WriteLine($"\nEndsaldo: {Geld.AlsText(konto.Saldo)}");
        

        Console.WriteLine();
    }

    private static void Einzahlen(Bankkonto konto, int rappen)
    {
        try
        {
            konto.Einzahlen(rappen);
            Melden("Einzahlen", rappen, Geld.AlsText(konto.Saldo));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Melden("Einzahlen", rappen, Grund(ex));
        }
    }

    private static void Abheben(Bankkonto konto, int rappen)
    {
        try
        {
            konto.Abheben(rappen);
            Melden("Abheben", rappen, Geld.AlsText(konto.Saldo));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Melden("Abheben", rappen, Grund(ex));
        }
        catch (InvalidOperationException ex)
        {
            Melden("Abheben", rappen, ex.Message);
        }
    }

    private static void Melden(string aktion, int rappen, string ergebnis)
    {
        Console.WriteLine($"{aktion,-10}{Geld.AlsText(rappen),16}  ->  {ergebnis}");
    }

    private static string Grund(ArgumentException ex)
    {
        return ex.Message.Split('(')[0].Trim();
    }
}
