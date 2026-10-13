# Strike Battle Royale — Game Design

## Original identity
This is an original tactical shooter concept. It should not reuse PUBG, Free Fire, or other games' names, logos, maps, UI layouts, character designs, weapon skins, audio, or other protected assets. Use original names and commissioned, licensed, or self-made assets.

## Core direction
- Target platform: Android first.
- Visual direction: grounded, realistic-looking tactical combat, optimized for older PCs and Android devices.
- Default weapon appearance: matte black, restrained highlights, no paid material/crafting requirement.
- Premium weapon trials: selected premium weapon variants can be temporarily available for seven days. When the trial expires, the player can still use the default matte-black version. Trial expiry must not remove the base weapon.
- Avoid pay-to-win stats: premium trials should be cosmetic or side-grade variants, not stronger damage or unfair advantages.
- Reloading: use weapon-specific, animation-timed reloads; no instant reload. Initial prototype values should be tuned through testing rather than copied from another game.

## Modes
### Offline practice match
- Start with a small test arena and 4 active combatants at a time for performance testing.
- Simulated opponents use distinct generated callsigns, such as Lucas, Terrian, John, and Robert. These are fictional bot names, not real user IDs.
- A larger offline session with up to 20 simulated participants can be explored after profiling performance. Twenty active, thinking bots may be too expensive for the target hardware, so use spawn waves / limited active AI if needed.
- Bots should roam between multiple waypoints, investigate targets, take cover, and engage rather than stand in one spot.

### Online mode
- Real players require a networked authoritative game server, matchmaking, session management, and anti-cheat. A button alone cannot make offline bots into online players.
- Build offline gameplay first, then add online networking after the basic game is stable.

## Maps
1. **Foundry Arena** — a compact original arena for quick offline/online matches.
2. **Dustwind Basin** — a larger original island/valley map with villages, ridgelines, roads, and scattered industrial structures. It must have its own layout and art, not recreate Erangel or another existing map.

## Performance plan
- Prototype on a small map, use simple colliders, baked lighting, limited realtime shadows, LODs, and compressed textures.
- Profile on target devices before expanding map size or bot count.
- First milestone: one player, one weapon, one practice bot, offline only.
- Second milestone: several bots, multiple weapons, HUD, reload animations.
- Third milestone: two original maps and a polished menu.
- Fourth milestone: online multiplayer prototype.
