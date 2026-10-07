namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Fahrstunde
{
    private int dauerMinuten;

    public DateTimeOffset Beginn { get; set; }
    public Fahrschueler Schueler { get; set; }
    public Fahrlehrer Lehrer { get; set; }
    public Fahrzeug Fahrzeug { get; set; }
    public string Thema { get; set; }

    public int DauerMinuten
    {
        get { return dauerMinuten; }
        set
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
        get { return Beginn.AddMinutes(DauerMinuten); }
    }

    public decimal Kosten
    {
        get
        {
            if (Lehrer == null)
            {
                return 0m;
            }

            return Lehrer.Stundenansatz / 60m * DauerMinuten;
        }
    }
}
