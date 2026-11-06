# ShadowKnight

A solo Unity 2D action-platformer portfolio project focused on melee combat, enemy behavior, and a complete gameplay loop. Explore the level, earn gold, upgrade your character, and defeat the boss.

## Play the Windows build

1. Download the Windows ZIP from the project's release page.
2. Extract the entire ZIP into a folder.
3. Run `ShadowKnight.exe` and select Play.

Keep the executable, its `_Data` folder, and all accompanying files together. The Unity Editor is not required to play the Windows build.

## Controls

| Input | Action |
| --- | --- |
| A / D or Left / Right Arrow | Move |
| Space | Jump |
| Left Mouse Button | Normal attack / combo |
| Right Mouse Button | Heavy attack / combo |
| Left Shift | Roll / dodge |
| Q | Use a healing potion |
| E | Use skill |
| F near a statue | Open the rest and upgrade menu |
| Mouse | Interact with UI buttons |

Normal attacks, heavy attacks, and rolls consume stamina. The skill has a cooldown. Potions are consumed when drinking begins, so an interrupted heal can still cost a potion.

## Gameplay

- Normal and heavy melee attacks, jump, roll, and a cooldown-based skill.
- Health, stamina regeneration, healing potions, and gold rewards.
- Damage, maximum health, and stamina upgrades, each with five levels and increasing prices.
- Statues that set a respawn checkpoint and provide rest and upgrades.
- Enemy detection, pursuit, attacks, damage reactions, and death states.
- A shield mechanic for Skeleton enemies.
- A boss that unlocks summoning at 50% health; summoned minions wait, pursue the player, and die in one hit.
- A reusable minion pool, tutorial triggers, HUD, respawn UI, and a victory screen.

Rest restores health, stamina, and potions and resets enemies. Progress is stored for the current session only; there is no persistent save system. Restarting the game resets progression.

## Development

- **Engine:** Unity 6.6, editor version `6000.6.4f1`
- **Language:** C#
- **Rendering:** Universal Render Pipeline, 2D
- **Input:** Unity Input System
- **Camera:** Cinemachine
- **UI:** Unity UI and TextMeshPro
- **Target platform:** Windows

This is a solo project. My work includes gameplay scripting, state-based player and enemy behavior, combat and progression systems, UI integration, level assembly, and animation/audio integration. Visual and audio assets are sourced from third-party packs.

## Code organization

```text
Assets/Scripts/
├── Player/
│   ├── Core/          # Movement, combat, health, inventory, upgrades, respawn
│   └── State/         # Player behavior states
├── Enemy/
│   ├── Core/          # Detection, movement, combat, health, enemy reset
│   ├── State/         # Enemy behavior states
│   ├── Scriptableobject/ # Enemy configuration assets
│   └── SummonCreatie/ # Summoned minion behavior
├── UI/                # HUD, panels, tutorials, upgrade stations, audio
└── Effect/            # Effect lifecycle scripts
```

Player and enemy controllers manage state transitions. Components own their data and expose methods for actions such as taking damage, spending stamina, and upgrading stats. Enemy configuration uses ScriptableObjects. Animation Events trigger combat effects at specific points in attack animations.

## Open and build the project

1. Add the project in Unity Hub and open it with Unity `6000.6.4f1`.
2. Allow Unity to restore packages and finish importing assets.
3. Open `Assets/Scenes/SampleScene.unity`.
4. For a Windows build, open **File > Build Profiles**, select Windows, and include `SampleScene` in the Scene List.
5. Build into a separate output folder outside `Assets`.

## Asset credits

Third-party assets used in this project include:

- Free 2D Pixel Art Black Knight Pack — player artwork and animations.
- Monsters Creatures Fantasy — enemy artwork and animations.
- Undead executioner puppet — boss-related artwork and animations.
- Cainos Pixel Art Platformer - Village Props — environment assets.
- Gentleland SteampunkUI — UI artwork and supporting asset utilities.
- Skymon Icon Pack Free — icons.
- Epic Adventure Orchestral Background Music — music by Marma.

Additional map and sound-effect assets are included in the project. This list is a starting credit inventory, not a complete license audit: verify creator names, required attribution, and the remaining packs before publication. Included third-party assets retain their respective licenses; this repository does not grant permission to redistribute them as standalone asset packs.
