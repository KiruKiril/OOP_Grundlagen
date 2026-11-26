namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

// Aufgabe 5: konsequent gekapselte Klasse.
// Das Geheimnis ist der Kilometerstand. Er liegt in einem privaten Feld,
// ist nach aussen nur lesbar und wachst einzig ueber KilometerFahren.
internal class Fahrzeug
{
    private readonly string marke;
    private readonly string modell;
    private readonly string kontrollschild;
    private int kilometerStand;
    private DateTimeOffset letzteAenderung = DateTimeOffset.Now;

    public Fahrzeug(string marke, string modell, string kontrollschild,
                    int kilometerStand)
    {
        if (kilometerStand < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(kilometerStand),
                "Der Kilometerstand darf nicht negativ sein.");
        }

        this.marke = marke;
        this.modell = modell;
        this.kontrollschild = kontrollschild;
        this.kilometerStand = kilometerStand;
    }

    public string Bezeichnung
    {
        get { return $"{marke} {modell} ({kontrollschild})"; }
    }

    public int KilometerStand
    {
        get { return kilometerStand; }
    }

    public DateTimeOffset LetzteAenderung
    {
        get { return letzteAenderung; }
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
}
