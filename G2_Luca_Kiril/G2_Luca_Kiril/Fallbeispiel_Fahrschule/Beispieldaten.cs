namespace G2_Luca_Kiril.Fallbeispiel_Fahrschule;

internal class Beispieldaten
{
    public static Fahrschule Fahrschule()
    {
        Fahrlehrer marco = new Fahrlehrer("Marco Bianchi", 95.00m,
            new List<string> { "B", "A" });
        marco.Geburtsdatum = new DateTimeOffset(1980, 3, 14, 0, 0, 0, TimeSpan.Zero);
        marco.Telefon = "079 111 22 33";

        Fahrlehrer sarah = new Fahrlehrer("Sarah Keller", 105.00m,
            new List<string> { "B", "C" });
        sarah.Geburtsdatum = new DateTimeOffset(1991, 11, 2, 0, 0, 0, TimeSpan.Zero);
        sarah.Telefon = "079 444 55 66";

        Fahrschueler luca = new Fahrschueler("Luca Rossi",
            new DateTimeOffset(2006, 6, 21, 0, 0, 0, TimeSpan.Zero),
            "luca.rossi@example.ch", true);

        Fahrschueler mia = new Fahrschueler("Mia Huber",
            new DateTimeOffset(2009, 1, 9, 0, 0, 0, TimeSpan.Zero));

        Fahrzeug golf = new Fahrzeug("VW", "Golf", "ZH 123 456", 2021, 48200,
            "Handschaltung");
        Fahrzeug corsa = new Fahrzeug("Opel", "Corsa", "ZH 654 321", 2015, 115300,
            "Automat");

        Fahrschule schule = new Fahrschule("Fahrschule Drive Easy",
            "Bahnhofstrasse 10, 8001 Zürich");

        schule.LehrerAnstellen(marco);
        schule.LehrerAnstellen(sarah);
        schule.SchuelerAufnehmen(luca);
        schule.SchuelerAufnehmen(mia);
        schule.FahrzeugAufnehmen(golf);
        schule.FahrzeugAufnehmen(corsa);

        Fahrstunde stunde1 = new Fahrstunde(luca, marco, golf,
            new DateTimeOffset(2026, 9, 15, 14, 0, 0, TimeSpan.Zero), 90);
        stunde1.Thema = "Autobahn auffahren und einspuren";

        Fahrstunde stunde2 = new Fahrstunde(mia, sarah, corsa,
            new DateTimeOffset(2026, 9, 16, 9, 30, 0, TimeSpan.Zero), 45);
        stunde2.Thema = "Rückwärts parkieren";

        schule.StundePlanen(stunde1);
        schule.StundePlanen(stunde2);

        return schule;
    }
}
