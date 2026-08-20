using _31.Scripts.Spawners.Interfaces;

namespace _31.Scripts.Spawners
{
    public class EnemySpawnService
    {
        private readonly IEnemySpawner _enemySpawner;
        private readonly float _spawnCooldown;

        private float _timer;

        public EnemySpawnService(
            IEnemySpawner enemySpawner,
            float spawnCooldown)
        {
            _enemySpawner = enemySpawner;
            _spawnCooldown = spawnCooldown;
            
            Spawn();
        }

        public void Update(float deltaTime)
        {
            _timer += deltaTime;

            if (_timer < _spawnCooldown)
                return;

            _timer = 0f;

            Spawn();
        }

        private void Spawn() => _enemySpawner.Spawn();
    }
}