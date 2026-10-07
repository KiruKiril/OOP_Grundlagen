namespace G2_Luca_Kiril.Tierpflege;

internal class Tier
{
    private readonly List<Fuetterung> fuetterungen;
    private DateTimeOffset? letzteFuetterung;

    public Tier(string name, string art)
    {
        Name = name;
        Art = art;
        fuetterungen = new List<Fuetterung>();
    }

    public string Name { get; private set; }
    public string Art { get; private set; }

    public int AnzahlFuetterungen
    {
        get { return fuetterungen.Count; }
    }

    public DateTimeOffset? LetzteFuetterung
    {
        get { return letzteFuetterung; }
    }

    public void Fuettern(int mengeGramm, string futter)
    {
        if (mengeGramm <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mengeGramm),
                "Die Futtermenge muss positiv sein.");
        }

        fuetterungen.Add(new Fuetterung(mengeGramm, futter));
        letzteFuetterung = DateTimeOffset.Now;
    }

    public int GesamtmengeGramm()
    {
        int summe = 0;

        foreach (Fuetterung fuetterung in fuetterungen)
        {
            summe += fuetterung.MengeGramm;
        }

        return summe;
    }

    public List<Fuetterung> Fuetterungen()
    {
        return new List<Fuetterung>(fuetterungen);
    }
}
