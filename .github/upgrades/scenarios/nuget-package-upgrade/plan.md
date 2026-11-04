# NuGet Package Upgrade Plan

## Overview

**Target**: Migracja `SixLabors.ImageSharp` do linii 4.x oraz dostosowanie adaptera PdfSharpCore do zmienionego API.
**Scope**: Solucja PdfSharpCore; pakiety SixLabors dostarczają assety `net8.0`, dlatego wszystkie projekty zależne zostaną ograniczone do `net8.0`.

## Tasks

### 01-imagesharp-api-migration: Migrate ImageSharp adapter to 4.x

Zaktualizować `PdfSharpCore/Utils/ImageSharpImageSource.cs` tak, aby korzystał z API ImageSharp 4.x dla ładowania obrazów i obsługi formatów. Należy zachować dotychczasowe ścieżki ładowania z tablicy bajtów, pliku i strumienia oraz obsługę PNG/JPEG/BMP.

Docelowa wersja pakietu pozostaje w linii 4.x (`4.1.3` w projekcie), zgodnie z wymaganiem użytkownika. Assessment wskazał wersję 3.2.0 jako automatycznie wspólną, ale nie jest ona akceptowalna dla tego zadania.

**Done when**: Kod adaptera używa API ImageSharp 4.x i nie zawiera usuniętych sygnatur ImageSharp 2.x/3.x.

---

### 02-target-net8: Retarget projects to net8.0

Ograniczyć projekty PdfSharpCore, Charting, MigraDocCore.DocumentObjectModel, MigraDocCore.Rendering oraz testowy do `net8.0`. ImageSharp 4.1.3 i SixLabors.Fonts 3.2.0 dostarczają assety `net8.0`, więc zachowanie targetów `net6.0`, `net7.0` i `net9.0` powoduje błędy CS0246 lub niezgodność referencji projektowych.

**Done when**: Wszystkie projekty w grafie zależności mają zgodny target `net8.0`, a restore nie generuje brakujących referencji SixLabors.

---

### 03-solution-validation: Validate solution and tests

Zbudować całą solucję po migracji, sprawdzić ostrzeżenia oraz uruchomić dostępne testy automatyczne. Naprawić problemy wynikające z migracji, jeśli ujawnią się poza adapterem.

**Done when**: Solucja buduje się bez błędów, testy kończą się pomyślnie, a wyniki walidacji są zapisane w `progress-details.md`.
