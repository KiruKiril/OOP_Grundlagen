namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrschueler
{
    private readonly DateTimeOffset registriertAm = DateTimeOffset.Now;
    private string email;
    private int anzahlAbsolvierterStunden;

    // Kurzer Konstruktor: nur das Nötigste.
    public Fahrschueler(string name, DateTimeOffset geburtsdatum)
    {
        Name = name;
        Geburtsdatum = geburtsdatum;
    }

    // Überladung: ruft mit this(...) den kurzen Konstruktor auf und ergänzt den Rest.
    public Fahrschueler(string name, DateTimeOffset geburtsdatum, string email,
                        bool hatLernfahrausweis)
        : this(name, geburtsdatum)
    {
        Email = email;
        HatLernfahrausweis = hatLernfahrausweis;
    }

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
    }

    public int Alter
    {
        get { return Alterrechner.Jahre(Geburtsdatum); }
    }

    public bool IstPruefungsreif
    {
        get { return HatLernfahrausweis && Alter >= 18 && anzahlAbsolvierterStunden >= 10; }
    }

    public void StundeGutschreiben()
    {
        anzahlAbsolvierterStunden++;
    }

    public int FehlendeStundenBisPruefung(int benoetigt)
    {
        int offen = benoetigt - anzahlAbsolvierterStunden;
        return offen > 0 ? offen : 0;
    }
}
