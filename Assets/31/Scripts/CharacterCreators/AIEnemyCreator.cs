using _31.Scripts.Character;
using _31.Scripts.CharacterCreators.Interfaces;
using _31.Scripts.CharactersFactories;
using UnityEngine;

namespace _31.Scripts.CharacterCreators
{
    public class AIEnemyCreator : IEnemyCreator
    {
        private readonly EnemyFactory _enemyFactory;
        
        private readonly EnemyCharacter _prefab;
        private readonly Transform _target;
        
        private readonly float _timeToChangeDirection;
        private readonly float _offset;

        public AIEnemyCreator(
            EnemyFactory enemyFactory,
            EnemyCharacter prefab,
            Transform target,
            float timeToChangeDirection,
            float offset)
        {
            _enemyFactory = enemyFactory;
            _prefab = prefab;
            _target = target;
            _timeToChangeDirection = timeToChangeDirection;
            _offset = offset;
        }

        public EnemyCharacter Create(Vector3 position) => _enemyFactory.CreateAIEnemy(
            _prefab,
            position,
            _target,
            _timeToChangeDirection,
            _offset);
    }
}