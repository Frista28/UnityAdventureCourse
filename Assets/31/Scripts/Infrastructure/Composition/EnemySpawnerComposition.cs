using _31.Scripts.Characters;
using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Spawners;
using UnityEngine;

namespace _31.Scripts.Infrastructure.Composition
{
    public class EnemySpawnerComposition
    {
        private readonly TimedCharacterSpawnService<Character> _timedSpawnService;

        public EnemySpawnerComposition(
            ICharacterCreator<Character> enemyCreator,
            Transform[] spawnPoints,
            float spawnInterval)
        {
            CharacterSpawnerOnSpawnPoints<Character> characterSpawner =
                new CharacterSpawnerOnSpawnPoints<Character>(
                    enemyCreator,
                    spawnPoints);

            _timedSpawnService =
                new TimedCharacterSpawnService<Character>(
                    characterSpawner,
                    spawnInterval);
        }

        public void Update(float deltaTime)
        {
            _timedSpawnService.Update(deltaTime);
        }
    }
}