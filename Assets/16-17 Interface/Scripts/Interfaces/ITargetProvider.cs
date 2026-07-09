using UnityEngine;

namespace _16_17_Interface.Scripts.Interfaces
{
    public interface ITargetProvider
    {
        Transform Target { get; }
        
        bool HasTarget { get; }
    }
}