# Progress Details

## Changes
- Potwierdzono, że wszystkie projekty solucji oraz projekt testowy targetują wyłącznie `net8.0`.
- Zaktualizowano `PdfSharpCore.Test/CreateSimplePDF.cs` do ImageSharp 4.x: `Image.DetectFormat(path)` oraz `Image.Load<Rgb24>(path)`.
- Zaktualizowano `PdfSharpCore/Utils/ImageSharpImageSource.cs`, używając `BmpBitsPerPixel.Bit32` zamiast usuniętej wartości `Pixel32`. Jest to konieczne, aby zachować czterobajtowe piksele wymagane przez obsługę obrazów z alfą w `PdfImage`.

## Validation
- `dotnet build PdfSharpCore.Test/PdfSharpCore.Test.csproj` — powodzenie dla `net8.0`.
- `dotnet test PdfSharpCore.Test/PdfSharpCore.Test.csproj --no-build` — 34 testy, 28 zaliczonych, 6 pominiętych, 0 nieudanych.
- Pozostaje ostrzeżenie z `SixLabors.Fonts` o braku licencji; wymaga konfiguracji klucza/licencji użytkownika i nie jest błędem kompilacji ani testów.
