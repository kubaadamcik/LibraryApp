LibraryApp
Desktopová aplikace pro knihovny umožňující správu čtenářů, knih a jejich půjčování.
Popis
LibraryApp je WPF aplikace vytvořená v C# pro knihovny, která usnadňuje správu čtenářů, evidenci knih ve skladu a správu výpůjček. Aplikace je určena pro knihovníky, kteří potřebují efektivně organizovat knihovní procesy prostřednictvím přehledného desktopového rozhraní.
Funkce

Správa čtenářů: Přidávání, úprava a mazání záznamů o čtenářích.
Správa knih: Přidávání knih do skladu, aktualizace informací a sledování dostupnosti.
Výpůjčky: Vytváření, vracení a sledování výpůjček knih.
Přehledy: Zobrazení aktuálního stavu skladu a historie výpůjček.

Instalace
Předpoklady

Operační systém: Windows 7/8/10/11
.NET Framework: Verze 4.8 nebo vyšší (dostupné na Microsoft .NET)
Git: (Volitelné) Pro klonování repozitáře (Git).
Visual Studio: (Volitelné) Pro vývoj nebo úpravy (doporučena verze 2022).

Kroky

Naklonujte repozitář:git clone https://github.com/kubaadamcik/LibraryApp/


Přejděte do složky projektu:cd library-app


Otevřete projekt v Visual Studio:
Otevřete soubor LibraryApp.sln.


Nainstalujte závislosti:
Ujistěte se, že máte nainstalovaný balíček System.Data.SQLite (lze přidat přes NuGet Package Manager).
Příklad příkazu pro NuGet:dotnet add package System.Data.SQLite




Sestavte a spusťte aplikaci:
V Visual Studio klikněte na Build > Build Solution a poté Start (nebo F5).



Alternativní spuštění
Pokud máte připravený spustitelný soubor (např. po vydání):

Stáhněte si nejnovější verzi z Releases.
Rozbalte archiv a spusťte LibraryApp.exe.

Použití
Po spuštění aplikace se otevře desktopové rozhraní:

Správa čtenářů: V sekci „Čtenáři“ klikněte na „Přidat čtenáře“ a zadejte jméno a kontaktní údaje.
Přidání knihy: V sekci „Knihy“ klikněte na „Přidat knihu“ a zadejte název, autora a ISBN.
Výpůjčka: V sekci „Výpůjčky“ vyberte čtenáře a knihu pro vytvoření záznamu.

Ukázka databáze
Aplikace automaticky vytvoří SQLite databázi (library.db) v adresáři aplikace při prvním spuštění. Struktura zahrnuje tabulky:

Readers (čtenáři)
Books (knihy)
Loans (výpůjčky)

Konfigurace
Pokud je potřeba upravit nastavení databáze:

Ověřte, že soubor library.db je ve stejném adresáři jako LibraryApp.exe.
(Volitelné) Upravte připojovací řetězec v konfiguračním souboru (např. App.config):<connectionStrings>
    <add name="SQLiteConnection" connectionString="Data Source=library.db;Version=3;" providerName="System.Data.SQLite" />
</connectionStrings>



Přispívání
Rádi uvítáme vaše příspěvky! Postupujte takto:

Forkněte repozitář.
Vytvořte novou větev (git checkout -b feature/nova-funkce).
Commitněte změny (git commit -m 'Přidána nová funkce').
Pushněte větev (git push origin feature/nova-funkce).
Vytvořte Pull Request.

Licence
Tento projekt je licencován pod MIT License.
Kontakt
Máte dotazy nebo návrhy? Vytvořte issue nebo kontaktujte autora na [email@priklad.cz].
