Installation

Voraussetzungen

Vor der Verwendung der Applikation muss das Projekt aus dem GitLab-Repository heruntergeladen werden. Für die Installation, Konfiguration und Ausführung werden folgende Programme benötigt:

Visual Studio 2022 Community
MySQL Workbench

Installation und Konfiguration

Nach der Installation der benötigten Programme muss in der MySQL Workbench eine Datenbankverbindung erstellt werden, sofern noch keine vorhanden ist.

Im GitLab-Repository befindet sich die Datei DB-Skript.sql. Diese ist in der MySQL Workbench zu öffnen und auszuführen, um die erforderliche Datenbankstruktur zu erstellen.

Anschliessend ist im Ordner Notenverwaltung die Datei Notenverwaltung.slnx mit Visual Studio zu öffnen.

Unter dem Projekt Notenverwaltung.API befindet sich die Datei appsettings.json. In dieser Datei ist das Objekt DefaultConnection zu konfigurieren. Die Werte für uid und Password müssen durch die Zugangsdaten der zuvor erstellten MySQL-Verbindung ersetzt werden.

Start der Applikation

Vor dem Start der Applikation muss in Visual Studio neben dem Start-Button das Startprofil auf StartAll gesetzt werden. Danach kann die Applikation gestartet werden.

Nach dem Start öffnen sich zwei Fenster:

Die Webanwendung ist unter https://localhost:7233/
 erreichbar

Das zweite Fenster stellt das Backend dar und kann für Testzwecke ignoriert werden