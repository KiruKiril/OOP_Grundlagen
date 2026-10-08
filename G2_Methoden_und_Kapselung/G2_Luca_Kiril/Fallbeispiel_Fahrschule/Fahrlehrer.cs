namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrlehrer
{
    private int stundenansatz;

    public Fahrlehrer(string name, int stundenansatz, List<string> kategorien)
    {
        Name = name;
        Stundenansatz = stundenansatz;
        Kategorien = kategorien;
    }

    public string Name { get; set; }
    public DateTimeOffset Geburtsdatum { get; set; }
    public string Telefon { get; set; }
    public List<string> Kategorien { get; set; } = new List<string>();

    public int Stundenansatz
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

    public int BerechneHonorar(int dauerMinuten)
    {
        return stundenansatz * dauerMinuten / 60;
    }
}
