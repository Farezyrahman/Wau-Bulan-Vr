# 🪁 Interactive Game-Based Learning of Wau Bulan with NPCs in Virtual Reality (VR)

**Final Year Project (PSM 2)**  
**Student:** Muhammad Farezy Bin Ab Rahman | **ID:** A22EC0209  
**Institution:** Universiti Teknologi Malaysia  
**Academic Session:** 2024/2025  
**Target Completion:** 25 May 2026  
**Status:** 🟡 **Active Development (Week 9/10)**

---

## 📋 Project Overview

This VR educational game aims to preserve and promote the traditional Malaysian art of **Wau Bulan** (iconic crescent-shaped kite) through immersive, interactive gameplay. Players learn the complete cultural process — from material gathering to crafting and flying — guided by friendly NPCs in a beautiful virtual Malaysian *kampung* (village).

The project serves as both an educational tool and cultural preservation initiative, combining traditional Malaysian heritage with cutting-edge VR technology on the Meta Quest 2 platform.

---

## 🎮 Core Gameplay (3 Levels)

### **Level 1: Exploration & Collection** 🏘️ — **Nearing Completion**
- **Objective:** Explore the traditional *kampung* environment and gather materials
- **Collectible Materials:**
  - **Buluh** (Bamboo strips) — Found scattered around village structures
  - **Kertas** (Decorative paper) — Located in specific village locations
  - **Tali** (String/twine) — Distributed throughout the environment
- **NPC Interactions:** (3 Main Characters)
  - **Tok Ngah** — Cultural guide providing heritage context
  - **Pakcik Hassan** — Material collection guidance
  - **Pakcik Azeimi** — Craft/flying preparation advice
- **Mechanics:**
  - XR Grab Interactable system for item pickup
  - Real-time inventory tracking (CollectibleItem.cs, InventoryManager system)
  - Checkpoint validation before Level 2 progression
  - Dialogue triggers and narrative progression
- **Current Status:**
  - Environment design: ~90% complete
  - Item collection system: ✅ Implemented
  - NPC dialogue system: ✅ Core system done, refinement in progress
  - Inventory UI: 🔄 Finalization phase
  - Checkpoint logic: 🔄 Testing and edge case handling

### **Level 2: Crafting Station** 🛠️ — **In Progress (Early Stage)**
- **Objective:** Step-by-step Wau Bulan assembly at traditional workbench
- **Mechanics:**
  - Snap zones for precision assembly of kite parts
  - Step-by-step guided assembly sequence
  - Visual feedback for valid/invalid placement
  - Customization options for kite design (colors, materials)
- **Current Status:**
  - Crafting station scene layout: 🔄 Initial design phase
  - Snap zone implementation: ⏳ Scheduled for late April
  - Assembly progression logic: ⏳ Pending snap zone setup
  - Customization system: ⏳ Queued for later implementation
- **Dependencies:** Requires finalized Wau Bulan 3D model (✅ Complete)

### **Level 3: Flight & Mastery** 🪁 — **In Progress (Mechanics Phase)**
- **Objective:** Fly the crafted Wau Bulan across 3 scenic zones with varying difficulty
- **Flight Zones:**
  - **Padang** (Easiest) — Open field with light winds
  - **Sawah Padi** (Medium) — Rice paddy with moderate winds
  - **Pantai** (Hardest) — Beach with strong coastal winds
- **Mechanics:**
  - Physics-based kite flight simulation
  - Wind system with direction/force/variation
  - Player controls (pull/release/steer interactions)
  - Dual-hand string tension interaction for immersion
  - Success/failure conditions (target height, duration, balance)
- **Current Status:**
  - Flight behavior research: ✅ Complete
  - Prototype code refactoring: 🔄 In progress
  - Wind system logic: ⏳ Scheduled for late April
  - Rigidbody integration: ⏳ Pending wind system
  - Player controls: ⏳ Queued after physics
  - Physics tuning: ⏳ Final phase (early May)

---

## 📊 Development Progress by Component

### ✅ **Completed Features (Week 1-4)**

