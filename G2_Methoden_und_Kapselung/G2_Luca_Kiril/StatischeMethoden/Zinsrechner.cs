namespace G2_Luca_Kiril.StatischeMethoden;

// Statische Methoden gehoeren zur Klasse, nicht zu einem Objekt.
// Darum braucht es hier kein new Zinsrechner().
// Betraege sind ganze Rappen wie im ganzen Projekt, der Zinssatz ist
// ein Prozentwert und darum eine Kommazahl.
internal static class Zinsrechner
{
    public static int Jahreszins(int rappen, decimal satzProzent)
    {
        return (int)Math.Round(rappen * satzProzent / 100m);
    }

    public static int Endkapital(int rappen, decimal satzProzent, int jahre)
    {
        int ergebnis = rappen;

        for (int jahr = 0; jahr < jahre; jahr++)
        {
            ergebnis += Jahreszins(ergebnis, satzProzent);
        }

        return ergebnis;
    }
}
