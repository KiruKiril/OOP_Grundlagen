namespace G2_Luca_Kiril.Parameteruebergabe;

internal class Aufgabe7
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 7: byValue / byReference bei Parametern ===\n");

        int a = 5;
        int aVorher = a;
        Adding1(a);
        Block("Werttyp int, Adding1(a) erhöht a um 1",
            $"{aVorher}", "5", $"{a}");

        Buch buch = new Buch { Titel = "C#" };
        string titelVorher = buch.Titel;
        RenameBuch(buch);
        Block("Referenztyp Buch, RenameBuch(buch) setzt den Titel neu",
            titelVorher, "Neuer Titel", buch.Titel);

        int b = 5;
        int bVorher = b;
        Adding1MitRef(ref b);
        Block("Werttyp int mit ref, Adding1MitRef(ref b) erhöht b um 1",
            $"{bVorher}", "6", $"{b}");

        Erklaerung();
    }

    // Das Fazit wird aus den beiden Werten ermittelt, nicht hingeschrieben.
    private static void Block(string titel, string vorher, string vorhersage,
                              string nachher)
    {
        Console.WriteLine(titel);
        Console.WriteLine($"  vorher       {vorher}");
        Console.WriteLine($"  Vorhersage   {vorhersage}");
        Console.WriteLine($"  nachher      {nachher}");
        Console.WriteLine(vorher == nachher
            ? "  -> Das Original hat die Änderung nicht mitbekommen.\n"
            : "  -> Das Original wurde mitgeändert.\n");
    }

    private static void Adding1(int a)
    {
        a = a + 1;
    }

    private static void RenameBuch(Buch buch)
    {
        buch.Titel = "Neuer Titel";
    }

    // Mit ref wird die Variable selbst uebergeben, nicht ihr Wert.
    private static void Adding1MitRef(ref int a)
    {
        a = a + 1;
    }

    private static void Erklaerung()
    {
        Console.WriteLine("Warum a unverändert bleibt");
        Console.WriteLine("Adding1 bekommt eine Kopie des Wertes 5, erhöht diese Kopie auf 6");
        Console.WriteLine("und wirft sie beim Verlassen weg. Die Variable a wurde nie");
        Console.WriteLine("angefasst. Mit ref wird dagegen die Variable selbst übergeben,");
        Console.WriteLine("darum steht bei b anschliessend 6.\n");

        Console.WriteLine("Warum der Buchtitel sich ändert");
        Console.WriteLine("Kopiert wird auch hier, aber kopiert wird die Adresse des Objekts.");
        Console.WriteLine("Beide Adressen zeigen auf dasselbe Buch, darum ändert RenameBuch");
        Console.WriteLine("genau jenes Buch, das der Aufrufer in der Hand hält.\n");

        Console.WriteLine("Seiteneffekt");
        Console.WriteLine("RenameBuch gibt nichts zurück und sieht am Aufruf harmlos aus,");
        Console.WriteLine("verändert aber das übergebene Objekt dauerhaft. Wer nur den Aufruf");
        Console.WriteLine("liest, rechnet nicht damit, und der Fehler fällt später an einer");
        Console.WriteLine("ganz anderen Stelle auf. Besser ist eine Methode auf dem Objekt");
        Console.WriteLine("selbst, etwa buch.TitelAendern(...), weil dort sichtbar ist,");
        Console.WriteLine("wer da ändert.\n");
    }
}
