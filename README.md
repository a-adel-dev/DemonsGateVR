# Alien Defense VR

This is a two weeks project done in Unity. Developed for Meta quest 2.
Watch a video demo here: https://youtu.be/I-2XNcESLpE

## Game Summary:

Alien Defense VR puts the player in charge of defending a gate opened by aliens and let him/her defend against hordes of aliens that are invading. The mission is simple, stop the aliens from invading earth.

## Gameplay Mechanics:

The game consists of waves of enemies that spawn around the player from all direction. Player should use the weapons they have to fend off the aliens. The main game loop is for the player to shoot aliens until the wave is cleared, take a breather, and face off the next wave, until either he/she beats the game or overwhelmed by the aliens.
Two types of weapons exist, pistols and machine guns, both can be equipped with magazines that are available for the player. The loading and shooting actions feel natural and realistic.

## Development:

- Health system: all entities in the game has their health. Aliens die from getting hit, player health depletes when hit.
- On Death Ragdoll effects: enemies have ragdoll effects on their death, making the action more bombastic.
- Shooting systems: A Raycast weapon system that allows modeling different guns.
- Wave spawning system: Waves scriptable objects describes the configuration of each wave. A Wave generator object runs through all the waves, executing them one by one. Editor scripts was used to configure the waves.
- Enemy AI: A state machine controls the behavior of enemies, letting them seek the player, shooting when in range, reloading when their weapons are exhausted.
- UI: a simple UI to Let the player know which wave they are on and their remaining health.
- Sound FX Manager: picks randomly between different sounds.
