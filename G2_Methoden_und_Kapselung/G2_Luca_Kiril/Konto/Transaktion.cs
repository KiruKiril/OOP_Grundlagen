namespace G2_Luca_Kiril.Konto;

internal class Transaktion
{
    public Transaktion(int betrag, string zweck, DateTimeOffset datum)
    {
        Betrag = betrag;
        Zweck = zweck;
        Datum = datum;
    }

    public int Betrag { get; private set; }
    public string Zweck { get; private set; }
    public DateTimeOffset Datum { get; private set; }

    public string Zeile()
    {
        string vorzeichen = Betrag < 0 ? "-" : "+";

        return $"{Datum:dd.MM.yyyy}  {vorzeichen} {Geld.AlsText(Math.Abs(Betrag)),12}  {Zweck}";
    }
}
