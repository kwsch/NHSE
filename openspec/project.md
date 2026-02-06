# Project Context

## Purpose
NHSE (New Horizons Save Editor) is a save file editor for Animal Crossing: New Horizons on Nintendo Switch. It allows users to view and modify game save data including items, villagers, island terrain, buildings, and player profiles.

## Tech Stack
- **Language**: C# 14 with nullable reference types enabled
- **Framework**: .NET 10.0
- **UI**: Windows Forms (.NET 10.0-windows)
- **Testing**: xUnit v3 + FluentAssertions
- **CI/CD**: Azure Pipelines (Windows)
- **Solution Format**: .slnx (XML-based solution file)

## Project Structure
```
NHSE.Core/        # Core library: save file parsing, structures, encryption, editing
NHSE.Injection/   # RAM injection via SysBot for live editing
NHSE.Parsing/     # Game file parsers (BCSV, MSBT, PBC formats)
NHSE.Sprites/     # Item and field sprite rendering
NHSE.Villagers/   # Villager data and resources
NHSE.WinForms/    # Windows Forms GUI application
NHSE.Tests/       # Unit tests
```

## Project Conventions

### Code Style
- File-scoped namespaces: `namespace NHSE.Core;`
- PascalCase for public members, properties, and methods
- Constants use UPPER_SNAKE_CASE or PascalCase (e.g., `NONE`, `FieldItemMin`)
- Use `[StructLayout]` and `[FieldOffset]` for binary data structures
- Prefer expression-bodied members for simple getters/setters
- Use `readonly` and `static readonly` where applicable
- Warnings treated as errors (`TreatWarningsAsErrors=true`)

### Architecture Patterns
- **Offset-based versioning**: Different game versions have separate offset classes (e.g., `MainSaveOffsets10`, `MainSaveOffsets20`)
- **Interface-driven design**: Core structures implement interfaces (e.g., `IVillager`, `ICopyableItem<T>`)
- **Resource embedding**: Localization and binary data embedded as resources
- **Provider pattern**: `ISaveFileProvider` for different save sources (folder, zip)

### Testing Strategy
- Unit tests in `NHSE.Tests` project
- Use xUnit `[Fact]` and `[Theory]` attributes
- FluentAssertions for readable assertions (`.Should().Be()`)
- Test classes are `static` with `static` test methods

### Git Workflow
- Main branch: `master`
- CI triggers on push to `master`
- Build artifacts published as `NHSE`

## Domain Context
- **Save file structure**: Nintendo Switch save data with encryption and hash verification
- **Game versions**: Multiple revision offsets (1.0 through 3.0+) with different data layouts
- **Items**: 8-byte structures with ItemId, SystemParam, AdditionalParam, FreeParam
- **Localization**: Supports en, de, es, fr, it, jp, ko, zhs, zht languages
- **Field items**: Items placed on the island map (ItemId >= 60,000)

## Important Constraints
- Windows-only GUI (WinForms)
- Must maintain backward compatibility with older save file versions
- Binary structures must match exact game memory layouts
- Hash validation required for save file integrity

## External Dependencies
- **SysBot**: Network-based RAM injection for live game editing
- No external NuGet packages in core library (self-contained)
- Test dependencies: FluentAssertions, xUnit, Microsoft.NET.Test.Sdk
