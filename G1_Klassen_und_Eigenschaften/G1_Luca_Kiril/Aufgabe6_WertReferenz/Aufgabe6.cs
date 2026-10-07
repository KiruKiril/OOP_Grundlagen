using G1_Luca_Kiril.Aufgabe1_Buch;

namespace G1_Luca_Kiril.Aufgabe6_WertReferenz;

internal class Aufgabe6
{
    public static void Ausfuehren()
    {
        Console.WriteLine("=== Aufgabe 6: byValue / byReference ===\n");

        int x = 10;
        int y = x;
        x = 20;

        Console.WriteLine("Werttyp int");
        Console.WriteLine("  Vorhersage:  10");
        Console.WriteLine($"  Tatsächlich: {y}\n");

        Buch buch1 = new Buch { Titel = "C# Programmierung" };
        Buch buch2 = buch1;
        buch1.Titel = "C# - Fortgeschritten";

        Console.WriteLine("Referenztyp Buch");
        Console.WriteLine("  Vorhersage:  C# - Fortgeschritten");
        Console.WriteLine($"  Tatsächlich: {buch2.Titel}");
        Console.WriteLine($"  Dasselbe Objekt: {ReferenceEquals(buch1, buch2)}\n");

        Buch buch3 = new Buch { Titel = "C# Programmierung" };
        Buch buch4 = new Buch { Titel = "C# Programmierung" };
        buch3.Titel = "Geändert";

        Console.WriteLine("Gegenprobe mit zwei eigenen Objekten");
        Console.WriteLine($"  buch3: {buch3.Titel}");
        Console.WriteLine($"  buch4: {buch4.Titel}");
        Console.WriteLine($"  Dasselbe Objekt: {ReferenceEquals(buch3, buch4)}\n");

        Console.WriteLine("Ein Werttyp speichert den Wert selbst, y = x kopiert ihn.");
        Console.WriteLine("Danach sind x und y unabhängig voneinander.");
        Console.WriteLine("Ein Referenztyp speichert nur die Adresse des Objekts.");
        Console.WriteLine("buch2 = buch1 kopiert die Adresse, nicht das Buch.");
        Console.WriteLine("Beide zeigen auf dasselbe Objekt, darum wirkt jede Änderung bei beiden.");
        Console.WriteLine();
    }
}
