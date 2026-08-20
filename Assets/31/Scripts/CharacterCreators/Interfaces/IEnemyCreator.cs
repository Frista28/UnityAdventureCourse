using _31.Scripts.Character;
using UnityEngine;

namespace _31.Scripts.CharacterCreators.Interfaces
{
    public interface IEnemyCreator
    {
        public EnemyCharacter Create(Vector3 position);
    }
}