using _31.Scripts.Character;
using _31.Scripts.CharacterCreators.Interfaces;
using _31.Scripts.Spawners.Interfaces;
using UnityEngine;

namespace _31.Scripts.Spawners
{
    public class EnemySpawnerOnSpawnPoints : IEnemySpawner
    {
        private readonly IEnemyCreator _enemyCreator;
        private readonly Transform[] _spawnPoints;

        public EnemySpawnerOnSpawnPoints(IEnemyCreator enemyCreator, Transform[] spawnPoints)
        {
            _enemyCreator = enemyCreator;
            _spawnPoints = spawnPoints;
        }
        
        public EnemyCharacter Spawn() => _enemyCreator.Create(GetRandomSpawnPoint().position);

        private Transform GetRandomSpawnPoint()
        {
            return _spawnPoints[
                Random.Range(0, _spawnPoints.Length)];
        }
    }
}