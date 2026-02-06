# Change: Add Sync Save Feature

## Why
Users often have multiple Animal Crossing save files and want to selectively transfer data (villagers, items, buildings, designs, etc.) from one save to another. Currently, there is no unified way to import specific components from another save file into the current one.

## What Changes
- Add a new "Sync" menu item to the Editor's menu bar
- Create a new `SyncSaveDialog` form that:
  - Allows users to browse and select another save file (main.dat)
  - Displays available data categories that can be imported:
    - Villagers (10 max)
    - Buildings (46 total)
    - Player Houses (up to 8)
    - Design Patterns (50 normal + 50 PRO)
    - Field Items (island items)
    - Terrain Data
    - Museum Donations
    - Turnip Prices
    - Weather Seed
  - Shows preview/summary of each category from the source save
  - Allows selective import of chosen categories into the current save
- Add core logic to handle cross-save data transfer with proper validation

## Impact
- **Affected specs**: New capability `sync-save`
- **Affected code**:
  - `NHSE.WinForms/Editor.cs` - Add Sync menu item
  - `NHSE.WinForms/Editor.Designer.cs` - Add menu UI components
  - New file: `NHSE.WinForms/Subforms/SyncSaveDialog.cs` - Main sync dialog
  - New file: `NHSE.Core/Editing/SaveSyncManager.cs` - Core sync logic

