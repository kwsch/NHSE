# Tasks for Add Sync Save Feature

## 1. Core Infrastructure
- [ ] 1.1 Create `SaveSyncCategory` enum defining all syncable data types
- [ ] 1.2 Create `SaveSyncManager` class in NHSE.Core for handling sync operations
- [ ] 1.3 Implement `GetSyncPreview()` method to generate summaries of source save data
- [ ] 1.4 Implement `SyncCategory()` method for each data category transfer

## 2. UI Components
- [ ] 2.1 Add `Menu_Sync` menu item to Editor menu bar
- [ ] 2.2 Create `SyncSaveDialog` form with:
  - [ ] 2.2.1 Source save file browser section
  - [ ] 2.2.2 Category selection checklist
  - [ ] 2.2.3 Preview panel showing source data summary
  - [ ] 2.2.4 Import button and cancel button
- [ ] 2.3 Wire up menu click event to show dialog

## 3. Sync Implementation
- [ ] 3.1 Implement villager sync (with origin data handling)
- [ ] 3.2 Implement building sync
- [ ] 3.3 Implement player house sync
- [ ] 3.4 Implement design pattern sync (normal + PRO)
- [ ] 3.5 Implement field items sync
- [ ] 3.6 Implement terrain sync
- [ ] 3.7 Implement museum donations sync
- [ ] 3.8 Implement turnip prices sync
- [ ] 3.9 Implement weather seed sync

## 4. Validation & Safety
- [ ] 4.1 Add save version compatibility check
- [ ] 4.2 Add confirmation dialog before sync
- [ ] 4.3 Handle origin data conflicts (player/town IDs)
- [ ] 4.4 Add error handling for corrupted source saves

## 5. Testing
- [ ] 5.1 Write unit tests for SaveSyncManager
- [ ] 5.2 Test sync between different save versions
- [ ] 5.3 Manual UI testing

