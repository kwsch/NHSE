# Design: Add Sync Save Feature

## Context
NHSE allows editing of Animal Crossing: New Horizons save files. Users frequently want to transfer specific data between saves (e.g., move villagers from one island to another, copy designs, or restore buildings). Currently, this requires exporting/importing individual files manually for each data type.

## Goals / Non-Goals
**Goals:**
- Provide a unified UI for transferring data between saves
- Support selective transfer (user chooses which categories to sync)
- Handle save version differences gracefully
- Maintain data integrity (proper origin data handling)

**Non-Goals:**
- Automatic merging/conflict resolution (user makes explicit choices)
- Support for partial villager data (all or nothing per villager)
- Network/cloud sync features

## Decisions

### Decision: Use Dialog-based UI Pattern
- **What**: Create a modal dialog similar to existing editors (MuseumEditor, VillagerHouseEditor)
- **Why**: Consistent with existing codebase patterns; keeps main editor clean

### Decision: Category-based Sync
- **What**: Organize sync options into categories (Villagers, Buildings, Items, etc.)
- **Why**: Matches how data is stored in save files; easier to understand for users

### Decision: Preview Before Sync
- **What**: Show summary of source save data before importing
- **Why**: Prevents accidental overwrites; helps users verify they selected correct source

### Decision: Origin Data Handling
- **What**: Automatically update origin data (player/town IDs) when syncing villagers/designs
- **Why**: Required for data to function correctly in target save; follows existing pattern in VillagerEditor

## Architecture

```
Editor.cs
    └── Menu_Sync_Click()
            └── SyncSaveDialog (new)
                    ├── Load source HorizonSave (read-only)
                    ├── Display sync categories with checkboxes
                    ├── Show preview of selected categories
                    └── SaveSyncManager.Sync() on confirm
                            └── Per-category sync methods
```

## Data Categories

| Category | Source | Target | Notes |
|----------|--------|--------|-------|
| Villagers | MainSave.GetVillagers() | MainSave.SetVillagers() | Need origin update |
| Buildings | MainSave.Buildings | MainSave.Buildings | 46 total |
| Player Houses | MainSave.GetPlayerHouses() | MainSave.SetPlayerHouses() | 8 max |
| Designs | Personal.Patterns | Personal.Patterns | 50 + 50 PRO |
| Field Items | MainSave field data | MainSave field data | Large data |
| Terrain | MainSave terrain | MainSave terrain | Acre-based |
| Museum | MainSave museum | MainSave museum | Donation records |
| Turnip | MainSave turnip | MainSave turnip | Price data |
| Weather | MainSave.WeatherSeed | MainSave.WeatherSeed | Single uint |

## Risks / Trade-offs

- **Risk**: Large data sync (field items, terrain) may be slow
  - Mitigation: Show progress indicator; allow cancellation
  
- **Risk**: Version mismatch between source and target saves
  - Mitigation: Check Offsets compatibility; warn user; use VillagerConverter pattern

- **Risk**: Corrupted source save
  - Mitigation: Wrap in try-catch; validate hash if possible

## Open Questions
- Should we support individual villager selection (sync villager #3 only)?
- Should we allow partial building sync (sync bridges only)?

