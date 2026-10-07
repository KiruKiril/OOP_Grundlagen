namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrschueler
{
    private readonly DateTimeOffset registriertAm = DateTimeOffset.Now;
    private readonly List<Fahrstunde> fahrstunden;
    private string email;

    public Fahrschueler(string name, DateTimeOffset geburtsdatum)
    {
        Name = name;
        Geburtsdatum = geburtsdatum;

        // Im Konstruktor erzeugt, damit die Klasse ab dem ersten
        // Moment funktioniert und keine leere Referenz zurueckbleibt.
        fahrstunden = new List<Fahrstunde>();
    }

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
        get { return fahrstunden.Count; }
    }

    public bool HatAutobahnGefahren
    {
        get
        {
            foreach (Fahrstunde stunde in fahrstunden)
            {
                if (stunde.AufAutobahn)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public int Alter
    {
        get { return Alterrechner.Jahre(Geburtsdatum); }
    }

    // Ohne Autobahnfahrt keine Prüfung, egal wie viele Fahrstunden
    public bool IstPruefungsreif
    {
        get
        {
            return HatLernfahrausweis
                   && Alter >= 18
                   && fahrstunden.Count >= 10
                   && HatAutobahnGefahren;
        }
    }

    public List<string> FehlendeAngaben()
    {
        List<string> fehlt = new List<string>();

        if (string.IsNullOrWhiteSpace(email))
        {
            fehlt.Add("E-Mail");
        }

        if (!HatLernfahrausweis)
        {
            fehlt.Add("Lernfahrausweis");
        }

        return fehlt;
    }

    public void StundeEintragen(Fahrstunde stunde)
    {
        if (stunde == null)
        {
            throw new ArgumentNullException(nameof(stunde));
        }

        fahrstunden.Add(stunde);
    }

    // Kopie nach aussen, damit niemand den Nachweis von aussen umschreibt.
    public List<Fahrstunde> Fahrstunden()
    {
        return new List<Fahrstunde>(fahrstunden);
    }
}
