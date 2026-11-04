# Progress Details

## Changes
- Zastąpiono usunięte overloady `Image.Load(..., out IImageFormat)` przez `Image.DetectFormat(...)` i `Image.Load(...)` w `ImageSharpImageSource.cs`.
- Ścieżka strumieniowa kopiuje dane do bufora, aby format był wykrywany bez zależności od pozycji i możliwości seekowania strumienia wejściowego.
- Usunięto `BmpBitsPerPixel.Pixel32`; używany jest domyślny `BmpEncoder` ImageSharp 4.x.
- Usunięto dwa istniejące ostrzeżenia C# dotyczące nieużywanej zmiennej i pola.

## Validation
- `dotnet build PdfSharpCore/Moondigo.PdfSharpCore.csproj --no-restore --verbosity:minimal` — kompilacja zakończona powodzeniem dla `net8.0`.
- Pozostają ostrzeżenia generowane przez `SixLabors.Fonts` o braku licencji Six Labors; wymagają klucza/licencji użytkownika i nie są ostrzeżeniami kodu.