| Component | Task | Status | Notes |
|-----------|------|--------|-------|
| **VR Infrastructure** | Meta SDK + XRI Integration | ✅ Done | Full Meta Quest 2 support |
| **VR Infrastructure** | XR Origin & Locomotion | ✅ Done | Hand tracking tested |
| **Environment** | Kampung pass 1 (terrain, buildings) | ✅ Done | Houses, palms, terrain placed |
| **3D Assets** | Wau Bulan model topology & cleanup | ✅ Done | Blender export ready |
| **3D Assets** | UV unwrap & materials | ✅ Done | Ready for Unity |
| **3D Assets** | Optimized export (FBX) | ✅ Done | Imported into Unity |
| **Level 1** | Final level flow design | ✅ Done | Exploration sequence locked |
| **Level 1** | NPC interaction system base | ✅ Done | Ray interactions working |
| **Dialogue** | Tok Ngah dialogue script | ✅ Done | Cultural guidance complete |
| **Dialogue** | Pakcik Hassan dialogue script | ✅ Done | Material collection guidance |
| **Dialogue** | Pakcik Azeimi dialogue script | ✅ Done | Crafting preparation guidance |
| **Item System** | Item collection (pick-up/store) | ✅ Done | `Items_Collect.cs` implemented |
| **Inventory** | Inventory data structure | ✅ Done | `InventoryManager.cs` working |
| **Level 2** | Wau Bulan crafting research | ✅ Done | Real process mapped to gameplay |

### 🔄 **Currently In Progress (Week 4-5)**

| Component | Task | Status | Timeline | Dependencies |
|-----------|------|--------|----------|--------------|
| **Environment** | Kampung pass 2 (lighting, polish) | 🔄 In Progress | 26/03 - 30/04 | Environment pass 1 |
| **Level 1** | Inventory UI panel (wrist-based) | 🔄 In Progress | 04/04 - 08/04 | Inventory backend |
| **Level 1** | Item validation rules | 🔄 In Progress | 05/04 - 08/04 | Item system |
| **Level 1** | Checkpoint progression logic | 🔄 In Progress | 06/04 - 10/04 | All dialogue scripts |
| **Level 1** | Dialogue UI & subtitles | 🔄 In Progress | 07/04 - 11/04 | NPC interactions |
| **Audio** | Placeholder audio collection | 🔄 In Progress | 08/04 - 12/04 | Research data |
| **Level 1** | Playtest exploration loop | 🔄 In Progress | 10/04 - 13/04 | UI + validation |
| **Level 3** | Flying behavior research | 🔄 In Progress | 12/04 - 15/04 | Physics balance |
| **Level 3** | Prototype code refactoring | 🔄 In Progress | 15/04 - 18/04 | Research data |
| **Level 2** | Crafting design & layout | 🔄 In Progress | 10/04 - 14/04 | Wau model + research |
| **Level 2** | Crafting station scene setup | 🔄 In Progress | 11/04 - 15/04 | Design phase |

### ⏳ **Upcoming Tasks (Week 6-10)**

| Component | Task | Timeline | Priority |
|-----------|------|----------|----------|
| **Level 2** | Snap zones for assembly | 14/04 - 18/04 | High |
| **Level 2** | Crafting progression validation | 16/04 - 19/04 | High |
| **Level 2** | Visual feedback system | 18/04 - 21/04 | High |
| **Level 2** | Customization system | 20/04 - 23/04 | Medium |
| **Level 2** | Instruction UI | 21/04 - 24/04 | Medium |
| **Level 2** | Full playtest | 24/04 - 26/04 | High |
| **Level 3** | Wind system implementation | 19/04 - 23/04 | High |
| **Level 3** | Rigidbody kite response | 21/04 - 24/04 | High |
| **Level 3** | Player controls | 24/04 - 27/04 | High |
| **Level 3** | String tension (dual-hand) | 27/04 - 30/04 | Medium |
| **Level 3** | Success/failure conditions | 29/04 - 01/05 | High |
| **Level 3** | Physics tuning | 01/05 - 04/05 | High |
| **Scene Integration** | Transition system (1→2→3) | 25/04 - 27/04 | High |
| **Scene Integration** | Scene loading flow | 28/04 - 01/05 | High |
| **Save System** | Save/load structure design | 02/05 - 03/05 | High |
| **Save System** | Implementation | 04/05 - 07/05 | High |
| **Save System** | Load/resume functionality | 06/05 - 08/05 | High |
| **Core HUD** | Persistent VR HUD | 04/05 - 08/05 | High |
| **Audio** | Full audio system integration | 05/05 - 09/05 | Medium |
| **Audio** | NPC voice placeholders | 06/05 - 09/05 | Medium |
| **Integration Test** | Full 3-level playtest | 09/05 - 11/05 | High |
| **Performance** | Quest 2 profiling & FPS test | 11/05 - 12/05 | High |
| **Optimization** | Asset & lighting optimization | 12/05 - 15/05 | High |
| **Optimization** | Script & physics optimization | 13/05 - 16/05 | High |
| **Polish** | Bug fixes (all levels) | 14/05 - 18/05 | High |
| **Polish** | UI/UX improvements | 15/05 - 18/05 | Medium |
| **User Testing** | 5-10 user playtests | 16/05 - 18/05 | Medium |
| **Documentation** | Screenshots & evidence capture | 16/05 - 20/05 | High |
| **Documentation** | Demo video recording | 18/05 - 20/05 | High |
| **Documentation** | Technical summary write-up | 18/05 - 21/05 | High |
| **Presentation** | Slide deck preparation | 20/05 - 21/05 | High |
| **Final Build** | Prepare submission build | 21/05 - 22/05 | High |
| **QA** | Final regression testing | 22/05 | High |
| **Submission** | PSM-2 final readiness | 23/05 | High |

