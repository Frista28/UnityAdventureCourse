using System.Drawing;
using UnityEngine;

namespace _22_23.Scripts.Interfaces.Click
{
    public interface IPointValidator
    {
        public bool IsValid(RaycastHit point);
    }
}