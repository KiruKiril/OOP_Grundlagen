using System.Text;

namespace G2_Luca_Kiril;

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
                    Fallbeispiel_Fahrschule.Aufgabe1.Ausfuehren();
                    break;
                case "2":
                    Fallbeispiel_Fahrschule.Aufgabe2.Ausfuehren();
                    break;
                case "3":
                    Konto.Aufgabe3.Ausfuehren();
                    break;
                case "4":
                    Konto.Aufgabe4.Ausfuehren();
                    break;
                case "5":
                    Fallbeispiel_Fahrschule.Aufgabe5.Ausfuehren();
                    break;
                case "6":
                    StatischeMethoden.Aufgabe6.Ausfuehren();
                    break;
                case "7":
                    Parameteruebergabe.Aufgabe7.Ausfuehren();
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
        Console.WriteLine("Arbeitsblatt G2 - Methoden & Kapselung");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("1  Methoden im Fallbeispiel");
        Console.WriteLine("2  Konstruktoren mit Überladung");
        Console.WriteLine("3  1-m-Beziehung kapseln");
        Console.WriteLine("4  Klasse Konto kapseln und testen");
        Console.WriteLine("5  Kapselung im eigenen Fallbeispiel");
        Console.WriteLine("6  Statische Methoden");
        Console.WriteLine("7  byValue / byReference bei Parametern");
        Console.WriteLine("0  Beenden");
        Console.Write("\nAuswahl: ");
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
