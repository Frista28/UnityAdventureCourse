using UnityEngine;

namespace _22_23.Scripts.Interfaces.Click
{
    public interface IPointProvider
    {
        public bool TryGetHit(out RaycastHit point);
    }
}