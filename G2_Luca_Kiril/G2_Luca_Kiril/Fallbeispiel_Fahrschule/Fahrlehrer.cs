namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrlehrer
{
    private decimal stundenansatz;

    public Fahrlehrer(string name, decimal stundenansatz)
    {
        Name = name;
        Stundenansatz = stundenansatz;
    }

    public Fahrlehrer(string name, decimal stundenansatz, List<string> kategorien)
        : this(name, stundenansatz)
    {
        Kategorien = kategorien;
    }

    public string Name { get; set; }
    public DateTimeOffset Geburtsdatum { get; set; }
    public string Telefon { get; set; }
    public List<string> Kategorien { get; set; } = new List<string>();

    public decimal Stundenansatz
    {
        get { return stundenansatz; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Der Stundenansatz muss grösser als 0 sein.");
            }

            stundenansatz = value;
        }
    }

    public bool KannKategorie(string kategorie)
    {
        return Kategorien.Contains(kategorie);
    }

    public decimal BerechneHonorar(int dauerMinuten)
    {
        return Stundenansatz / 60m * dauerMinuten;
    }
}
