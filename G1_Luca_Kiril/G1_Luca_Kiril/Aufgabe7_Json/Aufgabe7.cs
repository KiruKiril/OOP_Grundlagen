using System.Text.Json;
using G1_Luca_Kiril.Aufgabe1_Buch;

namespace G1_Luca_Kiril.Aufgabe7_Json;

internal class Aufgabe7
{
    // Buch speichert seine Daten in Feldern, die der Serializer
    // ohne IncludeFields ueberspringen wuerde.
    private static readonly JsonSerializerOptions Optionen = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 7: JSON speichern und laden ===\n");

        string ordner = Path.Combine(AppContext.BaseDirectory, "json-ausgabe");
        Directory.CreateDirectory(ordner);

        Console.WriteLine($"Ablage: {ordner}\n");

        SpeichernUndLaden(ordner);
        RedundanzVermeiden(ordner);
    }

    private static void SpeichernUndLaden(string ordner)
    {
        Buch buch = new Buch
        {
            Titel = "Microserfs",
            Seiten = 300,
            ISBN = "978-3-455-01173-9",
            Verlag = "Hoffmann und Campe",
            Erscheinungsjahr = 1995,
            Autor = new Autor
            {
                Name = "Douglas Coupland",
                Nationalitaet = "CAN",
                Geburtsdatum = new DateTimeOffset(1961, 12, 30, 0, 0, 0, TimeSpan.Zero)
            }
        };

        Console.WriteLine($"Ohne IncludeFields: {JsonSerializer.Serialize(buch)}");
        Console.WriteLine("Leer, weil Buch Felder statt Eigenschaften hat.\n");

        string pfad = Path.Combine(ordner, "buch.json");
        File.WriteAllText(pfad, JsonSerializer.Serialize(buch, Optionen));

        Console.WriteLine("Mit IncludeFields:");
        Console.WriteLine(File.ReadAllText(pfad));

        Buch geladen = JsonSerializer.Deserialize<Buch>(File.ReadAllText(pfad), Optionen);

        Console.WriteLine("Zurückgelesen:");
        Console.WriteLine($"  {geladen.Titel} von {geladen.Autor.Name}, {geladen.Seiten} Seiten");
        Console.WriteLine($"  Dasselbe Objekt wie das Original: {ReferenceEquals(buch, geladen)}\n");
    }

    private static void RedundanzVermeiden(string ordner)
    {
        Autor coupland = new Autor
        {
            Name = "Douglas Coupland",
            Nationalitaet = "CAN",
            Geburtsdatum = new DateTimeOffset(1961, 12, 30, 0, 0, 0, TimeSpan.Zero)
        };

        List<Buch> redundant = new List<Buch>
        {
            new Buch { Titel = "Microserfs", Seiten = 300, ISBN = "978-3-455-01173-9", Autor = coupland },
            new Buch { Titel = "Generation X", Seiten = 224, ISBN = "978-0-312-05436-3", Autor = coupland },
            new Buch { Titel = "JPod", Seiten = 528, ISBN = "978-1-4000-4075-5", Autor = coupland }
        };

        string pfadRedundant = Path.Combine(ordner, "buecher-redundant.json");
        File.WriteAllText(pfadRedundant, JsonSerializer.Serialize(redundant, Optionen));

        Bibliothek bibliothek = new Bibliothek
        {
            Autoren = new List<AutorDaten>
            {
                new AutorDaten
                {
                    Id = 1,
                    Name = "Douglas Coupland",
                    Nationalitaet = "CAN",
                    Geburtsdatum = new DateTimeOffset(1961, 12, 30, 0, 0, 0, TimeSpan.Zero)
                }
            },
            Buecher = new List<BuchDaten>
            {
                new BuchDaten { Id = 1, Titel = "Microserfs", AutorId = 1, Seiten = 300, ISBN = "978-3-455-01173-9" },
                new BuchDaten { Id = 2, Titel = "Generation X", AutorId = 1, Seiten = 224, ISBN = "978-0-312-05436-3" },
                new BuchDaten { Id = 3, Titel = "JPod", AutorId = 1, Seiten = 528, ISBN = "978-1-4000-4075-5" }
            }
        };

        string pfadNormalisiert = Path.Combine(ordner, "bibliothek.json");
        File.WriteAllText(pfadNormalisiert, JsonSerializer.Serialize(bibliothek, Optionen));

        long redundantBytes = new FileInfo(pfadRedundant).Length;
        long normalisiertBytes = new FileInfo(pfadNormalisiert).Length;

        Console.WriteLine("Drei Bücher desselben Autors:");
        Console.WriteLine($"  buecher-redundant.json: {redundantBytes} Bytes, Autor steht dreimal drin");
        Console.WriteLine($"  bibliothek.json:        {normalisiertBytes} Bytes, Autor steht einmal drin");
        Console.WriteLine("  Die Bücher verweisen über die AutorId, wie ein Fremdschlüssel.\n");

        Bibliothek geladen = JsonSerializer.Deserialize<Bibliothek>(
            File.ReadAllText(pfadNormalisiert), Optionen);

        Console.WriteLine("Nach dem Laden über die Id verknüpft:");
        foreach (BuchDaten buch in geladen.Buecher)
        {
            AutorDaten autor = geladen.AutorZuBuch(buch);

            Console.WriteLine($"  {buch.Titel} von {autor.Name}, {buch.Seiten} Seiten");
        }

        Console.WriteLine();
    }
}
