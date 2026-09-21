namespace G2_Luca_Kiril.StatischeMethoden;

// Statische Methoden gehoeren zur Klasse, nicht zu einem Objekt.
// Darum braucht es hier kein new Zinsrechner().
internal class Zinsrechner
{
    public static decimal Jahreszins(decimal kapital, decimal satzProzent)
    {
        return kapital * satzProzent / 100m;
    }

    public static decimal Endkapital(decimal kapital, decimal satzProzent, int jahre)
    {
        decimal ergebnis = kapital;

        for (int jahr = 0; jahr < jahre; jahr++)
        {
            ergebnis += Jahreszins(ergebnis, satzProzent);
        }

        return ergebnis;
    }

    public static int Addiere(int a, int b)
    {
        return a + b;
    }
}
