namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Fahrschueler
{
    private readonly DateTimeOffset registriertAm = DateTimeOffset.Now;
    private string email;
    private int anzahlAbsolvierterStunden;

    public string Name { get; set; }
    public DateTimeOffset Geburtsdatum { get; set; }
    public bool HatLernfahrausweis { get; set; }

    public DateTimeOffset RegistriertAm
    {
        get { return registriertAm; }
    }

    public string Email
    {
        get { return email; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains('@'))
            {
                throw new ArgumentException("Die E-Mail-Adresse muss ein @ enthalten.",
                    nameof(value));
            }

            email = value;
        }
    }

    public int AnzahlAbsolvierterStunden
    {
        get { return anzahlAbsolvierterStunden; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Die Anzahl Stunden darf nicht negativ sein.");
            }

            anzahlAbsolvierterStunden = value;
        }
    }

    public int Alter
    {
        get { return Alterrechner.Jahre(Geburtsdatum); }
    }

    public bool IstPruefungsreif
    {
        get { return HatLernfahrausweis && Alter >= 18 && AnzahlAbsolvierterStunden >= 10; }
    }
}
