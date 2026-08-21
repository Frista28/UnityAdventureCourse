using _31.Scripts.Characters.Configs;
using _31.Scripts.Characters.Creation.Interfaces;
using UnityEngine;

namespace _31.Scripts.Characters.Creation
{
    public class CharacterCreator<TCharacter> : ICharacterCreator<TCharacter> where TCharacter : Characters.Character
    {
        private readonly CharacterFactory<TCharacter> _characterFactory;
        private readonly TCharacter _prefab;
        private readonly CharacterConfig _config;

        public CharacterCreator(
            CharacterFactory<TCharacter> characterFactory, 
            TCharacter prefab,
            CharacterConfig config)
        {
            _characterFactory = characterFactory;
            _prefab = prefab;
            _config = config;
        }
        
        public TCharacter Create(Vector3 position) => _characterFactory.Create(_prefab, position, _config);
    }
}