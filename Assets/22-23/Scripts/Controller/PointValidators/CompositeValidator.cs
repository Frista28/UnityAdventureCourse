using System.Collections.Generic;
using _22_23.Scripts.Interfaces.Click;
using UnityEngine;

namespace _22_23.Scripts.Controller.PointValidators
{
    public class CompositeValidator : IPointValidator
    {
        private List<IPointValidator> _pointValidators = new List<IPointValidator>();

        public void AddValidator(IPointValidator pointValidator)
        {
            _pointValidators.Add(pointValidator);
        }
        
        public bool IsValid(RaycastHit point)
        {
            foreach (IPointValidator pointValidator in _pointValidators)
            {
                if (!pointValidator.IsValid(point))
                    return false;
            }
            return true;
        }
    }
}