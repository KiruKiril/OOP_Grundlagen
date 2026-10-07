namespace G2_Luca_Kiril.Konto;

internal class Bankkonto
{
    private decimal saldo;
    private readonly List<Transaktion> transaktionen;

    public Bankkonto(string iban)
    {
        Iban = iban;
        saldo = 0m;

        transaktionen = new List<Transaktion>();
    }

    public string Iban { get; private set; }

    public decimal Saldo
    {
        get { return saldo; }
    }

    public int AnzahlTransaktionen
    {
        get { return transaktionen.Count; }
    }

    // Kurze Variante bucht auf heute, die lange nimmt das Datum entgegen.
    public void Einzahlen(decimal betrag, string zweck)
    {
        Einzahlen(betrag, zweck, DateTimeOffset.Now);
    }

    public void Einzahlen(decimal betrag, string zweck, DateTimeOffset datum)
    {
        if (betrag <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(betrag),
                "Der Betrag muss positiv sein.");
        }

        saldo += betrag;
        transaktionen.Add(new Transaktion(betrag, zweck, datum));
    }

    public void Abheben(decimal betrag, string zweck)
    {
        Abheben(betrag, zweck, DateTimeOffset.Now);
    }

    public void Abheben(decimal betrag, string zweck, DateTimeOffset datum)
    {
        if (betrag <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(betrag),
                "Der Betrag muss positiv sein.");
        }

        if (betrag > saldo)
        {
            throw new InvalidOperationException("Kontostand reicht nicht aus.");
        }

        saldo -= betrag;
        transaktionen.Add(new Transaktion(-betrag, zweck, datum));
    }

    // Kopie nach aussen. Wer sie veraendert, veraendert nur die Kopie.
    // Ob intern eine Liste, ein Array oder eine Queue steckt, bleibt
    // das Geheimnis der Klasse.
    public List<Transaktion> Auszug()
    {
        return new List<Transaktion>(transaktionen);
    }
}
