namespace G2_Luca_Kiril.Konto;

internal class Aufgabe4
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 4: Klasse Konto kapseln und testen ===\n");

        Bankkonto konto = new Bankkonto("CH93 XXXX XXXX XXXX 2957");
        konto.Einzahlen(1000m, "Starteinlage");
        Console.WriteLine($"Startsaldo: {konto.Saldo:0.00} CHF\n");

        Console.WriteLine("Gültige Werte:");
        Einzahlen(konto, 500m);
        Abheben(konto, 200m);

        Console.WriteLine("\nUngültige Werte:");
        Einzahlen(konto, 0m);
        Einzahlen(konto, -100m);
        Abheben(konto, -50m);
        Abheben(konto, 99999m);

        Console.WriteLine($"\nEndsaldo: {konto.Saldo:0.00} CHF");
        Console.WriteLine("Jeder abgelehnte Versuch hat den Saldo unberührt gelassen.");
        Console.WriteLine("Ein öffentliches Feld Saldo hätte konto.Saldo = -5000 erlaubt.");
        Console.WriteLine();
    }

    private static void Einzahlen(Bankkonto konto, decimal betrag)
    {
        try
        {
            konto.Einzahlen(betrag, "Einzahlung");
            Console.WriteLine($"  Einzahlen {betrag,9:0.00}: neuer Saldo {konto.Saldo:0.00} CHF");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  Einzahlen {betrag,9:0.00}: {Meldung(ex)}");
        }
    }

    private static void Abheben(Bankkonto konto, decimal betrag)
    {
        try
        {
            konto.Abheben(betrag, "Bezug");
            Console.WriteLine($"  Abheben   {betrag,9:0.00}: neuer Saldo {konto.Saldo:0.00} CHF");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  Abheben   {betrag,9:0.00}: {Meldung(ex)}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  Abheben   {betrag,9:0.00}: {ex.Message}");
        }
    }

    private static string Meldung(ArgumentException ex)
    {
        return ex.Message.Split('(')[0].Trim();
    }
}
