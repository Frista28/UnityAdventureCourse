using _31.Scripts.Spawners.Interfaces;

namespace _31.Scripts.Spawners
{
    public class TimedCharacterSpawnService<TCharacter> where TCharacter : Characters.Character
    {
        private readonly ICharacterSpawner<TCharacter> _characterSpawner;
        private readonly float _spawnCooldown;

        private float _timer;

        public TimedCharacterSpawnService(
            ICharacterSpawner<TCharacter> characterSpawner,
            float spawnCooldown)
        {
            _characterSpawner = characterSpawner;
            _spawnCooldown = spawnCooldown;
            
            // Добавить сервис хранения заспавненных персонажей, а то сейчас они пропадают в пустоту
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

        private void Spawn() => _characterSpawner.Spawn();
    }
}