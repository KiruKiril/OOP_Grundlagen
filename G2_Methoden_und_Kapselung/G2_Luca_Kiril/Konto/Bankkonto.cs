namespace G2_Luca_Kiril.Konto;

internal class Bankkonto
{
    private int saldo;
    private readonly List<Transaktion> transaktionen;

    public Bankkonto(string iban)
    {
        Iban = iban;
        saldo = 0;

        transaktionen = new List<Transaktion>();
    }

    public string Iban { get; private set; }

    public int Saldo
    {
        get { return saldo; }
    }

    public int AnzahlTransaktionen
    {
        get { return transaktionen.Count; }
    }

    public void Einzahlen(int betrag)
    {
        Einzahlen(betrag, DateTimeOffset.Now);
    }

    public void Einzahlen(int betrag, DateTimeOffset datum)
    {
        if (betrag <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(betrag),
                "Der Betrag muss positiv sein.");
        }

        saldo += betrag;
        transaktionen.Add(new Transaktion(betrag, datum));
    }

    public void Abheben(int betrag)
    {
        Abheben(betrag, DateTimeOffset.Now);
    }

    public void Abheben(int betrag, DateTimeOffset datum)
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
        transaktionen.Add(new Transaktion(-betrag, datum));
    }
    
    public List<Transaktion> Auszug()
    {
        return new List<Transaktion>(transaktionen);
    }
}
