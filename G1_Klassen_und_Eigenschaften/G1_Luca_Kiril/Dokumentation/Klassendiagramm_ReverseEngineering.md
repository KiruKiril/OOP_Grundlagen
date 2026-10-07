# UML-Klassendiagramm Fahrschule (Reverse Engineering)

Automatisch aus den Quelldateien in `Aufgabe4_Eigenschaften` erzeugt,
nicht von Hand gezeichnet. Enthaelt den vollen Datenumfang, also alle
Felder und Eigenschaften.

Legende der Marker:

- `«nur lesbar»` Eigenschaft ohne Setter, also Read-Only oder berechnet
- `«geprueft»` Setter prueft den Wert und lehnt ungueltige Eingaben ab
- `-` privat, `+` oeffentlich

```mermaid
classDiagram
    class Alterrechner {
        +Jahre(DateTimeOffset) int
    }

    class Fahrlehrer {
        -decimal stundenansatz
        +string Name
        +DateTimeOffset Geburtsdatum
        +string Telefon
        +List~string~ Kategorien
        +decimal Stundenansatz «geprueft»
        +int Alter «nur lesbar»
    }

    class Fahrschueler {
        -DateTimeOffset registriertAm
        -string email
        -int anzahlAbsolvierterStunden
        +string Name
        +DateTimeOffset Geburtsdatum
        +bool HatLernfahrausweis
        +DateTimeOffset RegistriertAm «nur lesbar»
        +string Email «geprueft»
        +int AnzahlAbsolvierterStunden «geprueft»
        +int Alter «nur lesbar»
        +bool IstPruefungsreif «nur lesbar»
    }

    class Fahrschule {
        +string Name
        +string Adresse
        +List~Fahrlehrer~ Lehrer
        +List~Fahrschueler~ Schueler
        +List~Fahrzeug~ Fahrzeuge
        +List~Fahrstunde~ Stundenplan
        +int AnzahlSchueler «nur lesbar»
        +decimal Gesamtumsatz «nur lesbar»
    }

    class Fahrstunde {
        -int dauerMinuten
        +DateTimeOffset Beginn
        +Fahrschueler Schueler
        +Fahrlehrer Lehrer
        +Fahrzeug Fahrzeug
        +string Thema
        +int DauerMinuten «geprueft»
        +DateTimeOffset Ende «nur lesbar»
        +decimal Kosten «nur lesbar»
    }

    class Fahrzeug {
        -int baujahr
        -int kilometerStand
        +string Marke
        +string Modell
        +string Kontrollschild
        +string Getriebe
        +int Baujahr «geprueft»
        +int KilometerStand «geprueft»
        +string Bezeichnung «nur lesbar»
        +int AlterInJahren «nur lesbar»
        +bool BrauchtService «nur lesbar»
    }

    Fahrlehrer ..> Alterrechner
    Fahrschueler ..> Alterrechner
    Fahrschule "1" --> "*" Fahrlehrer
    Fahrschule "1" --> "*" Fahrschueler
    Fahrschule "1" --> "*" Fahrstunde
    Fahrschule "1" --> "*" Fahrzeug
    Fahrstunde "*" --> "1" Fahrlehrer
    Fahrstunde "*" --> "1" Fahrschueler
    Fahrstunde "*" --> "1" Fahrzeug
```
