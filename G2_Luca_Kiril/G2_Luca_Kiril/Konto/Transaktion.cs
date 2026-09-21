namespace G2_Luca_Kiril.Konto;

internal class Transaktion
{
    public Transaktion(decimal betrag, string art)
    {
        Betrag = betrag;
        Art = art;
        Datum = DateTimeOffset.Now;
    }

    public decimal Betrag { get; private set; }
    public string Art { get; private set; }
    public DateTimeOffset Datum { get; private set; }

    public string Beschreibung()
    {
        return $"{Datum:dd.MM.yyyy HH:mm:ss}  {Art,-10} {Betrag,10:0.00} CHF";
    }
}
