namespace G1_Luca_Kiril.Aufgabe7_Json;

internal class Bibliothek
{
    public List<AutorDaten> Autoren { get; set; } = new List<AutorDaten>();
    public List<BuchDaten> Buecher { get; set; } = new List<BuchDaten>();

    public AutorDaten AutorZuBuch(BuchDaten buch)
    {
        foreach (AutorDaten autor in Autoren)
        {
            if (autor.Id == buch.AutorId)
            {
                return autor;
            }
        }

        return null;
    }
}

internal class AutorDaten
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Nationalitaet { get; set; }
    public DateTimeOffset Geburtsdatum { get; set; }
}

internal class BuchDaten
{
    public int Id { get; set; }
    public string Titel { get; set; }
    public int AutorId { get; set; }
    public int Seiten { get; set; }
    public string ISBN { get; set; }
}