---

## 🛠️ Technologies & Tools

| Category | Technology |
|----------|-----------|
| **Game Engine** | Unity 2022 LTS |
| **VR Framework** | Meta All-in-One SDK |
| **Interaction** | XR Interaction Toolkit (XRI) v2.x |
| **Programming** | C# |
| **3D Modeling** | Blender 3.x |
| **UI** | TextMeshPro + Unity Canvas UI |
| **Target Platform** | Meta Quest 2 (Standalone VR) |
| **Development VCS** | Git + GitHub |

---

## 📁 Project Structure

```
Wau-Bulan-Vr/
├── Wau Bulan Vr/                    # Main Unity Project
│   ├── Assets/
│   │   ├── Scripts/                 # C# Gameplay Systems
│   │   │   ├── BambooBender.cs           # Bamboo bending mechanics
│   │   │   ├── BoxWind.cs                # Wind zone logic
│   │   │   ├── Items_Collect.cs          # Item pickup system
│   │   │   ├── NPC_Text.cs               # NPC dialogue management
│   │   │   ├── JoystickObjectMover.cs    # Player input handling
│   │   │   ├── SceneFader.cs             # Scene transition effects
│   │   │   ├── Score.cs                  # Scoring system
│   │   │   ├── TextRotateCam.cs          # UI orientation lock
│   │   │   ├── VRSliderPhysical.cs       # VR-specific UI
│   │   │   └── InventoryManager.cs       # Inventory tracking (core system)
│   │   │
│   │   ├── Scenes/                  # Level Scenes
│   │   │   ├── BasicScene.unity          # VR setup test scene
│   │   │   ├── Level 1.unity             # Main Level 1 (exploration)
│   │   │   ├── Level 2 (Level Design).unity  # Level 2 design iteration
│   │   │   ├── Level_2.unity             # Level 2 crafting (active)
│   │   │   ├── Level 3 - Mechanic.unity  # Level 3 flight mechanics
│   │   │   ├── Credit.unity              # Credits/end scene
│   │   │   └── SampleScene.unity         # Utility test scene
│   │   │
│   │   ├── Models/                  # 3D Models (FBX)
│   │   │   ├── FBX Files/               # Wau Bulan, environment assets
│   │   │   └── Wau_Bulan_Model.fbx
│   │   │
│   │   ├── Materials/               # PBR Materials
│   │   │   └── (Material definitions for kite and environment)
│   │   │
│   │   ├── Prefabs/                 # Reusable Game Objects
│   │   │   └── (NPC, collectible items, UI elements)
│   │   │
│   │   ├── Animations/              # Animation files (prepared for future)
│   │   │
│   │   ├── Resources/               # Dialogue data, config files
│   │   │
│   │   ├── Music/                   # Audio tracks & ambience
│   │   │
│   │   ├── Oculus/                  # Meta SDK Integration
│   │   │
│   │   ├── XR/                      # XR-specific assets
│   │   │
│   │   ├── XRI/                     # XR Interaction Toolkit assets
│   │   │
│   │   ├── TextMesh Pro/            # TextMeshPro resources
│   │   │
│   │   ├── Settings/                # Project settings
│   │   │
│   │   └── VRTemplateAssets/        # VR template defaults
│   │
│   ├── Packages/                    # Unity packages
│   │   ├── manifest.json            # Package dependencies
│   │   └── (Meta SDK, XRI, TextMeshPro)
│   │
│   ├── ProjectSettings/             # Unity configuration
│   │
│   └── Wau Bulan Vr.sln             # Visual Studio solution
│
├── README.md                        # This documentation
├── checklist_timeline_psm2.csv      # Development timeline & tasks
└── .gitignore                       # Git configuration
```

