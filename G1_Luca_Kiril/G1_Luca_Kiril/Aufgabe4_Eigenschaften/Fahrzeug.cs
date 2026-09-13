namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Fahrzeug
{
    private int baujahr;
    private int kilometerStand;

    public string Marke { get; set; }
    public string Modell { get; set; }
    public string Kontrollschild { get; set; }
    public string Getriebe { get; set; }

    public int Baujahr
    {
        get { return baujahr; }
        set
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
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Der Kilometerstand darf nicht negativ sein.");
            }

            if (value < kilometerStand)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Der Kilometerstand kann nicht kleiner werden.");
            }

            kilometerStand = value;
        }
    }

    public string Bezeichnung
    {
        get { return $"{Marke} {Modell} ({Kontrollschild})"; }
    }

    public int AlterInJahren
    {
        get { return DateTimeOffset.Now.Year - Baujahr; }
    }

    public bool BrauchtService
    {
        get { return KilometerStand > 100000 || AlterInJahren > 8; }
    }
}
