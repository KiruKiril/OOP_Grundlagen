namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

// Aufgabe 5: konsequent gekapselte Klasse.
// Das Geheimnis der Klasse ist der Kilometerstand. Er ist privat und kann
// von aussen nur ueber KilometerFahren wachsen, nie sinken oder springen.
internal class Fahrzeug
{
    private readonly string marke;
    private readonly string modell;
    private string kontrollschild;
    private int baujahr;
    private int kilometerStand;
    private DateTimeOffset letzteAenderung = DateTimeOffset.Now;

    public Fahrzeug(string marke, string modell)
    {
        this.marke = marke;
        this.modell = modell;
    }

    public Fahrzeug(string marke, string modell, string kontrollschild,
                    int baujahr, int kilometerStand, string getriebe)
        : this(marke, modell)
    {
        this.kontrollschild = kontrollschild;
        Baujahr = baujahr;
        Getriebe = getriebe;

        if (kilometerStand < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kilometerStand),
                "Der Kilometerstand darf nicht negativ sein.");
        }

        this.kilometerStand = kilometerStand;
    }

    public string Getriebe { get; private set; }

    public int Baujahr
    {
        get { return baujahr; }
        private set
        {
            if (value < 1900 || value > DateTimeOffset.Now.Year)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Das Baujahr muss zwischen 1900 und heute liegen.");
            }

            baujahr = value;
        }
    }

    public int KilometerStand
    {
        get { return kilometerStand; }
    }

    public DateTimeOffset LetzteAenderung
    {
        get { return letzteAenderung; }
    }

    public string Bezeichnung
    {
        get
        {
            if (string.IsNullOrWhiteSpace(kontrollschild))
            {
                return $"{marke} {modell}";
            }

            return $"{marke} {modell} ({kontrollschild})";
        }
    }

    public int AlterInJahren
    {
        get { return DateTimeOffset.Now.Year - baujahr; }
    }

    // Einzige Tuer nach innen: prueft den Wert und fuehrt danach den
    // Zeitstempel nach (Trigger).
    public void KilometerFahren(int kilometer)
    {
        if (kilometer <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kilometer),
                "Die gefahrenen Kilometer müssen positiv sein.");
        }

        kilometerStand += kilometer;
        letzteAenderung = DateTimeOffset.Now;
    }

    public bool BrauchtService()
    {
        return kilometerStand > 100000 || AlterInJahren > 8;
    }
}
