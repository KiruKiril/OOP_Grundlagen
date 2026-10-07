namespace G1_Luca_Kiril.Aufgabe2_Zoo;

internal class Aufgabe2
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 2: Fallbeispiel Zoo ===\n");

        Pfleger anna = new Pfleger
        {
            Name = "Anna Meier",
            Fachgebiet = "Raubtiere",
            Personalnummer = 1001
        };

        Pfleger bruno = new Pfleger
        {
            Name = "Bruno Steiner",
            Fachgebiet = "Vögel",
            Personalnummer = 1002
        };

        Tier kibo = new Tier
        {
            Name = "Kibo",
            Art = "Löwe",
            Geburtsdatum = new DateTimeOffset(2018, 4, 12, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 190.5
        };

        Tier zuri = new Tier
        {
            Name = "Zuri",
            Art = "Löwin",
            Geburtsdatum = new DateTimeOffset(2019, 7, 3, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 158.2
        };

        Tier rani = new Tier
        {
            Name = "Rani",
            Art = "Amurtiger",
            Geburtsdatum = new DateTimeOffset(2017, 5, 26, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 164.0
        };

        Tier coco = new Tier
        {
            Name = "Coco",
            Art = "Graupapagei",
            Geburtsdatum = new DateTimeOffset(2015, 2, 20, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 0.45
        };

        Tier kiwi = new Tier
        {
            Name = "Kiwi",
            Art = "Gelbbrustara",
            Geburtsdatum = new DateTimeOffset(2021, 9, 30, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 1.1
        };

        Tier pedro = new Tier
        {
            Name = "Pedro",
            Art = "Wellensittich",
            Geburtsdatum = new DateTimeOffset(2023, 3, 8, 0, 0, 0, TimeSpan.Zero),
            GewichtKg = 0.04
        };

        Kaefig raubtierhaus = new Kaefig
        {
            Bezeichnung = "Raubtierhaus",
            FlaecheQm = 450.0,
            IstAussengehege = true,
            ZustaendigerPfleger = anna,
            Tiere = new List<Tier> { kibo, zuri, rani }
        };

        Kaefig voliere = new Kaefig();
        voliere.Bezeichnung = "Grosse Voliere";
        voliere.FlaecheQm = 120.0;
        voliere.IstAussengehege = false;
        voliere.ZustaendigerPfleger = bruno;
        voliere.Tiere = new List<Tier>();
        voliere.Tiere.Add(coco);
        voliere.Tiere.Add(kiwi);
        voliere.Tiere.Add(pedro);

        Zoo zuerichZoo = new Zoo
        {
            Name = "Zoo Zürich",
            Ort = "Zürich",
            Kaefige = new List<Kaefig> { raubtierhaus, voliere },
            Pfleger = new List<Pfleger> { anna, bruno }
        };

        Ausgeben(zuerichZoo);
    }

    private static void Ausgeben(Zoo zoo)
    {
        Console.WriteLine($"{zoo.Name} in {zoo.Ort}");
        Console.WriteLine($"{zoo.Kaefige.Count} Käfige, {zoo.Pfleger.Count} Pfleger\n");

        foreach (Kaefig kaefig in zoo.Kaefige)
        {
            string lage = kaefig.IstAussengehege ? "Aussengehege" : "Innengehege";

            Console.WriteLine($"{kaefig.Bezeichnung} ({kaefig.FlaecheQm} m2, {lage})");
            Console.WriteLine($"  Pflege: {kaefig.ZustaendigerPfleger.Name}, " +
                              $"{kaefig.ZustaendigerPfleger.Fachgebiet}");

            foreach (Tier tier in kaefig.Tiere)
            {
                Console.WriteLine($"  - {tier.Name} ({tier.Art}), {tier.GewichtKg} kg, " +
                                  $"geboren {tier.Geburtsdatum:dd.MM.yyyy}");
            }

            Console.WriteLine();
        }
    }
}
