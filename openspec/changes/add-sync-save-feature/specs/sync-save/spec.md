# Sync Save Capability

This capability allows users to selectively import data from another Animal Crossing: New Horizons save file into the currently loaded save.

## ADDED Requirements

### Requirement: Sync Menu Entry
The system SHALL provide a "Sync" menu item in the Editor's Tools menu that opens the Sync Save dialog.

#### Scenario: User opens Sync dialog
- **WHEN** user clicks Tools > Sync menu item
- **THEN** the Sync Save dialog SHALL open as a modal window

### Requirement: Source Save Selection
The system SHALL allow users to browse and select a source save file (main.dat) to sync from.

#### Scenario: User selects source save
- **WHEN** user clicks the browse button in Sync dialog
- **THEN** a file browser dialog SHALL open filtered for main.dat files
- **AND** upon selection, the source save SHALL be loaded and previewed

#### Scenario: Source save load failure
- **WHEN** user selects an invalid or corrupted save file
- **THEN** the system SHALL display an error message
- **AND** the sync operation SHALL NOT proceed

### Requirement: Category Selection
The system SHALL display checkboxes for each syncable data category allowing selective import.

#### Scenario: User selects categories to sync
- **WHEN** the source save is loaded
- **THEN** the dialog SHALL display checkboxes for: Villagers, Buildings, Player Houses, Design Patterns, Field Items, Terrain, Museum Donations, Turnip Prices, Weather Seed
- **AND** each category SHALL show a summary of the source data

### Requirement: Villager Sync
The system SHALL allow importing all 10 villagers from the source save, updating their origin data to match the target save.

#### Scenario: Sync villagers
- **WHEN** user selects Villagers category and confirms sync
- **THEN** all 10 villagers from source save SHALL replace the target save villagers
- **AND** villager origin data (player/town IDs) SHALL be updated to match target save

### Requirement: Building Sync
The system SHALL allow importing all 46 buildings (houses, shops, bridges, inclines) from the source save.

#### Scenario: Sync buildings
- **WHEN** user selects Buildings category and confirms sync
- **THEN** all building data from source save SHALL replace target save buildings

### Requirement: Player House Sync
The system SHALL allow importing player house data including room layouts from the source save.

#### Scenario: Sync player houses
- **WHEN** user selects Player Houses category and confirms sync
- **THEN** all player house data from source save SHALL replace target save houses

### Requirement: Design Pattern Sync
The system SHALL allow importing design patterns (50 normal + 50 PRO designs) from the source save.

#### Scenario: Sync design patterns
- **WHEN** user selects Design Patterns category and confirms sync
- **THEN** all design patterns from source save SHALL replace target save patterns
- **AND** pattern origin data SHALL be updated to match target save

### Requirement: Field Items Sync
The system SHALL allow importing all field items (items placed on the island) from the source save.

#### Scenario: Sync field items
- **WHEN** user selects Field Items category and confirms sync
- **THEN** all field item data from source save SHALL replace target save field items

### Requirement: Terrain Sync
The system SHALL allow importing terrain data (elevation, rivers, cliffs) from the source save.

#### Scenario: Sync terrain
- **WHEN** user selects Terrain category and confirms sync
- **THEN** all terrain data from source save SHALL replace target save terrain

### Requirement: Museum Sync
The system SHALL allow importing museum donation records from the source save.

#### Scenario: Sync museum donations
- **WHEN** user selects Museum Donations category and confirms sync
- **THEN** all museum donation data from source save SHALL replace target save museum data

### Requirement: Turnip Price Sync
The system SHALL allow importing turnip price patterns from the source save.

#### Scenario: Sync turnip prices
- **WHEN** user selects Turnip Prices category and confirms sync
- **THEN** turnip price data from source save SHALL replace target save turnip data

### Requirement: Weather Seed Sync
The system SHALL allow importing the weather seed from the source save.

#### Scenario: Sync weather seed
- **WHEN** user selects Weather Seed category and confirms sync
- **THEN** the weather seed from source save SHALL replace target save weather seed

### Requirement: Version Compatibility Check
The system SHALL verify that the source and target saves are compatible before allowing sync.

#### Scenario: Compatible save versions
- **WHEN** source and target saves have compatible offsets
- **THEN** sync operations SHALL be allowed

#### Scenario: Incompatible save versions
- **WHEN** source and target saves have incompatible versions
- **THEN** the system SHALL display a warning message
- **AND** sync operations MAY be blocked or limited

### Requirement: Sync Confirmation
The system SHALL require user confirmation before performing the sync operation.

#### Scenario: User confirms sync
- **WHEN** user clicks the Import/Sync button
- **THEN** the system SHALL display a confirmation dialog listing selected categories
- **AND** sync SHALL proceed only if user confirms

### Requirement: Sync Completion Feedback
The system SHALL provide feedback upon sync completion.

#### Scenario: Successful sync
- **WHEN** sync operation completes successfully
- **THEN** the system SHALL display a success message
- **AND** the editor SHALL reload to reflect imported data

