using _22_23.Scripts.Spawner.Interfaces;

namespace _22_23.Scripts.Spawner
{
    public class SpawnerToggleController
    {
        private readonly ISpawner _spawner;
        
        private bool _enabled;

        public SpawnerToggleController(ISpawner spawner)
        {
            _spawner = spawner;
        }

        public void Toggle()
        {
            _enabled = !_enabled;
            
            if (_enabled)
                _spawner.Start();
            else
                _spawner.Stop();
        }
    }
}