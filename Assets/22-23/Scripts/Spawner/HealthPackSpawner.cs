using System.Collections;
using _22_23.Scripts.Character;
using _22_23.Scripts.Spawner.Interfaces;
using UnityEngine;

namespace _22_23.Scripts.Spawner
{
    public class HealthPackSpawner : ISpawner
    {
        private readonly IPositionProvider _playerPosition;
    
        private readonly GameObject _healthPackPrefab;
    
        private readonly float _timeToSpawn;

        private readonly MonoBehaviour _coroutineRunner;
    
        private Coroutine _healthPackCoroutine;


        public HealthPackSpawner(GameObject healthPackPrefab, float timeToSpawn, IPositionProvider playerPosition, MonoBehaviour corutinRunner)
        {
            _healthPackPrefab = healthPackPrefab;
            _timeToSpawn = timeToSpawn;
            _playerPosition = playerPosition;
            _coroutineRunner = corutinRunner;
        }

        public void Start()
        {
            if (_healthPackCoroutine != null)
                return;
        
            _healthPackCoroutine = _coroutineRunner.StartCoroutine(SpawnHealthPack());
        }

        public void Stop()
        {
            if (_healthPackCoroutine == null)
                return;
        
            _coroutineRunner.StopCoroutine(_healthPackCoroutine);
            _healthPackCoroutine = null;
        }

        private IEnumerator SpawnHealthPack()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeToSpawn);
                
                Spawn();
            }
        }

        private void Spawn()
        {
            Vector3 spawnPosition = _playerPosition.Position;
            
            spawnPosition.x += Random.Range(-2f, 2f);
            spawnPosition.z += Random.Range(-2f, 2f);

            spawnPosition.y += 0.5f;
            
            Object.Instantiate(_healthPackPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
