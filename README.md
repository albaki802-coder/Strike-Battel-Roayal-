# Strike Battle Royale

Starter source code for an Android-focused first-person battle royale prototype built with Unity and C#.

## Included starter systems
- First-person movement and mobile input methods
- Raycast weapon firing and reloading
- Health and damage system
- Respawning practice target
- Basic health/ammo HUD
- Android setup instructions

> These are starter scripts, not a complete packaged Unity game. You still need to create a Unity scene and add models, animations, sound, UI, and Android build settings.

## Unity setup
1. Install Unity Hub and a supported Unity LTS editor.
2. Install **Android Build Support**, including Android SDK & NDK Tools and OpenJDK.
3. Create a **3D (Core)** Unity project.
4. Copy this repository's `Assets/Scripts` folder into the Unity project's `Assets` folder.
5. Create a ground plane and directional light.
6. Create a Player capsule, add a CharacterController, and add a Camera as its child.
7. Attach PlayerController to the Player and assign the Camera transform to Camera Pivot.
8. Attach WeaponController to the Player or Camera and assign the Camera to Aim Camera.
9. Add HealthSystem and TargetDummy to a practice target.
10. Create a Canvas with joystick, look-drag area, fire and reload buttons. Connect them to the public methods on PlayerController and WeaponController.
11. Follow `Docs/ANDROID_SETUP.md` to configure and build for Android.

## Prototype limitations
This is an offline practice prototype. Online multiplayer, matchmaking, a shrinking safe zone, inventory, parachuting, polished assets, and production-ready anti-cheat are not included yet.
