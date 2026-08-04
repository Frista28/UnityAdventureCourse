using System;
using UnityEngine;
using UnityEngine.UI;

namespace _27_28.Scripts.Timer
{
    public class SliderBar : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Init(float startValue)
        {
            ValidateValue(startValue);
            
            _image.fillAmount = startValue;
        }

        public void SetValue(float value)
        {
            ValidateValue(value);
            
            _image.fillAmount = value;
        }

        private void ValidateValue(float value)
        {
            if (value > 1f || value < 0f)
                throw new ArgumentOutOfRangeException(nameof(value), "startValue must be between 0 and 1");
        }
    }
}