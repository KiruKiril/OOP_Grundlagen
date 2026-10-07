namespace G2_Luca_Kiril.Konto;

// Aufgaben 3 und 4: Der Saldo und die Transaktionen sind privat.
// Nach aussen gibt es nur Einzahlen, Abheben und Lesezugriffe.
internal class Bankkonto
{
    private decimal saldo;
    private readonly List<Transaktion> transaktionen;

    public Bankkonto(string iban)
    {
        Iban = iban;
        saldo = 0m;

        // Im Konstruktor initialisiert, damit die Klasse ab dem ersten
        // Moment funktioniert und keine leere Referenz zurueckbleibt.
        transaktionen = new List<Transaktion>();
    }

    public Bankkonto(string iban, decimal startsaldo)
        : this(iban)
    {
        if (startsaldo < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startsaldo),
                "Der Startsaldo darf nicht negativ sein.");
        }

        if (startsaldo > 0)
        {
            Einzahlen(startsaldo);
        }
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

    public void Einzahlen(decimal betrag)
    {
        if (betrag <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(betrag),
                "Der Betrag muss positiv sein.");
        }

        saldo += betrag;
        transaktionen.Add(new Transaktion(betrag, "Einzahlung"));
    }

    public void Abheben(decimal betrag)
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
        transaktionen.Add(new Transaktion(-betrag, "Auszahlung"));
    }

    // Kopie nach aussen. Wer sie veraendert, veraendert nur die Kopie.
    // Ob intern eine Liste, ein Array oder eine Queue steckt, bleibt
    // das Geheimnis der Klasse.
    public List<Transaktion> Auszug()
    {
        return new List<Transaktion>(transaktionen);
    }
}
