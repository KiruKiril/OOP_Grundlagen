namespace G1_Luca_Kiril.Aufgabe4_Eigenschaften;

internal class Fahrschule
{
    public string Name { get; set; }
    public string Adresse { get; set; }

    public List<Fahrlehrer> Lehrer { get; set; } = new List<Fahrlehrer>();
    public List<Fahrschueler> Schueler { get; set; } = new List<Fahrschueler>();
    public List<Fahrzeug> Fahrzeuge { get; set; } = new List<Fahrzeug>();
    public List<Fahrstunde> Stundenplan { get; set; } = new List<Fahrstunde>();

    public int AnzahlSchueler
    {
        get { return Schueler.Count; }
    }

    public decimal Gesamtumsatz
    {
        get
        {
            decimal summe = 0m;

            foreach (Fahrstunde stunde in Stundenplan)
            {
                summe += stunde.Kosten;
            }

            return summe;
        }
    }
}
