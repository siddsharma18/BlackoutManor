# Blackout Manor

A first-person horror survival game built with Unity. Navigate through a dark manor, avoid enemies, collect items, and escape before it's too late.

## Game Overview

Blackout Manor is a survival horror game where players must explore a dark manor, collect keys, avoid enemies, and find their way to freedom. The game features atmospheric environments, dynamic enemy AI, and immersive gameplay mechanics.

## Features

### Core Gameplay
- **First-Person Controls**: Smooth movement and camera controls with walking and running
- **Weapon System**: Pistol with shooting and reloading mechanics
- **Enemy AI**: Intelligent enemies that patrol waypoints and chase the player when detected
- **Item Collection**: Pick up keys, lanterns, and other items to progress
- **Interactive Objects**: Open chests, unlock doors, and interact with the environment
- **Death System**: Game over screen with restart functionality

### Audio & Atmosphere
- **Dynamic Footsteps**: Different footstep sounds based on surface type (wood, tile, carpet)
- **Enemy Sounds**: Distinct audio cues for idle, walking, and chasing states
- **Ambient Audio**: Immersive sound design to enhance the horror atmosphere

### UI & Menus
- **Main Menu**: Start screen with scene loading
- **Death Screen**: Restart or quit options
- **Cursor Control**: Automatic cursor locking/unlocking for menus

## Technical Details

### Unity Version
- **Unity 2022.3.62f2**

### Key Scripts

#### Player Systems
- `PlayerController.cs` - Handles player movement, camera control, and footstep sounds
- `Sway.cs` - Adds realistic weapon/item swaying motion
- `Pistol.cs` - Weapon shooting, reloading, and animation system

#### Enemy Systems
- `EnemyController.cs` - NavMesh-based AI with idle, patrol, and chase states
- `EnemyHealth.cs` - Enemy health management and death handling
- `KillPlayer.cs` - Triggers game over when player touches enemy

#### Interaction Systems
- `Door.cs` - End-game door that requires a key to unlock
- `KeyPickUp.cs` - Key collection mechanics
- `LanturnPickUp.cs` - Lantern pickup functionality
- `UseChest.cs` - Chest opening animations and item activation

#### UI Systems
- `MenuStuff.cs` - Scene loading and quit functionality
- `Death-Main-Menu.cs` - Death and main menu screen handlers
- `CursorControl.cs` - Mouse cursor management for menus

## Gameplay Mechanics

### Movement
- **WASD** - Move
- **Left Shift** - Run
- **Mouse** - Look around
- **Right Mouse Button** - Zoom/Aim
- **Space** - Jump (if enabled)

### Combat
- **Left Mouse Button** - Shoot
- **R** - Reload

### Objectives
1. Explore the manor
2. Collect the key
3. Avoid or defeat enemies
4. Find and unlock the exit door
5. Escape to freedom

## Project Structure

```
BlackoutManor/
├── Assets/
│   ├── BasicHorrorGameAssets/
│   │   ├── Scripts/          # Core game scripts
│   │   ├── Animations/       # Character and object animations
│   │   ├── Models/           # 3D models and materials
│   │   ├── Sounds/           # Audio files
│   │   ├── Effects/          # Visual effects
│   │   └── UI/               # UI elements
│   ├── Scenes/               # Unity scenes (MainMenu, SampleScene, DeathScene)
│   ├── Models/               # Additional 3D models
│   ├── Sounds/               # Additional audio files
│   └── Textures/             # Texture files
└── ProjectSettings/          # Unity project settings
```

## Getting Started

### Prerequisites
- Unity 2022.3.62f2 or compatible version
- Git (for cloning the repository)

### Installation

1. Clone the repository:
```bash
git clone https://github.com/siddsharma18/BlackoutManor.git
cd BlackoutManor
```

2. Open the project in Unity:
   - Launch Unity Hub
   - Click "Add" and select the `BlackoutManor` folder
   - Open the project with Unity 2022.3.62f2

3. Open the main scene:
   - Navigate to `Assets/Scenes/SampleScene.unity`
   - Press Play to start the game

## Assets

The game uses a combination of:
- Custom scripts and mechanics
- Basic Horror Game Assets package
- Custom 3D models and textures
- Sound effects and ambient audio

## Known Issues

- Some scripts may require additional setup in the Unity Inspector
- NavMesh needs to be baked for enemy AI to work properly
- Audio sources need to be assigned in the Inspector

## Development Notes

### Setting Up the Game

1. **Player Setup**:
   - Add `PlayerController` script to player GameObject
   - Assign camera reference
   - Set up footstep audio clips for different surface types

2. **Enemy Setup**:
   - Add `EnemyController` script to enemy GameObject
   - Set up waypoints for patrol behavior
   - Configure NavMesh Agent component
   - Assign audio clips for different states

3. **Weapon Setup**:
   - Add `Pistol` script to weapon GameObject
   - Configure shooting and reloading parameters
   - Set up animations

4. **Doors & Keys**:
   - Tag doors with appropriate tags
   - Set up key pickup objects with `KeyPickUp` script
   - Configure door script to check for key

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available for educational purposes.

## Author

**Siddharth Sharma**
- GitHub: [@siddsharma18](https://github.com/siddsharma18)

## Acknowledgments

- Unity Technologies for the game engine
- Basic Horror Game Assets contributors
- Sound and texture asset creators

---

**Note**: This is a work in progress. More features and improvements are planned for future releases.

