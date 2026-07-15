using _22_23.Scripts.Interfaces.Click;
using UnityEngine;

namespace _22_23.Scripts.Controller
{
    public class ClickProcessor
    {
        private readonly IPointProvider _pointProvider;
        private readonly IPointValidator _pointValidator;

        public ClickProcessor(IPointProvider pointProvider, IPointValidator pointValidator)
        {
            _pointProvider = pointProvider;
            _pointValidator = pointValidator;
        }

        public bool TryProcessClick(out Vector3 validPoint)
        {
            validPoint = Vector3.zero;

            if (_pointProvider.TryGetHit(out RaycastHit point))
            {
                if (_pointValidator.IsValid(point))
                {
                    validPoint = point.point;
                    return true;
                }
            }

            return false;
        }
    }
}