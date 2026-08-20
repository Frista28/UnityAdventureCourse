using System;

namespace _31.Scripts.Character.Interfaces
{
    public interface ICharacterLifecycle
    {
        event Action Destroyed;
    }
}