using System;

namespace _31.Scripts.Lifecycle.Interfaces
{
    public interface IDestroyable
    {
        event Action Destroyed;
    }
}