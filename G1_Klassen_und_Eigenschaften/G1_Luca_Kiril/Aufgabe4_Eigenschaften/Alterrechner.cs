namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Alterrechner
{
    public static int Jahre(DateTimeOffset geburtsdatum)
    {
        DateTimeOffset heute = DateTimeOffset.Now;
        int jahre = heute.Year - geburtsdatum.Year;

        if (geburtsdatum.AddYears(jahre) > heute)
        {
            jahre--;
        }

        return jahre;
    }
}
