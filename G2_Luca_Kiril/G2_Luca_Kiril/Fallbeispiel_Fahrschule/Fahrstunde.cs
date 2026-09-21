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

    public DateTimeOffset Ende
    {
        get { return Beginn.AddMinutes(dauerMinuten); }
    }

    public decimal Kosten()
    {
        return Lehrer.BerechneHonorar(dauerMinuten);
    }

    // Wird die Stunde durchgefuehrt, wachsen Kilometerstand und Stundenkonto.
    public void Durchfuehren(int gefahreneKilometer)
    {
        Fahrzeug.KilometerFahren(gefahreneKilometer);
        Schueler.StundeGutschreiben();
    }

    public string Beschreibung()
    {
        return $"{Beginn:dd.MM.yyyy HH:mm} bis {Ende:HH:mm}, {Schueler.Name} " +
               $"bei {Lehrer.Name} im {Fahrzeug.Bezeichnung}";
    }
}
