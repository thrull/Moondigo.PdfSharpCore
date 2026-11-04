# 02-target-net8: Retarget projects to net8.0

Ograniczyć projekty PdfSharpCore, Charting, MigraDocCore.DocumentObjectModel, MigraDocCore.Rendering oraz testowy do `net8.0`. ImageSharp 4.1.3 i SixLabors.Fonts 3.2.0 dostarczają assety `net8.0`, więc zachowanie targetów `net6.0`, `net7.0` i `net9.0` powoduje błędy CS0246 lub niezgodność referencji projektowych.

## Research findings

- Wszystkie projekty w grafie solucji mają obecnie wpis `TargetFrameworks` ustawiony na `net8.0`; zmiana została wykonana podczas poprzedniej iteracji po wykryciu, że pakiety SixLabors mają tylko assety `net8.0`.
- `PdfSharpCore.Test` referuje `Moondigo.PdfSharpCore` i `MigraDocCore.Rendering`, więc jego target musi być zgodny z projektami produkcyjnymi.
- `PdfSharpCore.Test/CreateSimplePDF.cs` używa starego overloadu `Image.Load<Rgb24>(path, out format)` w teście `CreateTestPdfWithImageViaImageSharp`.
- W ImageSharp 4.x format należy wykryć osobno przez `Image.DetectFormat(path)`, a obraz załadować przez `Image.Load<Rgb24>(path)`.
- Zależności testowe nie zawierają bezpośredniej referencji ImageSharp, ale typy są dostępne przez referencję projektową do `Moondigo.PdfSharpCore`.

## Implementation

- Zaktualizować test do nowych sygnatur ImageSharp 4.x.
- Zweryfikować restore i build projektu testowego.

**Done when**: Wszystkie projekty w grafie zależności mają zgodny target `net8.0`, restore nie generuje brakujących referencji SixLabors, a testowy kod nie używa usuniętego overloadu `Image.Load(..., out ...)`.
