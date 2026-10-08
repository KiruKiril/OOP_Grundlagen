namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrstunde
{
    private int dauerMinuten;

    public Fahrstunde(Fahrschueler schueler, Fahrlehrer lehrer, Fahrzeug fahrzeug,
                      DateTimeOffset beginn, int dauerMinuten)
    {
        Schueler = schueler;
        Lehrer = lehrer;
        Fahrzeug = fahrzeug;
        Beginn = beginn;
        DauerMinuten = dauerMinuten;
    }

    public Fahrschueler Schueler { get; private set; }
    public Fahrlehrer Lehrer { get; private set; }
    public Fahrzeug Fahrzeug { get; private set; }
    public DateTimeOffset Beginn { get; private set; }
    public string Thema { get; set; }
    public bool AufAutobahn { get; set; }

    public int DauerMinuten
    {
        get { return dauerMinuten; }
        private set
        {
            if (value < 45 || value > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Eine Fahrstunde dauert zwischen 45 und 180 Minuten.");
            }

            dauerMinuten = value;
        }
    }

    public int Kosten()
    {
        return Lehrer.BerechneHonorar(dauerMinuten);
    }

    public void Durchfuehren(int gefahreneKilometer)
    {
        Fahrzeug.KilometerFahren(gefahreneKilometer);
        Schueler.StundeEintragen(this);
    }
}
