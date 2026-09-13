using System.Text;

namespace G1_Luca_Kiril;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        bool weiter = true;

        while (weiter)
        {
            MenueAnzeigen();

            string eingabe = Console.ReadLine();
            Console.WriteLine();

            switch (eingabe)
            {
                case "1":
                    Aufgabe1_Buch.Aufgabe1.Ausfuehren();
                    break;
                case "2":
                    Aufgabe2_Zoo.Aufgabe2.Ausfuehren();
                    break;
                case "3":
                    Aufgabe3_Fallbeispiel.Aufgabe3.Ausfuehren();
                    break;
                case "4":
                    Aufgabe4_Eigenschaften.Aufgabe4.Ausfuehren();
                    break;
                case "5":
                    Aufgabe5_Erfassung.Aufgabe5.Ausfuehren();
                    break;
                case "6":
                    Aufgabe6_WertReferenz.Aufgabe6.Ausfuehren();
                    break;
                case "7":
                    Aufgabe7_Json.Aufgabe7.Ausfuehren();
                    break;
                case "a":
                case "A":
                    AlleAusfuehren();
                    break;
                case "0":
                    weiter = false;
                    break;
                default:
                    Console.WriteLine("Unbekannte Eingabe.\n");
                    break;
            }

            if (weiter)
            {
                Warten();
            }
        }
    }

    private static void MenueAnzeigen()
    {
        Console.WriteLine("Arbeitsblatt G1 - Klassen & Eigenschaften");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1  Klasse Buch");
        Console.WriteLine("2  Fallbeispiel Zoo");
        Console.WriteLine("3  Fahrschule mit Feldern");
        Console.WriteLine("4  Fahrschule mit Eigenschaften");
        Console.WriteLine("5  Erfassung über die Konsole");
        Console.WriteLine("6  byValue / byReference");
        Console.WriteLine("7  JSON speichern und laden");
        Console.WriteLine("a  alle ausser Aufgabe 5");
        Console.WriteLine("0  Beenden");
        Console.Write("\nAuswahl: ");
    }

    // Aufgabe 5 wartet auf Eingaben und laeuft deshalb nicht mit.
    private static void AlleAusfuehren()
    {
        Aufgabe1_Buch.Aufgabe1.Ausfuehren();
        Aufgabe2_Zoo.Aufgabe2.Ausfuehren();
        Aufgabe3_Fallbeispiel.Aufgabe3.Ausfuehren();
        Aufgabe4_Eigenschaften.Aufgabe4.Ausfuehren();
        Aufgabe6_WertReferenz.Aufgabe6.Ausfuehren();
        Aufgabe7_Json.Aufgabe7.Ausfuehren();
    }

    private static void Warten()
    {
        Console.WriteLine("Weiter mit einer beliebigen Taste.");

        if (!Console.IsInputRedirected)
        {
            Console.ReadKey(true);
        }

        Console.WriteLine();
    }
}
