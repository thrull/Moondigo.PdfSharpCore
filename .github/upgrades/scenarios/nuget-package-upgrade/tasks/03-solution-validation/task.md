# 03-solution-validation: Validate solution and tests

Zbudować całą solucję po migracji, sprawdzić ostrzeżenia oraz uruchomić dostępne testy automatyczne. Naprawić problemy wynikające z migracji, jeśli ujawnią się poza adapterem.

## Research findings

- Solucja zawiera projekty produkcyjne PdfSharpCore, Charting, MigraDocCore.DocumentObjectModel, MigraDocCore.Rendering, projekt testowy oraz SampleApp.
- Wszystkie projekty targetują `net8.0`, co jest wymagane przez assety ImageSharp 4.1.3 i SixLabors.Fonts 3.2.0.
- Projekt testowy został już zbudowany, a testy wykazały wcześniej 3 błędy związane z 24-bitowym BMP. Po zmianie na `BmpBitsPerPixel.Bit32` testy obrazów powinny działać poprawnie.
- Jedynym znanym ostrzeżeniem jest komunikat SixLabors.Fonts o braku licencji; nie można go usunąć bez klucza/licencji użytkownika.

**Done when**: Solucja buduje się bez błędów, testy kończą się pomyślnie, a wyniki walidacji są zapisane w `progress-details.md`.
