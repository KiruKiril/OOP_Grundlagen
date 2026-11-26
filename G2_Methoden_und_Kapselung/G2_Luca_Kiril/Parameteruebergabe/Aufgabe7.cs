namespace G2_Luca_Kiril.Parameteruebergabe;

internal class Aufgabe7
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 7: byValue / byReference bei Parametern ===\n");

        int a = 5;
        Adding1(a);

        Console.WriteLine("Werttyp int");
        Console.WriteLine("  Vorhersage:  5");
        Console.WriteLine($"  Tatsächlich: {a}\n");

        Buch buch = new Buch { Titel = "C#" };
        RenameBuch(buch);

        Console.WriteLine("Referenztyp Buch");
        Console.WriteLine("  Vorhersage:  Neuer Titel");
        Console.WriteLine($"  Tatsächlich: {buch.Titel}\n");

        int b = 5;
        Adding1MitRef(ref b);

        Console.WriteLine("Werttyp int mit ref");
        Console.WriteLine("  Vorhersage:  6");
        Console.WriteLine($"  Tatsächlich: {b}\n");

        Erklaerung();
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
        Console.WriteLine("genau jenes Objekt, das der Aufrufer in der Hand hält.\n");

        Console.WriteLine("Seiteneffekt");
        Console.WriteLine("RenameBuch gibt nichts zurück und sieht am Aufruf harmlos aus,");
        Console.WriteLine("verändert aber das übergebene Objekt dauerhaft. Wer nur den Aufruf");
        Console.WriteLine("liest, rechnet nicht damit, und der Fehler fällt später an einer");
        Console.WriteLine("ganz anderen Stelle auf. Besser ist eine Methode auf dem Objekt");
        Console.WriteLine("selbst, etwa buch.TitelAendern(...), weil dort sichtbar ist,");
        Console.WriteLine("wer da ändert.\n");
    }
}
