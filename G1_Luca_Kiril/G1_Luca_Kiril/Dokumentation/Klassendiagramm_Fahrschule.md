# Klassendiagramm Fahrschule (Aufgabe 3 und 4)
## Struktur mit Feldern (Aufgabe 3)

```mermaid
classDiagram
    class Fahrschule {
        +string Name
        +string Adresse
        +List~Fahrlehrer~ Lehrer
        +List~Fahrschueler~ Schueler
        +List~Fahrzeug~ Fahrzeuge
        +List~Fahrstunde~ Stundenplan
    }

    class Fahrlehrer {
        +string Name
        +DateTimeOffset Geburtsdatum
        +string Telefon
        +List~string~ Kategorien
        +decimal Stundenansatz
    }

    class Fahrschueler {
        +string Name
        +DateTimeOffset Geburtsdatum
        +string Email
        +bool HatLernfahrausweis
        +int AnzahlAbsolvierterStunden
    }

    class Fahrzeug {
        +string Marke
        +string Modell
        +string Kontrollschild
        +int Baujahr
        +int KilometerStand
        +string Getriebe
    }

    class Fahrstunde {
        +DateTimeOffset Beginn
        +int DauerMinuten
        +string Thema
    }

    Fahrschule "1" --> "*" Fahrlehrer
    Fahrschule "1" --> "*" Fahrschueler
    Fahrschule "1" --> "*" Fahrzeug
    Fahrschule "1" --> "*" Fahrstunde
    Fahrstunde "*" --> "1" Fahrschueler
    Fahrstunde "*" --> "1" Fahrlehrer
    Fahrstunde "*" --> "1" Fahrzeug
```

## Struktur mit Eigenschaften (Aufgabe 4)

```mermaid
classDiagram
    class Fahrschueler {
        -DateTimeOffset registriertAm
        -string email
        -int anzahlAbsolvierterStunden
        +string Name
        +DateTimeOffset Geburtsdatum
        +bool HatLernfahrausweis
        +DateTimeOffset RegistriertAm  «read-only»
        +string Email  «validiert»
        +int AnzahlAbsolvierterStunden  «validiert»
        +int Alter  «berechnet»
        +bool IstPruefungsreif  «berechnet»
    }

    class Fahrzeug {
        -int baujahr
        -int kilometerStand
        +string Marke
        +string Modell
        +string Kontrollschild
        +string Getriebe
        +int Baujahr  «validiert»
        +int KilometerStand  «validiert»
        +int AlterInJahren  «berechnet»
        +bool BrauchtService  «berechnet»
        +string Bezeichnung  «read-only»
    }

    class Fahrlehrer {
        -decimal stundenansatz
        +string Name
        +DateTimeOffset Geburtsdatum
        +string Telefon
        +List~string~ Kategorien
        +decimal Stundenansatz  «validiert»
        +int Alter  «berechnet»
    }

    class Fahrstunde {
        -int dauerMinuten
        +DateTimeOffset Beginn
        +string Thema
        +int DauerMinuten  «validiert»
        +DateTimeOffset Ende  «berechnet»
        +decimal Kosten  «berechnet»
    }

    class Fahrschule {
        +string Name
        +string Adresse
        +List~Fahrlehrer~ Lehrer
        +List~Fahrschueler~ Schueler
        +List~Fahrzeug~ Fahrzeuge
        +List~Fahrstunde~ Stundenplan
        +int AnzahlSchueler  «berechnet»
        +decimal Gesamtumsatz  «berechnet»
    }

    class Alterrechner {
        +Jahre(DateTimeOffset) int
    }

    Fahrschule "1" --> "*" Fahrlehrer
    Fahrschule "1" --> "*" Fahrschueler
    Fahrschule "1" --> "*" Fahrzeug
    Fahrschule "1" --> "*" Fahrstunde
    Fahrstunde "*" --> "1" Fahrschueler
    Fahrstunde "*" --> "1" Fahrlehrer
    Fahrstunde "*" --> "1" Fahrzeug
    Fahrschueler ..> Alterrechner
    Fahrlehrer ..> Alterrechner
```

## Wo steckt welche Anforderung aus Aufgabe 4

| Anforderung      | Umgesetzt in                                                      |
|------------------|-------------------------------------------------------------------|
| Read-Only        | `Fahrschueler.RegistriertAm`, `Fahrzeug.Bezeichnung`              |
| Berechneter Wert | `Fahrschueler.Alter`, `Fahrstunde.Kosten`, `Fahrschule.Gesamtumsatz` |
| Datenvalidierung | `Fahrzeug.KilometerStand`, `Fahrschueler.Email`, `Fahrstunde.DauerMinuten` |
