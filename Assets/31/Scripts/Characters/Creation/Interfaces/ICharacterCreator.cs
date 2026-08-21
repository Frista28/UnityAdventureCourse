using UnityEngine;

namespace _31.Scripts.Characters.Creation.Interfaces
{
    public interface ICharacterCreator<out TCharacter> where TCharacter : Characters.Character
    {
        public TCharacter Create(Vector3 position);
    }
}