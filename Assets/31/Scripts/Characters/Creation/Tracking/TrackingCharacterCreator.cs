using _31.Scripts.Characters.Creation.Interfaces;
using _31.Scripts.Lifecycle;
using UnityEngine;

namespace _31.Scripts.Characters.Creation.Tracking
{
    public class TrackingCharacterCreator<TCharacter> : ICharacterCreator<TCharacter> where TCharacter : Character
    {
        private readonly ICharacterCreator<TCharacter> _inner;
        private readonly DestroyableEventService _destroyableEventService;

        public TrackingCharacterCreator(ICharacterCreator<TCharacter> inner, DestroyableEventService destroyableEventService)
        {
            _inner = inner;
            _destroyableEventService = destroyableEventService;
        }
        
        public TCharacter Create(Vector3 position)
        {
            TCharacter character = _inner.Create(position);
            
            _destroyableEventService.AddDestroyable(character);
            
            return character;
        }
    }
}