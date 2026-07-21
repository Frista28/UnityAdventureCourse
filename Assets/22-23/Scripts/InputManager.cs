using _22_23.Scripts.Character;
using _22_23.Scripts.Spawner;
using UnityEngine;

namespace _22_23.Scripts
{
    public class InputManager : MonoBehaviour
    {
        private const KeyCode _toggleSpawnKey = KeyCode.F;
        
        [SerializeField] private GameObject _healthPackPrefab;
        [SerializeField] private PlayerController _playerController;
        
        [SerializeField] private float _timeToHealthPackSpawn;

        private SpawnerToggleController _controller;

        private void Awake()
        {
            HealthPackSpawner healthPackSpawner =
                new HealthPackSpawner(_healthPackPrefab, 
                    _timeToHealthPackSpawn, 
                    _playerController, 
                    this);
            
            _controller =  new SpawnerToggleController(healthPackSpawner);
        }

        private void Update()
        {
            if (Input.GetKeyDown(_toggleSpawnKey))
                _controller.Toggle();
        }
    }
}