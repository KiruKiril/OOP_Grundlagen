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

        MitRef();
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

    // Mit ref wird die Variable selbst übergeben, nicht ihr Wert.
    private static void Adding1MitRef(ref int a)
    {
        a = a + 1;
    }

    private static void MitRef()
    {
        int b = 5;
        Adding1MitRef(ref b);

        Console.WriteLine("Werttyp mit ref");
        Console.WriteLine($"  Tatsächlich: {b}");
        Console.WriteLine("  ref übergibt die Variable selbst, darum wirkt die Änderung.\n");
    }

    private static void Erklaerung()
    {
        Console.WriteLine("Warum a unverändert bleibt");
        Console.WriteLine("Die Methode bekommt eine Kopie des Wertes 5. Sie erhöht ihre");
        Console.WriteLine("eigene Kopie auf 6 und wirft sie beim Verlassen weg.");
        Console.WriteLine("Die Variable des Aufrufers wurde nie angefasst.\n");

        Console.WriteLine("Warum der Buchtitel sich ändert");
        Console.WriteLine("Kopiert wird auch hier, aber kopiert wird die Adresse des Objekts.");
        Console.WriteLine("Beide Adressen zeigen auf dasselbe Buch, darum ändert die Methode");
        Console.WriteLine("genau jenes Objekt, das der Aufrufer in der Hand hält.\n");

        Console.WriteLine("Seiteneffekt");
        Console.WriteLine("Die Methode verändert etwas ausserhalb ihrer selbst, ohne dass man");
        Console.WriteLine("es am Aufruf erkennt. RenameBuch gibt nichts zurück und sieht");
        Console.WriteLine("harmlos aus, ändert aber das übergebene Objekt dauerhaft.");
        Console.WriteLine("Das gilt als schlechter Stil, weil der Aufrufer die Änderung nicht");
        Console.WriteLine("erwartet, sie beim Lesen des Codes nicht sichtbar ist und Fehler");
        Console.WriteLine("dadurch an einer ganz anderen Stelle auffallen als dort, wo sie");
        Console.WriteLine("entstanden sind. Besser ist ein neues Objekt als Rückgabewert oder");
        Console.WriteLine("eine Methode auf dem Objekt selbst, etwa buch.TitelAendern(...).");
        Console.WriteLine();
    }
}
