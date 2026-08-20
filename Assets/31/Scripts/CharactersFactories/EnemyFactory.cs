using _31.Scripts.Character;
using _31.Scripts.Controllers;
using _31.Scripts.Inputs;
using UnityEngine;

namespace _31.Scripts.CharactersFactories
{
    public class EnemyFactory
    {
        private readonly CharacterFactory _characterFactory;
        private readonly CharacterInputControllerFactory _characterInputControllerFactory;

        public EnemyFactory(CharacterFactory characterFactory,
            CharacterInputControllerFactory characterInputControllerFactory)
        {
            _characterFactory = characterFactory;
            _characterInputControllerFactory = characterInputControllerFactory;
        }

        public EnemyCharacter CreateAIEnemy(
            EnemyCharacter prefabEnemy,
            Vector3 position,
            Transform target,
            float timeToChange,
            float offset)
        {
            EnemyCharacter enemy = _characterFactory.CreateEnemy(
                prefabEnemy,
                position,
                5f,
                900f);

            _characterInputControllerFactory.Create(
                enemy,
                enemy,
                enemy,
                new RandomCharacterInputInZone(timeToChange, target, enemy.transform, offset));

            return enemy;
        }
    }
}