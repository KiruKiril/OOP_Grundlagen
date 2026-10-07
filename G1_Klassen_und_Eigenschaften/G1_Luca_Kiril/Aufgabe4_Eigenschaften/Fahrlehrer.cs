namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Fahrlehrer
{
    private decimal stundenansatz;

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

    public int Alter
    {
        get { return Alterrechner.Jahre(Geburtsdatum); }
    }
}
