# Photon Multiplayer Prototype

## Overview
This is a 3D multiplayer prototype built using Unity and Photon PUN 2. It demonstrates core multiplayer networking concepts including room creation, client synchronization, direct rotation character movement, network animation syncing, and Remote Procedure Calls (RPCs). 

## Features Implemented
* **Photon Networking & Connection UI:** Full integration with Photon Cloud, featuring real-time UI text updates displaying the current connection status (e.g., "Connecting to Master...", "Joined Lobby").
* **Lobby & Room System:** Simple UI to Create, Join, and Leave rooms using custom room names (Max 2 players).
* **Player Spawning:** Automatic instantiation of the `Network Player` prefab across the network when joining a room.
* **Third-Person Controller:** Smooth, direct keyboard rotation movement and physics-based jumping.
* **Cinemachine 3 Integration:** Orbiting, collision-aware FreeLook camera that correctly links only to the local player.
* **Animation Syncing:** Fully networked Animator using `PhotonAnimatorView` for continuous walking states and discrete jump/wave triggers.
* **RPC Implementation:** Buffered RPC to randomly change the player's material color across all connected clients, ensuring late joiners also see the correct colors upon spawning.

## Prerequisites & Dependencies
* **Unity Version:** Unity 2022.3 LTS or higher (Unity 6 recommended).
* **Photon PUN 2:** Installed via the Unity Asset Store.
* **Unity Cinemachine:** Version 3.x (Installed via Package Manager).
* **TextMeshPro:** Essential for the UI elements.

## Project Setup Instructions

### 1. Configure the Photon App ID
To run this project, you must link it to a Photon Cloud account.
1. Create a free account at [PhotonEngine.com](https://www.photonengine.com/).
2. Create a new **PUN** application and copy the generated **App ID**.
3. In Unity, go to **Window > Photon Unity Networking > PUN Wizard**.
4. Click **Setup Project**, paste your App ID, and click **Setup**.

### 2. Scene Configuration
Ensure the scenes are added to your Build Settings in the exact following order:
1. `Lobby_Scene` (Index 0)
2. `Game_Scene` (Index 1)

### 3. Build & Test
To test the multiplayer functionality:
1. Go to **File > Build Settings** and click **Build and Run** to create a standalone executable.
2. Once the standalone build opens, press the **Play** button inside the Unity Editor to act as the second player.
3. In one client, click **Create Room** enter a room name and click **Create**.
4. In the second client, click **Join a Room** enter the exact same room name and click **Join**.

## Controls
* **W / S:** Move Forward / Backward
* **A / D:** Rotate Character Left / Right
* **Mouse:** Orbit Camera
* **Spacebar:** Jump
* **E:** Wave Emote
* **C:** Change Color (Triggers Buffered RPC)
