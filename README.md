
---

## 📄 README.md (英文版)

```markdown```
# 🥽 Unity VR Crafting & Dragging Game (for Meta Quest 3)

[![Unity Version](https://img.shields.io/badge/Unity-2022.3+-blueviolet?style=for-the-badge&logo=unity)](https://unity.com/)
[![Platform](https://img.shields.io/badge/Platform-Meta%20Quest%203-4267B2?style=for-the-badge&logo=meta)](https://www.meta.com/quest/)
[![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

A **VR crafting and dragging game** built with Unity, designed specifically for **Meta Quest 3**. The game features two distinct phases: crafting a car by combining components on a crafting table, followed by a block-placing puzzle. All interactions are designed for intuitive VR hand tracking and controller input.

## 🎮 Game Overview

The game is divided into two unique phases, each showcasing different VR interaction mechanics:

### Phase 1: Crafting the Car 🛠️
- **Objective**: Combine various components on a **crafting table** to assemble a car.
- **Mechanic**: Use your VR hands to grab individual parts (wheels, chassis, engine, etc.) and drag them onto the crafting table.
- **Crafting Logic**: Each component must be placed in the correct combination. The game tracks your progress until the final car is successfully crafted.
- **Goal**: Unlock the next phase by successfully building the car.

### Phase 2: Block Placing Challenge 🧩
- **Objective**: Grab specific blocks and drag them to designated target positions.
- **Mechanic**: After unlocking the car, the gameplay shifts to a puzzle-like challenge where you must place blocks in the correct spots.
- **Goal**: Complete the block placement to finish the game.

## ✨ Key Features

- **VR-Optimized Interactions**: Designed from the ground up for **Meta Quest 3**, with intuitive grab and drag mechanics.
- **Two-Phase Gameplay**: A crafting phase followed by a block-placement phase, offering variety and progression.
- **Hand Tracking Support**: Leverages Meta Quest's hand tracking for natural grabbing and dragging.
- **Crafting System**: Combine components in the correct order to craft new items and eventually a car.
- **Immersive Environment**: Built with Unity and Meta XR SDK for a seamless VR experience.

## 🛠️ Built With

- **Engine**: Unity (2022.3 LTS or later)
- **Target Platform**: Meta Quest 3 (Android build target)
- **SDKs**: Meta XR All-in-One SDK, XR Interaction Toolkit
- **Language**: C#
- **Interaction**: VR hand tracking and controller-based grabbing

## 🚀 Getting Started

### Prerequisites

- **Unity Hub** and **Unity Editor** (2022.3 LTS or later recommended)
- **Meta XR All-in-One SDK** (imported via Package Manager)
- A **Meta Quest 3** headset for testing (or use Link/Air Link for in-editor play)
- Basic understanding of Unity's XR Interaction Toolkit

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/LeoTheAuJai/Unity_dragging_game.git
   cd Unity_dragging_game
   ```

2. **Open in Unity Hub**
   - Launch Unity Hub.
   - Click "Open" and select the cloned project folder.
   - Open with a compatible Unity version (2022.3 LTS or later).

3. **Import Meta XR SDK** (if not already present)
   - Go to **Window > Package Manager**.
   - Ensure **Meta XR All-in-One SDK** and **XR Interaction Toolkit** are installed.

4. **Configure for Meta Quest 3**
   - Go to **File > Build Settings**.
   - Set platform to **Android**.
   - Under **Player Settings > Other Settings**:
     - Set **Minimum API Level** to 29 or higher.
     - Set **Scripting Backend** to **IL2CPP**.
     - Ensure **Target Architectures** includes **ARM64**.
   - Under **XR Plug-in Management**, enable **Oculus** (or Meta XR) for Android.

5. **Test in Editor or on Device**
   - Connect your Quest 3 via Link/Air Link and click **Play** in the editor, or build and run directly on the headset.

## 🎮 How to Play

### Phase 1: Crafting the Car
1. **Grab Components**: Reach out and grab the scattered car parts using your VR hands or controllers.
2. **Drag to Crafting Table**: Drag each component onto the designated crafting table area.
3. **Combine Correctly**: Follow the required combination order (e.g., chassis → engine → wheels) to progress.
4. **Complete the Car**: Once all components are correctly combined, the car is assembled, unlocking Phase 2.

### Phase 2: Block Placing
1. **Grab Blocks**: Pick up blocks from the environment.
2. **Drag to Target Positions**: Place each block into its correct designated spot.
3. **Complete the Challenge**: Once all blocks are correctly placed, the game is complete.

## 📁 Project Structure

```
Unity_dragging_game/
├── Assets/
│   ├── Scenes/           # Game scenes (crafting phase, block phase)
│   ├── Scripts/          # C# scripts for grabbing, crafting logic, block placement
│   ├── Prefabs/          # Reusable objects (components, blocks, crafting table)
│   ├── XR/               # XR rig and interaction settings
│   └── Sprites/Models/   # Visual assets
├── Packages/             # Unity package dependencies
├── ProjectSettings/      # Unity project configuration
├── .gitignore
├── LICENSE
└── README.md
```

## 🎯 Game Mechanics Explained

### Grabbing & Dragging
- Uses **XR Grab Interactable** components for intuitive object manipulation.
- Objects can be grabbed with either hand and dragged to target areas.

### Crafting System
- Each component has a required placement spot on the crafting table.
- The game tracks which components have been placed and in what order.
- When the correct combination is complete, the car is spawned, and the phase ends.

### Block Placement
- In Phase 2, blocks must be dragged to specific target locations.
- Visual feedback (color changes, highlights) indicates correct placement.
- Progress is tracked; the game completes when all blocks are correctly placed.

## 🎥 Demo Video

A gameplay demonstration will be available soon!

## 📄 License

This project is licensed under the **MIT License**. See the `LICENSE` file for details.

## 📬 Contact

Created by **LeoTheAuJai**. Feel free to reach out via GitHub.

---
```

---
```
## 📄 README.zh.md (中文版)

```markdown```
# 🥽 Unity VR 合成與拖拽遊戲 (for Meta Quest 3)

[![Unity 版本](https://img.shields.io/badge/Unity-2022.3+-blueviolet?style=for-the-badge&logo=unity)](https://unity.com/)
[![平台](https://img.shields.io/badge/平台-Meta%20Quest%203-4267B2?style=for-the-badge&logo=meta)](https://www.meta.com/quest/)
[![授權條款](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)](LICENSE)

這是一款使用 **Unity** 開發、專為 **Meta Quest 3** 設計的 **VR 合成與拖拽遊戲**。遊戲分為兩個階段：在合成台上將零件組合成一輛車，然後進入方塊放置挑戰。所有互動都針對 VR 手部追蹤與控制器操作進行了優化。

## 🎮 遊戲簡介

遊戲分為兩個獨特的階段，每個階段都展示不同的 VR 互動機制：

### 第一階段：合成賽車 🛠️
- **目標**：在**合成台**上組合各種零件，組裝出一輛完整的車。
- **機制**：使用 VR 雙手抓取零件（輪胎、底盤、引擎等），並將其拖曳到合成台上。
- **合成邏輯**：每個零件必須按照正確的組合方式放置。遊戲會記錄你的進度，直到成功合成出車子。
- **目標**：成功造出車子後，解鎖下一階段。

### 第二階段：方塊放置挑戰 🧩
- **目標**：抓取特定方塊，並將其拖曳到指定的目標位置。
- **機制**：進入第二階段後，遊戲變成一種類似拼圖的挑戰，你需要將方塊放到正確的位置。
- **目標**：完成所有方塊的放置，遊戲通關。

## ✨ 主要特色

- **VR 優化互動**：專為 **Meta Quest 3** 設計，具備直覺的抓取與拖曳機制。
- **雙階段玩法**：先合成再放置，兩種不同體驗帶來豐富的遊戲進程。
- **手部追蹤支援**：利用 Meta Quest 的手部追蹤功能，實現自然的抓取與拖曳。
- **合成系統**：按照正確順序組合零件，逐步合成新物品，最終造出車子。
- **沉浸式環境**：使用 Unity 與 Meta XR SDK 打造，提供流暢的 VR 體驗。

## 🛠️ 使用技術

- **遊戲引擎**：Unity（建議使用 2022.3 LTS 或更高版本）
- **目標平台**：Meta Quest 3（Android 建置目標）
- **SDKs**：Meta XR All-in-One SDK、XR Interaction Toolkit
- **程式語言**：C#
- **互動方式**：VR 手部追蹤與控制器抓取

## 🚀 本地安裝與執行

### 環境需求

- **Unity Hub** 與 **Unity Editor**（建議使用 2022.3 LTS 或更高版本）
- **Meta XR All-in-One SDK**（透過 Package Manager 導入）
- 用於測試的 **Meta Quest 3** 頭戴裝置（或透過 Link / Air Link 進行編輯器內測試）
- 對 Unity 的 XR Interaction Toolkit 有基本了解

### 安裝步驟

1. **複製專案**
   ```bash
   git clone https://github.com/LeoTheAuJai/Unity_dragging_game.git
   cd Unity_dragging_game
   ```

2. **在 Unity Hub 中開啟**
   - 啟動 Unity Hub。
   - 點擊「開啟 (Open)」，選擇複製的專案資料夾。
   - 使用相容的 Unity 版本（2022.3 LTS 或更高）開啟。

3. **導入 Meta XR SDK**（如果尚未導入）
   - 前往 **Window > Package Manager**。
   - 確認已安裝 **Meta XR All-in-One SDK** 和 **XR Interaction Toolkit**。

4. **針對 Meta Quest 3 進行設定**
   - 前往 **File > Build Settings**。
   - 將平台設為 **Android**。
   - 在 **Player Settings > Other Settings** 中：
     - 將 **Minimum API Level** 設為 29 或更高。
     - 將 **Scripting Backend** 設為 **IL2CPP**。
     - 確保 **Target Architectures** 包含 **ARM64**。
   - 在 **XR Plug-in Management** 中，為 Android 啟用 **Oculus**（或 Meta XR）。

5. **在編輯器中測試或部署至裝置**
   - 透過 Link / Air Link 連接 Quest 3，在編輯器中點擊 **Play** 測試；或直接建置並執行到頭戴裝置。

## 🎮 遊戲玩法

### 第一階段：合成賽車
1. **抓取零件**：用 VR 雙手或控制器抓取散落在環境中的汽車零件。
2. **拖曳至合成台**：將每個零件拖曳到合成台上的指定區域。
3. **正確組合**：按照正確的組合順序放置（例如：底盤 → 引擎 → 輪胎）來推進進度。
4. **完成組裝**：所有零件正確組合後，車子會合成完成，解鎖第二階段。

### 第二階段：方塊放置
1. **抓取方塊**：從環境中拾取方塊。
2. **拖曳至目標位置**：將每個方塊放置到正確的指定位置。
3. **完成挑戰**：所有方塊都正確放置後，遊戲通關。

## 📁 專案結構

```
Unity_dragging_game/
├── Assets/
│   ├── Scenes/           # 遊戲場景（合成階段、方塊階段）
│   ├── Scripts/          # C# 腳本（抓取邏輯、合成系統、方塊放置）
│   ├── Prefabs/          # 可重複使用的物件（零件、方塊、合成台）
│   ├── XR/               # XR 角色與互動設定
│   └── Sprites/Models/   # 視覺素材
├── Packages/             # Unity 套件相依性
├── ProjectSettings/      # Unity 專案設定
├── .gitignore
├── LICENSE
└── README.md
```

## 🎯 遊戲機制說明

### 抓取與拖曳
- 使用 **XR Grab Interactable** 組件實現直覺的物件操控。
- 物件可以用任一手抓取，並拖曳到目標區域。

### 合成系統
- 每個零件在合成台上都有對應的放置位置。
- 遊戲會記錄哪些零件已經放置，以及放置的順序。
- 當正確的組合完成時，車子會生成，並結束第一階段。

### 方塊放置
- 第二階段中，方塊必須被拖曳到指定的目標位置。
- 視覺回饋（顏色變化、高亮）會提示正確的放置位置。
- 遊戲會追蹤進度，所有方塊正確放置後即通關。

## 🎥 遊戲示範

遊戲玩法示範影片即將推出！

## 📄 授權條款

本專案採用 **MIT 授權條款**。詳細內容請參閱 `LICENSE` 檔案。

## 📬 聯絡我

此專案由 **LeoTheAuJai** 製作。歡迎透過 GitHub 與我交流。

---
```