---

## 🚀 Current Development Status (27 May 2026)

### **Overall Progress: ~50-55% Complete**

```
Phase 1: Core Systems & Level 1        ████████░░ 80% - Nearing completion
Phase 2: Level 2 Crafting             ██░░░░░░░░ 20% - Early implementation
Phase 3: Level 3 Flying               ██░░░░░░░░ 20% - Mechanics phase
Phase 4: Integration & Optimization   ░░░░░░░░░░  0% - Pending level completion
Phase 5: Polish & Testing             ░░░░░░░░░░  0% - Final phase
```

### **Key Metrics**

| Metric | Target | Current |
|--------|--------|---------|
| **FPS Target** | 60+ FPS on Quest 2 | ⏳ In optimization phase |
| **Build Size** | < 2 GB | ~1.2 GB (estimated) |
| **Playable Content** | 3 full levels | 1 level ~90%, 2 partial |
| **NPCs** | 3 unique characters | ✅ 3 dialogues written |
| **Scenes** | 7 main scenes | ✅ 7 scenes created |

---

## 📝 Key Features Implemented

### **Educational Value** 📚
- Authentic representation of Wau Bulan craftsmanship
- Step-by-step learning progression (gather → craft → fly)
- Cultural immersion through interactive gameplay with NPCs
- Historical and practical context via dialogue system

### **VR/UX Excellence** 🎮
- Intuitive hand-based interaction via XRI
- Natural movement and locomotion
- Comfortable gameplay optimized for Meta Quest 2
- Real-time inventory management system

### **Technical Architecture** 🔧
- Modular C# scripts (item system, inventory, NPC interactions)
- Extensible component-based design
- Physics-based interactions
- Save/load progression system (planned)
- Wind simulation for realistic flight (planned)

---

## 🏃 Getting Started

### **Prerequisites**
- Unity 2021 LTS (or later)
- Meta All-in-One SDK
- XR Interaction Toolkit package (v2.x)
- Meta Quest 2 device (for VR testing)
- Visual Studio or compatible C# IDE

