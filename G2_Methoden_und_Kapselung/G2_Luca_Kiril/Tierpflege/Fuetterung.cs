namespace G2_Luca_Kiril.Tierpflege;

internal class Fuetterung
{
    public Fuetterung(int mengeGramm, string futter)
    {
        MengeGramm = mengeGramm;
        Futter = futter;
        Zeitpunkt = DateTimeOffset.Now;
    }

    public int MengeGramm { get; private set; }
    public string Futter { get; private set; }
    public DateTimeOffset Zeitpunkt { get; private set; }

    public string Beschreibung()
    {
        return $"{Zeitpunkt:dd.MM.yyyy HH:mm:ss}  {Futter,-16} {MengeGramm,6} g";
    }
}
