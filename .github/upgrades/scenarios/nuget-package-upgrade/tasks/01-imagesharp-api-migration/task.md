# 01-imagesharp-api-migration: Migrate ImageSharp adapter to 4.x

Zaktualizować `PdfSharpCore/Utils/ImageSharpImageSource.cs` tak, aby korzystał z API ImageSharp 4.x dla ładowania obrazów i obsługi formatów. Należy zachować dotychczasowe ścieżki ładowania z tablicy bajtów, pliku i strumienia oraz obsługę PNG/JPEG/BMP.

Docelowa wersja pakietu pozostaje w linii 4.x (`4.1.3` w projekcie), zgodnie z wymaganiem użytkownika. Assessment wskazał wersję 3.2.0 jako automatycznie wspólną, ale nie jest ona akceptowalna dla tego zadania.

## Research findings

- `PdfSharpCore/Moondigo.PdfSharpCore.csproj` targetuje `net6.0;net7.0;net8.0;net9.0` i referuje `SixLabors.ImageSharp` `4.1.3` oraz `SixLabors.Fonts` `3.2.0`.
- `PdfSharpCore/Utils/ImageSharpImageSource.cs` używa usuniętego wzorca `Image.Load<TPixel>(source, out IImageFormat)` dla byte array, pliku i strumienia.
- Ten sam plik używa `BmpBitsPerPixel.Pixel32`, którego nie ma w ImageSharp 4.1.3.
- `PdfSharpCore/Drawing/XImage.cs` inicjalizuje adapter jako `ImageSharpImageSource<Rgba32>` i korzysta z jego ścieżek `FromFile`, `FromStream` oraz `FromBinary`; publiczny kontrakt adaptera musi pozostać bez zmian.
- Wstępny build po restore potwierdził błędy CS1503/CS1615 dla sygnatur `Image.Load` oraz CS0117 dla `Pixel32`.
- W repozytorium nie ma `Directory.Packages.props`; wersja jest ustawiana bezpośrednio w pliku projektu.

## Implementation constraints

- Zachować wykrywanie formatu PNG do ustawienia `Transparent`.
- Dla strumieni zapewnić poprawne wykrywanie formatu bez naruszenia pozycji wejściowego strumienia i bez pozostawienia zasobów do dyspozycji po utworzeniu obrazu.
- Użyć API ImageSharp 4.x bez warunkowej kompilacji dla net5.0.

**Done when**: Projekt `PdfSharpCore` buduje się dla `net6.0`–`net9.0`, adapter nie używa usuniętych sygnatur ImageSharp 2.x/3.x, a testy obrazu przechodzą.
