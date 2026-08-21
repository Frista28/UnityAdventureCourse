using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Spawners.Interfaces;
using UnityEngine;

namespace _31.Scripts.Spawners
{
    public class CharacterSpawnerOnSpawnPoints<TCharacter> : ICharacterSpawner<TCharacter> where TCharacter : Characters.Character
    {
        private readonly ICharacterCreator<TCharacter> _characterCreator;
        private readonly Transform[] _spawnPoints;

        public CharacterSpawnerOnSpawnPoints(ICharacterCreator<TCharacter> characterCreator, Transform[] spawnPoints)
        {
            _characterCreator = characterCreator;
            _spawnPoints = spawnPoints;
        }

        public TCharacter Spawn() => _characterCreator.Create(GetRandomSpawnPoint().position);

        private Transform GetRandomSpawnPoint()
        {
            return _spawnPoints[
                Random.Range(0, _spawnPoints.Length)];
        }
    }
}