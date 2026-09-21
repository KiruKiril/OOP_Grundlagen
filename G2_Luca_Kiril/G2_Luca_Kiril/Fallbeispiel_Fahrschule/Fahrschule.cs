namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Fahrschule
{
    private readonly List<Fahrlehrer> lehrer = new List<Fahrlehrer>();
    private readonly List<Fahrschueler> schueler = new List<Fahrschueler>();
    private readonly List<Fahrzeug> fahrzeuge = new List<Fahrzeug>();
    private readonly List<Fahrstunde> stundenplan = new List<Fahrstunde>();

    public Fahrschule(string name)
    {
        Name = name;
    }

    public Fahrschule(string name, string adresse)
        : this(name)
    {
        Adresse = adresse;
    }

    public string Name { get; private set; }
    public string Adresse { get; private set; }

    public int AnzahlSchueler
    {
        get { return schueler.Count; }
    }

    public void SchuelerAufnehmen(Fahrschueler neuerSchueler)
    {
        if (neuerSchueler == null)
        {
            throw new ArgumentNullException(nameof(neuerSchueler));
        }

        schueler.Add(neuerSchueler);
    }

    public void LehrerAnstellen(Fahrlehrer neuerLehrer)
    {
        lehrer.Add(neuerLehrer);
    }

    public void FahrzeugAufnehmen(Fahrzeug neuesFahrzeug)
    {
        fahrzeuge.Add(neuesFahrzeug);
    }

    public void StundePlanen(Fahrstunde stunde)
    {
        stundenplan.Add(stunde);
    }

    public Fahrschueler SucheSchueler(string name)
    {
        foreach (Fahrschueler eintrag in schueler)
        {
            if (eintrag.Name == name)
            {
                return eintrag;
            }
        }

        return null;
    }

    public Fahrlehrer SucheLehrerFuerKategorie(string kategorie)
    {
        foreach (Fahrlehrer eintrag in lehrer)
        {
            if (eintrag.KannKategorie(kategorie))
            {
                return eintrag;
            }
        }

        return null;
    }

    public decimal Gesamtumsatz()
    {
        decimal summe = 0m;

        foreach (Fahrstunde stunde in stundenplan)
        {
            summe += stunde.Kosten();
        }

        return summe;
    }

    // Kopie der Liste, damit von aussen niemand den Stundenplan umbaut.
    public List<Fahrstunde> Stundenplan()
    {
        return new List<Fahrstunde>(stundenplan);
    }

    public List<Fahrzeug> Fahrzeuge()
    {
        return new List<Fahrzeug>(fahrzeuge);
    }
}
