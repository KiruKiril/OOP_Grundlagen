namespace G2_Luca_Kiril;

// Geldbeträge sind im ganzen Projekt ganze Rappen, 100 Rappen sind ein Franken.
// Ganzzahlen rechnen exakt, Kommazahlen sammeln Rundungsfehler an.
internal class Geld
{
    public static string AlsText(int rappen)
    {
        return $"{rappen / 100m:0.00} CHF";
    }
}
