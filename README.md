# 🎮 Rec Game (Alpha)

A retro-style 2D platformer inspired by Recife's myths and legends, built using Unity and pixel art aesthetics.

> **Play now:** [Unity WebGL Build](https://play.unity.com/en/games/fc06de38-d5d7-4e85-a020-0c96b26db2ca/rec-game)  

---

## 📖 Overview

**Rec Game** is a pixel-art platform game that blends mystery, cultural storytelling, and traditional platform mechanics. Explore mythological stories from Recife, interact with legendary characters, and conquer challenges across 4 unique levels.

---

## 🧩 Features

### 🎮 Player Mechanics
- **Movement**: Move left/right with fluid controls.
- **Jumping**: Physics-based jumping on platforms and enemies.
- **Lives System**: Lose lives by falling or colliding with enemies.
- **Collectibles**: Red gems restore player lives.
- **Camera**: Smooth-follow camera that dynamically tracks the player.

### ⚔️ Combat System
- **Enemy Interaction**: Jump on enemies to defeat them.
- **Damage Handling**: Contact with enemies (except jumping) removes a life.
- **Game Over**: Losing all lives restarts the level.

### 👾 Enemies
- **Mechanics**: Patrol and chase mechanics depending on level difficulty.

### 🧭 Progression & World
- **4 Levels**: Each with increasing difficulty and new challenges.
- **World Map**: Retro-style map of Recife unlocking levels as you progress.
- **Story Integration**: Dialogues with folklore characters introduce each level.

### 🧑‍💻 User Interface
- **Main Menu**: Start and quit options.
- **HUD**: Live health and game status.
- **Level Selector**: Unlocked levels are accessible, others are disabled.


### 🌍 Environment & Physics
- Realistic physics including gravity and collision handling for platforms, characters, and objects.

---

## ⚙️ Architecture

- Modular **component-based** architecture in Unity.
- Clean **object-oriented** design for reusability and maintainability.
- Expandable systems for new levels, characters, or features.

---

## 🧪 Testing

### ✅ Automated (Play Mode) Tests

| Test                     | Description                                                    | Status   |
|--------------------------|----------------------------------------------------------------|----------|
| `KeeperCollisionTest`    | Player defeats enemy by jumping on top                         | ✅ Passed |
| `LifeCoinPasses`         | Player collects a life-giving coin (destroyed on contact)      | ✅ Passed |
| `FinishCoinPasses`       | Player collects level-ending coin (level marked completed)     | ✅ Passed |

### 🔁 End-to-End Tests

| Scenario                 | Description                                                    | Status   |
|--------------------------|----------------------------------------------------------------|----------|
| Player fall              | Player respawns with same health after falling                 | ✅ Passed |
| Enemy defeat             | Enemy is destroyed when player jumps on it                     | ✅ Passed |
| Level map access         | Only unlocked (green) levels can be accessed                   | ✅ Passed |

---

## 🛠 Development Phases

### 📅 Phase 1 – Planning (Mar–Apr)
- Researched Recife’s legends
- Defined project scope and tools
- Created MVP in Unity

### 💻 Phase 2 – Development (Apr–May)
- Built main menu
- Created all levels
- Implemented enemies and mechanics

### 🧪 Phase 3 – Testing (May)
- Ran automated and E2E tests
- Validated gameplay and functionality

---

## 📊 Non-Functional Requirements

| Requirement       | Description                                                       |
|-------------------|-------------------------------------------------------------------|
| ⚡ Performance     | Scene loading under 5s, < 1GB memory usage                        |
| ♻️ Scalability     | Easily add new levels, characters, and features                   |
| 🧠 Usability       | Intuitive UI and player feedback via animations     |
| 🔒 Reliability     | Game must be stable under concurrent actions                      |
| 🧹 Maintainability | Clean, documented, and modular code                               |

---

## 🎨 Visual Style

- **Pixel Art**: Inspired by 32-bit retro games
- **Color Palette**: Limited and consistent for nostalgic feel
- **Animations**: Classic sprite-based visuals

---

## 🚧 Future Enhancements

- Story intros at the beginning of each level
- Additional game levels and enemies
- New game modes
- Partnerships with cultural organizations to promote Recife’s folklore
- Create audio effects

---

## 🗃 Data Persistence

No database used – player data is not saved between sessions to maintain simplicity.

---

## 🙌 Contributing

Feel free to fork, clone, or submit pull requests!  
We welcome contributions that enhance game performance, level design, or story content.

---

## 📌 Authors

**João Ricardo de Oliveira Alves** – Initial development, game design, and lead programming  
**Gustless** - Added contributions and started sound effects
Built in Unity for educational and cultural purposes.

---

## 📎 License

This project is open-source for educational use.