### **Setup Instructions**

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Farezyrahman/Wau-Bulan-Vr.git
   cd Wau-Bulan-Vr
   ```

2. **Switch to Unity branch:**
   ```bash
   git checkout Unity
   ```

3. **Open in Unity Hub:**
   - Add the `Wau Bulan Vr` folder as a new project
   - Wait for packages to resolve (~5-10 minutes)

4. **Install Required Packages:**
   - Meta All-in-One SDK (via Package Manager)
   - XR Interaction Toolkit (should auto-import)

5. **Open a scene:**
   - Start with `Assets/Scenes/BasicScene.unity` for VR setup verification
   - Or open `Assets/Scenes/Level 1.unity` for gameplay

6. **Build & Deploy to Quest 2:**
   - File → Build Settings
   - Select Android platform
   - Build and deploy to connected Meta Quest 2

---

## 🧪 Testing Checklist

### **Level 1 - Exploration**
- [x] Item pickup mechanic works for all 3 materials
- [x] Inventory UI displays correct item counts
- [x] NPC interactions trigger dialogue properly
- [x] Checkpoint validation prevents progression with missing items
- [x] Scene transition to Level 2 is smooth

### **Level 2 - Crafting** (In Progress)
- [x] Crafting station scene loads correctly
- [ ] Snap zones detect correct assembly order
- [ ] Visual feedback shows valid/invalid placements
- [ ] Customization options function
- [x] Scene transition to Level 3 works

### **Level 3 - Flying** (In Progress)
- [ ] Kite physics responds to wind
- [ ] Player controls handle kite effectively
- [ ] 3 difficulty zones present different challenges
- [ ] Success/failure conditions trigger correctly
- [ ] End credits scene displays

### **Cross-Level**
- [ ] Save/load preserves progress between sessions
- [ ] 60+ FPS maintained on Meta Quest 2
- [ ] No memory leaks or crashes
- [ ] Audio plays without issues
- [ ] All VR interactions feel natural

---

## 📅 PSM-2 Timeline & Milestones

| Milestone | Target Date | Current Status | Week |
|-----------|------------|-----------------|------|
| **MVP Scope Finalized** | 16/03/2026 | ✅ Complete | 1 |
| **VR Core Setup** | 21/03/2026 | ✅ Complete | 1-2 |
| **Level 1 Environment** | 25/03/2026 | ✅ Complete | 2 |
| **NPC System & Dialogue** | 01/04/2026 | ✅ Complete | 3 |
| **Inventory System** | 04/04/2026 | ✅ Complete | 3 |
| **Level 1 Playtest** | 13/04/2026 | 🔄 In Progress | 4 |
| **Level 2 Layout** | 14/04/2026 | 🔄 In Progress | 4 |
| **Level 3 Mechanics** | 18/04/2026 | 🔄 In Progress | 4 |
| **Level 2 Crafting Complete** | 26/04/2026 | ⏳ Scheduled | 5-6 |
| **Level 3 Flight Complete** | 04/05/2026 | ⏳ Scheduled | 6-7 |
| **All 3 Levels Integrated** | 08/05/2026 | ⏳ Scheduled | 7 |
| **Performance Optimization** | 16/05/2026 | ⏳ Scheduled | 8-9 |
| **User Testing** | 18/05/2026 | ⏳ Scheduled | 9 |
| **Final Polish & Fixes** | 21/05/2026 | ⏳ Scheduled | 9 |
| **Build Preparation** | 22/05/2026 | ⏳ Scheduled | 10 |
| **Final QA & Submission** | 25/05/2026 | ⏳ Target Date | 10 |

---

## 🐛 Known Issues & Limitations

| Issue | Impact | Workaround / ETA |
|-------|--------|------------------|
| Level 2 snap zones not yet implemented | Blocks L2 testing | ⏳ Late April 2026 |
| Level 3 wind system incomplete | Affects flying feel | ⏳ Late April 2026 |
| Save/load system not started | Can't persist progress | ⏳ Early May 2026 |
| Audio system placeholders only | No final VO | ⏳ Early May 2026 |
| Performance profiling pending | FPS target unknown | ⏳ Mid-May 2026 |

---

## 📊 Development Velocity

| Week | Focus | Completed Items | Blockers |
|------|-------|-----------------|----------|
| 1 | Planning & VR Setup | 4 | None |
| 2 | Environment & NPC System | 6 | None |
| 3 | Dialogue & Item Collection | 7 | None |
| 4 | Inventory & Blender Assets | 8 | L2 design complexity |
| 5 | L1 Playtest & L2 Start | 5+ | Wind system design |
| 6-9 | L2/L3 Core Mechanics | TBD | Physics tuning |
| 10 | Polish & Optimization | TBD | Integration issues |

---

## 👤 Author & Contact

**Muhammad Farezy Bin Ab Rahman**  
**Student ID:** A22EC0209  
**Universiti Teknologi Malaysia**  
**Project Repository:** [Wau-Bulan-Vr](https://github.com/Farezyrahman/Wau-Bulan-Vr)

---

## 📚 References & Resources

- **Meta Quest Developer:** https://developer.meta.com/
- **XR Interaction Toolkit Docs:** https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit/latest/
- **Unity 2021 LTS Docs:** https://docs.unity3d.com/2021LTS/Documentation/
- **Wau Bulan Cultural References:** Traditional Malaysian Heritage Research
- **VR Comfort Guidelines:** Meta Best Practices & Industry Standards

---

## 📜 License

This project is developed as part of the Final Year Project (PSM 2) at Universiti Teknologi Malaysia (2024/2025).

---

## 🙏 Acknowledgments

- **Universiti Teknologi Malaysia** — Academic supervision and facilities
- **Meta/Oculus** — VR development platforms and tools
- **Open-source Community** — XR Interaction Toolkit, TextMeshPro, and supporting libraries
- **Malaysian Cultural Heritage Community** — Wau Bulan inspiration and reference materials

---

## 📈 Quick Links

- **Main Repository:** https://github.com/Farezyrahman/Wau-Bulan-Vr
- **Development Timeline (CSV):** See `checklist_timeline_psm2.csv` in repo root
- **Unity Branch:** https://github.com/Farezyrahman/Wau-Bulan-Vr/tree/Unity
- **Latest Build:** Available on local Meta Quest 2 device

---

**Last Updated:** 27 May 2026  
**Repository Status:** 🟡 Active Development  
**Weekly Review:** Every Monday (Project Management)
