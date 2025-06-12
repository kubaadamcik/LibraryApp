# LibraryApp
Desktopová aplikace pro knihovny umožňující správu čtenářů, knih a jejich půjčování.

## Popis
LibraryApp je WPF aplikace vytvořená v C# pro knihovny, která usnadňuje správu čtenářů, evidenci knih ve skladu a správu výpůjček. Aplikace je určena pro knihovníky, kteří potřebují efektivně organizovat knihovní procesy prostřednictvím přehledného desktopového rozhraní.

## Funkce
- **Správa čtenářů**: Přidávání, úprava a mazání záznamů o čtenářích.
- **Správa knih**: Přidávání knih do skladu, aktualizace informací a sledování dostupnosti.
- **Výpůjčky**: Vytváření, vracení a sledování výpůjček knih.
- **Přehledy**: Zobrazení aktuálního stavu skladu a historie výpůjček.

## Instalace
### Předpoklady
- **Operační systém**: Windows 7/8/10/11
- **.NET Framework**: Verze 4.8 nebo vyšší ([Microsoft .NET](https://dotnet.microsoft.com/))
- **SQLite**: Aplikace používá SQLite, databázový soubor je automaticky vytvořen při prvním spuštění.
- **Git**: (Volitelné) Pro klonování repozitáře ([Git](https://git-scm.com/)).
- **Visual Studio**: (Volitelné) Pro vývoj nebo úpravy (doporučena verze 2022).

### Kroky
1. Naklonujte repozitář:
   ```bash
   git clone https://github.com/kubaadamcik/LibraryApp/
   ```
2. Přejděte do složky projektu:
   ```bash
   cd LibraryApp
   ```
3. Otevřete projekt v **Visual Studio**:
   - Otevřete soubor `LibraryApp.sln`.
4. Nainstalujte závislosti:
   - Ujistěte se, že máte nainstalovaný balíček `System.Data.SQLite` (přes NuGet Package Manager).
   - Příklad příkazu pro NuGet:
     ```bash
     dotnet add package System.Data.SQLite
     ```
5. Sestavte a spusťte aplikaci:
   - V Visual Studio klikněte na **Build > Build Solution** a poté **Start** (nebo `F5`).

### Alternativní spuštění
Pokud máte připravený spustitelný soubor:
1. Stáhněte si nejnovější verzi z [Releases](https://github.com/kubaadamcik/LibraryApp/releases).
2. Rozbalte archiv a spusťte `LibraryApp.exe`.

## Použití
Po spuštění aplikace se otevře desktopové rozhraní:
- **Správa čtenářů**: V sekci „Čtenáři“ klikněte na „Přidat čtenáře“ a zadejte jméno a kontaktní údaje.
- **Přidání knihy**: V sekci „Knihy“ klikněte na „Přidat knihu“ a zadejte název, autora a ISBN.
- **Výpůjčka**: V sekci „Výpůjčky“ vyberte čtenáře a knihu pro vytvoření záznamu.

### Ukázka rozhraní
Níže jsou screenshoty hlavních funkcí aplikace:
- Hlavní okno s přehledem:
  ![Hlavní okno aplikace zobrazující seznam knih](screenshots/main-window.png)
- Přidání nové knihy:
  ![Formulář pro přidání knihy](screenshots/add-book.png)
- Správa výpůjček:
  ![Rozhraní pro správu výpůjček](screenshots/loans.png)

### Ukázka databáze
Aplikace automaticky vytvoří SQLite databázi (`library.db`) v adresáři
