namespace G1_Luca_Kiril.Aufgabe1_Buch;

internal class Aufgabe1
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 1: Klasse Buch ===\n");

        Autor coupland = new Autor
        {
            Name = "Douglas Coupland",
            Nationalitaet = "CAN",
            Geburtsdatum = new DateTimeOffset(1961, 12, 30, 0, 0, 0, TimeSpan.Zero)
        };

        Autor gutenberg = new Autor
        {
            Name = "Johannes Gutenberg",
            Nationalitaet = "DEU",
            Geburtsdatum = new DateTimeOffset(1400, 1, 1, 0, 0, 0, TimeSpan.Zero)
        };

        Buch meinLieblingsbuch = new Buch();
        meinLieblingsbuch.Titel = "Microserfs";
        meinLieblingsbuch.Autor = coupland;
        meinLieblingsbuch.Seiten = 300;
        meinLieblingsbuch.ISBN = "978-3-455-01173-9";
        meinLieblingsbuch.Verlag = "Hoffmann und Campe";
        meinLieblingsbuch.Erscheinungsjahr = 1995;

        Buch meinAeltestesBuch = new Buch
        {
            Titel = "Gutenbergs Leiden",
            Autor = gutenberg,
            Seiten = 512,
            ISBN = "978-3-000-00000-1",
            Verlag = "Mainzer Presse",
            Erscheinungsjahr = 1455
        };

        Ausgeben(meinLieblingsbuch);
        Ausgeben(meinAeltestesBuch);
    }

    private static void Ausgeben(Buch buch)
    {
        Console.WriteLine($"Titel:  {buch.Titel}");
        Console.WriteLine($"Autor:  {buch.Autor.Name} ({buch.Autor.Nationalitaet}, " +
                          $"geboren {buch.Autor.Geburtsdatum:dd.MM.yyyy})");
        Console.WriteLine($"Seiten: {buch.Seiten}");
        Console.WriteLine($"ISBN:   {buch.ISBN}");
        Console.WriteLine($"Verlag: {buch.Verlag}, {buch.Erscheinungsjahr}");
        Console.WriteLine();
    }
}
