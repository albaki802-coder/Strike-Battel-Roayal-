# Android setup

1. Install Unity Hub from the official Unity website and install a supported Unity LTS editor.
2. In Unity Hub's editor modules, install **Android Build Support**, **Android SDK & NDK Tools**, and **OpenJDK**.
3. Create a Unity **3D (Core)** project.
4. Copy this repository's `Assets/Scripts` directory into the Unity project's `Assets` directory.
5. Add a ground plane, a directional light, a player capsule with a CharacterController, and a Camera child.
6. Attach PlayerController to the player and assign the Camera transform to Camera Pivot.
7. Attach WeaponController to the player or camera and assign the Camera to Aim Camera.
8. Add HealthSystem to the player and practice targets. Add TargetDummy to targets.
9. Create a Canvas with joystick and drag-look UI. Feed joystick values into SetMoveInput and drag deltas into AddLookInput. Connect Fire and Reload UI controls to WeaponController.Fire and WeaponController.Reload.
10. Open Build Settings / Build Profiles, choose Android, and switch platform.
11. Set a unique package identifier under Project Settings > Player > Android, then build and test on your own device.

This prototype uses Unity's built-in UI Text component for broad compatibility. Multiplayer and online services are not included.
