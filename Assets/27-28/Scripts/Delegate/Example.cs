using UnityEngine;

namespace _27_28.Scripts.Delegate
{
    public class Example : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        
        private KillService _killer;

        private void Awake()
        {
            _killer = new KillService(this);
        }

        private void Update()
        {
            Debug.Log(_killer.Count);
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Enemy newEnemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
                _killer.KillWhen(newEnemy, () => newEnemy.IsDead);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Enemy newEnemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
                _killer.KillWhen(newEnemy, () => newEnemy.LifeTime >= 10f);
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Enemy newEnemy = Instantiate(_enemyPrefab, Vector3.zero, Quaternion.identity);
                _killer.KillWhen(newEnemy, () => _killer.Count > 10);
            }
        }
    }
}